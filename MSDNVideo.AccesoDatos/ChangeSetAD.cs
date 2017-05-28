using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Reflection;
using MSDNVideo.Comun;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de changesets
    /// </summary>
    public class ChangeSetAD : BaseAD
    {
        #region "Operaciones públicas"

        /// <summary>
        /// Actualiza la base de datos con todos los cambios incluidos en un Changeset
        /// </summary>
        /// <param name="changeSet">Changeset con cambios</param>
        public void ActualizarChangeSet(DisconnectedChangeSet changeSet)
        {
            EntidadesDataContext dc = GetDC();
            int i;
            object entidad;
            ITable tabla;

            if (changeSet.Agregados != null)
            {
                for (i = 0; i < changeSet.Agregados.Count; i++)
                {
                    entidad = changeSet.Agregados[i];
                    tabla = OperacionesEntidad.GetTablaFromEntidad(dc, entidad);
                    tabla.InsertOnSubmit(entidad);
                }
            }

            if (changeSet.Modificados != null)
            {
                for (i = 0; i < changeSet.Modificados.Count; i++)
                {
                    entidad = changeSet.Modificados[i];
                    tabla = OperacionesEntidad.GetTablaFromEntidad(dc, entidad);
                    tabla.Attach(entidad, changeSet.ModificadosOriginal[i]);
                }
            }

            if (changeSet.Eliminados != null)
            {
                for (i = 0; i < changeSet.Eliminados.Count; i++)
                {
                    entidad = changeSet.Eliminados[i];
                    tabla = OperacionesEntidad.GetTablaFromEntidad(dc, entidad);
                    tabla.Attach(entidad);
                    tabla.DeleteOnSubmit(entidad);
                }
            }

            dc.SubmitChanges();
        }

        #endregion

    }
}
