using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Comun;
using System.ComponentModel;

namespace MSDNVideo.Cajero
{
    [Serializable]
    public class EstadoSesion
    {
        private string _nifUsuario;
        private FiltroPeliculas _filtroPeliculas;
        private string _seleccionPelicula;
        private Accion _accionActual;

        public string NifUsuario
        {
            get
            {
                return _nifUsuario;
            }
            set
            {
                _nifUsuario = value;
            }
        }

        public FiltroPeliculas FiltroPeliculas
        {
            get
            {
                return _filtroPeliculas;
            }
            set
            {
                _filtroPeliculas = value;
            }
        }

        public string SeleccionPelicula
        {
            get
            {
                return _seleccionPelicula;
            }
            set
            {
                _seleccionPelicula = value;
            }
        }

        public Accion AccionActual
        {
            get
            {
                return _accionActual;
            }
            set
            {
                _accionActual = value;
            }
        }
    }
}
