Imports System.Data.SqlClient

Public Class Transferir

    Private Sub Transferir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tipo.Items.Clear()
        tipo.Items.AddRange(New String() {"Ahorros", "Débito", "Crédito"})
    End Sub

    Private Sub btnconfirmar_Click(sender As Object, e As EventArgs) Handles btnconfirmar.Click
        If tipo.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(txtingresenumero.Text) OrElse String.IsNullOrWhiteSpace(txtingresemonto.Text) Then
            MsgBox("Por favor, complete todos los campos.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim montoDecimal As Decimal
        If Not Decimal.TryParse(txtingresemonto.Text, montoDecimal) OrElse montoDecimal <= 0 Then
            MsgBox("Monto inválido.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim bancoOrigen As Integer = tarjeta.BancoIDUsuario
        Dim numeroCuentaOrigen As String = tarjeta.NumeroCuentaUsuario
        Dim numeroCuentaDestino As String = txtingresenumero.Text.Trim()

        If numeroCuentaDestino.Length < 3 Then
            MsgBox("Número de cuenta destino no válido.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim bancoDestino As Integer
        If Not Integer.TryParse(numeroCuentaDestino.Substring(0, 3), bancoDestino) Then
            MsgBox("No se pudo determinar el banco destino.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If bancoDestino = bancoOrigen AndAlso numeroCuentaDestino = numeroCuentaOrigen Then
            MsgBox("No puedes transferir a tu misma cuenta.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim tipoCuentaDestino As String = tipo.SelectedItem.ToString()
        Dim cajeroID As Integer = 2
        Dim conexionDestino As String = Nothing

        ' Buscar en qué servidor está la cuenta destino
        For Each cadena In ModuloConexion.Servidores
            Try
                Using conn As New SqlConnection(cadena)
                    conn.Open()
                    Dim sql As String = "SELECT COUNT(*) FROM CuentasReplica WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                    Using cmd As New SqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@BancoID", bancoDestino)
                        cmd.Parameters.AddWithValue("@NumeroCuenta", numeroCuentaDestino)
                        Dim existe As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        If existe > 0 Then
                            conexionDestino = cadena
                            Exit For
                        End If
                    End Using
                End Using
            Catch
                ' Ignorar errores individuales de conexión
            End Try
        Next

        If conexionDestino Is Nothing Then
            MsgBox("La cuenta destino no existe en ningún servidor.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ' Operar en servidor origen
        Try
            Using conn As New SqlConnection(ModuloConexion.ConexionLocal)
                conn.Open()

                Dim saldoOrigen As Decimal = 0
                Dim sqlSaldo As String = "SELECT Saldo FROM CuentasReplica WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                Using cmd As New SqlCommand(sqlSaldo, conn)
                    cmd.Parameters.AddWithValue("@BancoID", bancoOrigen)
                    cmd.Parameters.AddWithValue("@NumeroCuenta", numeroCuentaOrigen)
                    Dim result = cmd.ExecuteScalar()
                    If result Is Nothing Then
                        MsgBox("Cuenta origen no encontrada.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    saldoOrigen = Convert.ToDecimal(result)
                End Using

                If saldoOrigen < montoDecimal Then
                    MsgBox("Saldo insuficiente.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Using trans = conn.BeginTransaction()
                    Try
                        ' Registrar transferencia
                        Dim sqlTransferencia As String = "INSERT INTO Transferencias (TipoCuentaDestino, NumeroCuentaDestino, Monto, FechaTransferencia, CuentaOrigen, CajeroID) " &
                                                         "VALUES (@TipoCuentaDestino, @NumeroCuentaDestino, @Monto, GETDATE(), @CuentaOrigen, @CajeroID)"
                        Using cmd As New SqlCommand(sqlTransferencia, conn, trans)
                            cmd.Parameters.AddWithValue("@TipoCuentaDestino", tipoCuentaDestino)
                            cmd.Parameters.AddWithValue("@NumeroCuentaDestino", numeroCuentaDestino)
                            cmd.Parameters.AddWithValue("@Monto", montoDecimal)
                            cmd.Parameters.AddWithValue("@CuentaOrigen", numeroCuentaOrigen)
                            cmd.Parameters.AddWithValue("@CajeroID", cajeroID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Registrar en transacciones
                        Dim sqlTransaccion As String = "INSERT INTO Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CuentaDestino, CajeroID) " &
                                                       "VALUES ('Transferencia', @Monto, GETDATE(), @CuentaOrigen, @CuentaDestino, @CajeroID)"
                        Using cmd As New SqlCommand(sqlTransaccion, conn, trans)
                            cmd.Parameters.AddWithValue("@Monto", montoDecimal)
                            cmd.Parameters.AddWithValue("@CuentaOrigen", numeroCuentaOrigen)
                            cmd.Parameters.AddWithValue("@CuentaDestino", numeroCuentaDestino)
                            cmd.Parameters.AddWithValue("@CajeroID", cajeroID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Descontar saldo en cuenta origen
                        Dim sqlDescontar As String = "UPDATE CuentasReplica SET Saldo = Saldo - @Monto WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                        Using cmd As New SqlCommand(sqlDescontar, conn, trans)
                            cmd.Parameters.AddWithValue("@Monto", montoDecimal)
                            cmd.Parameters.AddWithValue("@BancoID", bancoOrigen)
                            cmd.Parameters.AddWithValue("@NumeroCuenta", numeroCuentaOrigen)
                            cmd.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                    Catch ex As Exception
                        trans.Rollback()
                        MsgBox("Error al registrar transferencia: " & ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try
                End Using
            End Using

            ' Acreditar en destino
            Try
                Using conn As New SqlConnection(conexionDestino)
                    conn.Open()
                    Dim sqlSumar As String = "UPDATE CuentasReplica SET Saldo = Saldo + @Monto WHERE BancoID = @BancoID AND NumeroCuenta = @NumeroCuenta"
                    Using cmd As New SqlCommand(sqlSumar, conn)
                        cmd.Parameters.AddWithValue("@Monto", montoDecimal)
                        cmd.Parameters.AddWithValue("@BancoID", bancoDestino)
                        cmd.Parameters.AddWithValue("@NumeroCuenta", numeroCuentaDestino)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Transferencia descontada pero no acreditada. Contacte soporte." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            MsgBox("Transferencia realizada con éxito.", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Error general: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub
End Class
