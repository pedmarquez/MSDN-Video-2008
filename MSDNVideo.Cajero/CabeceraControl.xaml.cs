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
    /// Interaction logic for CabeceraControl.xaml
    /// </summary>
    public partial class CabeceraControl : UserControl
    {
        public CabeceraControl()
        {
            InitializeComponent();
        }

        private void btnRetroceder_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.Back();
        }

        private void btnAvanzar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.Forward();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.GoHome();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.Exit();
        }
    }
}
