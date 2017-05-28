using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Comun;

namespace MSDNVideo.Tienda
{
    public partial class UsuariosPanel : UserControl, IPantalla
    {
        #region Campos

        private DisconnectedDataContext<EntidadesDataContext>   _disconnectedDataContext;
        private Dictionary<Socio, string>                       _nuevasClaves = new Dictionary<Socio,string>();
        private Dictionary<Socio, string>                       _nuevasClavesRepeticion = new Dictionary<Socio, string>();
        private const string                                    _claveDefault = "********";

        #endregion

        #region Constructor

        public UsuariosPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Interfaz IPantalla

        public int ComandosSoportados
        {
            get
            {
                return (int)ComandosPantalla.ConfirmarCierre |
                        (int)ComandosPantalla.Eliminar |
                        (int)ComandosPantalla.Guardar |
                        (int)ComandosPantalla.Nuevo |
                        (int)ComandosPantalla.Refrescar;
            }
        }

        public void Guardar()
        {
            socioBindingSource.EndEdit();
            ValidarClaveRepetida();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (changeSet.Validate() && ValidarClaves())
            {
                if (changeSet.HayCambios || _nuevasClaves.Count > 0)
                {
                    // Guardo el changeset
                    ConnectionHelper.ServiceClient.ChangeSet_ActualizarChangeSet(changeSet);

                    // Almacenamos las clave
                    foreach(KeyValuePair<Socio, string> entry in _nuevasClaves)
                    {
                        ConnectionHelper.ServiceClient.Usuarios_EstablecerClave(entry.Key.NIF, entry.Value);
                    }

                    // Refrescamos
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show("Corrija la información no válida antes de guardar", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void Nuevo()
        {
            Socio socio = (Socio)socioBindingSource.AddNew();
            socio.Nombre = "";
            socio.Provincia = "";
            socio.Telefono = "";
            socio.Saldo = 0;
            socio.Ciudad = "";
            socio.Direccion = "";
            socio.Email = "";
            claveTxtBox.Text = "";
            repetirClaveTxtBox.Text = "";

            ValidarClaveRepetida();
        }

        public void Eliminar()
        {
            socioBindingSource.RemoveCurrent();
        }

        public void Refrescar()
        {
            BindingList<Socio> socios;

            socios = ConnectionHelper.ServiceClient.Usuarios_ObtenerSocios();
            socioBindingSource.DataSource = socios;

            // Escuchamos los cambios en un DataContext desconectado
            _disconnectedDataContext = new DisconnectedDataContext<EntidadesDataContext>();
            _disconnectedDataContext.AttachList(socios);

            _nuevasClaves.Clear();
            _nuevasClavesRepeticion.Clear();
        }

        public void Buscar()
        {
            throw new NotImplementedException();
        }

        public bool ConfirmarCierre()
        {
            socioBindingSource.EndEdit();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (changeSet.HayCambios || _nuevasClaves.Count > 0)
            {
                DialogResult dlgResult;
                dlgResult = MessageBox.Show("Ha realizado modificaciones en la lista de usuarios. ¿Desea guardarlas?",
                        "MSDN Video",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (dlgResult == DialogResult.Yes)
                {
                    Guardar();
                    return true;
                }
                else if (dlgResult == DialogResult.No)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void Paginar(int primerRegistro)
        {
            throw new NotImplementedException();
        }

        public event MostrarInfoPaginacionHandler MostrarInfoPaginacion;

        #endregion

        #region Tratamiento de eventos

        private void UsuariosPanel_Load(object sender, EventArgs e)
        {
        }

        private void claveTxtBox_Leave(object sender, EventArgs e)
        {
            ValidarClaveRepetida();
        }

        private void socioBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Socio current = (Socio)socioBindingSource.Current;

            if (_nuevasClaves.ContainsKey(current))
            {
                // La clave está modificada
                claveTxtBox.Text = _nuevasClaves[current];
                repetirClaveTxtBox.Text = _nuevasClavesRepeticion[current];
            }
            else
            {
                claveTxtBox.Text = _claveDefault;
                repetirClaveTxtBox.Text = _claveDefault;
            }

            ValidarClaveRepetida();
        }

        #endregion

        #region Métodos auxiliares

        private bool ValidarClaves()
        {
            foreach (KeyValuePair<Socio, string> entry in _nuevasClaves)
            {
                if (entry.Value == "")
                    return false;

                if (entry.Value != _nuevasClavesRepeticion[entry.Key])
                    return false;
            }

            return true;
        }

        private void ValidarClaveRepetida()
        {
            if (claveTxtBox.Text == "")
                errorProvider1.SetError(claveTxtBox, "Introduzca una clave");
            else
                errorProvider1.SetError(claveTxtBox, null);

            if (claveTxtBox.Text != repetirClaveTxtBox.Text)
                errorProvider1.SetError(repetirClaveTxtBox, "La clave repetida no coincide");
            else
                errorProvider1.SetError(repetirClaveTxtBox, null);

            Socio current = (Socio)socioBindingSource.Current;
            if (claveTxtBox.Text != _claveDefault || repetirClaveTxtBox.Text != _claveDefault)
            {
                if (_nuevasClaves.ContainsKey(current))
                {
                    _nuevasClaves[current] = claveTxtBox.Text;
                    _nuevasClavesRepeticion[current] = repetirClaveTxtBox.Text;
                }
                else
                {
                    _nuevasClaves.Add(current, claveTxtBox.Text);
                    _nuevasClavesRepeticion.Add(current, repetirClaveTxtBox.Text);
                }
            }

        }

        #endregion
        
    }
}
