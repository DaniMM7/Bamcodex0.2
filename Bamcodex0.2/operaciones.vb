﻿Imports System.Data.SqlClient

Public Class operaciones
    Dim NombreCliente As String
    Dim SaldoCliente As String
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Public Shared saldop As String
    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub operaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
        Dim numeroTarjeta As String = tarjeta.ClienteNum.Trim()
        Dim tarjetaID As Integer = 0

        Try
            conectar()
            Dim comId As New SqlCommand("SELECT TarjetaID FROM Tarjeta WHERE NumeroTarjeta = @NumeroTarjeta", conexion_general)
            comId.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta)

            Dim result = comId.ExecuteScalar()
            If result IsNot Nothing Then
                tarjetaID = Convert.ToInt32(result)
            Else
                MsgBox("Número de tarjeta no encontrado.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error al obtener TarjetaID: " & ex.Message)
            Exit Sub
        End Try
        Dim sql As String = "SELECT CL.Nombre, CL.Apellido, CU.Saldo " &
                    "FROM Tarjeta T " &
                    "JOIN Cuentas CU ON T.CuentaID = CU.CuentaID " &
                    "JOIN Clientes CL ON CU.ClienteID = CL.ClienteID " &
                    "WHERE T.TarjetaID = @TarjetaID"

        Try
            Dim com As New SqlCommand(sql, conexion_general)
            com.Parameters.AddWithValue("@TarjetaID", tarjetaID)

            Dim dr As SqlDataReader = com.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    Dim nombre As String = dr("Nombre").ToString()
                    Dim apellido As String = dr("Apellido").ToString()
                    Dim saldo As Decimal = Convert.ToDecimal(dr("Saldo"))
                    txtNom.Text = nombre & " " & apellido
                    txtSaldo.Text = saldo.ToString("C2")
                    saldop = saldo

                End While
            Else
                MsgBox("No se encontró información para la tarjeta indicada.")
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        consulta.Show()
        CargarDatos()
    End Sub

    Private Sub Servicios_Click(sender As Object, e As EventArgs) Handles Servicios.Click
        Dim formServicios As New Servicios()
        formServicios.Show()
        Me.Hide()
        CargarDatos()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim formDepositar As New Depositar()
        formDepositar.Show()
        Me.Hide()
        CargarDatos()
    End Sub

    Private Sub Movi_Click(sender As Object, e As EventArgs) Handles Movi.Click
        CargarDatos()
        Dim formMov As New Historial()
        formMov.Show()
        Me.Hide()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim formRetirar As New Retirar()
        formRetirar.Show()
        Me.Hide()
        CargarDatos()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim formTransferir As New Transferir()
        formTransferir.Show()
        Me.Hide()
        CargarDatos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tarjeta As New tarjeta()
        tarjeta.Show()
        Me.Hide()
        CargarDatos()
    End Sub

    Public Sub CargarDatos()
        Dim numeroTarjeta As String = tarjeta.ClienteNum.Trim()
        Dim tarjetaID As Integer = 0

        Try
            conectar()
            Dim comId As New SqlCommand("SELECT TarjetaID FROM Tarjeta WHERE NumeroTarjeta = @NumeroTarjeta", conexion_general)
            comId.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta)

            Dim result = comId.ExecuteScalar()
            If result IsNot Nothing Then
                tarjetaID = Convert.ToInt32(result)
            Else
                MsgBox("Número de tarjeta no encontrado.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error al obtener TarjetaID: " & ex.Message)
            Exit Sub
        End Try

        Dim sql As String = "SELECT CL.Nombre, CL.Apellido, CU.Saldo " &
                            "FROM Tarjeta T " &
                            "JOIN Cuentas CU ON T.CuentaID = CU.CuentaID " &
                            "JOIN Clientes CL ON CU.ClienteID = CL.ClienteID " &
                            "WHERE T.TarjetaID = @TarjetaID"

        Try
            Dim com As New SqlCommand(sql, conexion_general)
            com.Parameters.AddWithValue("@TarjetaID", tarjetaID)

            Dim dr As SqlDataReader = com.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    Dim nombre As String = dr("Nombre").ToString()
                    Dim apellido As String = dr("Apellido").ToString()
                    Dim saldo As Decimal = Convert.ToDecimal(dr("Saldo"))
                    txtNom.Text = nombre & " " & apellido
                    txtSaldo.Text = saldo.ToString("C2")
                    saldop = saldo
                End While
            Else
                MsgBox("No se encontró información para la tarjeta indicada.")
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If conexion_general.State = ConnectionState.Open Then
                conexion_general.Close()
            End If
        End Try
    End Sub
End Class