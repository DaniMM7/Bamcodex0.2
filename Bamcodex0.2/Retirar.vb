Imports System.Data.SqlClient

Public Class Retirar
    Dim saldoCliente As Decimal = 0
    Dim montoSeleccionado As Decimal = 0
    Dim cadenaConexionActual As String = Nothing ' Guardar la conexión que funciona

    ' Solo se usa para consultar la tabla CuentasReplica (compartida)
    Private servidores As String() = {
        "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;User ID=prueba21;Password=coco",
        "Data Source=192.168.0.232;Initial Catalog=BDREPO;User ID=pepe4;Password=1234"
    }

    Private Sub Retirar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOtroMonto.Visible = False

        Dim bancoID As Integer = tarjeta.BancoIDUsuario
        Dim numeroCuenta As String = tarjeta.NumeroCuentaUsuario

        Dim encontrado As Boolean = False
        Dim sqlSaldo As String = "SELECT Saldo FROM CuentasReplica WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"

        For Each cadenaConexion In servidores
            Try
                Using conn As New SqlConnection(cadenaConexion)
                    conn.Open()

                    Using com As New SqlCommand(sqlSaldo, conn)
                        com.Parameters.AddWithValue("@BancoID", bancoID)
                        com.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta)

                        Dim result = com.ExecuteScalar()
                        If result IsNot Nothing Then
                            saldoCliente = Convert.ToDecimal(result)
                            lblSaldoActual.Text = saldoCliente.ToString("C")
                            operaciones.saldop = saldoCliente
                            cadenaConexionActual = cadenaConexion ' Guardar conexión válida
                            encontrado = True
                            Exit For
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al conectar a: " & cadenaConexion & vbCrLf & ex.Message)
            End Try
        Next

        If Not encontrado Then
            MsgBox("No se encontró la cuenta en ninguno de los servidores.")
            Me.Close()
        End If
    End Sub

    ' Botones de monto
    Private Sub btn1000_Click(sender As Object, e As EventArgs) Handles Btn1000.Click
        montoSeleccionado = 1000
    End Sub

    Private Sub btn500_Click(sender As Object, e As EventArgs) Handles Btn500.Click
        montoSeleccionado = 500
    End Sub

    Private Sub btn200_Click(sender As Object, e As EventArgs) Handles Btn200.Click
        montoSeleccionado = 200
    End Sub

    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles Btn100.Click
        montoSeleccionado = 100
    End Sub

    Private Sub btnOtroMonto_Click(sender As Object, e As EventArgs) Handles BtnOtroMonto.Click
        txtOtroMonto.Visible = True
        txtOtroMonto.Focus()
    End Sub

    Private Sub txtOtroMonto_Leave(sender As Object, e As EventArgs) Handles txtOtroMonto.Leave
        Dim monto As Decimal
        If Not Decimal.TryParse(txtOtroMonto.Text, monto) OrElse monto <= 0 Then
            MessageBox.Show("Monto inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOtroMonto.Focus()
        Else
            montoSeleccionado = monto
        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        If txtOtroMonto.Visible Then
            Dim monto As Decimal
            If Not Decimal.TryParse(txtOtroMonto.Text, monto) OrElse monto <= 0 Then
                MessageBox.Show("Monto inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOtroMonto.Focus()
                Return
            End If
            montoSeleccionado = monto
        End If

        If montoSeleccionado <= 0 Then
            MessageBox.Show("Selecciona o escribe un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If montoSeleccionado > saldoCliente Then
            MessageBox.Show("Fondos insuficientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validar inventario de billetes
        Dim montoInt As Integer = CInt(Math.Floor(montoSeleccionado))
        Dim billetesParaRetiro = CalcularBilletesParaRetiro(montoInt)
        If billetesParaRetiro Is Nothing Then
            MessageBox.Show("No hay billetes suficientes para cubrir ese monto. Intente con otro monto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Actualizar saldo en CuentasReplica (remoto) y localmente insertar/actualizar con conexion_general
        Dim bancoID As Integer = tarjeta.BancoIDUsuario
        Dim numeroCuenta As String = tarjeta.NumeroCuentaUsuario
        Dim nuevoSaldo As Decimal = saldoCliente - montoSeleccionado

        Try
            ' 1. Actualizar saldo en servidor remoto
            Using connRemoto As New SqlConnection(cadenaConexionActual)
                connRemoto.Open()
                Dim sqlActualizar As String = "UPDATE CuentasReplica SET Saldo = @nuevoSaldo WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                Using cmdActualizar As New SqlCommand(sqlActualizar, connRemoto)
                    cmdActualizar.Parameters.AddWithValue("@nuevoSaldo", nuevoSaldo)
                    cmdActualizar.Parameters.AddWithValue("@BancoID", bancoID)
                    cmdActualizar.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta)
                    cmdActualizar.ExecuteNonQuery()
                End Using
            End Using

            ' 2. Insertar transacción y actualizar billetes localmente
            conectar()
            Using transaccion = conexion_general.BeginTransaction()
                Try
                    ' Insertar en Transacciones
                    Dim sqlInsertar As String = "INSERT INTO Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CajeroID) " &
                                                "VALUES ('Retiro', @Monto, GETDATE(), @CuentaOrigen, 1)"
                    Using cmdInsertar As New SqlCommand(sqlInsertar, conexion_general, transaccion)
                        cmdInsertar.Parameters.AddWithValue("@Monto", montoSeleccionado)
                        cmdInsertar.Parameters.AddWithValue("@CuentaOrigen", numeroCuenta)
                        cmdInsertar.ExecuteNonQuery()
                    End Using

                    ' Actualizar inventario de billetes
                    For Each kvp In billetesParaRetiro
                        Dim valorBillete = kvp.Key
                        Dim cantidadUsada = kvp.Value
                        Dim sqlActualizarBilletes As String = "UPDATE BilletesCajero SET Cantidad = Cantidad - @CantidadUsada WHERE BilleteValor = @ValorBillete"
                        Using cmdUpdate As New SqlCommand(sqlActualizarBilletes, conexion_general, transaccion)
                            cmdUpdate.Parameters.AddWithValue("@CantidadUsada", cantidadUsada)
                            cmdUpdate.Parameters.AddWithValue("@ValorBillete", valorBillete)
                            cmdUpdate.ExecuteNonQuery()
                        End Using
                    Next

                    transaccion.Commit()

                    MessageBox.Show("Retiro exitoso. Nuevo saldo: " & nuevoSaldo.ToString("C"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    saldoCliente = nuevoSaldo
                    operaciones.saldop = nuevoSaldo
                    lblSaldoActual.Text = saldoCliente.ToString("C")
                    montoSeleccionado = 0
                    txtOtroMonto.Text = ""
                    txtOtroMonto.Visible = False

                Catch ex As Exception
                    transaccion.Rollback()
                    MessageBox.Show("Error durante el retiro local: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error general: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conexion_general.State = ConnectionState.Open Then conexion_general.Close()
        End Try
    End Sub

    Private Function CalcularBilletesParaRetiro(monto As Integer) As Dictionary(Of Integer, Integer)
        Dim billetesDisponibles As New Dictionary(Of Integer, Integer)

        Try
            conectar()
            Dim sql As String = "SELECT BilleteValor, Cantidad FROM BilletesCajero ORDER BY BilleteValor DESC"
            Dim cmd As New SqlCommand(sql, conexion_general)
            Dim dr = cmd.ExecuteReader()

            While dr.Read()
                Dim valor As Integer = Convert.ToInt32(dr("BilleteValor"))
                Dim cantidad As Integer = Convert.ToInt32(dr("Cantidad"))
                billetesDisponibles(valor) = cantidad
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox("Error leyendo inventario de billetes: " & ex.Message)
            Return Nothing
        Finally
            If conexion_general.State = ConnectionState.Open Then conexion_general.Close()
        End Try

        Dim resultado As New Dictionary(Of Integer, Integer)
        Dim montoRestante = monto

        For Each valor In New Integer() {500, 200, 100, 50}
            If billetesDisponibles.ContainsKey(valor) Then
                Dim billetesNecesarios = Math.Min(montoRestante \ valor, billetesDisponibles(valor))
                If billetesNecesarios > 0 Then
                    resultado(valor) = billetesNecesarios
                    montoRestante -= billetesNecesarios * valor
                End If
            End If
        Next

        If montoRestante > 0 Then
            Return Nothing
        Else
            Return resultado
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formOpe As New operaciones()
        formOpe.Show()
        Me.Hide()
    End Sub
End Class
