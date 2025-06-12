Imports System.Data.SqlClient
Public Class tarjeta
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Dim tarjeta As String
    Dim pin As String
    Dim res As Integer
    Public Shared ClienteNum As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tarjeta = txtNumTarjeta.Text
        pin = txtPIN.Text
        ' Construir la consulta SQL correctamente
        sql = "EXEC sp_ValidarPIN @NumeroTarjeta = '" & tarjeta & "', @PIN = '" & pin & "'"
        Try
            ' Conectar a la base de datos
            conectar()
            Dim com As New SqlCommand(sql, conexion_general)

            ' Ejecutar el comando
            Dim dr As SqlDataReader = com.ExecuteReader()

            ' Leer el resultado
            If dr.HasRows Then
                ' Si devuelve filas, el PIN es correcto
                ClienteNum = tarjeta
                MsgBox("Bienvenido(a)")
                operaciones.Show()
                Me.Hide()
            Else
                ' No devolvió filas: PIN incorrecto o tarjeta no encontrada
                MsgBox("Contraseña o número de tarjeta incorrectos.")
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Ocurrió un error: " & ex.Message)
        Finally
            ' Asegurarse de cerrar la conexión
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try
    End Sub

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

End Class