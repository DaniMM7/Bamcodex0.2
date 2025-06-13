Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Transferir
    Private Sub Transferir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llenar ComboBox al iniciar
        tipo.Items.AddRange(New String() {"Ahorros", "Débito", "Crédito"})
    End Sub

    Private Sub btnconfirmar_Click(sender As Object, e As EventArgs) Handles btnconfirmar.Click
        If tipo.SelectedIndex = -1 OrElse txtingresenumero.Text = "" OrElse txtingresemonto.Text = "" Then
            MsgBox("Por favor, complete todos los campos.", MsgBoxStyle.Exclamation, "Datos incompletos")
            Exit Sub
        End If

        Dim montoDecimal As Decimal
        If Not Decimal.TryParse(txtingresemonto.Text, montoDecimal) Then
            MsgBox("El monto ingresado no es válido.", MsgBoxStyle.Critical, "Error en el monto")
            Exit Sub
        End If

        Dim cuentaOrigenID As Integer = 1001 ' Ejemplo: ID de cuenta origen actual
        Dim cajeroID As Integer = 2          ' Ejemplo: ID del cajero que realiza la transferencia
        Dim numeroCuentaDestino As String = txtingresenumero.Text.Trim()

        Dim conexion As New SqlConnection("Server=ASUSVIVOBOOK\INSTANCIA2;Database=Bancodexxdb;Trusted_Connection=True;")

        Try
            conexion.Open()

            ' Verificar si la cuenta destino existe
            Dim sqlVerificarCuenta As String = "SELECT COUNT(*) FROM Cuentas WHERE CuentaID = @NumeroCuentaDestino"
            Using cmdVerificar As New SqlCommand(sqlVerificarCuenta, conexion)
                cmdVerificar.Parameters.AddWithValue("@NumeroCuentaDestino", numeroCuentaDestino)
                Dim cuentaExiste As Integer = Convert.ToInt32(cmdVerificar.ExecuteScalar())

                If cuentaExiste = 0 Then
                    MsgBox("La cuenta destino no existe. Verifique el número de cuenta.", MsgBoxStyle.Critical, "Error")
                    Return
                End If
            End Using

            Dim sqlTransferencia As String = "INSERT INTO Transferencias (TipoCuentaDestino, NumeroCuentaDestino, Monto, FechaTransferencia, CuentaOrigen, CajeroID) " &
                                             "VALUES (@TipoCuenta, @NumeroCuenta, @Monto, GETDATE(), @CuentaOrigen, @CajeroID)"

            Dim sqlTransaccion As String = "INSERT INTO Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CuentaDestino, CajeroID) " &
                                           "VALUES (@TipoTransaccion, @Monto, GETDATE(), @CuentaOrigen, @CuentaDestino, @CajeroID)"

            Using transaction = conexion.BeginTransaction()
                Try
                    ' Insertar en Transferencias
                    Using cmdTransferencia As New SqlCommand(sqlTransferencia, conexion, transaction)
                        cmdTransferencia.Parameters.AddWithValue("@TipoCuenta", tipo.SelectedItem.ToString())
                        cmdTransferencia.Parameters.AddWithValue("@NumeroCuenta", numeroCuentaDestino)
                        cmdTransferencia.Parameters.AddWithValue("@Monto", montoDecimal)
                        cmdTransferencia.Parameters.AddWithValue("@CuentaOrigen", cuentaOrigenID)
                        cmdTransferencia.Parameters.AddWithValue("@CajeroID", cajeroID)
                        cmdTransferencia.ExecuteNonQuery()
                    End Using

                    ' Insertar en Transacciones
                    Using cmdTransaccion As New SqlCommand(sqlTransaccion, conexion, transaction)
                        cmdTransaccion.Parameters.AddWithValue("@TipoTransaccion", "Transferencia")
                        cmdTransaccion.Parameters.AddWithValue("@Monto", montoDecimal)
                        cmdTransaccion.Parameters.AddWithValue("@CuentaOrigen", cuentaOrigenID)
                        cmdTransaccion.Parameters.AddWithValue("@CuentaDestino", numeroCuentaDestino)
                        cmdTransaccion.Parameters.AddWithValue("@CajeroID", cajeroID)
                        cmdTransaccion.ExecuteNonQuery()
                    End Using

                    ' Actualizar saldo de la cuenta origen (restar monto)
                    Dim sqlActualizarOrigen As String = "UPDATE Cuentas SET Saldo = Saldo - @Monto WHERE CuentaID = @CuentaOrigen"
                    Using cmdActualizarOrigen As New SqlCommand(sqlActualizarOrigen, conexion, transaction)
                        cmdActualizarOrigen.Parameters.AddWithValue("@Monto", montoDecimal)
                        cmdActualizarOrigen.Parameters.AddWithValue("@CuentaOrigen", cuentaOrigenID)
                        cmdActualizarOrigen.ExecuteNonQuery()
                    End Using

                    ' Actualizar saldo de la cuenta destino (sumar monto)
                    Dim sqlActualizarDestino As String = "UPDATE Cuentas SET Saldo = Saldo + @Monto WHERE CuentaID = @CuentaDestino"
                    Using cmdActualizarDestino As New SqlCommand(sqlActualizarDestino, conexion, transaction)
                        cmdActualizarDestino.Parameters.AddWithValue("@Monto", montoDecimal)
                        cmdActualizarDestino.Parameters.AddWithValue("@CuentaDestino", numeroCuentaDestino)
                        cmdActualizarDestino.ExecuteNonQuery()
                    End Using

                    ' Confirmar transacción
                    transaction.Commit()
                    MsgBox("Transferencia realizada correctamente.", MsgBoxStyle.Information, "Éxito")

                Catch exTrans As Exception
                    transaction.Rollback()
                    MsgBox("Error al realizar la transferencia: " & exTrans.Message, MsgBoxStyle.Critical, "Excepción")
                End Try
            End Using

        Catch ex As Exception
            MsgBox("Error al conectar con la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Excepción")
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub
End Class
