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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace MSDNVideo.Cajero
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IntroControl _introControl;
        private static int _numPantalla = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frameNav.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            // Creamos IntroControl
            _introControl = new IntroControl();
            _introControl.Width = double.NaN;
            _introControl.Height = double.NaN;
            mainGrid.Children.Add(_introControl);

            _introControl.IntroEnded += new IntroEndedHandler(OnIntroEnded);
            _introControl.IntroHidden += new IntroEndedHandler(OnIntroHidden);
        }

        public void Navigate(string pantalla, EstadoSesion estadoSesion)
        {
            Uri uri = new Uri(pantalla + "?" + _numPantalla, UriKind.Relative);
            _numPantalla++;

            frameNav.Navigate(uri, estadoSesion);
        }

        public void Back()
        {
            if (frameNav.NavigationService.CanGoBack)
                frameNav.GoBack();
        }

        internal void Forward()
        {
            if(frameNav.NavigationService.CanGoForward)
                frameNav.GoForward();
        }

        private void OnIntroEnded(object sender, EventArgs args)
        {
            frameNav.Visibility = Visibility.Visible;
            Fotogramas.Visibility = Visibility.Visible;
            Cabecera.Visibility = Visibility.Visible;

            Controlador.Instancia.NavegarA("InicioSesion.xaml");

            Storyboard sb = (Storyboard)Resources["FotogramaMove"];
            this.BeginStoryboard(sb);
        }

        private void OnIntroHidden(object sender, EventArgs args)
        {
            mainGrid.Children.Remove(_introControl);
            _introControl = null;
        }

        private void frameNav_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri != null && e.ExtraData != null)
            {
                ((IView)e.Content).EstadoSesion = (EstadoSesion)e.ExtraData;
            }
        }


        internal void Exit()
        {
            this.Close();
        }

        internal void GoHome()
        {
            Controlador.Instancia.NavegarA("InicioSesion.xaml");

            while (frameNav.NavigationService.CanGoBack)
                frameNav.NavigationService.RemoveBackEntry();

        }
    }
}
