using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.AccesoDatos;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Permissions;
using System.Threading;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Operaciones de negocio sobre películas
    /// </summary>
    [DataObjectAttribute(true)]
    public class PeliculasCN
    {
        #region Operaciones de Filtrado

        /// <summary>
        /// Obtiene todas las películas del sistema
        /// Seguridad: Público
        /// </summary>
        /// <param name="incluirActores">Incluir las entidades de actores asociadas a las películas</param>
        /// <returns>Lista de películas</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public BindingList<Pelicula> ObtenerPeliculas(bool incluirActores)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerPeliculas(incluirActores);
        }

        /// <summary>
        /// Obtiene las películas que cumplen el filtro dinámico indicado
        /// Seguridad: Público
        /// </summary>
        /// <param name="filtro">Filtro dinámico</param>
        /// <param name="incluirActores">Incluir actores asociados</param>
        /// <param name="incluirPuntuaciones">Incluir puntuaciones asociadas</param>
        /// <param name="total">Número total de registros sin paginar</param>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerPeliculasPorFiltro(FiltroPeliculas filtro, bool incluirActores, bool incluirPuntuaciones, out int total)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerPeliculasPorFiltro(filtro, incluirActores, incluirPuntuaciones, out total);
        }

        /// <summary>
        /// Obtiene la película con la código de barras indicado
        /// Seguridad: Público
        /// </summary>
        /// <param name="codBarras">Código de barras</param>
        /// <param name="incluirActores">Incluir actores asociados</param>
        /// <returns>Película</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pelicula ObtenerPeliculaPorCodBarras(string codBarras, bool incluirActores, bool incluirPuntuacionMedia)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, incluirActores, incluirPuntuacionMedia);
        }

        /// <summary>
        /// Obtiene las películas pendientes de devolver del usuario dado
        /// Seguridad: Administrador
        /// </summary>
        /// <param name="nifUsuario">NIF del usuario</param>
        /// <returns>Lista de películas</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated=true, Role="Admin")]
        public BindingList<Pelicula> ObtenerPeliculasPendienteDevolver(string nifUsuario)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerPeliculasPendienteDevolver(nifUsuario);
        }

        /// <summary>
        /// Obtiene las películas pendientes de devolver del usuario actual
        /// Seguridad: Socios
        /// </summary>
        /// <param name="nifUsuario">NIF del usuario</param>
        /// <returns>Lista de películas</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public BindingList<Pelicula> ObtenerMisPeliculasPendienteDevolver()
        {
            string nifUsuario = Thread.CurrentPrincipal.Identity.Name;
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerPeliculasPendienteDevolver(nifUsuario);
        }

        /// <summary>
        /// Obtiene las películas pendientes de recoger del usuario dado
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nifUsuario">NIF del usuario</param>
        /// <returns>Lista de películas</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<Pelicula> ObtenerPeliculasPendienteRecoger(string nifUsuario)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerPeliculasPendienteRecoger(nifUsuario);
        }

        /// <summary>
        /// Obtiene las películas pendientes de recoger del usuario actual
        /// Seguridad: Socios
        /// </summary>
        /// <returns>Lista de películas</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public BindingList<Pelicula> ObtenerMisPeliculasPendienteRecoger()
        {
            string nifUsuario = Thread.CurrentPrincipal.Identity.Name;
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerPeliculasPendienteRecoger(nifUsuario);
        }

        /// <summary>
        /// Obtiene las películas más alquiladas
        /// Seguridad: Público
        /// </summary>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerTopPeliculasAlquiler()
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerTopPeliculasAlquiler();
        }

        /// <summary>
        /// Obtiene las películas más vendidas
        /// Seguridad: Público
        /// </summary>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerTopPeliculasVentas()
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerTopPeliculasVentas();
        }


        /// <summary>
        /// Obtiene las películas más valoradas
        /// Seguridad: Público
        /// </summary>
        /// <returns>Lista de películas</returns>
        public BindingList<Pelicula> ObtenerTopPeliculasPuntuacion()
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            return peliculasAD.ObtenerTopPeliculasPuntuacion();
        }

        #endregion

        #region Mantenimiento de películas

        /// <summary>
        /// Modifica la película dada
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="pelicula">Película modificada</param>
        /// <param name="original">Película original</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void ActualizarPelicula(Pelicula pelicula, Pelicula original)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            peliculasAD.ActualizarPelicula(pelicula, original);
        }

        /// <summary>
        /// Elimina la película dada
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="pelicula">Película a eliminar</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void EliminarPelicula(Pelicula pelicula)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            peliculasAD.EliminarPelicula(pelicula);
        }

        /// <summary>
        /// Añade la película dada
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="pelicula">Película a añadir</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void AgregarPelicula(Pelicula pelicula)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            peliculasAD.AgregarPelicula(pelicula);
        }

        /// <summary>
        /// Obtiene la carátula asociada a la película indicada
        /// Seguridad: Público
        /// </summary>
        /// <param name="codBarras">Código de barras de la película</param>
        /// <param name="ancho">Ancho deseado de la imagen</param>
        /// <param name="alto">Alto deseado de la imagen</param>
        /// <returns>Array de bytes con la imagen de la carátula</returns>
        public byte[] ObtenerCaratula(string codBarras, int ancho, int alto)
        {
            PeliculasAD peliculasAD = new PeliculasAD();
            byte[] buffer;
            Bitmap bmpSource, bmpDest;
            MemoryStream memStream;
            buffer = peliculasAD.ObtenerCaratula(codBarras);

            if (ancho == 0 && alto == 0)
                return buffer;

            bmpSource = new Bitmap(new MemoryStream(buffer));
            if (ancho >= bmpSource.Width || alto >= bmpSource.Height)
                return buffer;

            bmpDest = new Bitmap(ancho, alto, bmpSource.PixelFormat);
            Graphics g = Graphics.FromImage(bmpDest);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(bmpSource,0,0,bmpDest.Width, bmpDest.Height);
            g.Dispose();

            memStream = new MemoryStream();
            bmpDest.Save(memStream, ImageFormat.Jpeg);

            return memStream.ToArray();
        }

        /// <summary>
        /// Modifica la carátula de una película
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="caratula">Array de bytes con la imagen de la película</param>
        /// <param name="codBarras">Código de barras de la película</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void ModificarCaratula(byte[] caratula, string codBarras)
        {
            PeliculasAD peliculasAD = new PeliculasAD();

            peliculasAD.ModificarCaratula(caratula, codBarras);
        }

        #endregion
    }
}
