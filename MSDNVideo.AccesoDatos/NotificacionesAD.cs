using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Data.Linq;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de notificaciones
    /// </summary>
    public partial class NotificacionesAD : BaseAD
    {
        #region "Operaciones de filtrado"

        /// <summary>
        /// Recupera todas las notificaciones del sistema
        /// </summary>
        /// <param name="incluirSocio">Incluye el socio asociado a la notificación</param>
        /// <param name="incluirPelicula">Incluye la película asociada a la notificación</param>
        /// <returns></returns>
        public BindingList<Notificacion> ObtenerNotificaciones(bool incluirSocio, bool incluirPelicula)
        {
            IQueryable<Notificacion> query;
            EntidadesDataContext dc = GetDC();

            IncluirEntidadesEnDC(dc, incluirSocio, incluirPelicula);

            query = from notificacion in dc.Notificacions select notificacion;
            return QueryToBindingList(query);
        }
        #endregion

        #region "Métodos privados"

        /// <summary>
        /// Incluye las entidades indicadas en la query de LINQ
        /// </summary>
        /// <param name="dc">Contexto LINQ</param>
        /// <param name="incluirSocio">Incluir socio</param>
        /// <param name="incluirPelicula">Incluir película</param>
        private void IncluirEntidadesEnDC(EntidadesDataContext dc, bool incluirSocio, bool incluirPelicula)
        {
            DataLoadOptions loadOptions = new DataLoadOptions();

            if (incluirPelicula)
                loadOptions.LoadWith<Notificacion>(notificacion => notificacion.Pelicula);

            if (incluirSocio)
                loadOptions.LoadWith<Notificacion>(notificacion => notificacion.Usuario);

            dc.LoadOptions = loadOptions;
        }

        #endregion
    }
}
