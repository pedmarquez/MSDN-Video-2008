using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace MSDNVideo.SetupHelper
{
    class CertInstaller
    {
        public bool InstalarCert(string rutaCert, out string msgError)
        {
            msgError = String.Empty;

            X509Store certStore = new X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser);
            if (certStore == null)
            {
                msgError = "No se pudo abrir el almacén de certificados del usuario acual";
                return false;
            }

            certStore.Open(OpenFlags.ReadWrite);
            X509Certificate2 cert = new X509Certificate2(rutaCert, "msdnvideo", X509KeyStorageFlags.Exportable);

            certStore.Add(cert);
            certStore.Close();

            return true;
        }
    }
}
