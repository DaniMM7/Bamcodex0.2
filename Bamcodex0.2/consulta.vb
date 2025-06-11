Imports System.Data.SqlClient

Public Class consulta
    Private Sub consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim saldo As String = operaciones.saldop.Trim()
        Saldoact.Text = saldo
        Dim sql As String = "SELECT CajeroID, FondosDisponibles FROM Cajero WHERE CajeroID = 1"

        Try
            conectar() ' Asegúrate de abrir la conexión antes de ejecutar el comando

            Dim com As New SqlCommand(sql, conexion_general)
            Dim dr As SqlDataReader = com.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    Dim cajeroid As String = dr("CajeroID").ToString()
                    Dim FondosDisponibles As String = dr("FondosDisponibles").ToString()
                    SaldoCajero.Text = FondosDisponibles
                End While
            Else
                MsgBox("No se encontró información para el cajero.")
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
End Class