using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MSDNVideo.Comun;
using MSDNVideo.AccesoDatos;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Lógica de negocio asociada a las entidades Actor
    /// </summary>
    public class ActoresCN
    {
        #region "Operaciones de mantenimiento"

        /// <summary>
        /// Obtiene todos los actores del sistema
        /// Seguridad: Público
        /// </summary>
        /// <returns>Lista de actores</returns>
        public BindingList<Actor> ObtenerActores()
        {
            ActoresAD actoresAD = new ActoresAD();

            return actoresAD.ObtenerActores();
        }

        /// <summary>
        /// Obtiene los actores por nombre
        /// Seguridad: Público
        /// </summary>
        /// <param name="nombre">Parte del nombre a buscar</param>
        /// <returns>Lista de actores</returns>
        public BindingList<Actor> ObtenerActoresPorNombre(string nombre)
        {
            ActoresAD actoresAD = new ActoresAD();

            return actoresAD.ObtenerActoresPorNombre(nombre);
        }

        #endregion
    }
}
