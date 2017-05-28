using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    [KnownType(typeof(Socio))]
    [KnownType(typeof(Usuario))]
    public partial class Puntuacion
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

        /// <summary>
        /// Recupera el usuario asociado
        /// Usada para forzar la serialización
        /// </summary>
        [DataMember()]
        private Usuario UsuarioParent
        {
            get
            {
                return Usuario;
            }
            set
            {
                if (value != null || _Usuario.HasLoadedOrAssignedValue)
                    Usuario = value;
            }
        }

        #endregion

    }
}
