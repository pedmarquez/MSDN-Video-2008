using MSDNVideo.AccesoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDNVideo.Comun;
using System.Transactions;
using System.ComponentModel;

namespace MSDNVideo.Pruebas
{


    [TestClass()]
    public class ChangesetTest
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
        public void ModificarPeliculaTest()
        {
            PeliculasAD peliculasAD = new PeliculasAD();
            ChangeSetAD changesetAD = new ChangeSetAD();
            string codBarras = "0045907014545";
            Pelicula pelicula;

            pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, false, false);

            DisconnectedDataContext<EntidadesDataContext> dataContext = new DisconnectedDataContext<EntidadesDataContext>();
            dataContext.Attach(pelicula);

            pelicula.Duracion = 100;

            using (TransactionScope tx = new TransactionScope())
            {
                DisconnectedChangeSet changeSet = dataContext.GetChangeSet();
                changesetAD.ActualizarChangeSet(changeSet);
                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, false, false);

                Assert.AreEqual(100, pelicula.Duracion);
            }

        }

        [TestMethod()]
        public void ModificarPeliculaYEliminarActorTest()
        {
            PeliculasAD peliculasAD = new PeliculasAD();
            ChangeSetAD changesetAD = new ChangeSetAD();
            string codBarras = "0045907014545";
            Pelicula pelicula;
            int actoresCount;

            pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, true, false);

            DisconnectedDataContext<EntidadesDataContext> dataContext = new DisconnectedDataContext<EntidadesDataContext>();
            dataContext.Attach(pelicula);

            pelicula.Duracion = 100;
            
            actoresCount = pelicula.ActoresPeliculas.Count;
            pelicula.ActoresPeliculas.RemoveAt(0);

            using (TransactionScope tx = new TransactionScope())
            {
                DisconnectedChangeSet changeSet = dataContext.GetChangeSet();
                changesetAD.ActualizarChangeSet(changeSet);

                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, true, false);

                Assert.AreEqual(100, pelicula.Duracion);
                Assert.AreEqual(actoresCount - 1, pelicula.ActoresPeliculas.Count);
            }

        }

        [TestMethod()]
        public void ModificarPeliculaYEliminarModificarAgregarActorTest()
        {
            PeliculasAD peliculasAD = new PeliculasAD();
            ChangeSetAD changesetAD = new ChangeSetAD();
            string codBarras = "0045907014545";
            Pelicula pelicula;
            int actoresCount;

            pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, true, false);

            DisconnectedDataContext<EntidadesDataContext> dataContext = new DisconnectedDataContext<EntidadesDataContext>();
            dataContext.Attach(pelicula);

            pelicula.Duracion = 100;

            actoresCount = pelicula.ActoresPeliculas.Count;
            pelicula.ActoresPeliculas[0].Papel = "Nuevo papel";
            pelicula.ActoresPeliculas.RemoveAt(0);

            ActoresPelicula nuevoActorPelicula = new ActoresPelicula();
            nuevoActorPelicula.ActorID = 100;
            nuevoActorPelicula.Papel = "Nuevo actor";
            pelicula.ActoresPeliculas.Add(nuevoActorPelicula);

            using (TransactionScope tx = new TransactionScope())
            {
                DisconnectedChangeSet changeSet = dataContext.GetChangeSet();
                changesetAD.ActualizarChangeSet(changeSet);

                pelicula = peliculasAD.ObtenerPeliculaPorCodBarras(codBarras, true, false);

                Assert.AreEqual(100, pelicula.Duracion);
                Assert.AreEqual(actoresCount, pelicula.ActoresPeliculas.Count);

                bool foundNuevo = false;
                bool foundAntiguo = false;
                foreach (ActoresPelicula actor in pelicula.ActoresPeliculas)
                {
                    if (actor.Papel == "Nuevo actor")
                        foundNuevo = true;
                    if (actor.Papel == "Nuevo papel")
                        foundAntiguo = true;
                }

                Assert.IsTrue(foundNuevo);
                Assert.IsFalse(foundAntiguo);

            }

        }

    }
}
