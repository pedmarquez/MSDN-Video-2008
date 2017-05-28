using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MSDNVideo.Comun;
using System.ComponentModel;

namespace MSDNVideo.Cajero
{
    /// <summary>
    /// Interaction logic for PeliculasPendientes.xaml
    /// </summary>
    public partial class PeliculasPendientes : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        private bool _isLoading;

        static PeliculasPendientes()
        {
            PeliculasPendientes.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(PeliculasPendientes),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );
        }

        public PeliculasPendientes()
        {
            InitializeComponent();
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(PeliculasPendientes.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(PeliculasPendientes.EstadoSesionProperty, value);
            }
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindingList<Pelicula> peliculas;

            Controlador.Instancia.EstadoSesion = EstadoSesion;

            if (EstadoSesion.AccionActual == Accion.Devolver)
            {
                peliculas = Controlador.Instancia.ObtenerPeliculasPendientesDevolver();
            }
            else
            {
                peliculas = Controlador.Instancia.ObtenerPeliculasPendientesRecoger();
                grpPanel.Header = "Reservas pendientes de recogida";
                lblSinResultados.Text = "No existen reservas pendientes de recogida";
            }
            ObjectDataProvider datasource = (ObjectDataProvider)Resources["PeliculaDS"];

            _isLoading = true;
            datasource.ObjectType = null;
            datasource.ObjectInstance = peliculas;

            lstPeliculas.SelectedIndex = -1;
            _isLoading = false;

            if (peliculas.Count == 0)
                pnlSinResultados.Visibility = Visibility.Visible;
        }

        private void lstPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isLoading)
            {
                Pelicula pelicula;
                pelicula = (Pelicula)lstPeliculas.SelectedItem;

                EstadoSesion.SeleccionPelicula = pelicula.CodBarras;

                if (EstadoSesion.AccionActual == Accion.Devolver)
                    Controlador.Instancia.NavegarA("ConfirmacionCompra.xaml");
                else
                {
                    Controlador.Instancia.RecogerPelicula();
                    Controlador.Instancia.NavegarA("RecogerDevolver.xaml");
                }
            }
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Controlador.Instancia.NavegarA("Menuprincipal.xaml");
        }
    }
}
