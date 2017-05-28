using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Comun;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de históricos
    /// </summary>
    public class HistoricosAD : BaseAD
    {
        #region "Operaciones de mantenimiento"

        /// <summary>
        /// Añade un registro de histórico
        /// </summary>
        /// <param name="historico">Histórico a añadie</param>
        public void AgregarHistorico(Historico historico)
        {
            EntidadesDataContext dc = GetDC();

            dc.Historicos.InsertOnSubmit(historico);
            dc.SubmitChanges();
        }

        #endregion
    }
}
