Public Class Servicios
    Private Sub Servicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CFE_Click(sender As Object, e As EventArgs) Handles CFE.Click

    End Sub

    Private Sub Telmex_Click(sender As Object, e As EventArgs) Handles Telmex.Click

    End Sub

    Private Sub Colegiaturas_Click(sender As Object, e As EventArgs) Handles Colegiaturas.Click

    End Sub

    Private Sub Tenencia_Click(sender As Object, e As EventArgs) Handles Tenencia.Click

    End Sub

    Private Sub No_Convenio_Click(sender As Object, e As EventArgs) Handles No_Convenio.Click

    End Sub

    Private Sub Continuar_Click(sender As Object, e As EventArgs) Handles Continuar.Click
        Dim formPago As New Servicios2()

        ' Puedes usar una variable para saber qué botón se presionó antes (como "CFE")
        formPago.ConvenioSeleccionado = "Luz (CFE)" ' o el valor real

        formPago.Show()
        Me.Hide()
    End Sub
End Class