using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSDNVideo.Tienda
{
    public class ToolStripPaginacion : ToolStripControlHost
    {
        public event PaginateChangeHandler PaginateChange;

        public ToolStripPaginacion()
            : base(new PaginacionControl())
        {
        }

        public PaginacionControl PaginacionControl
        {
            get
            {
                return Control as PaginacionControl;
            }
        }

        public int InicioPagina
        {
            get
            {
                return PaginacionControl.InicioPagina;
            }
            set
            {
                PaginacionControl.InicioPagina = value;
            }
        }

        public int RegistrosPagina
        {
            get
            {
                return PaginacionControl.RegistrosPagina;
            }
            set
            {
                PaginacionControl.RegistrosPagina = value;
            }
        }

        public int TotalRegistros
        {
            get
            {
                return PaginacionControl.TotalRegistros;
            }
            set
            {
                PaginacionControl.TotalRegistros = value;
            }
        }

        protected override void OnSubscribeControlEvents(Control c)
        {
            base.OnSubscribeControlEvents(c);

            PaginacionControl paginacionControl = (PaginacionControl)c;

            paginacionControl.PaginateChange +=
                new PaginateChangeHandler(OnPaginateChanged);
        }

        protected override void OnUnsubscribeControlEvents(Control c)
        {
            base.OnUnsubscribeControlEvents(c);

            PaginacionControl paginacionControl = (PaginacionControl)c;

            paginacionControl.PaginateChange -=
                new PaginateChangeHandler(OnPaginateChanged);
        }

        private void OnPaginateChanged(int first)
        {
            if (PaginateChange != null)
            {
                PaginateChange(first);
            }
        }

    }
}
