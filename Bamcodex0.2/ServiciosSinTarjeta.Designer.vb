<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiciosSinTarjeta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiciosSinTarjeta))
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.cboConvenios = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblError = New System.Windows.Forms.TextBox()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.Color.MistyRose
        Me.txtMonto.Location = New System.Drawing.Point(298, 424)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMonto.Multiline = True
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(341, 50)
        Me.txtMonto.TabIndex = 47
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.MistyRose
        Me.txtReferencia.Location = New System.Drawing.Point(298, 320)
        Me.txtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReferencia.Multiline = True
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(352, 57)
        Me.txtReferencia.TabIndex = 46
        '
        'cboConvenios
        '
        Me.cboConvenios.BackColor = System.Drawing.Color.MistyRose
        Me.cboConvenios.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConvenios.FormattingEnabled = True
        Me.cboConvenios.Location = New System.Drawing.Point(298, 230)
        Me.cboConvenios.Margin = New System.Windows.Forms.Padding(4)
        Me.cboConvenios.Name = "cboConvenios"
        Me.cboConvenios.Size = New System.Drawing.Size(341, 37)
        Me.cboConvenios.TabIndex = 45
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(294, 398)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 22)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Importe a pagar :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(294, 294)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(201, 22)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Captura la referencia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(294, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 22)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Numero del convenio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(379, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 31)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Ingrese el convenio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(396, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 44)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "SERVICIOS"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Black
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(799, 398)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(195, 62)
        Me.btnCancelar.TabIndex = 49
        Me.btnCancelar.Text = "Regresar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnPagar
        '
        Me.btnPagar.BackColor = System.Drawing.Color.Transparent
        Me.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPagar.Font = New System.Drawing.Font("Britannic Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagar.ForeColor = System.Drawing.Color.White
        Me.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPagar.Location = New System.Drawing.Point(702, 475)
        Me.btnPagar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(327, 102)
        Me.btnPagar.TabIndex = 48
        Me.btnPagar.Text = "Realizar pago"
        Me.btnPagar.UseVisualStyleBackColor = False
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblError)
        Me.PanelError.Location = New System.Drawing.Point(0, 45)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(276, 167)
        Me.PanelError.TabIndex = 51
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
        Me.lblError.Location = New System.Drawing.Point(12, 19)
        Me.lblError.Multiline = True
        Me.lblError.Name = "lblError"
        Me.lblError.ReadOnly = True
        Me.lblError.Size = New System.Drawing.Size(245, 91)
        Me.lblError.TabIndex = 0
        '
        'ServiciosSinTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Bamcodex0._2.My.Resources.Resources.Captura_de_pantalla_2025_06_11_024634
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(983, 575)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnPagar)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.cboConvenios)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "ServiciosSinTarjeta"
        Me.Text = "ServiciosSinTarjeta"
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMonto As TextBox
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents cboConvenios As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnPagar As Button
    Friend WithEvents PanelError As Panel
    Friend WithEvents lblError As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
