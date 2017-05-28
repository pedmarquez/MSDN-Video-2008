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
    /// Componente de acceso a datos de alquileres
    /// </summary>
    public class AlquileresAD : BaseAD
    {

        #region "Operaciones de filtrado"

        /// <summary>
        /// Obtiene todos los alquileres pendientes de devolver
        /// </summary>
        /// <param name="incluirSocio">Incluye la entidad de socio asociada en el alquiler devuelto</param>
        /// <param name="incluirPelicula">Incluye la entidad de película asociada en el alquiler devuelto</param>
        /// <returns>Lista de alquileres</returns>
        public BindingList<Alquiler> ObtenerAlquileresSinDevolver(bool incluirSocio, bool incluirPelicula)
        {
            IQueryable<Alquiler> query;
            EntidadesDataContext dc = GetDC();

            IncluirEntidadesEnDC(dc, incluirSocio, incluirPelicula);

            query = from alquiler in dc.Alquilers where alquiler.FechaRecogida != null select alquiler;
            return QueryToBindingList(query);
        }

        /// <summary>
        /// Obtiene todos los alquileres pendientes de recoger
        /// </summary>
        /// <param name="incluirSocio">Incluye la entidad de socio asociada en el alquiler devuelto</param>
        /// <param name="incluirPelicula">Incluye la entidad de película asociada en el alquiler devuelto</param>
        /// <returns>Lista de alquileres</returns>
        public BindingList<Alquiler> ObtenerAlquileresSinRecoger(bool incluirSocio, bool incluirPelicula)
        {
            IQueryable<Alquiler> query;
            EntidadesDataContext dc = GetDC();

            IncluirEntidadesEnDC(dc, incluirSocio, incluirPelicula);

            query = from alquiler in dc.Alquilers where alquiler.FechaRecogida == null select alquiler;
            return QueryToBindingList(query);
        }

        /// <summary>
        /// Obtiene los alquileres sin recoger del socio indicado
        /// </summary>
        /// <param name="nifSocio">NIF del socio</param>
        /// <param name="peliculaCodBarras">Código de barras de la película</param>
        /// <returns>Lista de alquileres</returns>
        public Alquiler ObtenerAlquilerSinRecogerPorSocioPelicula(string nifSocio, string peliculaCodBarras)
        {
            IQueryable<Alquiler> query;
            EntidadesDataContext dc = GetDC();

            query = from alquiler in dc.Alquilers where (alquiler.FechaRecogida == null && alquiler.Usuario.NIF == nifSocio && alquiler.Pelicula.CodBarras == peliculaCodBarras) select alquiler;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Obtiene los alquileres sin devolver del socio indicado
        /// </summary>
        /// <param name="nifSocio">NIF del socio</param>
        /// <param name="peliculaCodBarras">Código de barras de la película</param>
        /// <returns>Lista de alquileres</returns>
        public Alquiler ObtenerAlquilerSinDevolverPorSocioPelicula(string nifSocio, string peliculaCodBarras)
        {
            IQueryable<Alquiler> query;
            EntidadesDataContext dc = GetDC();

            query = from alquiler in dc.Alquilers where (alquiler.FechaRecogida != null && alquiler.Usuario.NIF == nifSocio && alquiler.Pelicula.CodBarras == peliculaCodBarras) select alquiler;
            return query.FirstOrDefault();
        }

        #endregion

        #region "Operaciones de mantenimiento"

        /// <summary>
        /// Añade un alquiler
        /// </summary>
        /// <param name="alquiler">Alquiler a añadir</param>
        public void AgregarAlquiler(Alquiler alquiler)
        {
            EntidadesDataContext dc = GetDC();

            dc.Alquilers.InsertOnSubmit(alquiler);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Actualiza un alquiler
        /// </summary>
        /// <param name="alquiler">Alquiler modificado</param>
        /// <param name="original">Alquiler original</param>
        public void ActualizarAlquiler(Alquiler alquiler, Alquiler original)
        {
            EntidadesDataContext dc = GetDC();

            dc.Alquilers.Attach(alquiler, original);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Elimina un alquiler
        /// </summary>
        /// <param name="alquiler">Alquiler a eliminar</param>
        public void EliminarAlquiler(Alquiler alquiler)
        {
            EntidadesDataContext dc = GetDC();

            dc.Alquilers.Attach(alquiler);
            dc.Alquilers.DeleteOnSubmit(alquiler);
            dc.SubmitChanges();
        }

        #endregion

        #region "Métodos privados"

        private void IncluirEntidadesEnDC(EntidadesDataContext dc, bool incluirSocio, bool incluirPelicula)
        {
            DataLoadOptions loadOptions = new DataLoadOptions();

            if (incluirPelicula)
                loadOptions.LoadWith<Alquiler>(alquiler => alquiler.Pelicula);
            
            if(incluirSocio)
                loadOptions.LoadWith<Alquiler>(alquiler => alquiler.Usuario);

            dc.LoadOptions = loadOptions;
        }

        #endregion

    }
}
