using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using MSDNVideo.Cajero.MSDNVideoServices;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Globalization;

namespace MSDNVideo.Cajero
{
    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class CaratulaConverter : IValueConverter
    {
        object IValueConverter.Convert(
           object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ObtenerCaratulaPelicula((string)value);
            else
                return null;
        }

        object IValueConverter.ConvertBack(
           object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private ImageSource ObtenerCaratulaPelicula(string codBarras)
        {
            byte[] buffer;

            if (ConnectionHelper.ServiceClient != null)
            {
                buffer = ConnectionHelper.ServiceClient.Peliculas_ObtenerCaratula(codBarras, 0, 0);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(buffer);
                bmp.EndInit();

                return bmp;
            }
            else
                return null;
        }

    } 
}
