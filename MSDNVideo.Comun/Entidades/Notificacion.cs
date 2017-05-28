using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace MSDNVideo.Comun
{
    [KnownType(typeof(Socio))]
    public partial class Notificacion : IDataErrorInfo
    {

        #region Propiedades extendidas

        /// <summary>
        /// Recupera el socio asociado a esta notificación
        /// </summary>
        public Socio Socio
        {
            get
            {
                return Usuario as Socio;
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


        /// <summary>
        /// Recupera la película asociada a esta notificación
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

        #region IDataErrorInfo Members

        public string Error
        {
            get 
            {
                if (this["Direccion"] == null)
                    return null;
                else
                    return "Error en socio";

            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Direccion")
                {
                    if (!ValidacionesEntidad.ValidarExiste(Direccion))
                        return "Introduzca una dirección válida";
                }

                return null;
            }

        }

        #endregion
    }
}
