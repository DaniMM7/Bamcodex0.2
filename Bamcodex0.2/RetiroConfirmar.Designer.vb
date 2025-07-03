<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RetiroConfirmar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RetiroConfirmar))
        Me.txtClaveRetiro = New System.Windows.Forms.TextBox()
        Me.txtPIN = New System.Windows.Forms.TextBox()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.BtnConfirmarRetiro = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblError = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtClaveRetiro
        '
        Me.txtClaveRetiro.BackColor = System.Drawing.Color.MistyRose
        Me.txtClaveRetiro.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveRetiro.Location = New System.Drawing.Point(297, 222)
        Me.txtClaveRetiro.Multiline = True
        Me.txtClaveRetiro.Name = "txtClaveRetiro"
        Me.txtClaveRetiro.Size = New System.Drawing.Size(353, 56)
        Me.txtClaveRetiro.TabIndex = 0
        '
        'txtPIN
        '
        Me.txtPIN.BackColor = System.Drawing.Color.MistyRose
        Me.txtPIN.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIN.Location = New System.Drawing.Point(297, 330)
        Me.txtPIN.Multiline = True
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.Size = New System.Drawing.Size(353, 56)
        Me.txtPIN.TabIndex = 1
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte.Location = New System.Drawing.Point(303, 442)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(0, 38)
        Me.lblImporte.TabIndex = 2
        '
        'BtnConfirmarRetiro
        '
        Me.BtnConfirmarRetiro.BackColor = System.Drawing.Color.Transparent
        Me.BtnConfirmarRetiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnConfirmarRetiro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConfirmarRetiro.Font = New System.Drawing.Font("Britannic Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirmarRetiro.ForeColor = System.Drawing.Color.White
        Me.BtnConfirmarRetiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConfirmarRetiro.Location = New System.Drawing.Point(689, 473)
        Me.BtnConfirmarRetiro.Name = "BtnConfirmarRetiro"
        Me.BtnConfirmarRetiro.Size = New System.Drawing.Size(329, 115)
        Me.BtnConfirmarRetiro.TabIndex = 27
        Me.BtnConfirmarRetiro.Text = "Confirmar"
        Me.BtnConfirmarRetiro.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(-15, 436)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(199, 56)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Regresar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblError)
        Me.PanelError.Location = New System.Drawing.Point(1, 142)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(276, 167)
        Me.PanelError.TabIndex = 53
        Me.PanelError.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(208, 100)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(65, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblError
        '
        Me.lblError.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblError.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.White
        Me.lblError.Location = New System.Drawing.Point(8, 14)
        Me.lblError.Multiline = True
        Me.lblError.Name = "lblError"
        Me.lblError.ReadOnly = True
        Me.lblError.Size = New System.Drawing.Size(245, 91)
        Me.lblError.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.MistyRose
        Me.TextBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(297, 433)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(353, 56)
        Me.TextBox1.TabIndex = 54
        '
        'RetiroConfirmar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(994, 587)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnConfirmarRetiro)
        Me.Controls.Add(Me.lblImporte)
        Me.Controls.Add(Me.txtPIN)
        Me.Controls.Add(Me.txtClaveRetiro)
        Me.Name = "RetiroConfirmar"
        Me.Text = "RetiroConfirmar"
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtClaveRetiro As TextBox
    Friend WithEvents txtPIN As TextBox
    Friend WithEvents lblImporte As Label
    Friend WithEvents BtnConfirmarRetiro As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents PanelError As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblError As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
