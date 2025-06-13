<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Servicios2
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RealizarPago = New System.Windows.Forms.Button()
        Me.NomEmpresa = New System.Windows.Forms.ComboBox()
        Me.Referencia = New System.Windows.Forms.TextBox()
        Me.Monto = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(452, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 44)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SERVICIOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(435, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ingrese el convenio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(345, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Numero del convenio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(345, 290)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(201, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Captura la referencia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(345, 394)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 22)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Importe a pagar :"
        '
        'RealizarPago
        '
        Me.RealizarPago.BackColor = System.Drawing.Color.Transparent
        Me.RealizarPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RealizarPago.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RealizarPago.Font = New System.Drawing.Font("Britannic Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RealizarPago.ForeColor = System.Drawing.Color.White
        Me.RealizarPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RealizarPago.Location = New System.Drawing.Point(808, 479)
        Me.RealizarPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RealizarPago.Name = "RealizarPago"
        Me.RealizarPago.Size = New System.Drawing.Size(332, 102)
        Me.RealizarPago.TabIndex = 36
        Me.RealizarPago.Text = "Realizar pago"
        Me.RealizarPago.UseVisualStyleBackColor = False
        '
        'NomEmpresa
        '
        Me.NomEmpresa.FormattingEnabled = True
        Me.NomEmpresa.Location = New System.Drawing.Point(349, 236)
        Me.NomEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NomEmpresa.Name = "NomEmpresa"
        Me.NomEmpresa.Size = New System.Drawing.Size(400, 24)
        Me.NomEmpresa.TabIndex = 37
        '
        'Referencia
        '
        Me.Referencia.Location = New System.Drawing.Point(349, 334)
        Me.Referencia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Referencia.Multiline = True
        Me.Referencia.Name = "Referencia"
        Me.Referencia.Size = New System.Drawing.Size(400, 40)
        Me.Referencia.TabIndex = 38
        '
        'Monto
        '
        Me.Monto.Location = New System.Drawing.Point(349, 438)
        Me.Monto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Monto.Multiline = True
        Me.Monto.Name = "Monto"
        Me.Monto.Size = New System.Drawing.Size(400, 41)
        Me.Monto.TabIndex = 39
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(-44, 438)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(260, 39)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Regresar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Servicios2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Bamcodex0._2.My.Resources.Resources.Captura_de_pantalla_2025_06_11_024634
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1141, 583)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Monto)
        Me.Controls.Add(Me.Referencia)
        Me.Controls.Add(Me.NomEmpresa)
        Me.Controls.Add(Me.RealizarPago)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Servicios2"
        Me.Text = "Servicios2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RealizarPago As Button
    Friend WithEvents NomEmpresa As ComboBox
    Friend WithEvents Referencia As TextBox
    Friend WithEvents Monto As TextBox
    Friend WithEvents Button1 As Button
End Class
