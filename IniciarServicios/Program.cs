using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Management;
using System.ServiceProcess;

namespace IniciarServicios
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarDTS();

            if(!IsServiceRunning(52442))
                IniciarApp(52442, "MSDNVideo.Servicios");
            if (!IsServiceRunning(52444))
                IniciarApp(52444, "MSDNVideo.Web");
        }

        static void IniciarApp(int port, string app)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = GetWebDevPath();
            startInfo.Arguments = "/port:" + port.ToString() + " /path:\"" + GetMSDNVideoPath() + "\\" + app + "\" /vpath:/\"" + app + "\"";

            Process.Start(startInfo);
        }

        static void IniciarDTS()
        {
            ServiceController service = new ServiceController("MSDTC");

            if (service != null && service.Status == ServiceControllerStatus.Stopped)
                service.Start();

        }

        static string GetWebDevPath()
        {
            string path;

            path = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
            path += @"\microsoft shared\DevServer\9.0\webdev.webserver.exe";
            
            return path;
        }

        static string GetMSDNVideoPath()
        {
            string path;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\MSDN Video");
            
            path = (string)key.GetValue("InstallDir");
            path = path.TrimEnd('\\');

            return path;
        }

        static bool IsServiceRunning(int port)
        {
            ManagementObjectSearcher wmiSearcher;
            ManagementObjectCollection processes;
            string query;
            string portArg;

            portArg = "/port:" + port.ToString();


            query = @"SELECT * FROM Win32_Process WHERE name = 'WebDev.WebServer.exe'";

            wmiSearcher = new ManagementObjectSearcher(query);
            processes = wmiSearcher.Get();

            foreach (ManagementObject process in processes)
            {
                string commandLine = (string)process["CommandLine"];
                if (commandLine != null && commandLine.IndexOf(portArg) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
