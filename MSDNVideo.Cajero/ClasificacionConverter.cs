using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using MSDNVideo.Comun;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MSDNVideo.Cajero
{
    [ValueConversion(typeof(Clasificaciones), typeof(string))]
    [ValueConversion(typeof(Clasificaciones), typeof(ImageSource))]
    public class ClasificacionConverter : IValueConverter
    {
        object IValueConverter.Convert(
           object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (targetType == typeof(string))
                {
                    switch ((Clasificaciones)value)
                    {
                        case Clasificaciones.Apta:
                            return "Apta";
                        case Clasificaciones.NR7:
                            return "NR -7";
                        case Clasificaciones.NR13:
                            return "NR -13";
                        case Clasificaciones.NR18:
                            return "NR -18";
                        default:
                            return null;
                    }
                }
                else
                {
                    string img;

                    switch ((Clasificaciones)value)
                    {
                        case Clasificaciones.Apta:
                            img = "Images/Apta.png";
                            break;
                        case Clasificaciones.NR7:
                            img = "Images/NR7.png";
                            break;
                        case Clasificaciones.NR13:
                            img = "Images/NR13.png";
                            break;
                        case Clasificaciones.NR18:
                            img = "Images/NR18.png";
                            break;
                        default:
                            return null;
                    }

                    return new BitmapImage(new Uri(img, UriKind.Relative));
                }

            }
            else
                return null;
        }

        object IValueConverter.ConvertBack(
           object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
