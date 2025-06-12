Imports System.Data.SqlClient

Public Class Depositar
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cuenta As String = txtCuenta.Text.Trim()
        Dim importeStr As String = txtImporte.Text.Trim()
        Dim importe As Decimal

        ' Validaciones básicas
        If cuenta = "" OrElse importeStr = "" Then
            MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Decimal.TryParse(importeStr, importe) OrElse importe <= 0 Then
            MessageBox.Show("El importe debe ser un número válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Cadena de conexión
        Dim cadenaConexion As String = "Data Source=DESKTOP-9S367KS\INSTANCIA;Initial Catalog=Bancodexx;Integrated Security=True"

        Using conexion As New SqlConnection(cadenaConexion)
            Try
                conexion.Open()

                ' Verificar si la cuenta existe
                Dim consultaCuenta As String = "SELECT Saldo FROM Cuentas WHERE NumeroCuenta = @Cuenta"
                Using comando As New SqlCommand(consultaCuenta, conexion)
                    comando.Parameters.AddWithValue("@Cuenta", cuenta)

                    Dim saldoActualObj = comando.ExecuteScalar()

                    If saldoActualObj Is Nothing Then
                        MessageBox.Show("La cuenta no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim saldoActual As Decimal = Convert.ToDecimal(saldoActualObj)
                    Dim nuevoSaldo As Decimal = saldoActual + importe

                    ' Actualizar el saldo
                    Dim actualizarSaldo As String = "UPDATE Cuentas SET Saldo = @NuevoSaldo WHERE NumeroCuenta = @Cuenta"
                    Using cmdActualizar As New SqlCommand(actualizarSaldo, conexion)
                        cmdActualizar.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo)
                        cmdActualizar.Parameters.AddWithValue("@Cuenta", cuenta)
                        cmdActualizar.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Depósito realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCuenta.Text = ""
                    txtImporte.Text = ""
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al realizar el depósito: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

End Class