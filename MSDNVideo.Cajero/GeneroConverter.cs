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
    [ValueConversion(typeof(Generos), typeof(string))]
    [ValueConversion(typeof(Generos), typeof(ImageSource))]
    public class GeneroConverter : IValueConverter
    {
        object IValueConverter.Convert(
           object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (targetType == typeof(string))
                {
                    switch ((Generos)value)
                    {
                        case Generos.Accion:
                            return "Acción";
                        case Generos.Comedia:
                            return "Comedia";
                        case Generos.Drama:
                            return "Drama";
                        case Generos.Romantica:
                            return "Romántica";
                        case Generos.Terror:
                            return "Terror";
                        case Generos.Thriller:
                            return "Thriller";                        
                        default:
                            return null;
                    }
                }
                else
                {
                    string img;

                    switch ((Generos)value)
                    {
                        case Generos.Accion:
                            img = "Images/Accion.png";
                            break;
                        case Generos.Comedia:
                            img = "Images/Comedia.png";
                            break;
                        case Generos.Drama:
                            img = "Images/Drama.png";
                            break;
                        case Generos.Romantica:
                            img = "Images/Romantica.png";
                            break;
                        case Generos.Terror:
                            img = "Images/Terror.png";
                            break;
                        case Generos.Thriller:
                            img = "Images/Thriller.png";
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
