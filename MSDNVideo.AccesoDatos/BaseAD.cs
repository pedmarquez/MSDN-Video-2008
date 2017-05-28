using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Comun;
using System.Data.Linq;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Clase base para los componentes de acceso a datos
    /// </summary>
    public class BaseAD
    {

        #region "Métodos protegidos"

        /// <summary>
        /// Crea el contexto de LINQ
        /// </summary>
        /// <returns>Contexto</returns>
        protected EntidadesDataContext GetDC()
        {
            EntidadesDataContext dc = new EntidadesDataContext();
            dc.DeferredLoadingEnabled = false;

            return dc;
        }

        /// <summary>
        /// Transforma una query de LINQ a una lista BindingList
        /// </summary>
        /// <typeparam name="T">Tipo de la entidad</typeparam>
        /// <param name="query">Query LINQ</param>
        /// <returns>Lista transformada</returns>
        protected BindingList<T> QueryToBindingList<T>(IQueryable<T> query)
        {
            BindingList<T> result = new BindingList<T>();

            foreach (T item in query)
            {
                result.Add(item);
            }
            return result;

        }

        #endregion
    }
}
