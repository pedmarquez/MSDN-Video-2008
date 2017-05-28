using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Configuration.Install;

namespace MSDNVideo.SetupHelper
{
    [RunInstaller(true)]
    public partial class CustomAction : Installer
    {
        public CustomAction()
        {
            InitializeComponent();
        }

        public CustomAction(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string msgError;
            string rutaInstallDir;
            string cnnString;

            rutaInstallDir = this.Context.Parameters["Args"];

            // Comprobar versión de Visual Studio
            VS2008Checker vs2008Checker = new VS2008Checker();
            if (!vs2008Checker.IsVS2008Installed())
            {
                throw new ApplicationException("MSDN Video necesita Visual Studio 2008 Standard o superior, se cancelerá la instalación");
            }

            // Adjuntar base de datos
            DBInstaller dbInstaller = new DBInstaller();
            if (!dbInstaller.CrearBD(rutaInstallDir + "\\MSDNVideo.Datos", out msgError, out cnnString))
            {
                throw new ApplicationException(msgError);
            }


            // Cambiar archivos de configuración
            FileConfiguration fileConfiguration = new FileConfiguration();
            if (!fileConfiguration.ModificarConexion(cnnString, rutaInstallDir + "\\MSDNVideo.Web\\web.config", out msgError))
            {
                throw new ApplicationException(msgError);
            }
            if (!fileConfiguration.ModificarConexion(cnnString, rutaInstallDir + "\\MSDNVideo.Servicios\\web.config", out msgError))
            {
                throw new ApplicationException(msgError);
            }

            // Instalar certificado para autenticación WCF
            CertInstaller certInstaller = new CertInstaller();
            if (!certInstaller.InstalarCert(rutaInstallDir + "\\MSDNVideoCert.pfx", out msgError))
            {
                throw new ApplicationException(msgError);
            }
        }
    }
}
