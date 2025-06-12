Imports System.Data.SqlClient

Public Class Servicios2
    Public Property ConvenioSeleccionado As String

    Private Sub Servicios2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conectar()

            Dim sql As String = "SELECT NumeroConvenio, NombreConvenio FROM Convenios ORDER BY NombreConvenio"
            Dim com As New SqlCommand(sql, conexion_general)
            Dim dr As SqlDataReader = com.ExecuteReader()

            NomEmpresa.Items.Clear()

            While dr.Read()
                Dim numero As String = dr("NumeroConvenio").ToString()
                Dim nombre As String = dr("NombreConvenio").ToString()
                NomEmpresa.Items.Add(numero & " - " & nombre)
            End While

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error al cargar convenios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try
    End Sub


    Private Sub RealizarPago_Click(sender As Object, e As EventArgs) Handles RealizarPago.Click

        ' Lista de convenios válidos (puedes mover esto a nivel de clase si quieres)
        Dim conveniosValidos As New Dictionary(Of String, String) From {
            {"01001", "Luz (CFE)"},
            {"02002", "Telmex"},
            {"03003", "Colegaturas"},
            {"04004", "Tenencia"}
        }

        Dim entrada As String = NomEmpresa.Text.Trim()
        Dim convenioExiste As Boolean = False

        ' Verificar por número o por nombre
        For Each kvp As KeyValuePair(Of String, String) In conveniosValidos
            If entrada = kvp.Key Or entrada.ToLower() = kvp.Value.ToLower() Then
                convenioExiste = True
                Exit For
            End If
        Next

        If Not convenioExiste Then
            MessageBox.Show("El número o nombre del convenio no es válido. Intente de nuevo.", "Convenio no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Si pasa la validación, puedes continuar con el proceso de pago aquí:
        MessageBox.Show("Convenio válido. Continuando con el pago...", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Lógica de pago...
    End Sub


End Class