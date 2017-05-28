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
    public partial class DevolucionesPanel : UserControl, IPantalla
    {
        #region "Constructor"

        public DevolucionesPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region "Tratamiento de eventos"

        private void DevolucionesPanel_Load(object sender, EventArgs e)
        {
            usuarioDataGridViewTextBoxColumn.EntityConverter = typeof(SocioConverter);
            peliculaDataGridViewTextBoxColumn.EntityConverter = typeof(PeliculaConverter);
        }

        private void alquilerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Alquiler alquiler = (Alquiler)alquilerBindingSource.Current;
            string codBarras;

            // Cambiamos carátula película
            if (alquiler != null)
            {
                codBarras = alquiler.Pelicula.CodBarras;
                devolverButton.Enabled = true;
            }
            else
            {
                codBarras = null;
                devolverButton.Enabled = false;
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

        private void devolverButton_Click(object sender, EventArgs e)
        {
            EstadoPedido estadoPedido;
            Historico historico;
            Alquiler alquiler = (Alquiler)alquilerBindingSource.Current;
            estadoPedido = ConnectionHelper.ServiceClient.DevolverPelicula(out historico, alquiler.Usuario.NIF, alquiler.Pelicula.CodBarras);

            if (estadoPedido == EstadoPedido.Realizado)
            {
                MessageBox.Show("Se realizó la devolución correctamente", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refrescar();
            }
            else if (estadoPedido == EstadoPedido.SaldoInsuficiente)
            {
                MessageBox.Show("El socio no dispone de saldo suficiente para la devolución", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Se produjo un error de concurrencia. Inténtelo más tarde.", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Interfaz IPantalla

        public int ComandosSoportados
        {
            get
            {
                return  (int)ComandosPantalla.ConfirmarCierre |
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

            alquileres = ConnectionHelper.ServiceClient.ObtenerAlquileresSinDevolver(true, true);
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

        #region "Convertidores para la rejilla"

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
