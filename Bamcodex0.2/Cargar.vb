Imports System.Data.SqlClient
Module Cargar
    Public conexion_general As SqlConnection

    Public base As String
    Public Sub conectar()
        conexion_general = New SqlConnection
        conexion_general.ConnectionString = ("server=DESKTOP-9S367KS\INSTANCIA; database=Bancodexxdb; integrated security=true")
        conexion_general.Open()
    End Sub
End Module
