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
    public partial class RecogidasPanel : UserControl, IPantalla
    {

        #region Constructor

        public RecogidasPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Intefaz IPantalla

        public int ComandosSoportados
        {
            get
            {
                return (int)ComandosPantalla.ConfirmarCierre |
                        (int)ComandosPantalla.Refrescar;
            }
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public void Nuevo()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Refrescar()
        {
            BindingList<Alquiler> alquileres;

            alquileres = ConnectionHelper.ServiceClient.ObtenerAlquileresSinRecoger(true, true);
            alquilerBindingSource.DataSource = alquileres;

        }

        public void Buscar()
        {
            throw new NotImplementedException();
        }

        public bool ConfirmarCierre()
        {
            return true;
        }

        public void Paginar(int primerRegistro)
        {
            throw new NotImplementedException();
        }

        public event MostrarInfoPaginacionHandler MostrarInfoPaginacion;

        #endregion

        #region Tratamiento de eventos

        private void alquilerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Alquiler alquiler = (Alquiler)alquilerBindingSource.Current;
            string codBarras;

            // Cambiamos carátula película
            if (alquiler != null)
            {
                codBarras = alquiler.Pelicula.CodBarras;
                recogerButton.Enabled = true;
            }
            else
            {
                codBarras = null;
                recogerButton.Enabled = false;
            }

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

        private void RecogidasPanel_Load(object sender, EventArgs e)
        {
            usuarioDataGridViewTextBoxColumn.EntityConverter = typeof(SocioConverter);
            peliculaDataGridViewTextBoxColumn.EntityConverter = typeof(PeliculaConverter);
        }

        private void recogerButton_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = (Alquiler)alquilerBindingSource.Current;
            ConnectionHelper.ServiceClient.RecogerPelicula(alquiler.Usuario.NIF, alquiler.Pelicula.CodBarras);

            MessageBox.Show("Se realizó la recogida correctamente", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refrescar();
        }

        #endregion

        #region Convertidores de entidad para rejilla

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
    }
}
