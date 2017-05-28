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
    /// Interaction logic for ConfirmacionCompra.xaml
    /// </summary>
    public partial class ConfirmacionCompra : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        static ConfirmacionCompra()
        {
            ConfirmacionCompra.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(ConfirmacionCompra),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );
        }

        public ConfirmacionCompra()
        {
            InitializeComponent();
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(ConfirmacionCompra.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(ConfirmacionCompra.EstadoSesionProperty, value);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Pelicula pelicula;
            Socio socio;

            Controlador.Instancia.EstadoSesion = EstadoSesion;

            pelicula = Controlador.Instancia.ObtenerPelicula();
            socio = Controlador.Instancia.ObtenerSocio();

            ObjectDataProvider dataSource = (ObjectDataProvider)Resources["PeliculaDS"];
            dataSource.ObjectType = null;
            dataSource.ObjectInstance = pelicula;

            lblSaldo.Text = socio.Saldo.ToString() + " €";

            if (EstadoSesion.AccionActual == Accion.Alquilar)
            {
                lblPrecio.Text = "0,15 € / hora";
                btnConfirmar.Content = "Alquilar";
            }
            else if (EstadoSesion.AccionActual == Accion.Comprar)
            {
                lblPrecio.Text = "21,00 €";
                btnConfirmar.Content = "Comprar";
            }
            else if (EstadoSesion.AccionActual == Accion.Devolver)
            {
                decimal precio = Controlador.Instancia.CalcularPrecioAlquiler();
                lblPrecio.Text = precio.ToString() + " €";
                btnConfirmar.Content = "Devolver";
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            EstadoPedido estadoPedido;


            if(EstadoSesion.AccionActual == Accion.Alquilar)
                estadoPedido = Controlador.Instancia.AlquilarPelicula();
            else if (EstadoSesion.AccionActual == Accion.Comprar)
                estadoPedido = Controlador.Instancia.ComprarPelicula();
            else // Accion.Devolver
                estadoPedido = Controlador.Instancia.DevolverPelicula();

            lblError.Visibility = Visibility.Visible;
            if (estadoPedido == EstadoPedido.SaldoInsuficiente)
                lblError.Text = "Saldo insuficiente";
            else if (estadoPedido == EstadoPedido.StockInsuficiente)
                lblError.Text = "No hay unidades disponibles";
            else if (estadoPedido == EstadoPedido.ErrorConcurrencia)
                lblError.Text = "Se produjo un error en la compra";
            else
            {
                lblError.Visibility = Visibility.Hidden;
                Controlador.Instancia.NavegarA("RecogerDevolver.xaml");
            }

        }
    }
}
