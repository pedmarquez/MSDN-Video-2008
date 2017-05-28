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
    /// Interaction logic for RecogerDevolver.xaml
    /// </summary>
    public partial class RecogerDevolver : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        static RecogerDevolver()
        {
            RecogerDevolver.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(RecogerDevolver),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );
        }

        public RecogerDevolver()
        {
            InitializeComponent();
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(RecogerDevolver.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(RecogerDevolver.EstadoSesionProperty, value);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Pelicula pelicula;

            Controlador.Instancia.EstadoSesion = EstadoSesion;

            pelicula = Controlador.Instancia.ObtenerPelicula();

            ObjectDataProvider dataSource = (ObjectDataProvider)Resources["PeliculaDS"];
            dataSource.ObjectType = null;
            dataSource.ObjectInstance = pelicula;

            if (EstadoSesion.AccionActual == Accion.Devolver)
            {
                lblMensaje.Text = "Introduzca la película en el dispensador";
                grpPanel.Header = "Devolver película";
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Controlador.Instancia.NavegarA("MenuPrincipal.xaml");
        }
    }
}
