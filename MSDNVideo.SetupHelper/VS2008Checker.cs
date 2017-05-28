using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace MSDNVideo.SetupHelper
{
    class VS2008Checker
    {
        public bool IsVS2008Installed()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\DevDiv\VS\Servicing\9.0\");

            if (key == null)
                return false;
            else
                return true;
        }
    }
}
