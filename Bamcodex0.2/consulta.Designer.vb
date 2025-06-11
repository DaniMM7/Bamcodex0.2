<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class consulta
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Saldoact = New System.Windows.Forms.Label()
        Me.SaldoCajero = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(417, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CONSULTA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(364, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(315, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "El detalle de tu saldo es:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Britannic Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(394, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 26)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Su saldo actual es de:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Britannic Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(394, 343)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(231, 26)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Disponible en cajero :"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Britannic Bold", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(828, 515)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(207, 47)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "SALIR"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Saldoact
        '
        Me.Saldoact.AutoSize = True
        Me.Saldoact.Location = New System.Drawing.Point(495, 253)
        Me.Saldoact.Name = "Saldoact"
        Me.Saldoact.Size = New System.Drawing.Size(48, 16)
        Me.Saldoact.TabIndex = 31
        Me.Saldoact.Text = "Label4"
        '
        'SaldoCajero
        '
        Me.SaldoCajero.AutoSize = True
        Me.SaldoCajero.Location = New System.Drawing.Point(498, 403)
        Me.SaldoCajero.Name = "SaldoCajero"
        Me.SaldoCajero.Size = New System.Drawing.Size(48, 16)
        Me.SaldoCajero.TabIndex = 32
        Me.SaldoCajero.Text = "Label6"
        '
        'consulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Bamcodex0._2.My.Resources.Resources.Captura_de_pantalla_2025_06_11_020704
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1035, 583)
        Me.Controls.Add(Me.SaldoCajero)
        Me.Controls.Add(Me.Saldoact)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "consulta"
        Me.Text = "consulta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Saldoact As Label
    Friend WithEvents SaldoCajero As Label
End Class
