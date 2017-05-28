using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Comun;

namespace MSDNVideo.Tienda
{
    public partial class SeleccionSocioForm : Form, ILookupDialog
    {
        private Socio _selectedSocio;
        private IDisconnectedDataContext _lookupDataContext;

        public SeleccionSocioForm()
        {
            InitializeComponent();
        }

        public Socio SelectedSocio
        {
            get
            {
                return _selectedSocio;
            }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            BindingList<Socio> socios = ConnectionHelper.ServiceClient.Usuarios_ObtenerSociosPorNombre(buscarTxtBox.Text);

            socioBindingSource.DataSource = socios;
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            Socio socio = (Socio)socioBindingSource.Current;
            
            if (_lookupDataContext != null)
                socio = (Socio)_lookupDataContext.Attach(socio);

            if (socio == null)
            {
                MessageBox.Show("Seleccione un socio existente", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _selectedSocio = socio;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ILookupDialog Members


        public object SelectedObject
        {
            get
            {
                return _selectedSocio;
            }
            set
            {
                _selectedSocio = (Socio)value;
            }
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

        #endregion
    }
}
