Imports System.Data.SqlClient

Public Class Servicios2
    Public Property ConvenioSeleccionado As String
    Private cadenaConexionActual As String = Nothing
    Public Property UsuarioActual As String

    Private servidores As String() = {
        "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;User ID=prueba21;Password=coco",
        "Data Source=192.168.0.232;Initial Catalog=BDREPO;User ID=pepe4;Password=1234"
    }

    Private Sub Servicios2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conectar()

            Dim sql As String = "SELECT NumeroConvenio, NombreConvenio FROM Convenios ORDER BY NombreConvenio"
            Using com As New SqlCommand(sql, conexion_general)
                Using dr As SqlDataReader = com.ExecuteReader()
                    NomEmpresa.Items.Clear()
                    While dr.Read()
                        Dim numero As String = dr("NumeroConvenio").ToString()
                        Dim nombre As String = dr("NombreConvenio").ToString()
                        NomEmpresa.Items.Add(numero & " - " & nombre)
                    End While
                End Using
            End Using

            If Not String.IsNullOrEmpty(ConvenioSeleccionado) Then
                For Each item As String In NomEmpresa.Items
                    If item.Contains(ConvenioSeleccionado) Then
                        NomEmpresa.SelectedItem = item
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar convenios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try
    End Sub

    Private Sub RealizarPago_Click(sender As Object, e As EventArgs) Handles RealizarPago.Click
        Dim bancoID As Integer = tarjeta.BancoIDUsuario
        Dim numeroCuenta As String = tarjeta.NumeroCuentaUsuario

        If String.IsNullOrEmpty(numeroCuenta) OrElse bancoID = 0 Then
            MessageBox.Show("No se ha identificado la cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(Referencia.Text) Then
            MessageBox.Show("Por favor ingrese la referencia.", "Falta referencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim montoPago As Decimal
        If Not Decimal.TryParse(Monto.Text.Replace("$", "").Trim(), montoPago) OrElse montoPago <= 0 Then
            MessageBox.Show("Ingrese un monto válido.", "Monto incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Buscar conexión válida (solo para leer saldo)
        Dim saldoActual As Decimal = 0
        Dim saldoObtenido As Boolean = False
        Dim sqlSaldo As String = "SELECT Saldo FROM CuentasReplica WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"

        For Each cadenaConexion In servidores
            Try
                Using conn As New SqlConnection(cadenaConexion)
                    conn.Open()
                    Using cmd As New SqlCommand(sqlSaldo, conn)
                        cmd.Parameters.AddWithValue("@BancoID", bancoID)
                        cmd.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta)

                        Dim result = cmd.ExecuteScalar()
                        If result IsNot Nothing Then
                            saldoActual = Convert.ToDecimal(result)
                            cadenaConexionActual = cadenaConexion
                            saldoObtenido = True
                            Exit For
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ' Continuar con el siguiente servidor
            End Try
        Next

        If Not saldoObtenido Then
            MessageBox.Show("No se pudo consultar el saldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If saldoActual < montoPago Then
            MessageBox.Show("No hay fondos suficientes.", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Confirmación
        If MessageBox.Show(
            $"Realizarás el pago de {Monto.Text} desde la cuenta {numeroCuenta}.{vbCrLf}¿Deseas continuar?",
            "Confirmar pago",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question) <> DialogResult.OK Then
            Exit Sub
        End If

        ' === Paso 1: Actualizar saldo en servidor remoto ===
        Try
            Using conn As New SqlConnection(cadenaConexionActual)
                conn.Open()
                Dim actualizarSaldo As String = "UPDATE CuentasReplica SET Saldo = Saldo - @Monto WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                Using cmdActualizar As New SqlCommand(actualizarSaldo, conn)
                    cmdActualizar.Parameters.AddWithValue("@Monto", montoPago)
                    cmdActualizar.Parameters.AddWithValue("@BancoID", bancoID)
                    cmdActualizar.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta)
                    cmdActualizar.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el saldo en servidor remoto: " & ex.Message)
            Exit Sub
        End Try

        ' === Paso 2: Insertar en Transacciones localmente ===
        Try
            conectar()
            Using trans = conexion_general.BeginTransaction()
                Try
                    Dim insertarTransaccion As String = "INSERT INTO Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CajeroID) " &
                                                        "VALUES ('PagoServicio', @Monto, GETDATE(), @CuentaOrigen, 1)"
                    Using cmdTrans As New SqlCommand(insertarTransaccion, conexion_general, trans)
                        cmdTrans.Parameters.AddWithValue("@Monto", montoPago)
                        cmdTrans.Parameters.AddWithValue("@CuentaOrigen", numeroCuenta)
                        cmdTrans.ExecuteNonQuery()
                    End Using

                    trans.Commit()
                    MessageBox.Show("Pago realizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Error al registrar la transacción local: " & ex.Message)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error con la base local: " & ex.Message)
        Finally
            If conexion_general.State = ConnectionState.Open Then conexion_general.Close()
        End Try
    End Sub

    ' ==== Validaciones ====

    Private Sub Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Monto.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." AndAlso Monto.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub Monto_Leave(sender As Object, e As EventArgs) Handles Monto.Leave
        Dim montoDecimal As Decimal
        If Decimal.TryParse(Monto.Text.Replace("$", "").Trim(), montoDecimal) Then
            Monto.Text = montoDecimal.ToString("C2")
        End If
    End Sub

    Private Sub Referencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Referencia.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New Servicios()
        ope.Show()
        Me.Hide()
    End Sub
End Class
