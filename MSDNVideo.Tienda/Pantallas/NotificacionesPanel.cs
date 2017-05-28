using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Comun;
using System.IO;

namespace MSDNVideo.Tienda
{
    public partial class NotificacionesPanel : UserControl, IPantalla
    {
        #region "Campos"

        private DisconnectedDataContext<EntidadesDataContext> _disconnectedDataContext;

        #endregion

        #region "Constructor"

        public NotificacionesPanel()
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
            notificacionBindingSource.EndEdit();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (changeSet.Validate() && ValidarNIFSocio() && ValidarCodBarrasPelicula())
            {
                if (changeSet.HayCambios)
                {
                    // Guardo el changeset
                    ConnectionHelper.ServiceClient.ChangeSet_ActualizarChangeSet(changeSet);

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
            Notificacion notificacion = (Notificacion)notificacionBindingSource.AddNew();
            caratulaPicture.Image = null;
            notificacion.FechaAlta = DateTime.Now;

            ValidarCodBarrasPelicula();
            ValidarNIFSocio();
        }

        public void Eliminar()
        {
            notificacionBindingSource.RemoveCurrent();
        }

        public void Refrescar()
        {
            BindingList<Notificacion> notificaciones;

            notificaciones = ConnectionHelper.ServiceClient.Notificaciones_ObtenerNotificaciones(true, true);
            notificacionBindingSource.DataSource = notificaciones;

            // Escuchamos los cambios en un DataContext desconectado
            _disconnectedDataContext = new DisconnectedDataContext<EntidadesDataContext>();
            _disconnectedDataContext.AttachList(notificaciones);
        }

        public void Buscar()
        {
            throw new NotImplementedException();
        }

        public bool ConfirmarCierre()
        {
            notificacionBindingSource.EndEdit();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (changeSet.HayCambios)
            {
                DialogResult dlgResult;
                dlgResult = MessageBox.Show("Ha realizado modificaciones en la lista de notificaciones. ¿Desea guardarlas?",
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

        private void NotificacionesPanel_Load(object sender, EventArgs e)
        {
            socioDataGridViewTextBoxColumn.EntityConverter = typeof(SocioConverter);
            peliculaDataGridViewTextBoxColumn.EntityConverter = typeof(PeliculaConverter);

            // Binding de ComboBoxes
            tipoNotificacionCmbBox.DataBindings.Add(new Binding("SelectedIndex", notificacionBindingSource, "TipoNotificacion"));
        }

        private void nifTxtBox_Leave(object sender, EventArgs e)
        {
            // Lookup de socio
            ValidarNIFSocio();
        }

        private void selSocioButton_Click(object sender, EventArgs e)
        {
            SeleccionSocioForm socioDlg = new SeleccionSocioForm();

            if (socioDlg.ShowDialog() == DialogResult.OK)
            {
                EstablecerSocio(socioDlg.SelectedSocio);
                errorProvider1.SetError(selSocioButton, null);
            }
        }

        private void selPeliculaButton_Click(object sender, EventArgs e)
        {
            SeleccionPeliculaForm peliculaDlg = new SeleccionPeliculaForm();

            if (peliculaDlg.ShowDialog() == DialogResult.OK)
            {
                EstablecerPelicula(peliculaDlg.SelectedPelicula);
                errorProvider1.SetError(selPeliculaButton, null);
            }
        }

        private void codBarrasTxtBox_Leave(object sender, EventArgs e)
        {
            // Lookup de película
            ValidarCodBarrasPelicula();
        }

        private void notificacionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            UpdateCaratula();
        }

        #endregion

        #region Convertidores para rejilla

        public class SocioConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                return ((Socio)value).Nombre;
            }
        }

        public class PeliculaConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                return ((Pelicula)value).Titulo;
            }
        }

        #endregion

        #region Métodos auxiliares

        private bool ValidarNIFSocio()
        {
            Socio socio;
            string nif = nifTxtBox.Text;
            
            if (nif != "")
                socio = ConnectionHelper.ServiceClient.Usuarios_ObtenerSocioPorNIF(nif);
            else
                socio = null;

            EstablecerSocio(socio);
            nifTxtBox.Text = nif;

            if (socio == null)
            {
                errorProvider1.SetError(selSocioButton, "Introduzca un NIF de socio válido");
                return false;
            }
            else
            {
                errorProvider1.SetError(selSocioButton, null);
                return true;
            }
        }

        private bool ValidarCodBarrasPelicula()
        {
            Pelicula pelicula;
            string codBarras = codBarrasTxtBox.Text;

            if (codBarras != "")
                pelicula = ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculaPorCodBarras(codBarras, false, false);
            else
                pelicula = null;

            EstablecerPelicula(pelicula);
            codBarrasTxtBox.Text = codBarras;

            if (pelicula == null)
            {
                errorProvider1.SetError(selPeliculaButton, "Introduzca un código de barras de película válido");
                return false;
            }
            else
            {
                errorProvider1.SetError(selPeliculaButton, null);
                return true;
            }
        }

        private void EstablecerSocio(Socio socio)
        {
            if(socio != null)
                socio = (Socio)_disconnectedDataContext.Attach(socio);

            Notificacion notificacion = (Notificacion)notificacionBindingSource.Current;
            if(notificacion != null)
                notificacion.Usuario = socio;
        }

        private void EstablecerPelicula(Pelicula pelicula)
        {
            if (pelicula != null)
                pelicula = (Pelicula)_disconnectedDataContext.Attach(pelicula);

            Notificacion notificacion = (Notificacion)notificacionBindingSource.Current;
            notificacion.Pelicula = pelicula;

            UpdateCaratula();
        }

        private void UpdateCaratula()
        {
            Notificacion notificacion = (Notificacion)notificacionBindingSource.Current;
            string codBarras;

            if (notificacion != null && notificacion.Pelicula != null)
                codBarras = notificacion.Pelicula.CodBarras;
            else
                codBarras = null;

            if (codBarras != null)
            {
                byte[] buffer = ConnectionHelper.ServiceClient.Peliculas_ObtenerCaratula(codBarras, 0, 0);
                if (buffer != null)
                {
                    Bitmap caratula = new Bitmap(new MemoryStream(buffer));
                    caratulaPicture.Image = caratula;
                }
                else
                    caratulaPicture.Image = null;
            }
            else
                caratulaPicture.Image = null;
        }

        #endregion
    }
}
