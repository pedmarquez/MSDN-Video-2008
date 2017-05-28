using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MSDNVideo.Comun;
using MSDNVideo.AccesoDatos;
using System.Security.Permissions;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Operaciones de negocio sobre notificaciones
    /// </summary>
    public class NotificacionesCN
    {
        #region Operaciones públicas

        /// <summary>
        /// Obtiene todas las notificaciones del sistema
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="incluirSocio">Incluye la entidad socio en el resultado</param>
        /// <param name="incluirPelicula">Incluye la entidad película en el resultado</param>
        /// <returns>Lista de notificaciones</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<Notificacion> ObtenerNotificaciones(bool incluirSocio, bool incluirPelicula)
        {
            NotificacionesAD notificacionesAD = new NotificacionesAD();

            return notificacionesAD.ObtenerNotificaciones(incluirSocio, incluirPelicula);
        }

        #endregion
    }
}
