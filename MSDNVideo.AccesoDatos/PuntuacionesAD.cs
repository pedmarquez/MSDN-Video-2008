using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Comun;
using System.ComponentModel;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de puntuaciones
    /// </summary>
    public class PuntuacionesAD : BaseAD
    {
        #region "Operaciones públicas"

        /// <summary>
        /// Obtiene la puntuación media de la película dada
        /// </summary>
        /// <param name="codBarras">Código de barras de la película</param>
        /// <returns>Media de puntuación</returns>
        public decimal ObtenerPuntuacionMediaPelicula(string codBarras)
        {
            EntidadesDataContext dc;
            decimal result;

            dc = GetDC();

            result = (from puntuacion in dc.Puntuacions where puntuacion.Pelicula.CodBarras == codBarras select puntuacion.ValorPuntuacion).Average();

            return result;
        }

        #endregion
    }
}
