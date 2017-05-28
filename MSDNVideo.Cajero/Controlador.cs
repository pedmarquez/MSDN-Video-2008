using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Cajero.MSDNVideoServices;
using MSDNVideo.Comun;
using System.ComponentModel;

namespace MSDNVideo.Cajero
{
    public enum Accion
    {
        Alquilar,
        Comprar,
        Recoger,
        Devolver
    }

    public class Controlador
    {
        private EstadoSesion _estadoSesion;

        private static Controlador _instancia;

        static Controlador()
        {
            _instancia = new Controlador();
            _instancia._estadoSesion = new EstadoSesion();
        }

        public static Controlador Instancia
        {
            get
            {
                return _instancia;
            }
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return _estadoSesion;
            }
            set
            {
                _estadoSesion = value;
            }
        }

        public void NavegarA(string pantalla)
        {
            MainWindow mainWindow;
            mainWindow = (MainWindow)App.Current.MainWindow;

            mainWindow.Navigate(pantalla, EstadoSesion);
        }

        public string IniciarSesion(string nif, string clave)
        {
            string errorMessage;

            if (!ConnectionHelper.SetConnectionData(nif, clave, null, out errorMessage))
            {
                return errorMessage;
            }


            EstadoSesion.NifUsuario = nif;

            return null;
        }

        public BindingList<Pelicula> ObtenerPeliculas(out int numPeliculas)
        {
            return ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculasPorFiltro(out numPeliculas, EstadoSesion.FiltroPeliculas, false, false);
        }

        public Pelicula ObtenerPelicula()
        {
            return ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculaPorCodBarras(EstadoSesion.SeleccionPelicula, true, true);
        }

        public EstadoPedido AlquilarPelicula()
        {
            return ConnectionHelper.ServiceClient.AlquilarMiPeliculaYRecoger(EstadoSesion.SeleccionPelicula);
        }

        public EstadoPedido ComprarPelicula()
        {
            return ConnectionHelper.ServiceClient.ComprarMiPelicula(EstadoSesion.SeleccionPelicula);
        }

        public void RecogerPelicula()
        {
            ConnectionHelper.ServiceClient.RecogerMiPelicula(EstadoSesion.SeleccionPelicula);
        }

        public EstadoPedido DevolverPelicula()
        {
            Historico historico;

            return ConnectionHelper.ServiceClient.DevolverMiPelicula(out historico, EstadoSesion.SeleccionPelicula);
        }

        public Socio ObtenerSocio()
        {
            return (Socio)ConnectionHelper.ServiceClient.Usuarios_ObtenerMiUsuario();
        }

        public decimal CalcularPrecioAlquiler()
        {
            return ConnectionHelper.ServiceClient.CalcularMiPrecioAlquiler(EstadoSesion.SeleccionPelicula);
        }

        internal BindingList<Pelicula> ObtenerPeliculasPendientesDevolver()
        {
            return ConnectionHelper.ServiceClient.Peliculas_ObtenerMisPeliculasPendienteDevolver();
        }

        internal BindingList<Pelicula> ObtenerPeliculasPendientesRecoger()
        {
            return ConnectionHelper.ServiceClient.Peliculas_ObtenerMisPeliculasPendienteRecoger();
        }

    }
}
