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

namespace MSDNVideo.Cajero
{
    /// <summary>
    /// Interaction logic for FiltrarPeliculas.xaml
    /// </summary>
    public partial class FiltrarPeliculas : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        static FiltrarPeliculas()
        {
            FiltrarPeliculas.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(FiltrarPeliculas),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );
        }

        public FiltrarPeliculas()
        {
            InitializeComponent();
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(FiltrarPeliculas.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(FiltrarPeliculas.EstadoSesionProperty, value);
            }
        }

        private void AplicarFiltro(FiltroPeliculas filtro)
        {
            EstadoSesion.FiltroPeliculas = filtro;

            Controlador.Instancia.NavegarA("ListaPeliculas.xaml");
        }

        private FiltroPeliculas CrearFiltro()
        {
            FiltroPeliculas filtro = new FiltroPeliculas();
            filtro.IncluirTotal = true;
            filtro.PeliculasPagina = 5;

            return filtro;
        }

        private void btnTodas_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();

            AplicarFiltro(filtro);
        }

        private void btnEstrenos_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Novedad = true;
            filtro.CamposFiltrado = (int)CamposFiltro.Novedad;

            AplicarFiltro(filtro);
        }

        private void btnApta_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Clasificacion = Clasificaciones.Apta;
            filtro.CamposFiltrado = (int)CamposFiltro.Clasificacion;

            AplicarFiltro(filtro);
        }

        private void btnNR7_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Clasificacion = Clasificaciones.NR7;
            filtro.CamposFiltrado = (int)CamposFiltro.Clasificacion;

            AplicarFiltro(filtro);
        }

        private void btnNR13_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Clasificacion = Clasificaciones.NR13;
            filtro.CamposFiltrado = (int)CamposFiltro.Clasificacion;

            AplicarFiltro(filtro);
        }

        private void btnNR18_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Clasificacion = Clasificaciones.NR18;
            filtro.CamposFiltrado = (int)CamposFiltro.Clasificacion;

            AplicarFiltro(filtro);
        }

        private void btnRomantica_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Genero = Generos.Romantica;
            filtro.CamposFiltrado = (int)CamposFiltro.Genero;

            AplicarFiltro(filtro);
        }

        private void btnDrama_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Genero = Generos.Drama;
            filtro.CamposFiltrado = (int)CamposFiltro.Genero;

            AplicarFiltro(filtro);
        }

        private void btnComedia_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Genero = Generos.Comedia;
            filtro.CamposFiltrado = (int)CamposFiltro.Genero;

            AplicarFiltro(filtro);
        }

        private void btnThriller_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Genero = Generos.Thriller;
            filtro.CamposFiltrado = (int)CamposFiltro.Genero;

            AplicarFiltro(filtro);
        }

        private void btnTerror_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Genero = Generos.Terror;
            filtro.CamposFiltrado = (int)CamposFiltro.Genero;

            AplicarFiltro(filtro);
        }

        private void btnAccion_Click(object sender, RoutedEventArgs e)
        {
            FiltroPeliculas filtro = CrearFiltro();
            filtro.Genero = Generos.Accion;
            filtro.CamposFiltrado = (int)CamposFiltro.Genero;

            AplicarFiltro(filtro);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador.Instancia.EstadoSesion = EstadoSesion;
        }
    }
}
