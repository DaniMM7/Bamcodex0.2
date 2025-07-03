<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transferir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Transferir))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnconfirmar = New System.Windows.Forms.Button()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.txtingresenumero = New System.Windows.Forms.TextBox()
        Me.txtingresemonto = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblError = New System.Windows.Forms.TextBox()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(423, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 44)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TRANSFERIR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(340, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(425, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "¿A QUE TIPO DE CUENTA DESEA TRANSFERIR?  "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(364, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(368, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "INGRESE NUMERO DE CUENTA / TARJETA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(485, 403)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "INGRESE MONTO"
        '
        'btnconfirmar
        '
        Me.btnconfirmar.BackColor = System.Drawing.Color.Transparent
        Me.btnconfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnconfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnconfirmar.Font = New System.Drawing.Font("Britannic Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconfirmar.ForeColor = System.Drawing.Color.White
        Me.btnconfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnconfirmar.Location = New System.Drawing.Point(830, 511)
        Me.btnconfirmar.Name = "btnconfirmar"
        Me.btnconfirmar.Size = New System.Drawing.Size(256, 71)
        Me.btnconfirmar.TabIndex = 35
        Me.btnconfirmar.Text = "Confirmar"
        Me.btnconfirmar.UseVisualStyleBackColor = False
        '
        'tipo
        '
        Me.tipo.BackColor = System.Drawing.Color.MistyRose
        Me.tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo.FormattingEnabled = True
        Me.tipo.Location = New System.Drawing.Point(344, 182)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(421, 37)
        Me.tipo.TabIndex = 36
        '
        'txtingresenumero
        '
        Me.txtingresenumero.BackColor = System.Drawing.Color.MistyRose
        Me.txtingresenumero.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtingresenumero.Location = New System.Drawing.Point(344, 309)
        Me.txtingresenumero.Multiline = True
        Me.txtingresenumero.Name = "txtingresenumero"
        Me.txtingresenumero.Size = New System.Drawing.Size(421, 51)
        Me.txtingresenumero.TabIndex = 37
        '
        'txtingresemonto
        '
        Me.txtingresemonto.BackColor = System.Drawing.Color.MistyRose
        Me.txtingresemonto.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtingresemonto.Location = New System.Drawing.Point(386, 446)
        Me.txtingresemonto.Name = "txtingresemonto"
        Me.txtingresemonto.Size = New System.Drawing.Size(330, 34)
        Me.txtingresemonto.TabIndex = 38
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(-57, 403)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(260, 90)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Regresar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblError)
        Me.PanelError.Location = New System.Drawing.Point(0, 12)
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
        'Transferir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Bamcodex0._2.My.Resources.Resources.Captura_de_pantalla_2025_06_11_023527
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1085, 594)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtingresemonto)
        Me.Controls.Add(Me.txtingresenumero)
        Me.Controls.Add(Me.tipo)
        Me.Controls.Add(Me.btnconfirmar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "Transferir"
        Me.Text = "Transferir"
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnconfirmar As Button
    Friend WithEvents tipo As ComboBox
    Friend WithEvents txtingresenumero As TextBox
    Friend WithEvents txtingresemonto As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PanelError As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblError As TextBox
End Class
