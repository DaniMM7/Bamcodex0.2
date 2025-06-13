Imports System.Data.SqlClient

Public Class Retirar
    Dim saldoCliente As Decimal = 0
    Dim montoSeleccionado As Decimal = 0
    Dim tarjetaID As Integer = 0

    Private Sub Retirar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtOtroMonto.Visible = False
        saldoCliente = Convert.ToDecimal(operaciones.saldop)
        lblSaldoActual.Text = saldoCliente.ToString("C") ' Asigna a tu label del saldo actual

        ' Obtener el ID de tarjeta actual para saber a quién actualizar
        Dim numeroTarjeta As String = tarjeta.ClienteNum.Trim()

        Try
            conectar()
            Dim comId As New SqlCommand("SELECT TarjetaID FROM Tarjeta WHERE NumeroTarjeta = @num", conexion_general)
            comId.Parameters.AddWithValue("@num", numeroTarjeta)

            Dim result = comId.ExecuteScalar()
            If result IsNot Nothing Then
                tarjetaID = Convert.ToInt32(result)
            Else
                MsgBox("No se encontró la tarjeta.")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If conexion_general.State = ConnectionState.Open Then conexion_general.Close()
        End Try
    End Sub

    ' Botones de monto
    Private Sub btn1000_Click(sender As Object, e As EventArgs) Handles btn1000.Click
        montoSeleccionado = 1000
    End Sub

    Private Sub btn500_Click(sender As Object, e As EventArgs) Handles btn500.Click
        montoSeleccionado = 500
    End Sub

    Private Sub btn200_Click(sender As Object, e As EventArgs) Handles btn200.Click
        montoSeleccionado = 200
    End Sub

    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles btn100.Click
        montoSeleccionado = 100
    End Sub

    ' Otro monto personalizado 
    Private Sub TxtOtroMonto_Click(sender As Object, e As EventArgs) Handles TxtOtroMonto.Click
        If Decimal.TryParse(TxtOtroMonto.Text, montoSeleccionado) = False Then
            MsgBox("Monto inválido")
            Return
        End If
    End Sub

    ' Botón Confirmar Retiro
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ' Validar monto ingresado
        If txtOtroMonto.Visible Then
            Dim monto As Decimal
            If Not Decimal.TryParse(txtOtroMonto.Text, monto) OrElse monto <= 0 Then
                MessageBox.Show("Monto inválido. Por favor ingrese un número válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOtroMonto.Focus()
                Return
            End If
            montoSeleccionado = monto
        End If



        If montoSeleccionado > saldoCliente Then
            MessageBox.Show("Fondos insuficientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim nuevoSaldo As Decimal = saldoCliente - montoSeleccionado

        Try
            conectar()
            Using transaction = conexion_general.BeginTransaction()
                Try
                    ' Actualizar saldo
                    Dim sqlActualizar As String = "UPDATE Cuentas SET Saldo = @nuevoSaldo WHERE CuentaID = (SELECT CuentaID FROM Tarjeta WHERE TarjetaID = @tarjetaID)"
                    Using cmdActualizar As New SqlCommand(sqlActualizar, conexion_general, transaction)
                        cmdActualizar.Parameters.AddWithValue("@nuevoSaldo", nuevoSaldo)
                        cmdActualizar.Parameters.AddWithValue("@tarjetaID", tarjetaID)
                        Dim filasAfectadas As Integer = cmdActualizar.ExecuteNonQuery()

                        If filasAfectadas = 0 Then
                            Throw New Exception("No se pudo actualizar el saldo.")
                        End If
                    End Using

                    ' Insertar transacción de retiro
                    Dim sqlInsertar As String = "INSERT INTO Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CuentaDestino, CajeroID) " &
                                           "VALUES (@tipo, @monto, @fecha, (SELECT CuentaID FROM Tarjeta WHERE TarjetaID = @tarjetaID), NULL, NULL)"
                    Using cmdInsertar As New SqlCommand(sqlInsertar, conexion_general, transaction)
                        cmdInsertar.Parameters.AddWithValue("@tipo", "Retiro") ' Debe coincidir con restricción CHECK
                        cmdInsertar.Parameters.AddWithValue("@monto", montoSeleccionado)
                        cmdInsertar.Parameters.AddWithValue("@fecha", DateTime.Now)
                        cmdInsertar.Parameters.AddWithValue("@tarjetaID", tarjetaID)
                        cmdInsertar.ExecuteNonQuery()
                    End Using

                    transaction.Commit()

                    MessageBox.Show("Has retirado " & montoSeleccionado.ToString("C") & ". Nuevo saldo: " & nuevoSaldo.ToString("C"))
                    saldoCliente = nuevoSaldo
                    operaciones.saldop = saldoCliente
                    lblSaldoActual.Text = saldoCliente.ToString("C")
                    montoSeleccionado = 0
                    txtOtroMonto.Text = ""
                    txtOtroMonto.Visible = False

                Catch exTrans As Exception
                    transaction.Rollback()
                    MessageBox.Show("Error al realizar la transacción: " & exTrans.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al retirar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conexion_general.State = ConnectionState.Open Then conexion_general.Close()
        End Try
    End Sub



    Private Sub TxtOtroMonto_Leave(sender As Object, e As EventArgs) Handles txtOtroMonto.Leave
        Dim monto As Decimal
        If Not Decimal.TryParse(txtOtroMonto.Text, monto) OrElse monto <= 0 Then
            MessageBox.Show("Monto inválido. Por favor ingrese un número válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOtroMonto.Focus()
        Else
            montoSeleccionado = monto
        End If
    End Sub

    Private Sub BtnOtroMonto_Click(sender As Object, e As EventArgs) Handles BtnOtroMonto.Click
        TxtOtroMonto.Visible = True
        TxtOtroMonto.Focus() '
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub
End Class