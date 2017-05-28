using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSDNVideo.Tienda
{
    public class DataGridViewRatingColumn : DataGridViewColumn
    {
        public DataGridViewRatingColumn()
        {
            this.CellTemplate = new DataGridViewRatingCell();
        }
    }
}
