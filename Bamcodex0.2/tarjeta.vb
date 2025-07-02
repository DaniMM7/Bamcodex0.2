Imports System.Data.SqlClient


Public Class tarjeta
    Public Shared NumeroCuentaUsuario As String
    Public Shared BancoIDUsuario As Integer

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NumeroCuentaUsuario = txtNumTarjeta.Text.Trim()
        Dim nipIngresado As String = txtPIN.Text.Trim()

        If NumeroCuentaUsuario = "" OrElse nipIngresado = "" Then
            MsgBox("Debe ingresar número de cuenta y NIP.", MsgBoxStyle.Exclamation, "Faltan datos")
            Exit Sub
        End If

        ' Intentar primero en el servidor local (BancoID 19)
        Dim servidores As String() = {
        "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;User ID=prueba21;Password=coco",      ' TU servidor (019)
        "Data Source=192.168.0.232;Initial Catalog=BDREPO;User ID=pepe4;Password=1234"
        }
        ' "Data Source=192.168.0.152;Initial Catalog=BancoMazebankone;User ID=PBANCO;Password=1234",
        '"Data Source=192.168.0.129;Initial Catalog=CajeroBueno;User ID=PBANCO;Password=1234",
        '"Data Source=192.168.0.173;Initial Catalog=BancoDB1;User ID=pepe4;Password=1234",
        '"Data Source=192.168.0.178;Initial Catalog=BANCO;User ID=AMVAL;Password=12345"

        Dim conectado As Boolean = False

        For Each cadena In servidores
            If IntentarLoginTarjeta(cadena, nipIngresado) Then
                conectado = True
                Exit For
            End If
        Next

        If Not conectado Then
            MsgBox("Cuenta o NIP incorrectos.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
    Private Function IntentarLoginTarjeta(cadenaConexion As String, nip As String) As Boolean
        Try
            Using conn As New SqlConnection(cadenaConexion)
                conn.Open()

                MsgBox("Probando servidor: " & cadenaConexion) ' <-- Esto te ayudará a ver si pasa por ahí

                Dim query As String = "
                SELECT BancoID, CuentaID
                FROM CuentasReplica
                WHERE NumeroCuenta = @cuenta AND NIP = @nip
            "

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@cuenta", NumeroCuentaUsuario)
                    cmd.Parameters.AddWithValue("@nip", nip)

                    Dim reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        BancoIDUsuario = Convert.ToInt32(reader("BancoID"))
                        reader.Close()

                        MsgBox("Cuenta encontrada en: " & cadenaConexion) ' <-- Depuración clave
                        operaciones.Show()
                        Me.Hide()
                        Return True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al conectar a: " & cadenaConexion & vbCrLf & ex.Message) ' Importante para saber si falla
        End Try

        Return False
    End Function

    Private Sub tarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conectar() ' Asegúrate que este método abre la conexión y asigna conexion_general
            If conexion_general.State = ConnectionState.Open Then
                MsgBox("Conexión exitosa a la base de datos.")
            Else
                MsgBox("No se pudo abrir la conexión.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error al conectar: " & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtPIN.Clear()
        txtNumTarjeta.Clear()
    End Sub

    Private Sub retirost_Click(sender As Object, e As EventArgs) Handles retirost.Click
        Dim formTarjeta As New RetiroSinTarjeta()
        formTarjeta.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles volver.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formServ As New ServiciosSinTarjeta()
        formServ.Show()
        Me.Hide()
    End Sub
End Class