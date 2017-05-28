using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Tienda.MSDNVideoServices;
using MSDNVideo.Comun;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MSDNVideo.Tienda
{
    public partial class InicioSesionForm : Form
    {
        private string _detalleError;

        public InicioSesionForm()
        {
            InitializeComponent();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            string errorText;
            bool hayError = false;

            this.Cursor = Cursors.WaitCursor;

            if (!ConnectionHelper.SetConnectionData(nifTxtBox.Text, claveTxtBox.Text, servidorTxtBox.Text, out errorText))
            {
                // Error de conexión
                lblError.Text = "Servidor no disponible";
                _detalleError = errorText;
                lnkDetalles.Visible = true;
                hayError = true;
            }

            this.Cursor = Cursors.Default;

            if (!hayError)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void lnkDetalles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(_detalleError, "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        

    }
}
