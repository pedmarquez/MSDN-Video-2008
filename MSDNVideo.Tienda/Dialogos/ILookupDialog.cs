using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Comun;

namespace MSDNVideo.Tienda
{
    public interface ILookupDialog
    {
        DialogResult ShowDialog();
        object SelectedObject { get; set; }
        IDisconnectedDataContext LookupDataContext { get; set; }
    }

}
