Imports System.Data.SqlClient

Public Class operaciones
    Public Shared saldop As String

    Private Sub operaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    ' Botones del menú
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        consulta.Show()
    End Sub

    Private Sub Servicios_Click(sender As Object, e As EventArgs) Handles Servicios.Click
        Dim formServicios As New Servicios()
        formServicios.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim formDepositar As New Depositar()
        formDepositar.Show()
        Me.Hide()
    End Sub

    Private Sub Movi_Click(sender As Object, e As EventArgs) Handles Movi.Click
        Dim formMov As New Historial()
        formMov.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim formRetirar As New Retirar()
        formRetirar.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim formTransferir As New Transferir()
        formTransferir.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formLogin As New tarjeta()
        formLogin.Show()
        Me.Hide()
    End Sub

    ' Método principal para consultar saldo
    Public Sub CargarDatos()
        Dim numeroCuenta As String = tarjeta.NumeroCuentaUsuario
        Dim saldoEncontrado As Boolean = False

        ' Lista de servidores donde buscar
        Dim servidores As String() = {
        "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;User ID=prueba21;Password=coco",      ' TU servidor (019)
        "Data Source=192.168.0.152;Initial Catalog=BancoMazebankone;User ID=PBANCO;Password=1234",
        "Data Source=192.168.0.232;Initial Catalog=BDREPO;User ID=pepe4;Password=1234",
        "Data Source=192.168.0.129;Initial Catalog=CajeroBueno;User ID=PBANCO;Password=1234",
        "Data Source=192.168.0.173;Initial Catalog=BancoDB1;User ID=pepe4;Password=1234",
        "Data Source=192.168.0.178;Initial Catalog=BANCO;User ID=AMVAL;Password=12345"
    }

        For Each cadena As String In servidores
            Try
                Using conn As New SqlConnection(cadena)
                    conn.Open()

                    Dim sql As String = "SELECT Saldo FROM CuentasReplica WHERE NumeroCuenta = @cuenta"
                    Using cmd As New SqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@cuenta", numeroCuenta)

                        Dim resultado = cmd.ExecuteScalar()
                        If resultado IsNot Nothing Then
                            Dim saldoDecimal As Decimal = Convert.ToDecimal(resultado)
                            txtSaldo.Text = saldoDecimal.ToString("C2")
                            saldop = saldoDecimal.ToString()
                            txtNom.Text = "Cliente Banorte"
                            saldoEncontrado = True
                            Exit For
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ' Omitir errores de conexión
            End Try
        Next

        If Not saldoEncontrado Then
            MsgBox("Cuenta no encontrada en ningún servidor.")
        End If
    End Sub

    Private Sub operaciones_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        CargarDatos()
    End Sub
End Class