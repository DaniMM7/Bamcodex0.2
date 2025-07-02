Public Class ValidarBilletes
    Public Property TotalBilletes As Decimal = 0D

    ' El evento Load ya no hace nada
    Private Sub ValidarBilletes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No hacer nada aquí
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        Dim b50, b100, b200, b500 As Integer

        ' Validar que todos los campos sean numéricos, si no lo son, se asume 0
        If Not Integer.TryParse(txt50.Text.Trim(), b50) Then b50 = 0
        If Not Integer.TryParse(txt100.Text.Trim(), b100) Then b100 = 0
        If Not Integer.TryParse(txt200.Text.Trim(), b200) Then b200 = 0
        If Not Integer.TryParse(txt500.Text.Trim(), b500) Then b500 = 0

        ' Calcular total
        TotalBilletes = (b50 * 50) + (b100 * 100) + (b200 * 200) + (b500 * 500)

        If TotalBilletes <= 0 Then
            lblMensaje.Text = "Debe ingresar al menos un billete."
            lblMensaje.Visible = True
            Exit Sub
        End If

        ' Todo correcto
        lblMensaje.Visible = False
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
