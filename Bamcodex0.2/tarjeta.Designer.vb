<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tarjeta
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtNumTarjeta = New System.Windows.Forms.TextBox()
        Me.txtPIN = New System.Windows.Forms.TextBox()
        Me.retirost = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LavenderBlush
        Me.Label1.Location = New System.Drawing.Point(779, 491)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INGRESE SU NIP:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightCoral
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Britannic Bold", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(787, 599)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(327, 36)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "ELIMINAR"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.LightCoral
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Britannic Bold", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(787, 545)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(327, 36)
        Me.Button4.TabIndex = 37
        Me.Button4.Text = "ACCEDER"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'txtNumTarjeta
        '
        Me.txtNumTarjeta.BackColor = System.Drawing.Color.MistyRose
        Me.txtNumTarjeta.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumTarjeta.Location = New System.Drawing.Point(774, 147)
        Me.txtNumTarjeta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNumTarjeta.Name = "txtNumTarjeta"
        Me.txtNumTarjeta.Size = New System.Drawing.Size(299, 34)
        Me.txtNumTarjeta.TabIndex = 38
        '
        'txtPIN
        '
        Me.txtPIN.BackColor = System.Drawing.Color.MistyRose
        Me.txtPIN.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIN.Location = New System.Drawing.Point(967, 487)
        Me.txtPIN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.Size = New System.Drawing.Size(122, 34)
        Me.txtPIN.TabIndex = 39
        '
        'retirost
        '
        Me.retirost.BackColor = System.Drawing.Color.MistyRose
        Me.retirost.CausesValidation = False
        Me.retirost.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.retirost.Location = New System.Drawing.Point(110, 408)
        Me.retirost.Name = "retirost"
        Me.retirost.Size = New System.Drawing.Size(214, 55)
        Me.retirost.TabIndex = 40
        Me.retirost.Text = "Retiro sin tarjeta"
        Me.retirost.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MistyRose
        Me.Button1.CausesValidation = False
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(464, 408)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(214, 55)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "Pagar servicios"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnPagar
        '
        Me.btnPagar.BackColor = System.Drawing.Color.LightCoral
        Me.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPagar.Font = New System.Drawing.Font("Britannic Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagar.ForeColor = System.Drawing.Color.White
        Me.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPagar.Location = New System.Drawing.Point(-39, 565)
        Me.btnPagar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(251, 48)
        Me.btnPagar.TabIndex = 49
        Me.btnPagar.Text = "Volver"
        Me.btnPagar.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MistyRose
        Me.Button3.CausesValidation = False
        Me.Button3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(803, 408)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(255, 55)
        Me.Button3.TabIndex = 50
        Me.Button3.Text = "Inserte su tarjeta"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'tarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Bamcodex0._2.My.Resources.Resources.Captura_de_pantalla_2025_07_03_094935
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1126, 646)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnPagar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.retirost)
        Me.Controls.Add(Me.txtPIN)
        Me.Controls.Add(Me.txtNumTarjeta)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "tarjeta"
        Me.Text = "tarjeta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents txtNumTarjeta As TextBox
    Friend WithEvents txtPIN As TextBox
    Friend WithEvents retirost As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnPagar As Button
    Friend WithEvents Button3 As Button
End Class
