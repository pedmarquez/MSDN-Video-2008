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
    public class AlquileresTest
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
        public void AlquilarPeliculaTest()
        {
            AlquileresCN alquileresCN = new AlquileresCN();
            PeliculasCN peliculasCN = new PeliculasCN();
            Pelicula pelicula;
            AlquileresAD alquileresAD = new AlquileresAD();
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            int unidadesAlquiladas;
            Alquiler alquiler;

            // Necesitamos ser administrador para alquilar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            // Recuperamos datos para comprobar
            pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
            unidadesAlquiladas = pelicula.UnidadesAlquiladas;

            using (TransactionScope tx = new TransactionScope())
            {
                alquileresCN.AlquilarPelicula(nifSocio, codBarrasPelicula);

                pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                Assert.AreEqual(unidadesAlquiladas + 1, pelicula.UnidadesAlquiladas);

                alquiler = alquileresAD.ObtenerAlquilerSinRecogerPorSocioPelicula(nifSocio, codBarrasPelicula);
                Assert.IsNotNull(alquiler);
                Assert.IsFalse(alquiler.FechaRecogida.HasValue);
            }
        }

        [TestMethod()]
        public void RecogerPeliculaTest()
        {
            AlquileresCN alquileresCN = new AlquileresCN();
            PeliculasCN peliculasCN = new PeliculasCN();
            Pelicula pelicula;
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            int unidadesAlquiladas; 
            Alquiler alquiler;
            AlquileresAD alquileresAD = new AlquileresAD();

            // Necesitamos ser administrador para recoger, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            // Recuperamos datos para comprobar
            pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
            unidadesAlquiladas = pelicula.UnidadesAlquiladas;

            using (TransactionScope tx = new TransactionScope())
            {
                alquileresCN.AlquilarPelicula(nifSocio, codBarrasPelicula);
                alquileresCN.RecogerPelicula(nifSocio, codBarrasPelicula);

                pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                Assert.AreEqual(unidadesAlquiladas + 1, pelicula.UnidadesAlquiladas);

                alquiler = alquileresAD.ObtenerAlquilerSinDevolverPorSocioPelicula(nifSocio, codBarrasPelicula);
                Assert.IsNotNull(alquiler);
                Assert.IsTrue(alquiler.FechaRecogida.HasValue);
            }
        }

        [TestMethod()]
        public void DevolverPeliculaTest()
        {
            AlquileresCN alquileresCN = new AlquileresCN();
            PeliculasCN peliculasCN = new PeliculasCN();
            Pelicula pelicula;
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            int unidadesAlquiladas;
            Alquiler alquiler;
            AlquileresAD alquileresAD = new AlquileresAD();
            Historico historico;

            // Necesitamos ser administrador para devolver, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            // Recuperamos datos para comprobar
            pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
            unidadesAlquiladas = pelicula.UnidadesAlquiladas;

            using (TransactionScope tx = new TransactionScope())
            {
                alquileresCN.AlquilarPelicula(nifSocio, codBarrasPelicula);
                alquileresCN.RecogerPelicula(nifSocio, codBarrasPelicula);
                alquileresCN.DevolverPelicula(nifSocio, codBarrasPelicula, out historico);

                pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                Assert.AreEqual(unidadesAlquiladas, pelicula.UnidadesAlquiladas);

                Assert.AreEqual((Decimal)0.15, historico.Precio);

                alquiler = alquileresAD.ObtenerAlquilerSinDevolverPorSocioPelicula(nifSocio, codBarrasPelicula);
                Assert.IsNull(alquiler);
            }
        }

        [TestMethod()]
        public void AlquilarPeliculaSinSaldoTest()
        {
            AlquileresCN alquileresCN = new AlquileresCN();
            UsuariosAD usuariosAD = new UsuariosAD();
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            Socio socio, socioOriginal;

            // Necesitamos ser administrador para alquilar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            using (TransactionScope tx = new TransactionScope())
            {
                // Quitamos el saldo al socio
                socio = usuariosAD.ObtenerSocioPorNIF(nifSocio);
                socioOriginal = (Socio)OperacionesEntidad.CreateDataCopy(socio, false);
                socio.Saldo = 0;
                usuariosAD.ActualizarUsuario(socio, socioOriginal);

                // Intentamos alquilar
                EstadoPedido estadoPedido = alquileresCN.AlquilarPelicula(nifSocio, codBarrasPelicula);

                Assert.AreEqual(EstadoPedido.SaldoInsuficiente, estadoPedido);
            }
        }

        [TestMethod()]
        public void AlquilarPeliculaSinStockTest()
        {
            AlquileresCN alquileresCN = new AlquileresCN();
            PeliculasAD peliculasAD = new PeliculasAD();
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            Pelicula pelicula, peliculaOriginal;

            // Necesitamos ser administrador para alquilar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            using (TransactionScope tx = new TransactionScope())
            {
                // Quitamos el stock a la pelicula
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                peliculaOriginal = (Pelicula)OperacionesEntidad.CreateDataCopy(pelicula, false);
                pelicula.UnidadesAlquiladas = pelicula.UnidadesAlquiler + pelicula.UnidadesVentaAlquiler;
                peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);

                // Intentamos alquilar
                EstadoPedido estadoPedido = alquileresCN.AlquilarPelicula(nifSocio, codBarrasPelicula);

                Assert.AreEqual(EstadoPedido.StockInsuficiente, estadoPedido);
            }
        }

        [TestMethod()]
        public void AlquilarPeliculaSinModalidadTest()
        {
            AlquileresCN alquileresCN = new AlquileresCN();
            PeliculasAD peliculasAD = new PeliculasAD();
            string nifSocio = "00000000T";
            string codBarrasPelicula = "0686983675479";
            Pelicula pelicula, peliculaOriginal;

            // Necesitamos ser administrador para alquilar, impersonamos
            ConnectionHelper.ImpersonateAdmin();

            using (TransactionScope tx = new TransactionScope())
            {
                // Quitamos el stock a la pelicula
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarrasPelicula, false, false);
                peliculaOriginal = (Pelicula)OperacionesEntidad.CreateDataCopy(pelicula, false);
                pelicula.UnidadesAlquiler = 0;
                pelicula.UnidadesVentaAlquiler = 0;
                peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);

                // Intentamos alquilar
                EstadoPedido estadoPedido = alquileresCN.AlquilarPelicula(nifSocio, codBarrasPelicula);

                Assert.AreEqual(EstadoPedido.ModalidadNoDisponible, estadoPedido);
            }
        }

    }
}
