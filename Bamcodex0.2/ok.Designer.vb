<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ok
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ok))
        Me.RealizarPago = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RealizarPago
        '
        Me.RealizarPago.BackColor = System.Drawing.Color.Transparent
        Me.RealizarPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RealizarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RealizarPago.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RealizarPago.ForeColor = System.Drawing.Color.White
        Me.RealizarPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RealizarPago.Location = New System.Drawing.Point(209, 425)
        Me.RealizarPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RealizarPago.Name = "RealizarPago"
        Me.RealizarPago.Size = New System.Drawing.Size(502, 61)
        Me.RealizarPago.TabIndex = 50
        Me.RealizarPago.Text = "Aceptar"
        Me.RealizarPago.UseVisualStyleBackColor = False
        '
        'ok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(941, 561)
        Me.Controls.Add(Me.RealizarPago)
        Me.Name = "ok"
        Me.Text = "ok"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RealizarPago As Button
End Class
