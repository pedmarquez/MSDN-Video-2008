using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDNVideo.AccesoDatos;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Transactions;

namespace MSDNVideo.Pruebas
{
    [TestClass()]
    public class ActoresADTest
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
        public void ObtenerActoresPorNombreTest()
        {
            ActoresAD target = new ActoresAD();
            string nombre = "Robin Williams";
            BindingList<Actor> result;

            result = target.ObtenerActoresPorNombre(nombre);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(nombre, result[0].Nombre);
        }

        [TestMethod()]
        public void ModificarActorTest()
        {
            ActoresAD target = new ActoresAD();
            string nombre = "Robin Williams";
            Actor actor, actorOriginal;
            BindingList<Actor> result;

            actor = target.ObtenerActoresPorNombre(nombre)[0];
            actorOriginal = (Actor)OperacionesEntidad.CreateDataCopy(actor, false);

            actor.UrlPersonal = "nueva url";

            using (TransactionScope tx = new TransactionScope())
            {
                target.ActualizarActor(actor, actorOriginal);
                result = target.ObtenerActoresPorNombre(nombre);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("nueva url", result[0].UrlPersonal);
            }

        }

        [TestMethod()]
        public void EliminarActorTest()
        {
            ActoresAD target = new ActoresAD();
            string nombre = "Robin Williams";
            Actor actor;

            actor = target.ObtenerActoresPorNombre(nombre)[0];
            using (TransactionScope tx = new TransactionScope())
            {
                target.EliminarActor(actor);
                Assert.AreEqual(0, target.ObtenerActoresPorNombre(nombre).Count);
            }

        }

        [TestMethod()]
        public void AgregarActorTest()
        {
            ActoresAD target = new ActoresAD();
            string nombre = "Nuevo actor prueba";
            Actor actor;
            BindingList<Actor> result;

            actor = new Actor();
            actor.Nombre = nombre;

            using (TransactionScope tx = new TransactionScope())
            {
                target.AgregarActor(actor);
                result = target.ObtenerActoresPorNombre(nombre);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(nombre, result[0].Nombre);
            }

        }

    }
}
