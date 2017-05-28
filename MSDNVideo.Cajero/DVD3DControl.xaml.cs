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
    /// Interaction logic for DVD3DControl.xaml
    /// </summary>
    public partial class DVD3DControl : UserControl
    {
        static readonly DependencyProperty ImagenCaratulaProperty;

        static DVD3DControl()
        {
            DVD3DControl.ImagenCaratulaProperty = DependencyProperty.Register(
                "ImagenCaratula", typeof(ImageSource), typeof(DVD3DControl));
        }

        public DVD3DControl()
        {
            InitializeComponent();

        }

        public ImageSource ImagenCaratula
        {
            get
            {
                return (ImageSource)base.GetValue(DVD3DControl.ImagenCaratulaProperty); ;
            }
            set
            {
                base.SetValue(DVD3DControl.ImagenCaratulaProperty, value);
            }
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BrushFront.ImageSource = ImagenCaratula;
        }
    }
}
