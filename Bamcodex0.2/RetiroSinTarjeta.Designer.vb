<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RetiroSinTarjeta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RetiroSinTarjeta))
        Me.BtnMonto1000 = New System.Windows.Forms.Button()
        Me.BtnMonto500 = New System.Windows.Forms.Button()
        Me.BtnMonto300 = New System.Windows.Forms.Button()
        Me.BtnMonto100 = New System.Windows.Forms.Button()
        Me.BtnOtroMonto = New System.Windows.Forms.Button()
        Me.BtnConfirmar = New System.Windows.Forms.Button()
        Me.TxtMontoPersonalizado = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnMonto1000
        '
        Me.BtnMonto1000.BackColor = System.Drawing.Color.Transparent
        Me.BtnMonto1000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnMonto1000.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMonto1000.Font = New System.Drawing.Font("Britannic Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMonto1000.ForeColor = System.Drawing.Color.White
        Me.BtnMonto1000.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMonto1000.Location = New System.Drawing.Point(0, 155)
        Me.BtnMonto1000.Name = "BtnMonto1000"
        Me.BtnMonto1000.Size = New System.Drawing.Size(313, 115)
        Me.BtnMonto1000.TabIndex = 21
        Me.BtnMonto1000.Text = "$1,000"
        Me.BtnMonto1000.UseVisualStyleBackColor = False
        '
        'BtnMonto500
        '
        Me.BtnMonto500.BackColor = System.Drawing.Color.Transparent
        Me.BtnMonto500.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnMonto500.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMonto500.Font = New System.Drawing.Font("Britannic Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMonto500.ForeColor = System.Drawing.Color.White
        Me.BtnMonto500.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMonto500.Location = New System.Drawing.Point(12, 297)
        Me.BtnMonto500.Name = "BtnMonto500"
        Me.BtnMonto500.Size = New System.Drawing.Size(301, 115)
        Me.BtnMonto500.TabIndex = 22
        Me.BtnMonto500.Text = "$500"
        Me.BtnMonto500.UseVisualStyleBackColor = False
        '
        'BtnMonto300
        '
        Me.BtnMonto300.BackColor = System.Drawing.Color.Transparent
        Me.BtnMonto300.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnMonto300.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMonto300.Font = New System.Drawing.Font("Britannic Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMonto300.ForeColor = System.Drawing.Color.White
        Me.BtnMonto300.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMonto300.Location = New System.Drawing.Point(12, 438)
        Me.BtnMonto300.Name = "BtnMonto300"
        Me.BtnMonto300.Size = New System.Drawing.Size(301, 115)
        Me.BtnMonto300.TabIndex = 23
        Me.BtnMonto300.Text = "$200"
        Me.BtnMonto300.UseVisualStyleBackColor = False
        '
        'BtnMonto100
        '
        Me.BtnMonto100.BackColor = System.Drawing.Color.Transparent
        Me.BtnMonto100.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnMonto100.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMonto100.Font = New System.Drawing.Font("Britannic Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMonto100.ForeColor = System.Drawing.Color.White
        Me.BtnMonto100.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMonto100.Location = New System.Drawing.Point(775, 155)
        Me.BtnMonto100.Name = "BtnMonto100"
        Me.BtnMonto100.Size = New System.Drawing.Size(329, 115)
        Me.BtnMonto100.TabIndex = 24
        Me.BtnMonto100.Text = "$100"
        Me.BtnMonto100.UseVisualStyleBackColor = False
        '
        'BtnOtroMonto
        '
        Me.BtnOtroMonto.BackColor = System.Drawing.Color.Transparent
        Me.BtnOtroMonto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnOtroMonto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOtroMonto.Font = New System.Drawing.Font("Britannic Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOtroMonto.ForeColor = System.Drawing.Color.White
        Me.BtnOtroMonto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOtroMonto.Location = New System.Drawing.Point(775, 288)
        Me.BtnOtroMonto.Name = "BtnOtroMonto"
        Me.BtnOtroMonto.Size = New System.Drawing.Size(256, 115)
        Me.BtnOtroMonto.TabIndex = 25
        Me.BtnOtroMonto.Text = "otro monto"
        Me.BtnOtroMonto.UseVisualStyleBackColor = False
        '
        'BtnConfirmar
        '
        Me.BtnConfirmar.BackColor = System.Drawing.Color.Transparent
        Me.BtnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConfirmar.Font = New System.Drawing.Font("Britannic Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirmar.ForeColor = System.Drawing.Color.White
        Me.BtnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConfirmar.Location = New System.Drawing.Point(775, 424)
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(256, 115)
        Me.BtnConfirmar.TabIndex = 26
        Me.BtnConfirmar.Text = "Confirmar"
        Me.BtnConfirmar.UseVisualStyleBackColor = False
        '
        'TxtMontoPersonalizado
        '
        Me.TxtMontoPersonalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoPersonalizado.Location = New System.Drawing.Point(470, 288)
        Me.TxtMontoPersonalizado.Name = "TxtMontoPersonalizado"
        Me.TxtMontoPersonalizado.Size = New System.Drawing.Size(191, 38)
        Me.TxtMontoPersonalizado.TabIndex = 27
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(443, 566)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(260, 39)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Regresar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'RetiroSinTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1096, 607)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtMontoPersonalizado)
        Me.Controls.Add(Me.BtnConfirmar)
        Me.Controls.Add(Me.BtnOtroMonto)
        Me.Controls.Add(Me.BtnMonto100)
        Me.Controls.Add(Me.BtnMonto300)
        Me.Controls.Add(Me.BtnMonto500)
        Me.Controls.Add(Me.BtnMonto1000)
        Me.Name = "RetiroSinTarjeta"
        Me.Text = "RetiroSinTarjeta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnMonto1000 As Button
    Friend WithEvents BtnMonto500 As Button
    Friend WithEvents BtnMonto300 As Button
    Friend WithEvents BtnMonto100 As Button
    Friend WithEvents BtnOtroMonto As Button
    Friend WithEvents BtnConfirmar As Button
    Friend WithEvents TxtMontoPersonalizado As TextBox
    Friend WithEvents Button1 As Button
End Class
