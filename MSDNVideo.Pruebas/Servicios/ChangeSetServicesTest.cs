using MSDNVideo.AccesoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDNVideo.Comun;
using System.Transactions;
using MSDNVideo.Pruebas.MSDNVideoServices;

namespace MSDNVideo.Pruebas
{


    [TestClass()]
    public class ChangeSetServicesTest
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
        public void ChangeSetModificacionTest()
        {
            IMSDNVideoServices client = ConnectionHelper.ServiceClient;
            int duracionOriginal;

            Pelicula pelicula = client.Peliculas_ObtenerPeliculaPorCodBarras("0045907014545", false, false);

            DisconnectedDataContext<EntidadesDataContext> dataContext = new DisconnectedDataContext<EntidadesDataContext>();
            dataContext.Attach(pelicula);

            duracionOriginal = pelicula.Duracion;
            pelicula.Duracion = 100;

            DisconnectedChangeSet changeSet = dataContext.GetChangeSet();
            client.ChangeSet_ActualizarChangeSet(changeSet);
            pelicula = client.Peliculas_ObtenerPeliculaPorCodBarras("0045907014545", false, false);
            Assert.AreEqual(100, pelicula.Duracion);

            // Compensación
            dataContext.AcceptChanges();
            dataContext.Attach(pelicula);
            pelicula.Duracion = duracionOriginal;
            changeSet = dataContext.GetChangeSet();
            client.ChangeSet_ActualizarChangeSet(changeSet);
        }

        [TestMethod()]
        public void ChangeSetModificacionBorradoTest()
        {
            IMSDNVideoServices client = ConnectionHelper.ServiceClient;
            int actoresCount;

            Pelicula pelicula = client.Peliculas_ObtenerPeliculaPorCodBarras("0045907014545", true, false);
            ActoresPelicula actorPeliculaBorrado;

            DisconnectedDataContext<EntidadesDataContext> dataContext = new DisconnectedDataContext<EntidadesDataContext>();
            dataContext.Attach(pelicula);

            pelicula.Duracion = 119;
            actoresCount = pelicula.ActoresPeliculas.Count;

            actorPeliculaBorrado = (ActoresPelicula)OperacionesEntidad.CreateDataCopy(pelicula.ActoresPeliculas[0], false);
            pelicula.ActoresPeliculas.RemoveAt(0);

            DisconnectedChangeSet changeSet = dataContext.GetChangeSet();
            client.ChangeSet_ActualizarChangeSet(changeSet);
            pelicula = client.Peliculas_ObtenerPeliculaPorCodBarras("0045907014545", true, false);
            Assert.AreEqual(119, pelicula.Duracion);
            Assert.AreEqual(actoresCount-1, pelicula.ActoresPeliculas.Count);

            // Compensación
            dataContext.AcceptChanges();
            dataContext.Attach(pelicula);
            pelicula.Duracion = 118;
            pelicula.ActoresPeliculas.Add(actorPeliculaBorrado);
            changeSet = dataContext.GetChangeSet();
            client.ChangeSet_ActualizarChangeSet(changeSet);
        }


    }
}
