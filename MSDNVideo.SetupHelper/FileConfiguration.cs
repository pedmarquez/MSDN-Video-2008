using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MSDNVideo.SetupHelper
{
    class FileConfiguration
    {
        public bool ModificarConexion(string cnnString, string rutaWebconfig, out string errorMsg)
        {
            bool correcto = true;

            errorMsg = string.Empty;

            try
            {
                // Almacenar en el archivo de configuración
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaWebconfig);
                XmlNodeList nodes = doc.SelectNodes(@"/configuration/connectionStrings/add[@name='MSDNVideo.Comun.Properties.Settings.MSDNVideoConnectionString']/@connectionString");
                if (nodes.Count == 0)
                {
                    errorMsg = "Error al leer el archivo de configuración";
                    return false;
                }

                nodes[0].Value = cnnString;

                doc.Save(rutaWebconfig);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en " + rutaWebconfig + ": " + e.Message);
                errorMsg = e.Message;
                correcto = false;
            }

            return correcto;
        }
    }
}
