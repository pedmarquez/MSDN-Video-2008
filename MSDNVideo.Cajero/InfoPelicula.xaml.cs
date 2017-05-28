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
    /// Interaction logic for InfoPelicula.xaml
    /// </summary>
    public partial class InfoPelicula : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        static InfoPelicula()
        {
            InfoPelicula.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(InfoPelicula),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );
        }

        public InfoPelicula()
        {
            InitializeComponent();
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(InfoPelicula.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(InfoPelicula.EstadoSesionProperty, value);
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

            if (EstadoSesion.AccionActual == Accion.Alquilar)
            {
                grpCompraAlquiler.Header = "Alquiler";
                if (pelicula.DisponibleAlquiler > 0)
                {
                    lblPrecio.Text = "0,15 € / hora";
                    lblUnidades.Text = pelicula.DisponibleAlquiler.ToString();
                }
                else
                {
                    panelInfo.Visibility = Visibility.Hidden;
                    lblSinUnidades.Visibility = Visibility.Visible;
                    btnAccion.Content = "Notificar";
                }
            }
            else
            {
                grpCompraAlquiler.Header = "Compra";
                if (pelicula.DisponibleVenta > 0)
                {
                    lblPrecio.Text = "21,00 €";
                    lblUnidades.Text = pelicula.DisponibleVenta.ToString();
                    btnAccion.Content = "Comprar";
                }
                else
                {
                    panelInfo.Visibility = Visibility.Hidden;
                    lblSinUnidades.Visibility = Visibility.Visible;
                    btnAccion.Content = "Notificar";
                }

            }

        }

        private void btnAccion_Click(object sender, RoutedEventArgs e)
        {
            Controlador.Instancia.NavegarA("ConfirmacionCompra.xaml");
        }
    }
}
