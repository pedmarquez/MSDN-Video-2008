using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MSDNVideo.Cajero
{
    public interface IView
    {
        EstadoSesion EstadoSesion
        {
            get;
            set;
        }
    }
}
