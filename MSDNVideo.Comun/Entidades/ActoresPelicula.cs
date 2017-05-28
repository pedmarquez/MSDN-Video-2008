using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    public partial class ActoresPelicula : IDataErrorInfo
    {
        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                if (this["Papel"] == null)
                    return null;
                else
                    return "Error en el reparto";
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Papel")
                {
                    if (!ValidacionesEntidad.ValidarLongitudMaxima(Papel, 150))
                        return "El papel debe tener una longitud menor de 150 caracteres";
                }

                return null;
            }
        }

        #endregion

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
                if(value != null || _Pelicula.HasLoadedOrAssignedValue)
                    Pelicula = value;
            }
        }

        /// <summary>
        /// Recupera el actor asociado
        /// Usada para forzar la serialización
        /// </summary>
        [DataMember()]
        private Actor ActorParent
        {
            get
            {
                return Actor;
            }
            set
            {
                if (value != null || _Actor.HasLoadedOrAssignedValue)
                    Actor = value;
            }
        }

        #endregion

    }
}
