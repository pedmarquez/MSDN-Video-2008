using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSDNVideo.Tienda
{
    public class DataGridViewLookupCell<T> : DataGridViewTextBoxCell
    {
        public DataGridViewLookupCell()
        {
        }

        public override void  InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            LookupControl lookUpControl;

 	        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            lookUpControl = (LookupControl)(this.DataGridView.EditingControl);
            lookUpControl.LookupDialogForm = typeof(T);
            lookUpControl.IsObjectLookup = true;

            if (this.Value != null && !(this.Value == DBNull.Value))
            {
                lookUpControl.Value = this.FormattedValue;
            }
            else
            {
                lookUpControl.Value = String.Empty;
            }
        }


        public override Type EditType
        {
            get { return typeof(LookupControl); }
        }
    }
}
