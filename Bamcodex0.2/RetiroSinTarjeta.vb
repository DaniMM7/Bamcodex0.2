Public Class RetiroSinTarjeta
    ' Variable de clase para guardar el monto seleccionado
    Private montoSeleccionado As Decimal = 0

    Private Sub RetiroSinTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtMontoPersonalizado.Visible = False
    End Sub

    Private Sub BtnMonto100_Click(sender As Object, e As EventArgs) Handles BtnMonto100.Click
        montoSeleccionado = 100D
        TxtMontoPersonalizado.Visible = False
    End Sub

    Private Sub BtnMonto300_Click(sender As Object, e As EventArgs) Handles BtnMonto300.Click
        montoSeleccionado = 300D
        TxtMontoPersonalizado.Visible = False
    End Sub

    Private Sub BtnMonto500_Click(sender As Object, e As EventArgs) Handles BtnMonto500.Click
        montoSeleccionado = 500D
        TxtMontoPersonalizado.Visible = False
    End Sub

    Private Sub BtnOtroMonto_Click(sender As Object, e As EventArgs) Handles BtnOtroMonto.Click
        TxtMontoPersonalizado.Visible = True
        TxtMontoPersonalizado.Focus()
    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        ' Validar monto personalizado si está visible
        If TxtMontoPersonalizado.Visible Then
            Dim montoPersonalizado As Decimal
            If Not Decimal.TryParse(TxtMontoPersonalizado.Text.Trim(), montoPersonalizado) OrElse montoPersonalizado <= 0 Then
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtMontoPersonalizado.Focus()
                Return
            End If
            montoSeleccionado = montoPersonalizado
        End If

        ' Validar que se haya seleccionado o ingresado un monto válido
        If montoSeleccionado <= 0 Then
            MessageBox.Show("Seleccione o ingrese un monto para retirar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Abrir formulario de confirmación y pasar el monto seleccionado
        Dim frmConfirmar As New RetiroConfirmar(montoSeleccionado)
        frmConfirmar.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New tarjeta()
        ope.Show()
        Me.Hide()
    End Sub

    Private Sub TxtMontoPersonalizado_TextChanged(sender As Object, e As EventArgs) Handles TxtMontoPersonalizado.TextChanged

    End Sub
End Class