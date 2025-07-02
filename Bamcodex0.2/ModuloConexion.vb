Module ModuloConexion

    ' Lista pública de cadenas de conexión para los diferentes servidores
    Public Servidores As String() = {
        "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;User ID=prueba21;Password=coco",
        "Data Source=192.168.0.152;Initial Catalog=BancoMazebankone;User ID=PBANCO;Password=1234",
        "Data Source=192.168.0.232;Initial Catalog=BDREPO;User ID=pepe4;Password=1234",
        "Data Source=192.168.0.129;Initial Catalog=CajeroBueno;User ID=PBANCO;Password=1234",
        "Data Source=192.168.0.173;Initial Catalog=BancoDB1;User ID=pepe4;Password=1234",
        "Data Source=192.168.0.178;Initial Catalog=BANCO;User ID=AMVAL;Password=12345"
    }

    ' Servidor local para tablas que sólo están en local (por ejemplo Transacciones)
    Public ConexionLocal As String = "Data Source=ASUSVIVOBOOK\INSTANCIA2;Initial Catalog=bancodexxdb;User ID=prueba21;Password=coco"

End Module

