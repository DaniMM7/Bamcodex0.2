Public Class Servicios

    Private Sub AbrirFormularioServicios2(convenioNombre As String)
        Dim formPago As New Servicios2()
        formPago.ConvenioSeleccionado = "Luz (CFE)"
        formPago.UsuarioActual = "juan" ' <- Este valor lo tomas según el login
        formPago.Show()
        Me.Hide()

    End Sub

    Private Sub CFE_Click(sender As Object, e As EventArgs) Handles CFE.Click
        AbrirFormularioServicios2("01001") ' o también "Luz (CFE)"
    End Sub

    Private Sub Telmex_Click(sender As Object, e As EventArgs) Handles Telmex.Click
        AbrirFormularioServicios2("02002")
    End Sub

    Private Sub Colegiaturas_Click(sender As Object, e As EventArgs) Handles Colegiaturas.Click
        AbrirFormularioServicios2("03003")
    End Sub

    Private Sub Tenencia_Click(sender As Object, e As EventArgs) Handles Tenencia.Click
        AbrirFormularioServicios2("04004")
    End Sub

    Private Sub No_Convenio_Click(sender As Object, e As EventArgs) Handles No_Convenio.Click
        AbrirFormularioServicios2("") ' No selecciona ningún convenio
    End Sub

    ' Este botón "Continuar" puedes usarlo si ya hay una selección previa
    Private Sub Continuar_Click(sender As Object, e As EventArgs) Handles Continuar.Click
        AbrirFormularioServicios2("01001") ' puedes modificar esto si seleccionas desde combo u otro espacio
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub
End Class
