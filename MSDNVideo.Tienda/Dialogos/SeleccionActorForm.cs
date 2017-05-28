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
    public partial class SeleccionActorForm : Form, ILookupDialog
    {
        private object _selectedObject;
        private IDisconnectedDataContext _lookupDataContext;

        public SeleccionActorForm()
        {
            InitializeComponent();
        }

        public object SelectedObject
        {
            get { return _selectedObject; }
            set { _selectedObject = value; }
        }

        public IDisconnectedDataContext LookupDataContext
        {
            get { return _lookupDataContext; }
            set { _lookupDataContext = value; }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            BindingList<Actor> actores = ConnectionHelper.ServiceClient.Actores_ObtenerActoresPorNombre(buscarTxtBox.Text);
            _lookupDataContext.AttachAll(actores);

            actorBindingSource.DataSource = actores;
        }

        private void seleccionarExistenteButton_Click(object sender, EventArgs e)
        {
            Actor actor = (Actor)actorBindingSource.Current;

            if (actor == null)
            {
                MessageBox.Show("Seleccione un actor existente", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _selectedObject = actor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            string error = null;
            Actor nuevoActor = new Actor();

            nuevoActor.Nombre = nombreTxtBox.Text;
            nuevoActor.UrlPersonal = urlTxtBox.Text;

            error = nuevoActor["Nombre"];
            if (error == null)
                error = nuevoActor["UrlPersonal"];
            if (error != null)
                MessageBox.Show(error, "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _selectedObject = nuevoActor;
                _lookupDataContext.AddNew(nuevoActor);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
