using MSDNVideo.AccesoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDNVideo.Comun;
using System.Transactions;
using System.ComponentModel;

namespace MSDNVideo.Pruebas
{


    [TestClass()]
    public class PeliculasADTest
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void ObtenerPeliculaPorCodBarrasTest()
        {
            PeliculasAD target = new PeliculasAD();
            string codBarras = "0045907014545";
            bool incluirActores = false;
            Pelicula actual;

            actual = target.ObtenerPeliculaPorCodBarras(codBarras, incluirActores, false);
            Assert.AreEqual("María Antonieta", actual.Titulo);
            Assert.AreEqual(0, actual.ActoresPeliculas.Count);
        }

        [TestMethod()]
        public void ObtenerPeliculaConActoresPorCodBarrasTest()
        {
            PeliculasAD target = new PeliculasAD();
            string codBarras = "0045907014545";
            bool incluirActores = true;
            Pelicula actual;

            actual = target.ObtenerPeliculaPorCodBarras(codBarras, incluirActores, false);
            Assert.AreEqual("María Antonieta", actual.Titulo);
            Assert.AreEqual(9, actual.ActoresPeliculas.Count);
        }

        [TestMethod()]
        public void ObtenerPeliculaConPuntuacionPorCodBarrasTest()
        {
            PeliculasAD target = new PeliculasAD();
            string codBarras = "0045907014545";
            Pelicula actual;

            actual = target.ObtenerPeliculaPorCodBarras(codBarras, false, true);
            Assert.IsTrue(actual.PuntuacionMedia > 0);
        }

        [TestMethod()]
        public void ObtenerPeliculaNoExistenteTest()
        {
            PeliculasAD target = new PeliculasAD();
            string codBarras = "0000000000000";
            bool incluirActores = true;
            Pelicula actual;

            actual = target.ObtenerPeliculaPorCodBarras(codBarras, incluirActores, false);
            Assert.IsNull(actual);
        }

        [TestMethod()]
        public void ObtenerPeliculaPorFiltro1Test()
        {
            PeliculasAD target = new PeliculasAD();
            string codBarras = "0045907014545";
            bool incluirActores = false;
            BindingList<Pelicula> actual;
            FiltroPeliculas filtro = new FiltroPeliculas();
            filtro.CamposFiltrado = (int)CamposFiltro.CodBarras;
            filtro.CodBarras = codBarras;
            int total;

            actual = target.ObtenerPeliculasPorFiltro(filtro, incluirActores, false, out total);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(codBarras, actual[0].CodBarras);
        }

        [TestMethod()]
        public void ObtenerPeliculaPorFiltro2Test()
        {
            PeliculasAD target = new PeliculasAD();
            bool incluirActores = false;
            BindingList<Pelicula> actual;
            FiltroPeliculas filtro = new FiltroPeliculas();
            filtro.CamposFiltrado = (int)CamposFiltro.Titulo;
            filtro.Titulo = "dos";
            int total;

            actual = target.ObtenerPeliculasPorFiltro(filtro, incluirActores, false, out total);
            Assert.AreEqual(4, actual.Count);
        }

        [TestMethod()]
        public void ObtenerPeliculaPorFiltro3Test()
        {
            PeliculasAD target = new PeliculasAD();
            bool incluirActores = false;
            BindingList<Pelicula> actual;
            FiltroPeliculas filtro = new FiltroPeliculas();
            filtro.CamposFiltrado = (int)CamposFiltro.Titulo;
            filtro.Titulo = "dos";
            filtro.PeliculasPagina = 2;
            filtro.InicioPagina = 1;
            filtro.IncluirTotal = true;
            int total;

            actual = target.ObtenerPeliculasPorFiltro(filtro, incluirActores, false, out total);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(4, total);
        }

        [TestMethod()]
        public void ModificarPeliculaTest()
        {
            PeliculasAD peliculasAD = new PeliculasAD();
            string codBarras = "0045907014545";
            Pelicula pelicula, peliculaOriginal;

            pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, false, false);
            peliculaOriginal = (Pelicula)OperacionesEntidad.CreateDataCopy(pelicula, false);

            pelicula.Duracion = 100;

            using (TransactionScope tx = new TransactionScope())
            {
                peliculasAD.ActualizarPelicula(pelicula, peliculaOriginal);
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, false, false);

                Assert.AreEqual(100, pelicula.Duracion);
            }

        }

        [TestMethod()]
        public void EliminarPeliculaTest()
        {
            PeliculasAD peliculasAD = new PeliculasAD();
            string codBarras = "0045907014545";
            Pelicula pelicula;

            pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, false, false);
            using (TransactionScope tx = new TransactionScope())
            {
                peliculasAD.EliminarPelicula(pelicula);
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, false, false);

                Assert.IsNull(pelicula);
            }

        }

        [TestMethod()]
        public void AgregarPeliculaTest()
        {
            PeliculasAD peliculasAD = new PeliculasAD();
            Pelicula pelicula;
            string codBarras = "1111111111111";
            string titulo = "Titulo prueba";

            pelicula = new Pelicula();
            pelicula.CodBarras = codBarras;
            pelicula.Titulo = titulo;
            pelicula.Sinopsis = "Sinopsis";
            
            using (TransactionScope tx = new TransactionScope())
            {
                peliculasAD.AgregarPelicula(pelicula);
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, false, false);

                Assert.IsNotNull(pelicula);
                Assert.AreEqual(codBarras, pelicula.CodBarras);
                Assert.AreEqual(titulo, pelicula.Titulo);
            }

        }

    }
}
