Imports System.Data.SqlClient

Public Class Depositar

    Private servidores As String() = {
        "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;Integrated Security=True",
        "Data Source=192.168.0.232;Initial Catalog=BDREPO;User ID=pepe4;Password=1234",
        "Data Source=192.168.0.173;Initial Catalog=BancoDB1;User ID=pepe4;Password=1234;"
    }

    Private Sub Depositar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(tarjeta.NumeroCuentaUsuario) Then
            txtCuenta.Text = tarjeta.NumeroCuentaUsuario
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim validarForm As New ValidarBilletes()
        Dim resultado = validarForm.ShowDialog()

        If resultado = DialogResult.OK Then
            txtImporte.Text = validarForm.TotalBilletes.ToString("F2")
        Else
            Exit Sub
        End If

        RealizarDeposito()
    End Sub

    Private Sub RealizarDeposito()
        Dim numeroCuenta As String = txtCuenta.Text.Trim()
        Dim importeStr As String = txtImporte.Text.Trim()
        Dim importe As Decimal

        If String.IsNullOrEmpty(numeroCuenta) OrElse String.IsNullOrEmpty(importeStr) Then
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Decimal.TryParse(importeStr, importe) OrElse importe <= 0 Then
            MessageBox.Show("El importe debe ser un número válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim bancoID As Integer
        If numeroCuenta.Length < 3 OrElse Not Integer.TryParse(numeroCuenta.Substring(0, 3), bancoID) Then
            MessageBox.Show("Número de cuenta no válido. Debe iniciar con el código del banco (3 dígitos).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim conexionCuenta As String = Nothing

        ' Buscar servidor donde esté la cuenta (CuentasReplica)
        For Each cadena In servidores
            Try
                Using conn As New SqlConnection(cadena)
                    conn.Open()
                    Dim sqlExiste As String = "SELECT COUNT(*) FROM dbo.CuentasReplica WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                    Using cmd As New SqlCommand(sqlExiste, conn)
                        cmd.Parameters.AddWithValue("@BancoID", bancoID)
                        cmd.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta)
                        Dim existe As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        If existe > 0 Then
                            conexionCuenta = cadena
                            Exit For
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al conectar con el servidor: " & cadena & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        Next

        If conexionCuenta Is Nothing Then
            MessageBox.Show("La cuenta no existe en ninguno de los servidores configurados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Actualizar saldo en servidor remoto (donde esté la cuenta)
        Using connCuenta As New SqlConnection(conexionCuenta)
            Try
                connCuenta.Open()
                Using transCuenta = connCuenta.BeginTransaction()
                    Try
                        ' Obtener saldo actual
                        Dim sqlSaldo As String = "SELECT Saldo FROM dbo.CuentasReplica WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                        Dim saldoActual As Decimal

                        Using cmdSaldo As New SqlCommand(sqlSaldo, connCuenta, transCuenta)
                            cmdSaldo.Parameters.AddWithValue("@BancoID", bancoID)
                            cmdSaldo.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta)
                            Dim result = cmdSaldo.ExecuteScalar()

                            If result Is Nothing OrElse IsDBNull(result) Then
                                MessageBox.Show("La cuenta no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                transCuenta.Rollback()
                                Exit Sub
                            End If

                            saldoActual = Convert.ToDecimal(result)
                        End Using

                        Dim nuevoSaldo As Decimal = saldoActual + importe

                        ' Actualizar saldo
                        Dim sqlUpdate As String = "UPDATE dbo.CuentasReplica SET Saldo = @NuevoSaldo WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                        Using cmdUpdate As New SqlCommand(sqlUpdate, connCuenta, transCuenta)
                            cmdUpdate.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo)
                            cmdUpdate.Parameters.AddWithValue("@BancoID", bancoID)
                            cmdUpdate.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta)
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        transCuenta.Commit()
                    Catch ex As Exception
                        transCuenta.Rollback()
                        MessageBox.Show("Error al actualizar saldo en la cuenta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al conectar con el servidor de la cuenta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End Using

        ' Insertar la transacción en el servidor local (primer servidor)
        Dim conexionLocal As String = servidores(0)

        Using connLocal As New SqlConnection(conexionLocal)
            Try
                connLocal.Open()
                Using transLocal = connLocal.BeginTransaction()
                    Try
                        Dim sqlInsert As String = "INSERT INTO dbo.Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CuentaDestino, CajeroID) " &
                                                 "VALUES (@TipoTransaccion, @Monto, @FechaTransaccion, @CuentaOrigen, NULL, @CajeroID)"
                        Using cmdInsert As New SqlCommand(sqlInsert, connLocal, transLocal)
                            cmdInsert.Parameters.AddWithValue("@TipoTransaccion", "Deposito")
                            cmdInsert.Parameters.AddWithValue("@Monto", importe)
                            cmdInsert.Parameters.AddWithValue("@FechaTransaccion", DateTime.Now)
                            cmdInsert.Parameters.AddWithValue("@CuentaOrigen", numeroCuenta)
                            cmdInsert.Parameters.AddWithValue("@CajeroID", 2) ' Cambiar si se tiene cajero real
                            cmdInsert.ExecuteNonQuery()
                        End Using

                        transLocal.Commit()

                        MessageBox.Show("Depósito realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCuenta.Clear()
                        txtImporte.Clear()
                    Catch ex As Exception
                        transLocal.Rollback()
                        MessageBox.Show("Error al registrar la transacción: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al conectar con el servidor local: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub

End Class
