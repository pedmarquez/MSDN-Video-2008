using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDNVideo.LogicaNegocio;
using MSDNVideo.AccesoDatos;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Transactions;

namespace MSDNVideo.Pruebas
{
    [TestClass()]
    public class ComprasTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void ComprarPeliculaTest()
        {
            ComprasCN comprasCN = new ComprasCN();
            PeliculasCN peliculasCN = new PeliculasCN();
            Pelicula pelicula;
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            int unidadesVenta;

            // Necesitamos ser administrador para comprar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            // Recuperamos datos para comprobar
            pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
            unidadesVenta = pelicula.UnidadesVenta;

            using (TransactionScope tx = new TransactionScope())
            {
                comprasCN.ComprarPelicula(nifSocio, codBarrasPelicula);

                pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                Assert.AreEqual(unidadesVenta - 1, pelicula.UnidadesVenta);
            }
        }


        [TestMethod()]
        public void ComprarPeliculaSinSaldoTest()
        {
            ComprasCN comprasCN = new ComprasCN();
            UsuariosAD usuariosAD = new UsuariosAD();
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            Socio socio, socioOriginal;

            // Necesitamos ser administrador para comprar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            using (TransactionScope tx = new TransactionScope())
            {
                // Quitamos el saldo al socio
                socio = usuariosAD.ObtenerSocioPorNIF(nifSocio);
                socioOriginal = (Socio)OperacionesEntidad.CreateDataCopy(socio, false);
                socio.Saldo = 0;
                usuariosAD.ActualizarUsuario(socio, socioOriginal);

                // Intentamos comprar
                EstadoPedido estadoPedido = comprasCN.ComprarPelicula(nifSocio, codBarrasPelicula);

                Assert.AreEqual(EstadoPedido.SaldoInsuficiente, estadoPedido);
            }
        }

        [TestMethod()]
        public void ComprarPeliculaSinStockTest()
        {
            ComprasCN comprasCN = new ComprasCN();
            PeliculasAD peliculasAD = new PeliculasAD();
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            Pelicula pelicula, peliculaOriginal;

            // Necesitamos ser administrador para comprar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            using (TransactionScope tx = new TransactionScope())
            {
                // Quitamos el stock a la pelicula
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                peliculaOriginal = (Pelicula)OperacionesEntidad.CreateDataCopy(pelicula, false);
                pelicula.UnidadesVenta = 0;
                pelicula.UnidadesVentaAlquiler = 1;
                pelicula.UnidadesAlquiladas = 1;
                pelicula.UnidadesAlquiler = 0;
                peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);

                // Intentamos alquilar
                EstadoPedido estadoPedido = comprasCN.ComprarPelicula(nifSocio, codBarrasPelicula);

                Assert.AreEqual(EstadoPedido.StockInsuficiente, estadoPedido);
            }
        }

        [TestMethod()]
        public void ComprarPeliculaSinModalidadTest()
        {
            ComprasCN comprasCN = new ComprasCN();
            PeliculasAD peliculasAD = new PeliculasAD();
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            Pelicula pelicula, peliculaOriginal;

            // Necesitamos ser administrador para comprar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            using (TransactionScope tx = new TransactionScope())
            {
                // Quitamos el stock a la pelicula
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                peliculaOriginal = (Pelicula)OperacionesEntidad.CreateDataCopy(pelicula, false);
                pelicula.UnidadesVenta = 0;
                pelicula.UnidadesVentaAlquiler = 0;
                peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);

                // Intentamos alquilar
                EstadoPedido estadoPedido = comprasCN.ComprarPelicula(nifSocio, codBarrasPelicula);

                Assert.AreEqual(EstadoPedido.ModalidadNoDisponible, estadoPedido);
            }
        }
    }
}
