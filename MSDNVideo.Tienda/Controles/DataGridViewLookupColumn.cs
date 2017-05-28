using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Comun;

namespace MSDNVideo.Tienda
{
    public class DataGridViewLookupColumn : DataGridViewColumn
    {
        private IDisconnectedDataContext _lookupDataContext;
        private Type _lookupDialogForm;
        private Type _entityConverter;

        public DataGridViewLookupColumn()
        {
            this.CellTemplate = new DataGridViewLookupObjectCell();
        }

        public IDisconnectedDataContext LookupDataContext
        {
            get
            {
                return _lookupDataContext;
            }
            set
            {
                _lookupDataContext = value;
            }
        }

        public Type LookupDialogForm
        {
            get
            {
                return _lookupDialogForm;
            }
            set
            {
                _lookupDialogForm = value;
            }
        }

        public Type EntityConverter
        {
            get
            {
                return _entityConverter;
            }
            set
            {
                _entityConverter = value;
            }
        }
    }
}
