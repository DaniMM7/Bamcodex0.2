<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Depositar
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.Button()
        Me.txtCuenta = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(478, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DEPOSITAR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(408, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(401, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "INGRESA LA CUENTA O TARJETA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(461, 389)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(298, 31)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "IMPORTE A DEPOSITAR"
        '
        'txtImporte
        '
        Me.txtImporte.BackColor = System.Drawing.Color.Transparent
        Me.txtImporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtImporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.txtImporte.Font = New System.Drawing.Font("Britannic Bold", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.ForeColor = System.Drawing.Color.White
        Me.txtImporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtImporte.Location = New System.Drawing.Point(395, 458)
        Me.txtImporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(375, 54)
        Me.txtImporte.TabIndex = 29
        Me.txtImporte.Text = "$ 0.0"
        Me.txtImporte.UseVisualStyleBackColor = False
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.Transparent
        Me.txtCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.txtCuenta.Font = New System.Drawing.Font("Britannic Bold", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.ForeColor = System.Drawing.Color.White
        Me.txtCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCuenta.Location = New System.Drawing.Point(304, 249)
        Me.txtCuenta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(577, 74)
        Me.txtCuenta.TabIndex = 30
        Me.txtCuenta.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
        Me.txtCuenta.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(926, 628)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(292, 112)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Confirmar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Depositar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Bamcodex0._2.My.Resources.Resources.Captura_de_pantalla_2025_06_11_021807
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1216, 742)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Depositar"
        Me.Text = "Depositar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtImporte As Button
    Friend WithEvents txtCuenta As Button
    Friend WithEvents Button2 As Button
End Class
