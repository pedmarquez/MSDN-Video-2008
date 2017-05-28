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
    /// Interaction logic for PuntuacionControl.xaml
    /// </summary>
    public partial class PuntuacionControl : UserControl
    {
        static readonly DependencyProperty ValorProperty;

        static PuntuacionControl()
        {
            PuntuacionControl.ValorProperty = DependencyProperty.Register(
                "Valor", typeof(decimal), typeof(PuntuacionControl));
        }

        public PuntuacionControl()
        {
            InitializeComponent();
        }

        public decimal Valor
        {
            get
            {
                return (decimal)base.GetValue(PuntuacionControl.ValorProperty); ;
            }
            set
            {
                base.SetValue(PuntuacionControl.ValorProperty, value);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            mainPanel.Width = (Width * (double)Valor) / 10;
        }
    }
}
