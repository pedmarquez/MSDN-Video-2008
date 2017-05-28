using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.AccesoDatos;
using MSDNVideo.Comun;
using System.Security.Permissions;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Operaciones de negocio sobre Changesets
    /// </summary>
    public class ChangeSetCN
    {
        #region Operaciones públicas

        /// <summary>
        /// Actualiza los cambios acumulados en un Changeset
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="changeSet">Changeset a actualizar</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void ActualizarChangeSet(DisconnectedChangeSet changeSet)
        {
            ChangeSetAD changeSetAD = new ChangeSetAD();
            changeSetAD.ActualizarChangeSet(changeSet);
        }

        #endregion

    }
}
