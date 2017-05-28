using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interop = MSDNVideo.Pruebas.MSDNVideoServicesInterop;

namespace MSDNVideo.Pruebas
{
    [TestClass()]
    public class InteropServicesTest
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
            Interop.MSDNVideoServices serviceClient = new Interop.MSDNVideoServices();
            string codBarras = "0045907014545";
            Interop.Pelicula pelicula;

            

            pelicula = serviceClient.Peliculas_ObtenerPeliculaPorCodBarras(codBarras, false, true, false, true);
            Assert.AreEqual(codBarras, pelicula.CodBarras);
        }

        [TestMethod()]
        public void ObtenerPeliculaActoresTest()
        {
            Interop.MSDNVideoServices serviceClient = new Interop.MSDNVideoServices();
            string codBarras = "1111768176787";
            Interop.Pelicula pelicula;

            pelicula = serviceClient.Peliculas_ObtenerPeliculaPorCodBarras(codBarras, true, true, false, true);
            Assert.AreEqual(codBarras, pelicula.CodBarras);
            Assert.AreEqual(8, pelicula.ActoresPeliculas.Length);
            Assert.AreEqual(102, pelicula.ActoresPeliculas[0].ActorParent.ActorID);
        }

    }
}
