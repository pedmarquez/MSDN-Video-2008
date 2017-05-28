using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;

namespace MSDNVideo.SetupHelper
{
    class DBInstaller
    {
        public bool CrearBD(string rutaBD, out string msgError, out string cnnString)
        {
            string instanceName;

            msgError = String.Empty;

            instanceName = GetInstance();

            if (instanceName == null)
            {
                msgError = "No se encontró ninguna instancia de SQL Server funcionando en esta máquina. Asegúrese de tener una versión de SQL Server 2005 instalada en la máquina y arrancada";
                cnnString = String.Empty;
                return false;
            }

            if (!AdjuntarBD(instanceName, rutaBD, out cnnString))
            {
                msgError = "No se pudo adjuntar la base de datos. Asegúrese que tiene instalado SQL Server 2005 o superior y está arrancado";
                return false;
            }


            return true;
        }

        private string GetInstance()
        {
            ManagementObjectSearcher wmiSearcher;
            ManagementObjectCollection results = null;
            string query, scope;

            // Probamos con SQL Server 2005
            scope = @"root\Microsoft\SqlServer\ComputerManagement";
            query = @"SELECT * FROM SqlService WHERE SQLServiceType = 1 AND State = 4"; // Servicio tipo SQL Server y arrancado
            

            wmiSearcher = new ManagementObjectSearcher(scope,query);

            try
            {
                results = wmiSearcher.Get();
            }
            catch (ManagementException)
            {
                // El scope no existe, no está instalado SQL Server 2005
            }


            if (results != null && results.Count != 0)
            {
                foreach (ManagementObject instance in results)
                {
                    return (string)instance["ServiceName"];
                }
            }

            // Probamos con SQL Server 2008
            scope = @"root\Microsoft\SqlServer\ComputerManagement10";

            wmiSearcher = new ManagementObjectSearcher(scope, query);
            try
            {
                results = wmiSearcher.Get();
            }
            catch (ManagementException)
            {
                // El scope no existe, no está instalado SQL Server 2008
            }

            if (results == null || results.Count == 0)
                return null;

            foreach (ManagementObject instance in results)
            {
                return (string)instance["ServiceName"];
            }

            return null;
        }

        private bool AdjuntarBD(string instance, string rutaBD, out string cnnString)
        {
            StringCollection files;

            // Convertimos MSSQLSERVER a .
            instance = instance.Replace("MSSQLSERVER", ".");

            // Convertimos MSSQL$INSTANCENAME a ./INSTANCENAME
            instance = instance.Replace("MSSQL$", @".\");

            Server dbServer = new Server(instance);
            cnnString = "Server=" + dbServer.ConnectionContext.ServerInstance + ";Integrated security=true;Database=MSDNVideoDB";

            files = new StringCollection();
            files.Add(rutaBD + "\\MSDNVideo.mdf");
            files.Add(rutaBD + "\\MSDNVideo_log.LDF");
            dbServer.AttachDatabase("MSDNVideoDB", files, "sa", AttachOptions.RebuildLog);

            return true;
        }
    }
}
