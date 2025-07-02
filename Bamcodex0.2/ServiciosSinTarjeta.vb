Imports System.Data.SqlClient

Public Class ServiciosSinTarjeta

    Private Sub ServiciosSinTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conectar()
            Dim sql As String = "SELECT NumeroConvenio, NombreConvenio FROM Convenios ORDER BY NombreConvenio"

            Using cmd As New SqlCommand(sql, conexion_general)
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    cboConvenios.Items.Clear()
                    While dr.Read()
                        Dim numero As String = dr("NumeroConvenio").ToString()
                        Dim nombre As String = dr("NombreConvenio").ToString()
                        cboConvenios.Items.Add(numero & " - " & nombre)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar convenios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conexion_general.State = ConnectionState.Open Then conexion_general.Close()
        End Try
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        ' Limpiar el label de error
        lblError.Text = ""
        PanelError.Visible = False
        lblError.Visible = False


        If cboConvenios.SelectedIndex = -1 Then
            lblError.Text = "Seleccione una empresa."
            PanelError.Visible = True
            lblError.Visible = True

            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtReferencia.Text) Then
            lblError.Text = "Ingrese la referencia o línea de captura."
            PanelError.Visible = True
            lblError.Visible = True
            Exit Sub
        End If

        Dim montoDecimal As Decimal
        Dim montoTexto As String = txtMonto.Text.Replace("$", "").Trim()
        If Not Decimal.TryParse(montoTexto, montoDecimal) OrElse montoDecimal <= 0 Then
            lblError.Text = "Ingrese un monto válido mayor a cero."
            PanelError.Visible = True
            lblError.Visible = True
            Exit Sub
        End If

        ' Abrir formulario de billetes
        Dim formBilletes As New ValidarBilletes()
        If formBilletes.ShowDialog() = DialogResult.OK Then
            Dim totalBilletes As Decimal = formBilletes.TotalBilletes

            If totalBilletes <> montoDecimal Then
                lblError.Text = $"El total ingresado en billetes ({totalBilletes:C}) no coincide con el monto a pagar ({montoDecimal:C})."
                PanelError.Visible = True
                lblError.Visible = True
                Exit Sub
            End If

            ' Obtener solo el número de convenio (antes del guión)
            Dim convenioPartes As String() = cboConvenios.SelectedItem.ToString().Split("-"c)
            Dim numeroConvenio As String = convenioPartes(0).Trim()

            Try
                conectar()

                Dim insertSql As String = "INSERT INTO PagosServiciosAnonimos (NumeroConvenio, Referencia, Monto, FechaPago) " &
                                      "VALUES (@Convenio, @Referencia, @Monto, GETDATE())"

                Using cmdInsert As New SqlCommand(insertSql, conexion_general)
                    cmdInsert.Parameters.AddWithValue("@Convenio", numeroConvenio)
                    cmdInsert.Parameters.AddWithValue("@Referencia", txtReferencia.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@Monto", montoDecimal)

                    cmdInsert.ExecuteNonQuery()
                End Using

                Dim formok As New ok()
                formok.Show()



                cboConvenios.SelectedIndex = -1
                txtReferencia.Clear()
                txtMonto.Clear()

            Catch ex As Exception
                lblError.ForeColor = Color.Red
                lblError.Text = "Error al registrar el pago: " & ex.Message
                PanelError.Visible = True
                lblError.Visible = True
            Finally
                If conexion_general.State = ConnectionState.Open Then conexion_general.Close()
            End Try

        Else
            lblError.Text = "Operación cancelada por el usuario."
            PanelError.Visible = True
            lblError.Visible = True
        End If
    End Sub


    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." AndAlso txtMonto.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Dim montoDecimal As Decimal
        If Decimal.TryParse(txtMonto.Text.Replace("$", "").Trim(), montoDecimal) Then
            txtMonto.Text = montoDecimal.ToString("C2")
        End If
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim volver As New tarjeta()
        volver.Show()
        Me.Hide()
    End Sub

    Private Sub Monto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub
End Class
