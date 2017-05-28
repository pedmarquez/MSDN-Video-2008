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
    /// Interaction logic for InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Page, IView
    {
        static readonly DependencyProperty EstadoSesionProperty;

        static InicioSesion()
        {
            InicioSesion.EstadoSesionProperty = DependencyProperty.Register(
                "EstadoSesion", typeof(EstadoSesion), typeof(InicioSesion),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal)
            );

        }

        public InicioSesion()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador.Instancia.EstadoSesion = EstadoSesion;
            if (EstadoSesion.NifUsuario != null)
            {
                txtNIF.Text = EstadoSesion.NifUsuario;
            }
            else
            {
                txtNIF.Text = "00000000T";
                txtClave.Password = "12345";
            }
        }

        public EstadoSesion EstadoSesion
        {
            get
            {
                return (EstadoSesion)base.GetValue(InicioSesion.EstadoSesionProperty);
            }
            set
            {
                base.SetValue(InicioSesion.EstadoSesionProperty, value);
            }
        }

        private void IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string error;
            error = Controlador.Instancia.IniciarSesion(txtNIF.Text, txtClave.Password);
            
            if (error != null)
            {
                lblError.Text = error;
                lblError.Visibility = Visibility.Visible;
            }
            else
            {
                Controlador.Instancia.NavegarA("MenuPrincipal.xaml");
            }
        }

    }
}
