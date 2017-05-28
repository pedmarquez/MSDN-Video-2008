using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MSDNVideo.Comun;
using MSDNVideo.AccesoDatos;
using System.Data.Linq;
using System.Security.Permissions;
using System.Threading;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Operaciones de negocio de compras
    /// </summary>
    public class ComprasCN
    {
        #region Campos

        private const int       _numIntentosConcurrencia = 3;
        private const decimal   _precioVenta = 21;
        
        #endregion

        #region Comprar película

        /// <summary>
        /// Realiza la compra de una película
        /// Seguridad: Adminisradores
        /// </summary>
        /// <param name="nifSocio">NIF del socio</param>
        /// <param name="peliculaCodBarras">Película a comprar</param>
        /// <returns>Resultado de la operación</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public EstadoPedido ComprarPelicula(string nifSocio, string peliculaCodBarras)
        {
            int intento = 0;
            EstadoPedido estadoPedido = EstadoPedido.ErrorConcurrencia;

            while (intento < _numIntentosConcurrencia && estadoPedido == EstadoPedido.ErrorConcurrencia)
            {
                estadoPedido = ComprarPeliculaInternal(nifSocio, peliculaCodBarras);
                intento += 1;
            }

            return estadoPedido;
        }

        /// <summary>
        /// Realiza la compra de una película por el usuario actual
        /// Seguridad: Socios
        /// </summary>
        /// <param name="peliculaCodBarras">Película a comprar</param>
        /// <returns>Resultado de la operación</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Socio")]
        public EstadoPedido ComprarMiPelicula(string peliculaCodBarras)
        {
            string nifSocio = Thread.CurrentPrincipal.Identity.Name;
            int intento = 0;
            EstadoPedido estadoPedido = EstadoPedido.ErrorConcurrencia;

            while (intento < _numIntentosConcurrencia && estadoPedido == EstadoPedido.ErrorConcurrencia)
            {
                estadoPedido = ComprarPeliculaInternal(nifSocio, peliculaCodBarras);
                intento += 1;
            }

            return estadoPedido;
        }

        private EstadoPedido ComprarPeliculaInternal(string nifSocio, string peliculaCodBarras)
        {
            Socio socio, socioOriginal;
            Pelicula pelicula, peliculaOriginal;
            Historico historico;

            UsuariosAD usuariosAD = new UsuariosAD();
            PeliculasAD peliculasAD = new PeliculasAD();
            HistoricosAD historicosAD = new HistoricosAD();

            // Recuperamos película y usuario
            pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(peliculaCodBarras, false, false);
            socio = usuariosAD.ObtenerSocioPorNIF(nifSocio);

            if(pelicula == null || socio == null)
                throw new ArgumentException();

            peliculaOriginal =(Pelicula) OperacionesEntidad.CreateDataCopy(pelicula, false);
            socioOriginal = (Socio)OperacionesEntidad.CreateDataCopy(socio, false);

            using(TransactionScope tx = new TransactionScope())
            {
                // Comprobamos stock
                if (pelicula.DisponibleVenta == 0)
                {
                    if (pelicula.UnidadesVentaAlquiler + pelicula.UnidadesVenta == 0)
                        return EstadoPedido.ModalidadNoDisponible;
                    else
                        return EstadoPedido.StockInsuficiente;
                }

                // Comprobamos saldo
                if (socio.Saldo < _precioVenta)
                    return EstadoPedido.SaldoInsuficiente;
                
                // Actualizamos stock
                if (pelicula.UnidadesVenta > 0)
                    pelicula.UnidadesVenta--;
                else
                    pelicula.UnidadesVentaAlquiler--;

                try
                {
                    peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);
                }
                catch (ChangeConflictException)
                {
                    return EstadoPedido.ErrorConcurrencia;
                }

                // Actualizamos saldo
                socio.Saldo -= _precioVenta;
                try
                {
                    usuariosAD.ActualizarUsuario(socio, socioOriginal);
                }
                catch (ChangeConflictException)
                {
                    return EstadoPedido.ErrorConcurrencia;
                }

                // Almacenamos en histórico
                historico = new Historico();
                historico.SocioID = socio.UsuarioID;
                historico.PeliculaID = pelicula.PeliculaID;
                historico.TipoOperacion = TipoOperacion.Venta;
                historico.Fecha = DateTime.Now;
                historico.Precio = _precioVenta;

                historicosAD.AgregarHistorico(historico);

                tx.Complete();
            }

            return EstadoPedido.Realizado;
        }

        #endregion
    }
}
