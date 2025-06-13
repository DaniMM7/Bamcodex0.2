Imports System.Data.SqlClient

Public Class Historial
    ' Supón que esta variable contiene el ID de la cuenta actual
    Private cuentaIDActual As Integer = 1001 ' Cambia este valor según tu contexto
    Private Sub Historial_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        CargarMovimientos()
    End Sub
    Private Sub Historial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar tipos de transacciones en ComboBox, incluyendo opción "Todos"
        ComboBoxTipoTransaccion.Items.Clear()
        ComboBoxTipoTransaccion.Items.Add("Todos")
        ComboBoxTipoTransaccion.Items.Add("Donacion")
        ComboBoxTipoTransaccion.Items.Add("PagoServicio")
        ComboBoxTipoTransaccion.Items.Add("Transferencia")
        ComboBoxTipoTransaccion.Items.Add("Deposito")
        ComboBoxTipoTransaccion.Items.Add("Retiro")
        ComboBoxTipoTransaccion.SelectedIndex = 0 ' Seleccionar "Todos" por defecto

        ' Cargar todos los movimientos al iniciar
        CargarMovimientos()
    End Sub

    Private Sub ComboBoxTipoTransaccion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBoxTipoTransaccion.SelectionChangeCommitted
        CargarMovimientos()
    End Sub

    Private Sub CargarMovimientos()
        Dim tipoTransaccion As String = ComboBoxTipoTransaccion.SelectedItem.ToString()

        Dim cadenaConexion As String = "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;Integrated Security=True"

        Dim consulta As String
        If tipoTransaccion = "Todos" Then
            consulta = "SELECT TransaccionID, TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CuentaDestino, CajeroID " &
                       "FROM dbo.Transacciones " &
                       "WHERE CuentaOrigen = @CuentaOrigen " &
                       "ORDER BY FechaTransaccion DESC"
        Else
            consulta = "SELECT TransaccionID, TipoTransaccion, Monto, FechaTransaccion, CuentaOrigen, CuentaDestino, CajeroID " &
                       "FROM dbo.Transacciones " &
                       "WHERE TipoTransaccion = @TipoTransaccion AND CuentaOrigen = @CuentaOrigen " &
                       "ORDER BY FechaTransaccion DESC"
        End If

        Using conexion As New SqlConnection(cadenaConexion)
            Try
                conexion.Open()
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@CuentaOrigen", cuentaIDActual)
                    If tipoTransaccion <> "Todos" Then
                        comando.Parameters.AddWithValue("@TipoTransaccion", tipoTransaccion)
                    End If

                    Dim adapter As New SqlDataAdapter(comando)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    DataGridViewMovimientos.DataSource = dt

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron movimientos para la cuenta y filtro seleccionados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al consultar movimientos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ope As New operaciones()
        ope.Show()
        Me.Hide()
    End Sub
End Class