﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class operaciones
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Servicios = New System.Windows.Forms.Button()
        Me.Movi = New System.Windows.Forms.Button()
        Me.txtNom = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(451, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(494, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "¿QUÉ OPERACIÓN DESEA REALIZAR? "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(65, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "¡Bienvenido(a)!"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Britannic Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(75, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Saldo actual"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(349, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 16)
        Me.Label11.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Britannic Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.Bamcodex0._2.My.Resources.Resources.preguntas_mas_frecuentes__2_
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(345, 98)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(315, 100)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "CONSULTAR"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Bernard MT Condensed", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(852, 452)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(237, 86)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Salir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Britannic Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = Global.Bamcodex0._2.My.Resources.Resources.retirar
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(693, 98)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(321, 100)
        Me.Button4.TabIndex = 22
        Me.Button4.Text = "RETIRAR"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Britannic Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = Global.Bamcodex0._2.My.Resources.Resources.transferir_dinero
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(345, 217)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(315, 100)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "TRANSFERIR"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Britannic Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Image = Global.Bamcodex0._2.My.Resources.Resources.depositar
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(345, 329)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(315, 100)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "DEPOSITAR"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Servicios
        '
        Me.Servicios.BackColor = System.Drawing.Color.Transparent
        Me.Servicios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Servicios.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Servicios.Font = New System.Drawing.Font("Britannic Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Servicios.ForeColor = System.Drawing.Color.White
        Me.Servicios.Image = Global.Bamcodex0._2.My.Resources.Resources.hotel
        Me.Servicios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Servicios.Location = New System.Drawing.Point(693, 217)
        Me.Servicios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Servicios.Name = "Servicios"
        Me.Servicios.Size = New System.Drawing.Size(321, 100)
        Me.Servicios.TabIndex = 25
        Me.Servicios.Text = "SERVICIOS"
        Me.Servicios.UseVisualStyleBackColor = False
        '
        'Movi
        '
        Me.Movi.BackColor = System.Drawing.Color.Transparent
        Me.Movi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Movi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Movi.Font = New System.Drawing.Font("Britannic Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Movi.ForeColor = System.Drawing.Color.White
        Me.Movi.Image = Global.Bamcodex0._2.My.Resources.Resources.caridad
        Me.Movi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Movi.Location = New System.Drawing.Point(693, 329)
        Me.Movi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Movi.Name = "Movi"
        Me.Movi.Size = New System.Drawing.Size(321, 100)
        Me.Movi.TabIndex = 26
        Me.Movi.Text = "MOVIMIENTOS"
        Me.Movi.UseVisualStyleBackColor = False
        '
        'txtNom
        '
        Me.txtNom.AutoSize = True
        Me.txtNom.BackColor = System.Drawing.Color.Transparent
        Me.txtNom.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNom.ForeColor = System.Drawing.Color.White
        Me.txtNom.Location = New System.Drawing.Point(12, 185)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(18, 27)
        Me.txtNom.TabIndex = 27
        Me.txtNom.Text = " "
        '
        'txtSaldo
        '
        Me.txtSaldo.AutoSize = True
        Me.txtSaldo.BackColor = System.Drawing.Color.Transparent
        Me.txtSaldo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.ForeColor = System.Drawing.Color.White
        Me.txtSaldo.Location = New System.Drawing.Point(12, 270)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(18, 27)
        Me.txtSaldo.TabIndex = 28
        Me.txtSaldo.Text = " "
        '
        'operaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BackgroundImage = Global.Bamcodex0._2.My.Resources.Resources.Captura_de_pantalla_2025_06_09_003444
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1089, 545)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.Movi)
        Me.Controls.Add(Me.Servicios)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "operaciones"
        Me.Text = "operaciones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Servicios As Button
    Friend WithEvents Movi As Button
    Friend WithEvents txtNom As Label
    Friend WithEvents txtSaldo As Label
End Class
