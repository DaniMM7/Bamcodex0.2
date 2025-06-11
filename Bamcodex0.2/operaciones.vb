Imports System.Data.SqlClient

Public Class operaciones
    Dim NombreCliente As String
    Dim SaldoCliente As String
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Public Shared saldop As String
    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub operaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim numeroTarjeta As String = tarjeta.ClienteNum.Trim()
        Dim tarjetaID As Integer = 0

        Try
            conectar()
            Dim comId As New SqlCommand("SELECT TarjetaID FROM Tarjeta WHERE NumeroTarjeta = @NumeroTarjeta", conexion_general)
            comId.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta)

            Dim result = comId.ExecuteScalar()
            If result IsNot Nothing Then
                tarjetaID = Convert.ToInt32(result)
            Else
                MsgBox("Número de tarjeta no encontrado.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error al obtener TarjetaID: " & ex.Message)
            Exit Sub
        End Try
        Dim sql As String = "SELECT CL.Nombre, CL.Apellido, CU.Saldo " &
                    "FROM Tarjeta T " &
                    "JOIN Cuentas CU ON T.CuentaID = CU.CuentaID " &
                    "JOIN Clientes CL ON CU.ClienteID = CL.ClienteID " &
                    "WHERE T.TarjetaID = @TarjetaID"

        Try
            Dim com As New SqlCommand(sql, conexion_general)
            com.Parameters.AddWithValue("@TarjetaID", tarjetaID)

            Dim dr As SqlDataReader = com.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    Dim nombre As String = dr("Nombre").ToString()
                    Dim apellido As String = dr("Apellido").ToString()
                    Dim saldo As Decimal = Convert.ToDecimal(dr("Saldo"))
                    txtNom.Text = nombre & " " & apellido
                    txtSaldo.Text = saldo.ToString("C2")
                    saldop = saldo

                End While
            Else
                MsgBox("No se encontró información para la tarjeta indicada.")
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        consulta.Show()

    End Sub
End Class