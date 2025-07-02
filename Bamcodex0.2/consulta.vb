Imports System.Data.SqlClient

Public Class consulta
    Private servidores As String() = {
        "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;User ID=prueba21;Password=coco",      ' Local
        "Data Source=192.168.0.232;Initial Catalog=BDREPO;User ID=pepe4;Password=1234"
        }

    Private Sub consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim saldo As String = operaciones.saldop.Trim()
        Saldoact.Text = saldo

        Dim encontrado As Boolean = False
        Dim query As String = "SELECT CajeroID, FondosDisponibles FROM Cajero WHERE CajeroID = 1"

        For Each cadenaConexion In servidores
            Try
                Using conn As New SqlConnection(cadenaConexion)
                    conn.Open()

                    Using cmd As New SqlCommand(query, conn)
                        Using dr As SqlDataReader = cmd.ExecuteReader()
                            If dr.HasRows Then
                                While dr.Read()
                                    Dim cajeroid As String = dr("CajeroID").ToString()
                                    Dim fondosDisponibles As String = dr("FondosDisponibles").ToString()
                                    SaldoCajero.Text = fondosDisponibles
                                End While
                                encontrado = True
                                Exit For ' Sale del ciclo si encontró datos
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al conectar a: " & cadenaConexion & vbCrLf & ex.Message)
            End Try
        Next

        If Not encontrado Then
            MsgBox("No se encontró información para el cajero en ninguno de los servidores.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub
End Class