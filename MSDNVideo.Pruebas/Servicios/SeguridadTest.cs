using MSDNVideo.AccesoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDNVideo.Comun;
using System.Transactions;
using MSDNVideo.Pruebas.MSDNVideoServices;
using System.Security;
using System.ServiceModel.Security;

namespace MSDNVideo.Pruebas
{


    [TestClass()]
    public class SeguridadTest
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
        public void AccesoInvitadoTest()
        {
            IMSDNVideoServices client = ConnectionHelper.CreateCustomServiceClient("Invitado", null);
            Usuario usuario;

            usuario = client.Usuarios_ObtenerMiUsuario();

            Assert.IsNull(usuario);
        }

        [TestMethod()]
        public void AccesoSocioTest()
        {
            IMSDNVideoServices client = ConnectionHelper.CreateCustomServiceClient("00000000T", "12345");;
            Usuario usuario;

            usuario = client.Usuarios_ObtenerMiUsuario();

            Assert.IsNotNull(usuario);
            Assert.AreEqual("00000000T", usuario.NIF);
            Assert.AreEqual(Rol.Socio, usuario.Rol);
        }

        [TestMethod()]
        public void AccesoAdminTest()
        {
            IMSDNVideoServices client = ConnectionHelper.CreateCustomServiceClient("99999999R", "12345");
            Usuario usuario;

            usuario = client.Usuarios_ObtenerMiUsuario();

            Assert.IsNotNull(usuario);
            Assert.AreEqual("99999999R", usuario.NIF);
            Assert.AreEqual(Rol.Admin, usuario.Rol);
        }

        [TestMethod()]
        [ExpectedException(typeof(MessageSecurityException))]
        public void AccesoSocioNoExisteTest()
        {
            IMSDNVideoServices client = ConnectionHelper.CreateCustomServiceClient("11111111P", "12345");
            Usuario usuario;

            usuario = client.Usuarios_ObtenerMiUsuario();

        }

        [TestMethod()]
        [ExpectedException(typeof(MessageSecurityException))]
        public void AccesoClaveIncorrectaTest()
        {
            IMSDNVideoServices client = ConnectionHelper.CreateCustomServiceClient("00000000T", "00000");
            Usuario usuario;

            usuario = client.Usuarios_ObtenerMiUsuario();
        }

        [TestMethod()]
        public void AccesoOperacionConPermisoTest()
        {
            IMSDNVideoServices client = ConnectionHelper.CreateCustomServiceClient("99999999R", "12345");

            client.Peliculas_ObtenerPeliculasPendienteDevolver("00000000T");
        }

        [TestMethod()]
        [ExpectedException(typeof(SecurityAccessDeniedException))]
        public void AccesoOperacionSinPermisoTest()
        {
            IMSDNVideoServices client = ConnectionHelper.CreateCustomServiceClient("00000000T", "12345");

            client.Peliculas_ObtenerPeliculasPendienteDevolver("00000000T");
        }

    }
}
