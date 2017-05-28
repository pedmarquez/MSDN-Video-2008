using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDNVideo.Tienda
{
    public delegate void MostrarInfoPaginacionHandler(int primerRegistro, int registrosPagina, int totalRegistros);

    enum ComandosPantalla
    {
        Guardar = 1,
        Nuevo = 2,
        Eliminar = 4,
        Refrescar = 8,
        Buscar = 16,
        ConfirmarCierre = 32,
        Paginacion = 64
    }

    interface IPantalla
    {
        int ComandosSoportados { get; }

        void Guardar();

        void Nuevo();

        void Eliminar();

        void Refrescar();

        void Buscar();

        bool ConfirmarCierre();

        void Paginar(int primerRegistro);

        event MostrarInfoPaginacionHandler MostrarInfoPaginacion;
    }
}
