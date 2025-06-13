Imports System.Data.SqlClient

Public Class RetiroConfirmar
    Private montoRetiro As Decimal
    Private cadenaConexion As String = "Server=ASUSVIVOBOOK\INSTANCIA2;Database=Bancodexxdb;Trusted_Connection=True;"
    Public Sub New(monto As Decimal)
        InitializeComponent()
        montoRetiro = monto
    End Sub


    Private Sub RetiroConfirmar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblImporte.Text = "Importe a retirar: " & montoRetiro.ToString("C")

    End Sub

    Private Sub btnConfirmarRetiro_Click(sender As Object, e As EventArgs) Handles BtnConfirmarRetiro.Click
        Dim claveRetiro As String = txtClaveRetiro.Text.Trim()
        Dim pin As String = txtPIN.Text.Trim()

        If String.IsNullOrEmpty(claveRetiro) Then
            MessageBox.Show("Ingrese la clave de retiro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtClaveRetiro.Focus()
            Return
        End If

        If String.IsNullOrEmpty(pin) Then
            MessageBox.Show("Ingrese el PIN de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPIN.Focus()
            Return
        End If

        If Not ValidarSaldoYCredenciales(montoRetiro, claveRetiro, pin) Then
            Return
        End If

        ProcesarRetiro(montoRetiro, claveRetiro)

        MessageBox.Show("Retiro realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Function ValidarSaldoYCredenciales(monto As Decimal, clave As String, pin As String) As Boolean
        Using conexion As New SqlConnection(cadenaConexion)
            Try
                conexion.Open()

                ' Validar que la clave existe, no usada y obtener CuentaID y Monto autorizado
                Dim sqlClave As String = "SELECT CuentaID, Monto, Usado FROM RetirosSinTarjeta WHERE CodigoRetiro = @Clave"
                Using cmdClave As New SqlCommand(sqlClave, conexion)
                    cmdClave.Parameters.AddWithValue("@Clave", clave)
                    Using reader = cmdClave.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("Clave de retiro no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If

                        Dim cuentaID As Integer = reader.GetInt32(0)
                        Dim montoAutorizado As Decimal = reader.GetDecimal(1)
                        Dim usado As Boolean = reader.GetBoolean(2)

                        If usado Then
                            MessageBox.Show("Esta clave de retiro ya fue utilizada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If

                        If monto > montoAutorizado Then
                            MessageBox.Show("El monto solicitado excede el monto autorizado para esta clave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If

                        reader.Close()

                        ' Validar saldo suficiente
                        Dim sqlSaldo As String = "SELECT Saldo FROM Cuentas WHERE CuentaID = @CuentaID"
                        Using cmdSaldo As New SqlCommand(sqlSaldo, conexion)
                            cmdSaldo.Parameters.AddWithValue("@CuentaID", cuentaID)
                            Dim saldoObj = cmdSaldo.ExecuteScalar()
                            If saldoObj Is Nothing Then
                                MessageBox.Show("Cuenta no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            End If

                            Dim saldo As Decimal = Convert.ToDecimal(saldoObj)
                            If saldo < monto Then
                                MessageBox.Show("Fondos insuficientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            End If
                        End Using

                        Dim sqlPin As String = "SELECT COUNT(*) FROM Tarjeta t " &
                       "INNER JOIN RetirosSinTarjeta r ON t.CuentaID = r.CuentaID " &
                       "WHERE r.CodigoRetiro = @Clave AND t.PIN = @PIN AND r.Usado = 0"

                        Using cmdPin As New SqlCommand(sqlPin, conexion)
                            cmdPin.Parameters.AddWithValue("@Clave", clave)
                            cmdPin.Parameters.AddWithValue("@PIN", pin)
                            Dim countPin As Integer = Convert.ToInt32(cmdPin.ExecuteScalar())
                            If countPin = 0 Then
                                MessageBox.Show("PIN incorrecto o clave usada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            End If
                        End Using


                        Return True
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al validar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Private Sub ProcesarRetiro(monto As Decimal, clave As String)
        Using conexion As New SqlConnection(cadenaConexion)
            conexion.Open()
            Using transaction = conexion.BeginTransaction()
                Try
                    ' Obtener CuentaID desde clave
                    Dim cuentaID As Integer
                    Dim sqlCuenta As String = "SELECT CuentaID FROM RetirosSinTarjeta WHERE CodigoRetiro = @Clave"
                    Using cmdCuenta As New SqlCommand(sqlCuenta, conexion, transaction)
                        cmdCuenta.Parameters.AddWithValue("@Clave", clave)
                        cuentaID = Convert.ToInt32(cmdCuenta.ExecuteScalar())
                    End Using

                    ' Actualizar saldo
                    Dim sqlActualizarSaldo As String = "UPDATE Cuentas SET Saldo = Saldo - @Monto WHERE CuentaID = @CuentaID"
                    Using cmdActualizar As New SqlCommand(sqlActualizarSaldo, conexion, transaction)
                        cmdActualizar.Parameters.AddWithValue("@Monto", monto)
                        cmdActualizar.Parameters.AddWithValue("@CuentaID", cuentaID)
                        cmdActualizar.ExecuteNonQuery()
                    End Using

                    ' Marcar clave como usada
                    Dim sqlMarcarUsado As String = "UPDATE RetirosSinTarjeta SET Usado = 1 WHERE CodigoRetiro = @Clave"
                    Using cmdMarcar As New SqlCommand(sqlMarcarUsado, conexion, transaction)
                        cmdMarcar.Parameters.AddWithValue("@Clave", clave)
                        cmdMarcar.ExecuteNonQuery()
                    End Using

                    ' Insertar en transacciones
                    Dim sqlInsertarTransaccion As String = "INSERT INTO Transacciones (TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CajeroID) " &
                                                           "VALUES (@TipoTransaccion, @Monto, GETDATE(), @CuentaOrigen, NULL)"
                    Using cmdInsertar As New SqlCommand(sqlInsertarTransaccion, conexion, transaction)
                        cmdInsertar.Parameters.AddWithValue("@TipoTransaccion", "Retiro")
                        cmdInsertar.Parameters.AddWithValue("@Monto", monto)
                        cmdInsertar.Parameters.AddWithValue("@CuentaOrigen", cuentaID)
                        cmdInsertar.ExecuteNonQuery()
                    End Using

                    transaction.Commit()

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Error al procesar el retiro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New RetiroSinTarjeta()
        ope.Show()
        Me.Hide()
    End Sub
End Class