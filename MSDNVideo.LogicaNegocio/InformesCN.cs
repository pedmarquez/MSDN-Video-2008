using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MSDNVideo.Comun;
using MSDNVideo.AccesoDatos;
using System.Security.Permissions;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Lógica de negocio asociada a Informes
    /// </summary>
    public class InformesCN
    {
        #region Informe saldos

        /// <summary>
        /// Obtiene un informe con el estado de los saldos de socios
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="saludInforme">Estimación positiva, negativa o neutra de los resultados del informe</param>
        /// <returns>Lista con los datos del informe</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<InformeSaldos> ObtenerInformeSaldos(out SaludInforme saludInforme)
        {
            InformesAD informesAD = new InformesAD();
            BindingList<InformeSaldos> informeSaldos;

            informeSaldos = informesAD.ObtenerInformeSaldos();

            // Calculamos salud informe
            decimal saldosTotales, saldosBajos;
            decimal porcentajeSaldosBajos;
            
            saldosTotales = (from informeSaldo in informeSaldos select informeSaldo.Saldo).Sum();
            saldosBajos = (from informeSaldo in informeSaldos where informeSaldo.Saldo < 10 select informeSaldo.Saldo).Sum();
            porcentajeSaldosBajos = 100 * saldosBajos / saldosTotales;

            if (porcentajeSaldosBajos > 60)
                saludInforme = SaludInforme.Positivo;
            else if(porcentajeSaldosBajos > 40)
                saludInforme = SaludInforme.Neutro;
            else
                saludInforme = SaludInforme.Negativo;

            return informeSaldos;
        }

        #endregion

        #region Informe de Stock

        /// <summary>
        /// Obtiene un informe con el estado de las existencias de películas
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="saludInforme">Estimación positiva, negativa o neutra de los resultados del informe</param>
        /// <returns>Lista con los datos del informe</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<InformeStock> ObtenerInformeStock(out SaludInforme saludInforme)
        {
            InformesAD informesAD = new InformesAD();
            BindingList<InformeStock> informeStocks;

            informeStocks = informesAD.ObtenerInformeStock();

            // Calculamos salud informe
            int peliculasTotales, peliculasStockBajo;
            int porcentajeStockBajo;

            peliculasTotales = (from informeStock in informeStocks select informeStock.NumPeliculas).Sum();
            peliculasStockBajo = (from informeStock in informeStocks where informeStock.Unidades <= 2 select informeStock.NumPeliculas).Sum();
            porcentajeStockBajo = 100 * peliculasStockBajo / peliculasTotales;

            if (porcentajeStockBajo > 30)
                saludInforme = SaludInforme.Negativo;
            else if (porcentajeStockBajo > 15)
                saludInforme = SaludInforme.Neutro;
            else
                saludInforme = SaludInforme.Positivo;

            return informeStocks;
        }

        #endregion

        #region Informe de Ventas

        /// <summary>
        /// Obtiene un informe con el estado de las ventas por día
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="saludInforme">Estimación positiva, negativa o neutra de los resultados del informe</param>
        /// <returns>Lista con los datos del informe</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<InformeVentas> ObtenerInformeVentas(out SaludInforme saludInforme)
        {
            InformesAD informesAD = new InformesAD();
            BindingList<InformeVentas> informeVentas;

            informeVentas = informesAD.ObtenerInformeVentas();

            // Calculamos salud informe
            decimal ventasMedias;
            decimal menorVenta;
            decimal porcentajeDesvioMedia;

            ventasMedias = (from informeVenta in informeVentas select (informeVenta.Ventas + informeVenta.Alquileres)).Sum() / 7;
            if (informeVentas.Count < 7)
                menorVenta = 0;
            else
                menorVenta = (from informeVenta in informeVentas select (informeVenta.Ventas + informeVenta.Alquileres)).Min();

            porcentajeDesvioMedia = 100 * menorVenta / ventasMedias;

            if (porcentajeDesvioMedia > 70)
                saludInforme = SaludInforme.Positivo;
            else if (porcentajeDesvioMedia > 50)
                saludInforme = SaludInforme.Neutro;
            else
                saludInforme = SaludInforme.Negativo;

            return informeVentas;
        }

        #endregion
    }
}
