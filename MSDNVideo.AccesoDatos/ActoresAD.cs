using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Data.Linq.SqlClient;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de actores
    /// </summary>
    public class ActoresAD : BaseAD
    {
        #region "Operaciones de filtrado"

        /// <summary>
        /// Obtiene todos los actores del sistema
        /// </summary>
        /// <returns>Lista de actores</returns>
        public BindingList<Actor> ObtenerActores()
        {
            IQueryable<Actor> query;
            EntidadesDataContext dc = GetDC();

            query = from actor in dc.Actors select actor;
            return QueryToBindingList<Actor>(query);
        }

        /// <summary>
        /// Realiza una búsqueda por el nombre dado
        /// </summary>
        /// <param name="nombre">Parte del nombre a buscar</param>
        /// <returns>Lista de actores</returns>
        public BindingList<Actor> ObtenerActoresPorNombre(string nombre)
        {
            IQueryable<Actor> query;
            EntidadesDataContext dc = GetDC();

            query = from actor in dc.Actors where SqlMethods.Like(actor.Nombre, "%" + nombre + "%") select actor;
            return QueryToBindingList(query);

        }

        #endregion

        #region "Operaciones de mantenimiento"

        /// <summary>
        /// Modifica el actor dado
        /// </summary>
        /// <param name="actor">Actor modificado</param>
        /// <param name="original">Actor original</param>
        public void ActualizarActor(Actor actor, Actor original)
        {
            EntidadesDataContext dc = GetDC();

            dc.Actors.Attach(actor, original);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Elimina el actor dado
        /// </summary>
        /// <param name="actor">Actor a eliminar</param>
        public void EliminarActor(Actor actor)
        {
            EntidadesDataContext dc = GetDC();

            dc.Actors.Attach(actor);
            dc.Actors.DeleteOnSubmit(actor);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Añade el actor dado
        /// </summary>
        /// <param name="actor">Actor a añadir</param>
        public void AgregarActor(Actor actor)
        {
            EntidadesDataContext dc = GetDC();

            dc.Actors.InsertOnSubmit(actor);
            dc.SubmitChanges();
        }

        #endregion
    }
}
