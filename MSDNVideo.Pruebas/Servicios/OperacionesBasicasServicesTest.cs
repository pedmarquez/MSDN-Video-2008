using MSDNVideo.AccesoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDNVideo.Comun;
using System.Transactions;
using MSDNVideo.Pruebas.MSDNVideoServices;

namespace MSDNVideo.Pruebas
{


    [TestClass()]
    public class OperacionesBasicasServicesTest
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
        public void ObtenerPeliculaTest()
        {
            IMSDNVideoServices client = ConnectionHelper.ServiceClient;
            Pelicula pelicula;
            string codBarras = "1111768176787";

            pelicula = client.Peliculas_ObtenerPeliculaPorCodBarras(codBarras, false, false);

            Assert.AreEqual(codBarras, pelicula.CodBarras);
            
        }

        [TestMethod()]
        public void ObtenerPeliculaYActoresTest()
        {
            IMSDNVideoServices client = ConnectionHelper.ServiceClient;
            Pelicula pelicula;
            string codBarras = "1111768176787";

            pelicula = client.Peliculas_ObtenerPeliculaPorCodBarras(codBarras, true, false);

            Assert.AreEqual(codBarras, pelicula.CodBarras);
            Assert.AreEqual(8, pelicula.ActoresPeliculas.Count);

        }

    }
}
