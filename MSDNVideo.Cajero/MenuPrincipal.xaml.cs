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

namespace MSDNVideo.Cajero
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        static MenuPrincipal()
        {
            MenuPrincipal.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(MenuPrincipal),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );
        }

        public MenuPrincipal()
        {
            InitializeComponent();

        }


        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(MenuPrincipal.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(MenuPrincipal.EstadoSesionProperty, value);
            }
        }

        private void btnAlquilar_Click(object sender, RoutedEventArgs e)
        {
            EstadoSesion.AccionActual = Accion.Alquilar;
            Controlador.Instancia.NavegarA("FiltrarPeliculas.xaml");
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            EstadoSesion.AccionActual = Accion.Comprar;
            Controlador.Instancia.NavegarA("FiltrarPeliculas.xaml");
        }

        private void btnRecoger_Click(object sender, RoutedEventArgs e)
        {
            EstadoSesion.AccionActual = Accion.Recoger;
            Controlador.Instancia.NavegarA("PeliculasPendientes.xaml");
        }

        private void btnDevolver_Click(object sender, RoutedEventArgs e)
        {
            EstadoSesion.AccionActual = Accion.Devolver;
            Controlador.Instancia.NavegarA("PeliculasPendientes.xaml");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador.Instancia.EstadoSesion = EstadoSesion;
        }

    }
}
