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
    public partial class VentaAlquilerPanel : UserControl, IPantalla
    {
        #region Campos

        private FiltroPeliculas     _filtroActual;
        private const int           _registrosPorPagina = 10;

        #endregion

        #region Constructor

        public VentaAlquilerPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Interfaz IPantalla

        public int ComandosSoportados
        {
            get
            {
                return  (int)ComandosPantalla.ConfirmarCierre |
                        (int)ComandosPantalla.Paginacion |
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
            BindingList<Pelicula> peliculas;
            int total;

            peliculas = ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculasPorFiltro(out total, _filtroActual, false, false);
            peliculasBindingSource.DataSource = peliculas;

            socioBindingSource.DataSource = typeof(Socio);

            // Actualizamos info de paginación
            if (MostrarInfoPaginacion != null)
                MostrarInfoPaginacion(_filtroActual.InicioPagina, _registrosPorPagina, total);
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
            _filtroActual.InicioPagina = primerRegistro;
            Refrescar();
        }

        public event MostrarInfoPaginacionHandler MostrarInfoPaginacion;

        #endregion

        #region Tratamiento de eventos

        private void VentaAlquilerPanel_Load(object sender, EventArgs e)
        {
            // Filtro por defecto
            _filtroActual = new FiltroPeliculas();
            _filtroActual.InicioPagina = 0;
            _filtroActual.PeliculasPagina = _registrosPorPagina;
            _filtroActual.IncluirTotal = true;
        }

        private void peliculasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Pelicula pelicula = (Pelicula)peliculasBindingSource.Current;
            string codBarras;

            // Cambiamos carátula película
            codBarras = pelicula.CodBarras;
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

        private void selSocioButton_Click(object sender, EventArgs e)
        {
            SeleccionSocioForm socioDlg = new SeleccionSocioForm();

            if (socioDlg.ShowDialog() == DialogResult.OK)
            {
                EstablecerSocio(socioDlg.SelectedSocio);
            }
        }

        private void nifTxtBox_Leave(object sender, EventArgs e)
        {
            ValidarNIF();
        }

        private void comprarButton_Click(object sender, EventArgs e)
        {
            EstadoPedido estadoPedido;

            if (ValidarNIF())
            {
                Socio socio = (Socio)socioBindingSource.Current;
                Pelicula pelicula = (Pelicula)peliculasBindingSource.Current;

                estadoPedido = ConnectionHelper.ServiceClient.ComprarPelicula(socio.NIF, pelicula.CodBarras);
                if (estadoPedido == EstadoPedido.Realizado)
                {
                    MessageBox.Show("Se realizó la compra correctamente", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refrescar();
                }

            }
            else
            {
                MessageBox.Show("Corrija la información no válida antes de guardar", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void alquilarButton_Click(object sender, EventArgs e)
        {
            EstadoPedido estadoPedido;

            if (ValidarNIF())
            {
                Socio socio = (Socio)socioBindingSource.Current;
                Pelicula pelicula = (Pelicula)peliculasBindingSource.Current;

                estadoPedido = ConnectionHelper.ServiceClient.AlquilarPelicula(socio.NIF, pelicula.CodBarras);
                if (estadoPedido == EstadoPedido.Realizado)
                {
                    if (clienteRecogeChkBox.Checked)
                        ConnectionHelper.ServiceClient.RecogerPelicula(socio.NIF, pelicula.CodBarras);

                    MessageBox.Show("Se realizó el alquiler correctamente", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Refrescar();
                }

            }
            else
            {
                MessageBox.Show("Corrija la información no válida antes de guardar", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Métodos auxiliares

        private void EstablecerSocio(Socio socio)
        {
            BindingList<Socio> socios = socioBindingSource.DataSource as BindingList<Socio>;
            if (socios == null)
            {
                socios = new BindingList<Socio>();
                socios.Add(socio);
                socioBindingSource.DataSource = socios;
            }
            else
            {
                socios[0] = socio;
            }
        }

        private bool ValidarNIF()
        {
            // Realizamos un lookup del NIF del socio
            Socio socio = ConnectionHelper.ServiceClient.Usuarios_ObtenerSocioPorNIF(nifTxtBox.Text);
            if (socio == null)
            {
                EstablecerSocio(null);
                errorProvider1.SetError(selSocioButton, "El NIF introducido no corresponde con ningún socio");
                return false;
            }
            else
            {
                EstablecerSocio(socio);
                errorProvider1.SetError(selSocioButton, null);
                return true;
            }
        }

        #endregion

    }
}
