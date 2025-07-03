<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Historial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Historial))
        Me.ComboBoxTipoTransaccion = New System.Windows.Forms.ComboBox()
        Me.DataGridViewMovimientos = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridViewMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxTipoTransaccion
        '
        Me.ComboBoxTipoTransaccion.BackColor = System.Drawing.Color.MistyRose
        Me.ComboBoxTipoTransaccion.FormattingEnabled = True
        Me.ComboBoxTipoTransaccion.Location = New System.Drawing.Point(45, 83)
        Me.ComboBoxTipoTransaccion.Name = "ComboBoxTipoTransaccion"
        Me.ComboBoxTipoTransaccion.Size = New System.Drawing.Size(681, 24)
        Me.ComboBoxTipoTransaccion.TabIndex = 0
        '
        'DataGridViewMovimientos
        '
        Me.DataGridViewMovimientos.BackgroundColor = System.Drawing.Color.MistyRose
        Me.DataGridViewMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewMovimientos.Location = New System.Drawing.Point(45, 129)
        Me.DataGridViewMovimientos.Name = "DataGridViewMovimientos"
        Me.DataGridViewMovimientos.RowHeadersWidth = 51
        Me.DataGridViewMovimientos.RowTemplate.Height = 24
        Me.DataGridViewMovimientos.Size = New System.Drawing.Size(681, 308)
        Me.DataGridViewMovimientos.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(-37, 466)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(260, 39)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Regresar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Historial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(769, 519)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridViewMovimientos)
        Me.Controls.Add(Me.ComboBoxTipoTransaccion)
        Me.DoubleBuffered = True
        Me.Name = "Historial"
        Me.Text = "Historial"
        CType(Me.DataGridViewMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxTipoTransaccion As ComboBox
    Friend WithEvents DataGridViewMovimientos As DataGridView
    Friend WithEvents Button1 As Button
End Class
