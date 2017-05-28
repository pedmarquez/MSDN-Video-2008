using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MSDNVideo.Comun;
using MSDNVideo.AccesoDatos;
using System.Data.Linq;
using System.ComponentModel;
using System.Security.Permissions;
using System.Threading;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Lógica de negocio asociada a alquileres
    /// </summary>
    public class AlquileresCN
    {
        #region Campos

        private const int       _numIntentosConcurrencia = 3;
        private const decimal   _precioHora = .15M;
        private const decimal   _minSaldoParaAlquilar = .15M;

        #endregion

        #region "Alquilar película"

        /// <summary>
        /// Alquila una película por el socio indicado
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nifSocio">NIF del socio</param>
        /// <param name="peliculaCodBarras">Código de barras de la película</param>
        /// <returns>Resultado del alquiler</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public EstadoPedido AlquilarPelicula(string nifSocio, string peliculaCodBarras)
        {
            return AlquilarPeliculaInternal(nifSocio, peliculaCodBarras);
        }

        /// <summary>
        /// Alquila una película por el socio actual
        /// Seguridad: Socios
        /// </summary>
        /// <param name="peliculaCodBarras">Código de barras de la película</param>
        /// <returns>Resultado del alquiler</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public EstadoPedido AlquilarMiPelicula(string peliculaCodBarras)
        {
            string nifSocio = Thread.CurrentPrincipal.Identity.Name;

            return AlquilarPeliculaInternal(nifSocio, peliculaCodBarras);
        }

        private EstadoPedido AlquilarPeliculaInternal(string nifSocio, string peliculaCodBarras)
        {
            int intento = 0;
            EstadoPedido estadoPedido = EstadoPedido.ErrorConcurrencia;

            while (intento < _numIntentosConcurrencia && estadoPedido == EstadoPedido.ErrorConcurrencia)
            {
                estadoPedido = AlquilarPeliculaIntento(nifSocio, peliculaCodBarras);
                intento += 1;
            }

            return estadoPedido;
        }

        private EstadoPedido AlquilarPeliculaIntento(string nifSocio, string peliculaCodBarras)
        {
            Socio socio, socioOriginal;
            Pelicula pelicula, peliculaOriginal;
            Historico historico;
            Alquiler alquiler;

            UsuariosAD usuariosAD = new UsuariosAD();
            PeliculasAD peliculasAD = new PeliculasAD();
            HistoricosAD historicosAD = new HistoricosAD();
            AlquileresAD alquileresAD = new AlquileresAD();

            // Recuperamos película y usuario
            pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(peliculaCodBarras, false, false);
            socio = usuariosAD.ObtenerSocioPorNIF(nifSocio);

            if (pelicula == null || socio == null)
                throw new ArgumentException();

            peliculaOriginal = (Pelicula)OperacionesEntidad.CreateDataCopy(pelicula, false);
            socioOriginal = (Socio)OperacionesEntidad.CreateDataCopy(socio, false);

            using (TransactionScope tx = new TransactionScope())
            {
                // Comprobamos stock
                if (pelicula.DisponibleAlquiler == 0)
                {
                    if (pelicula.UnidadesVentaAlquiler + pelicula.UnidadesAlquiler == 0)
                        return EstadoPedido.ModalidadNoDisponible;
                    else
                        return EstadoPedido.StockInsuficiente;
                }

                // Comprobamos saldo
                if (socio.Saldo < _minSaldoParaAlquilar)
                    return EstadoPedido.SaldoInsuficiente;

                // Actualizamos stock
                pelicula.UnidadesAlquiladas++;

                try
                {
                    peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);
                }
                catch (ChangeConflictException)
                {
                    return EstadoPedido.ErrorConcurrencia;
                }

                // Creamos alquiler
                alquiler = new Alquiler();
                alquiler.SocioID = socio.UsuarioID;
                alquiler.PeliculaID = pelicula.PeliculaID;
                alquiler.FechaAlquiler = DateTime.Now;
                alquileresAD.AgregarAlquiler(alquiler);

                // Almacenamos en histórico
                historico = new Historico();
                historico.SocioID = socio.UsuarioID;
                historico.PeliculaID = pelicula.PeliculaID;
                historico.TipoOperacion = TipoOperacion.Alquiler;
                historico.Fecha = alquiler.FechaAlquiler;

                historicosAD.AgregarHistorico(historico);

                tx.Complete();
            }

            return EstadoPedido.Realizado;
        }


        #endregion

        #region "Recoger película"

        /// <summary>
        /// Recoge una película reservada previamente
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nifSocio">NIF del socio que recoge la película</param>
        /// <param name="peliculaCodBarras">Película a recoger</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void RecogerPelicula(string nifSocio, string peliculaCodBarras)
        {
            RecogerPeliculaInternal(nifSocio, peliculaCodBarras);
        }

        /// <summary>
        /// Recoge una película reservada previamente por el usuario actual
        /// Seguridad: Socios
        /// </summary>
        /// <param name="peliculaCodBarras">Película a recoger</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public void RecogerMiPelicula(string peliculaCodBarras)
        {
            string nifSocio = Thread.CurrentPrincipal.Identity.Name;

            RecogerPeliculaInternal(nifSocio, peliculaCodBarras);
        }

        private void RecogerPeliculaInternal(string nifSocio, string peliculaCodBarras)
        {
            Alquiler alquiler, alquilerOriginal;
            Historico historico;
            AlquileresAD alquileresAD = new AlquileresAD();
            HistoricosAD historicosAD = new HistoricosAD();

            using(TransactionScope tx = new TransactionScope())
            {
                // Buscamos alquiler pendiente de recoger
                alquiler = alquileresAD.ObtenerAlquilerSinRecogerPorSocioPelicula(nifSocio, peliculaCodBarras);
                if(alquiler == null)
                    throw new ArgumentException();

                // Actualización estado alquiler
                alquilerOriginal = (Alquiler)OperacionesEntidad.CreateDataCopy(alquiler, false);
                alquiler.FechaRecogida = DateTime.Now;
                alquileresAD.ActualizarAlquiler(alquiler, alquilerOriginal);

                // Almacenamos en históricos
                historico = new Historico();
                historico.PeliculaID = alquiler.PeliculaID;
                historico.SocioID = alquiler.SocioID;
                historico.Fecha = alquiler.FechaAlquiler;
                historico.FechaRecogida = alquiler.FechaRecogida;
                historico.TipoOperacion = TipoOperacion.Recogida;
                historicosAD.AgregarHistorico(historico);

                tx.Complete();
            }
        }

        #endregion

        #region "Alquilar y recoger"

        /// <summary>
        /// Alquila una película y la recoge inmediatamente
        /// Seguridad: Adminustradores
        /// </summary>
        /// <param name="nifSocio">NIF del socio</param>
        /// <param name="peliculaCodBarras">Código de barras de la película</param>
        /// <returns>Resultado</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public EstadoPedido AlquilarPeliculaYRecoger(string nifSocio, string peliculaCodBarras)
        {
            return AlquilarPeliculaYRecogerInternal(nifSocio, peliculaCodBarras);
        }

        /// <summary>
        /// Alquila una película y la recoge inmediatamente por el usuario actual
        /// Seguridad: Socios
        /// </summary>
        /// <param name="peliculaCodBarras">Código de barras de la película</param>
        /// <returns>Resultado</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public EstadoPedido AlquilarMiPeliculaYRecoger(string peliculaCodBarras)
        {
            string nifSocio = Thread.CurrentPrincipal.Identity.Name;

            return AlquilarPeliculaYRecogerInternal(nifSocio, peliculaCodBarras);
        }

        private EstadoPedido AlquilarPeliculaYRecogerInternal(string nifSocio, string peliculaCodBarras)
        {
            EstadoPedido estadoPedido;

            using (TransactionScope tx = new TransactionScope())
            {
                estadoPedido = AlquilarPeliculaInternal(nifSocio, peliculaCodBarras);
                RecogerPeliculaInternal(nifSocio, peliculaCodBarras);

                tx.Complete();
            }

            return estadoPedido;
        }

        #endregion

        #region "Devolver película"

        /// <summary>
        /// Devuelve una película alquilada por un socio
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nifSocio">NIF del socio</param>
        /// <param name="peliculaCodBarras">Película a devolver</param>
        /// <param name="historico">Datos de la operación</param>
        /// <returns>Resultado</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public EstadoPedido DevolverPelicula(string nifSocio, string peliculaCodBarras, out Historico historico)
        {
            int intento = 0;
            EstadoPedido estadoPedido = EstadoPedido.ErrorConcurrencia;
            
            historico = null;
            while (intento < _numIntentosConcurrencia && estadoPedido == EstadoPedido.ErrorConcurrencia)
            {
                estadoPedido = DevolverPeliculaInternal(nifSocio, peliculaCodBarras, out historico);
                intento++;
            }

            return estadoPedido;
        }

        /// <summary>
        /// Devuelve una película alquilada por el socio actual
        /// Seguridad: Socios
        /// </summary>
        /// <param name="peliculaCodBarras">Película a devolver</param>
        /// <param name="historico">Datos de la operación</param>
        /// <returns>Resultado</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public EstadoPedido DevolverMiPelicula(string peliculaCodBarras, out Historico historico)
        {
            string nifSocio = Thread.CurrentPrincipal.Identity.Name;
            int intento = 0;
            EstadoPedido estadoPedido = EstadoPedido.ErrorConcurrencia;

            historico = null;
            while (intento < _numIntentosConcurrencia && estadoPedido == EstadoPedido.ErrorConcurrencia)
            {
                estadoPedido = DevolverPeliculaInternal(nifSocio, peliculaCodBarras, out historico);
                intento++;
            }

            return estadoPedido;
        }

        /// <summary>
        /// Calcula el precio de un alquiler
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nifSocio">NIF del socio</param>
        /// <param name="peliculaCodBarras">Película alquilada</param>
        /// <returns>Valor en euros</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public decimal CalcularPrecioAlquiler(string nifSocio, string peliculaCodBarras)
        {
            return CalcularPrecioAlquilerInternal(nifSocio, peliculaCodBarras);
        }

        /// <summary>
        /// Calcula el precio de un alquiler del usuario actual
        /// Seguridad: Socios
        /// </summary>
        /// <param name="peliculaCodBarras">Película alquilada</param>
        /// <returns>Valor en euros</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public decimal CalcularMiPrecioAlquiler(string peliculaCodBarras)
        {
            string nifSocio = Thread.CurrentPrincipal.Identity.Name;

            return CalcularPrecioAlquilerInternal(nifSocio, peliculaCodBarras);
        }

        private decimal CalcularPrecioAlquilerInternal(string nifSocio, string peliculaCodBarras)
        {
            Alquiler alquiler;
            AlquileresAD alquileresAD = new AlquileresAD();

            alquiler = alquileresAD.ObtenerAlquilerSinDevolverPorSocioPelicula(nifSocio, peliculaCodBarras);
            if (alquiler == null)
                throw new ArgumentException();

            return CalcularPrecio(alquiler.FechaAlquiler, alquiler.FechaRecogida.Value, DateTime.Now);
        }

        private EstadoPedido DevolverPeliculaInternal(string nifSocio, string peliculaCodBarras, out Historico historico)
        {
            Alquiler alquiler;
            Pelicula pelicula, peliculaOriginal;
            Socio socio, socioOriginal;
            AlquileresAD alquileresAD = new AlquileresAD();
            HistoricosAD historicosAD = new HistoricosAD();
            PeliculasAD peliculasAD = new PeliculasAD();
            UsuariosAD usuariosAD = new UsuariosAD();

            historico = null;
            using(TransactionScope tx = new TransactionScope())
            {
                // Buscamos alquiler pendiente de devolver
                alquiler = alquileresAD.ObtenerAlquilerSinDevolverPorSocioPelicula(nifSocio, peliculaCodBarras);
                if(alquiler == null)
                    throw new ArgumentException();

                // Actualización de stock
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(peliculaCodBarras, false, false);
                peliculaOriginal = (Pelicula)OperacionesEntidad.CreateDataCopy(pelicula, false);
                pelicula.UnidadesAlquiladas --;
                try
                {
                    peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);
                }
                catch(ChangeConflictException)
                {
                    // Error de concurrencia
                    return EstadoPedido.ErrorConcurrencia;
                }

                // Almacenamos en históricos
                historico = new Historico();
                historico.PeliculaID = alquiler.PeliculaID;
                historico.SocioID = alquiler.SocioID;
                historico.Fecha = alquiler.FechaAlquiler;
                historico.FechaRecogida = alquiler.FechaRecogida;
                historico.FechaDevolucion = DateTime.Now;
                historico.TipoOperacion = TipoOperacion.Devolucion;
                historico.Precio = CalcularPrecio(alquiler.FechaAlquiler, alquiler.FechaRecogida.Value, historico.FechaDevolucion.Value);
                historicosAD.AgregarHistorico(historico);

                // Borrado alquiler
                try
                {
                    alquileresAD.EliminarAlquiler(alquiler);
                }
                catch(ChangeConflictException)
                {
                    // Error de concurrencia
                    return EstadoPedido.ErrorConcurrencia;
                }

                // Actualización saldo
                socio = usuariosAD.ObtenerSocioPorNIF(nifSocio);
                socioOriginal = (Socio)OperacionesEntidad.CreateDataCopy(socio, false);
                socio.Saldo -= historico.Precio;
                if(socio.Saldo < 0)
                    return EstadoPedido.SaldoInsuficiente;
                try
                {
                    usuariosAD.ActualizarUsuario(socio, socioOriginal);
                }
                catch(ChangeConflictException)
                {
                    // Error de concurrencia
                    return EstadoPedido.ErrorConcurrencia;
                }

                tx.Complete();
            }

            return EstadoPedido.Realizado;
        }

        #endregion

        #region "Mantenimiento alquileres"

        /// <summary>
        /// Obtiene todos los alquileres pendientes de devolución
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="incluirSocio">Incluye información de los socios</param>
        /// <param name="incluirPelicula">Incluye información de la película</param>
        /// <returns>Lista de alquileres</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<Alquiler> ObtenerAlquileresSinDevolver(bool incluirSocio, bool incluirPelicula)
        {
            AlquileresAD alquileresAD = new AlquileresAD();

            return alquileresAD.ObtenerAlquileresSinDevolver(incluirSocio, incluirPelicula);
        }

        /// <summary>
        /// Obtiene todos los alquileres sin recoger
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="incluirSocio">Incluye información de los socios</param>
        /// <param name="incluirPelicula">Incluye información de la película</param>
        /// <returns>Lista de alquileres</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<Alquiler> ObtenerAlquileresSinRecoger(bool incluirSocio, bool incluirPelicula)
        {
            AlquileresAD alquileresAD = new AlquileresAD();

            return alquileresAD.ObtenerAlquileresSinRecoger(incluirSocio, incluirPelicula);
        }

        #endregion

        #region "Calcular precio"

        private decimal CalcularPrecio(DateTime fechaAlquiler, DateTime fechaRecogida , DateTime fechaDevolucion)
        {
            int numHoras;
            decimal precio;

            numHoras = (int)(Math.Ceiling((fechaDevolucion - fechaRecogida).TotalHours));
            precio = numHoras * _precioHora;

            // Recogida tardía: a partir de una hora después
            numHoras = (int)(Math.Floor((fechaRecogida - fechaAlquiler).TotalHours));
            precio += numHoras * _precioHora;

            return precio;
        }

        #endregion

    }
}
