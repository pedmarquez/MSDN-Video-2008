using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDNVideo.Comun
{
    public enum Clasificaciones
    {
        Apta = 0,
        NR7 = 1,
        NR13 = 2,
        NR18 = 3
    }

    public enum Generos
    {
        Romantica = 0,
        Drama = 1,
        Comedia = 2,
        Thriller = 3,
        Terror = 4,
        Accion = 5
    }

    public enum Rol
    {
        Socio = 0,
        Admin = 1
    }

    public enum CamposFiltro : int
    {
        CodBarras = 1,
        Titulo = 2,
        Novedad = 4,
        Clasificacion = 8,
        Genero = 16
    }

    public enum TipoOperacion
    {
        Alquiler,
        Venta,
        Recarga,
        Recogida,
        Devolucion
    }

    public enum EstadoPedido
    {
        Realizado,
        StockInsuficiente,
        ModalidadNoDisponible,
        SaldoInsuficiente,
        ErrorConcurrencia
    }

    public enum TipoNotificacion
    {
        Email = 0,
        SMS = 1,
        Messenger = 2
    }

    public enum SaludInforme
    {
        Positivo,
        Neutro,
        Negativo
    }
}
