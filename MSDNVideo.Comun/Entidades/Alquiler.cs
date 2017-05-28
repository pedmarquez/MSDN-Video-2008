using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    [KnownType(typeof(Socio))]
    public partial class Alquiler
    {

        #region Propiedades extendidas

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


        /// <summary>
        /// Recupera el socio asociado con este alquiler
        /// </summary>
        public Socio Socio
        {
            get
            {
                return Usuario as Socio;
            }
        }

        /// <summary>
        /// Calcula las horas de alquiler de la película si se devolviese ahora
        /// </summary>
        public int HorasAlquiler
        {
            get
            {
                if (FechaRecogida.HasValue)
                    return (int)(Math.Ceiling((DateTime.Now - FechaRecogida.Value).TotalHours));
                else
                    return 0;
            }
        }

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
