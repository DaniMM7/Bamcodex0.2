Imports System.Data.SqlClient

Public Class Depositar

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cuentaIDStr As String = txtCuenta.Text.Trim()
        Dim importeStr As String = txtImporte.Text.Trim()
        Dim importe As Decimal

        ' Validaciones básicas
        If String.IsNullOrEmpty(cuentaIDStr) OrElse String.IsNullOrEmpty(importeStr) Then
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Decimal.TryParse(importeStr, importe) OrElse importe <= 0 Then
            MessageBox.Show("El importe debe ser un número válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim cuentaID As Integer
        If Not Integer.TryParse(cuentaIDStr, cuentaID) Then
            MessageBox.Show("El ID de la cuenta debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim cadenaConexion As String = "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;Integrated Security=True"

        Using conexion As New SqlConnection(cadenaConexion)
            Try
                conexion.Open()

                Using transaction = conexion.BeginTransaction()
                    Try
                        ' Obtener saldo actual
                        Dim consultaSaldo As String = "SELECT Saldo FROM dbo.Cuentas WHERE CuentaID = @CuentaID"
                        Dim saldoActual As Decimal

                        Using cmdConsulta As New SqlCommand(consultaSaldo, conexion, transaction)
                            cmdConsulta.Parameters.AddWithValue("@CuentaID", cuentaID)
                            Dim resultado = cmdConsulta.ExecuteScalar()

                            If resultado Is Nothing Then
                                MessageBox.Show("La cuenta no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                transaction.Rollback()
                                Exit Sub
                            End If

                            saldoActual = Convert.ToDecimal(resultado)
                        End Using

                        Dim nuevoSaldo As Decimal = saldoActual + importe

                        ' Actualizar saldo
                        Dim actualizarSaldo As String = "UPDATE dbo.Cuentas SET Saldo = @NuevoSaldo WHERE CuentaID = @CuentaID"
                        Using cmdActualizar As New SqlCommand(actualizarSaldo, conexion, transaction)
                            cmdActualizar.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo)
                            cmdActualizar.Parameters.AddWithValue("@CuentaID", cuentaID)
                            cmdActualizar.ExecuteNonQuery()
                        End Using

                        ' Insertar transacción
                        Dim cajeroID As Integer = 2 ' Asigna el cajero correspondiente

                        Dim insertarTransaccion As String = "INSERT INTO dbo.Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CuentaDestino, CajeroID) " &
                                                            "VALUES (@TipoTransaccion, @Monto, @FechaTransaccion, @CuentaOrigen, NULL, @CajeroID)"
                        Using cmdInsertar As New SqlCommand(insertarTransaccion, conexion, transaction)
                            cmdInsertar.Parameters.AddWithValue("@TipoTransaccion", "Deposito")
                            cmdInsertar.Parameters.AddWithValue("@Monto", importe)
                            cmdInsertar.Parameters.AddWithValue("@FechaTransaccion", DateTime.Now)
                            cmdInsertar.Parameters.AddWithValue("@CuentaOrigen", cuentaID)
                            cmdInsertar.Parameters.AddWithValue("@CajeroID", cajeroID)
                            cmdInsertar.ExecuteNonQuery()
                        End Using

                        ' Confirmar transacción
                        transaction.Commit()

                        MessageBox.Show("Depósito realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCuenta.Clear()
                        txtImporte.Clear()

                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show("Error al procesar el depósito: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al conectar a la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub
End Class
