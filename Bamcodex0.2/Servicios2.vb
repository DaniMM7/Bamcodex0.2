﻿Imports System.Data.SqlClient

<DebuggerDisplay("{GetDebuggerDisplay(),nq}")>
Public Class Servicios2
    Public Property ConvenioSeleccionado As String
    Private SaldoDisponible As Decimal = 1000D
    Public Property UsuarioActual As String


    Private Sub Servicios2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conectar()

            Dim sql As String = "SELECT NumeroConvenio, NombreConvenio FROM Convenios ORDER BY NombreConvenio"
            Using com As New SqlCommand(sql, conexion_general)
                Using dr As SqlDataReader = com.ExecuteReader()
                    NomEmpresa.Items.Clear()
                    While dr.Read()
                        Dim numero As String = dr("NumeroConvenio").ToString()
                        Dim nombre As String = dr("NombreConvenio").ToString()
                        NomEmpresa.Items.Add(numero & " - " & nombre)
                    End While
                End Using
            End Using

            ' Asignar el servicio seleccionado automáticamente si existe en la lista
            If Not String.IsNullOrEmpty(ConvenioSeleccionado) Then
                For Each item As String In NomEmpresa.Items
                    If item.Contains(ConvenioSeleccionado) Then
                        NomEmpresa.SelectedItem = item
                        Exit For
                    End If
                Next
            End If


        Catch ex As Exception
            MessageBox.Show("Error al cargar convenios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try
    End Sub

    Private Sub RealizarPago_Click(sender As Object, e As EventArgs) Handles RealizarPago.Click
        Dim numeroTarjeta As String = tarjeta.ClienteNum

        If String.IsNullOrEmpty(numeroTarjeta) Then
            MessageBox.Show("No se ha identificado ninguna tarjeta. Por favor, inicie sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Validar referencia
        If String.IsNullOrWhiteSpace(Referencia.Text) Then
            MessageBox.Show("Por favor ingrese la referencia.", "Falta referencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar monto
        Dim montoPago As Decimal
        Dim montoTexto As String = Monto.Text.Replace("$", "").Trim()

        If Not Decimal.TryParse(montoTexto, montoPago) OrElse montoPago <= 0 Then
            MessageBox.Show("Por favor ingrese un monto válido mayor a cero.", "Monto incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            conectar()

            ' Paso 1: Obtener CuentaID asociado al NumeroTarjeta
            Dim consultaCuentaID As String = "SELECT CuentaID FROM dbo.Tarjeta WHERE NumeroTarjeta = @NumeroTarjeta"
            Dim cuentaIDObj As Object = Nothing
            Using cmdCuentaID As New SqlCommand(consultaCuentaID, conexion_general)
                cmdCuentaID.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta)
                cuentaIDObj = cmdCuentaID.ExecuteScalar()
            End Using

            If cuentaIDObj Is Nothing Then
                MessageBox.Show("No se encontró una cuenta asociada a la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim cuentaID As Integer = Convert.ToInt32(cuentaIDObj)

            ' Paso 2: Obtener saldo de la cuenta
            Dim consultaSaldo As String = "SELECT Saldo FROM dbo.Cuentas WHERE CuentaID = @CuentaID"
            Dim saldoObj As Object = Nothing
            Using cmdSaldo As New SqlCommand(consultaSaldo, conexion_general)
                cmdSaldo.Parameters.AddWithValue("@CuentaID", cuentaID)
                saldoObj = cmdSaldo.ExecuteScalar()
            End Using

            If saldoObj Is Nothing Then
                MessageBox.Show("No se encontró la cuenta para verificar saldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim saldoActual As Decimal = Convert.ToDecimal(saldoObj)

            ' Paso 3: Verificar saldo suficiente
            If saldoActual < montoPago Then
                MessageBox.Show("No hay fondos suficientes.", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Confirmar operación
            Dim respuesta As DialogResult = MessageBox.Show(
            $"Realizarás el pago de {Monto.Text} con la tarjeta {numeroTarjeta}.{vbCrLf}¿Deseas continuar?",
            "Confirmar pago",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
        )

            If respuesta <> DialogResult.OK Then
                Exit Sub
            End If

            ' Paso 4: Actualizar saldo restando el monto
            Dim actualizarSaldo As String = "UPDATE dbo.Cuentas SET Saldo = Saldo - @Monto WHERE CuentaID = @CuentaID"
            Using cmdActualizar As New SqlCommand(actualizarSaldo, conexion_general)
                cmdActualizar.Parameters.AddWithValue("@Monto", montoPago)
                cmdActualizar.Parameters.AddWithValue("@CuentaID", cuentaID)
                Dim filasAfectadas = cmdActualizar.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    MessageBox.Show("Pago realizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al actualizar saldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error en la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try
    End Sub



    ' === Validación para Monto ===

    Private Sub Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Monto.KeyPress
        ' Permitir solo números, punto decimal y teclas de control (como Backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        ' No permitir más de un punto decimal
        If e.KeyChar = "." AndAlso Monto.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub Monto_Leave(sender As Object, e As EventArgs) Handles Monto.Leave
        Dim montoDecimal As Decimal
        If Decimal.TryParse(Monto.Text.Replace("$", "").Trim(), montoDecimal) Then
            Monto.Text = montoDecimal.ToString("C2") ' Ej: $1,234.56
        End If
    End Sub

    ' === Validación para Referencia ===

    Private Sub Referencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Referencia.KeyPress
        ' Solo permite números
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Function GetDebuggerDisplay() As String
        Return ToString()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New Servicios()
        ope.Show()
        Me.Hide()
    End Sub
End Class