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
    /// Interaction logic for ListaPeliculas.xaml
    /// </summary>
    public partial class ListaPeliculas : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        private bool _isLoading;

        static ListaPeliculas()
        {
            ListaPeliculas.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(ListaPeliculas),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );
        }

        public ListaPeliculas()
        {
            InitializeComponent();
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(ListaPeliculas.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(ListaPeliculas.EstadoSesionProperty, value);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindingList<Pelicula> peliculas;
            int numPeliculas;

            Controlador.Instancia.EstadoSesion = EstadoSesion;

            peliculas = Controlador.Instancia.ObtenerPeliculas(out numPeliculas);
            ObjectDataProvider datasource = (ObjectDataProvider)Resources["PeliculaDS"];

            _isLoading = true;
            datasource.ObjectType = null;
            datasource.ObjectInstance = peliculas;

            lstPeliculas.SelectedIndex = -1;
            _isLoading = false;

            ctrlPaginacion.NumElementos = numPeliculas;

            ctrlPaginacion.ElementoActual = EstadoSesion.FiltroPeliculas.InicioPagina;
        }

        private void OnPaginationChanged(object sender, PaginationChangedEventArgs e)
        {
            EstadoSesion.FiltroPeliculas.InicioPagina = (e.PaginaSeleccionada - 1) * EstadoSesion.FiltroPeliculas.PeliculasPagina;

            Controlador.Instancia.NavegarA("ListaPeliculas.xaml");
        }

        private void lstPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isLoading)
            {
                Pelicula pelicula;
                pelicula = (Pelicula)lstPeliculas.SelectedItem;

                EstadoSesion.SeleccionPelicula = pelicula.CodBarras;
                Controlador.Instancia.NavegarA("InfoPelicula.xaml");
            }
        }
    }
}
