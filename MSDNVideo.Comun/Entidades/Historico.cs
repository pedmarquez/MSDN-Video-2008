using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    public partial class Historico
    {
        #region Propiedades extendidas

        /// <summary>
        /// Recupera la película asociada
        /// Usada para forzar la serialización
        /// </summary>
        [DataMember()]
        private Pelicula PeliculaParent
        {
            get
            {
                return Pelicula;
            }
            set
            {
                if (value != null || _Pelicula.HasLoadedOrAssignedValue)
                    Pelicula = value;
            }
        }

        #endregion
    }
}
