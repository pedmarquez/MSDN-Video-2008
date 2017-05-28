using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de notificaciones
    /// </summary>
    public class PeliculasAD : BaseAD
    {
        #region "Operaciones de filtrado"

        /// <summary>
        /// Obtiene todas las películas del sistema
        /// </summary>
        /// <param name="incluirActores">Incluir las entidades de actores asociadas a las películas</param>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerPeliculas(bool incluirActores)
        {
            IQueryable<Pelicula> query;
            EntidadesDataContext dc = GetDC();

            IncluirEntidadesEnDC(dc, incluirActores, false);

            query = from pelicula in dc.Peliculas select pelicula;
            return QueryToBindingList(query);
        }

        /// <summary>
        /// Obtiene las películas que cumplen el filtro dinámico indicado
        /// </summary>
        /// <param name="filtro">Filtro dinámico</param>
        /// <param name="incluirActores">Incluir actores asociados</param>
        /// <param name="incluirPuntuaciones">Incluir puntuaciones asociadas</param>
        /// <param name="total">Número total de registros sin paginar</param>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerPeliculasPorFiltro(FiltroPeliculas filtro, bool incluirActores, bool incluirPuntuaciones, out int total)
        {
            IQueryable<Pelicula> query;
            EntidadesDataContext dc = GetDC();

            IncluirEntidadesEnDC(dc, incluirActores, incluirPuntuaciones);

            // Construcción del filtro dinámico
            string queryString = "";
            List<object> parameters = new List<object>();
            int numParam = 0;

            if ((filtro.CamposFiltrado & (int)CamposFiltro.CodBarras) == (int)CamposFiltro.CodBarras)
            {
                queryString += " and CodBarras = @" + numParam.ToString();
                parameters.Add(filtro.CodBarras);
                numParam++;
            }
            if ((filtro.CamposFiltrado & (int)CamposFiltro.Titulo) == (int)CamposFiltro.Titulo)
            {
                queryString += " and Titulo L @" + numParam.ToString();
                parameters.Add("%" + filtro.Titulo + "%");
                numParam++;
            }
            if ((filtro.CamposFiltrado & (int)CamposFiltro.Clasificacion) == (int)CamposFiltro.Clasificacion)
            {
                queryString += " and Clasificacion = @" + numParam.ToString();
                parameters.Add(filtro.Clasificacion);
                numParam++;
            }
            if ((filtro.CamposFiltrado & (int)CamposFiltro.Genero) == (int)CamposFiltro.Genero)
            {
                queryString += " and Genero = @" + numParam.ToString();
                parameters.Add(filtro.Genero);
                numParam++;
            }
            if ((filtro.CamposFiltrado & (int)CamposFiltro.Novedad) == (int)CamposFiltro.Novedad)
            {
                queryString += " and Novedad = @" + numParam.ToString();
                parameters.Add(filtro.Novedad);
                numParam++;
            }
            if (numParam == 0)
            {
                query = from pelicula in dc.Peliculas select pelicula;
            }
            else
            {
                queryString = queryString.Substring(5);
                query = dc.Peliculas.Where(queryString, parameters.ToArray());
            }

            if (filtro.IncluirTotal)
                total = query.Count();
            else
                total = 0;

            // Paginación
            if(filtro.InicioPagina != 0)
                query = query.Skip<Pelicula>(filtro.InicioPagina);
            if (filtro.PeliculasPagina != 0)
                query = query.Take<Pelicula>(filtro.PeliculasPagina);

            return QueryToBindingList(query);
        }

        /// <summary>
        /// Obtiene la película con la código de barras indicado
        /// </summary>
        /// <param name="codBarras">Código de barras</param>
        /// <param name="incluirActores">Incluir actores asociados</param>
        /// <returns>Película</returns>
        public Pelicula ObtenerPeliculaPorCodBarras(string codBarras, bool incluirActores, bool incluirPuntuacionMedia)
        {
            Pelicula result;
            EntidadesDataContext dc = GetDC();

            IncluirEntidadesEnDC(dc, incluirActores, false);

            result = dc.Peliculas.Where(pelicula => pelicula.CodBarras == codBarras).SingleOrDefault();

            if (incluirPuntuacionMedia)
            {
                result.PuntuacionMedia = (from puntuacion in dc.Puntuacions where puntuacion.PeliculaID == result.PeliculaID select puntuacion.ValorPuntuacion).Average();
            }

            return result;
        }

        /// <summary>
        /// Obtiene las películas pendientes de devolver del usuario dado
        /// </summary>
        /// <param name="nifUsuario">NIF del usuario</param>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerPeliculasPendienteDevolver(string nifUsuario)
        {
            IQueryable<Pelicula> query;
            EntidadesDataContext dc = GetDC();

            query = from pelicula in dc.Peliculas
                    from alquiler in pelicula.Alquileres
                    where (alquiler.Usuario.NIF == nifUsuario
                    && alquiler.FechaRecogida != null)
                    select pelicula;

            return QueryToBindingList(query);
        }

        /// <summary>
        /// Obtiene las películas pendientes de recoger del usuario dado
        /// </summary>
        /// <param name="nifUsuario">NIF del usuario</param>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerPeliculasPendienteRecoger(string nifUsuario)
        {
            IQueryable<Pelicula> query;
            EntidadesDataContext dc = GetDC();

            query = from pelicula in dc.Peliculas
                    from alquiler in pelicula.Alquileres
                    where (alquiler.Usuario.NIF == nifUsuario
                    && alquiler.FechaRecogida == null)
                    select pelicula;

            return QueryToBindingList(query);
        }

        /// <summary>
        /// Obtiene las películas más alquiladas
        /// </summary>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerTopPeliculasAlquiler()
        {
            EntidadesDataContext dc = GetDC();

            var query1 = (from historico in dc.Historicos
                     where historico.TipoOperacion == TipoOperacion.Alquiler
                     group historico by historico.PeliculaID into g
                     orderby g.Count() descending
                     select new { PeliculaID = g.Key });

            var query2 = (from pelicula in dc.Peliculas
                         join q in query1 on pelicula.PeliculaID equals q.PeliculaID
                         select pelicula).Take<Pelicula>(10);

            return QueryToBindingList(query2);
        }

        /// <summary>
        /// Obtiene las películas más vendidas
        /// </summary>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerTopPeliculasVentas()
        {
            EntidadesDataContext dc = GetDC();

            var query1 = (from historico in dc.Historicos
                          where historico.TipoOperacion == TipoOperacion.Venta
                          group historico by historico.PeliculaID into g
                          orderby g.Count() descending
                          select new { PeliculaID = g.Key });

            var query2 = (from pelicula in dc.Peliculas
                          join q in query1 on pelicula.PeliculaID equals q.PeliculaID
                          select pelicula).Take<Pelicula>(10);

            return QueryToBindingList(query2);
        }


        /// <summary>
        /// Obtiene las películas más valoradas
        /// </summary>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerTopPeliculasPuntuacion()
        {
            EntidadesDataContext dc = GetDC();

            var query1 = (from puntuacion in dc.Puntuacions
                          group puntuacion by puntuacion.PeliculaID into g
                          orderby g.Average(puntuacion => puntuacion.ValorPuntuacion) descending
                          select new { PeliculaID = g.Key });

            var query2 = (from pelicula in dc.Peliculas
                          join q in query1 on pelicula.PeliculaID equals q.PeliculaID
                          select pelicula).Take<Pelicula>(10);

            return QueryToBindingList(query2);
        }

        #endregion

        #region "Operaciones de mantenimiento"

        /// <summary>
        /// Modifica la película dada
        /// </summary>
        /// <param name="pelicula">Película modificada</param>
        /// <param name="original">Película original</param>
        public void ActualizarPelicula(Pelicula pelicula, Pelicula original)
        {
            EntidadesDataContext dc = GetDC();

            dc.Peliculas.Attach(pelicula, original);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Elimina la película dada
        /// </summary>
        /// <param name="pelicula">Película a eliminar</param>
        public void EliminarPelicula(Pelicula pelicula)
        {
            EntidadesDataContext dc = GetDC();

            dc.Peliculas.Attach(pelicula);
            dc.Peliculas.DeleteOnSubmit(pelicula);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Añade la película dada
        /// </summary>
        /// <param name="pelicula">Película a añadir</param>
        public void AgregarPelicula(Pelicula pelicula)
        {
            EntidadesDataContext dc = GetDC();

            dc.Peliculas.InsertOnSubmit(pelicula);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Obtiene la carátula asociada a la película indicada
        /// </summary>
        /// <param name="codBarras">Código de barras de la película</param>
        /// <returns>Array de bytes con la imagen de la carátula</returns>
        public byte[] ObtenerCaratula(string codBarras)
        {
            EntidadesDataContext dc = GetDC();

            using (SqlConnection cnn = (SqlConnection)dc.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtenerCaratula", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codBarras", codBarras);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader["Caratula"] != DBNull.Value)
                    return (byte[])reader["Caratula"];
                else
                    return null;
            }
        }

        /// <summary>
        /// Modifica la carátula de una película
        /// </summary>
        /// <param name="caratula">Array de bytes con la imagen de la película</param>
        /// <param name="codBarras">Código de barras de la película</param>
        public void ModificarCaratula(byte[] caratula, string codBarras)
        {
            EntidadesDataContext dc = GetDC();

            using (SqlConnection cnn = (SqlConnection)dc.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModificarCaratula", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("caratula", caratula);
                cmd.Parameters.AddWithValue("codBarras", codBarras);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region "Métodos internos"

        /// <summary>
        /// Incluye las entidades dadas en la query de LINQ
        /// </summary>
        /// <param name="dc">Contexto LINQ</param>
        /// <param name="incluirActores">Incluir actores asociados</param>
        /// <param name="incluirPuntuaciones">Incluir puntuaciones asociadas</param>
        private void IncluirEntidadesEnDC(EntidadesDataContext dc, bool incluirActores, bool incluirPuntuaciones)
        {
            DataLoadOptions loadOptions = new DataLoadOptions();

            if (incluirActores)
            {
                loadOptions.LoadWith<Pelicula>(pelicula => pelicula.ActoresPeliculas);
                loadOptions.LoadWith<ActoresPelicula>(actoresPelicula => actoresPelicula.Actor);
            }

            if (incluirPuntuaciones)
            {
                loadOptions.LoadWith<Pelicula>(pelicula => pelicula.Puntuaciones);
                loadOptions.LoadWith<Puntuacion>(puntuacion => puntuacion.Usuario);
            }

            dc.LoadOptions = loadOptions;
        }

        #endregion
    }
}
