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

namespace MSDNVideo.Tienda
{
    public partial class MainForm : Form
    {
        #region Campos

        private IPantalla       _pantallaActual = null;
        ToolStripPaginacion     _toolStripPaginacion;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Tratamiento de eventos

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Añadimos dinámicamente el control de paginación
            _toolStripPaginacion = new ToolStripPaginacion();
            toolStrip1.Items.Add(_toolStripPaginacion);
            _toolStripPaginacion.Alignment = ToolStripItemAlignment.Right;

            _toolStripPaginacion.PaginateChange += new PaginateChangeHandler(toolStripPaginateChange);

            MostrarComandosSoportados(0);

            IniciarSesion();
        }

        void toolStripPaginateChange(int first)
        {
            if (_pantallaActual.ConfirmarCierre())
                _pantallaActual.Paginar(first);
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            _pantallaActual.Guardar();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            _pantallaActual.Eliminar();
        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            _pantallaActual.Nuevo();
        }

        void OnMostrarInfoPaginacion(int primerRegistro, int registrosPagina, int totalRegistros)
        {
            _toolStripPaginacion.RegistrosPagina = registrosPagina;
            _toolStripPaginacion.TotalRegistros = totalRegistros;
            _toolStripPaginacion.InicioPagina = primerRegistro;
        }

        private void panelBotones_BotonClicked(int botonIndex)
        {
            switch (botonIndex)
            {
                case 0:
                    // Películas
                    MostrarPantalla(new PeliculasPanel());
                    break;
                case 1:
                    // Usuarios
                    MostrarPantalla(new UsuariosPanel());
                    break;
                case 2:
                    // Devoluciones
                    MostrarPantalla(new DevolucionesPanel());
                    break;
                case 3:
                    // Ventas y alquileres
                    MostrarPantalla(new VentaAlquilerPanel());
                    break;
                case 4:
                    // Recogidas
                    MostrarPantalla(new RecogidasPanel());
                    break;
                case 5:
                    // Notificaciones
                    MostrarPantalla(new NotificacionesPanel());
                    break;
                case 6:
                    // Puntuaciones
                    MostrarPantalla(new PuntuacionesPanel());
                    break;
            }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            _pantallaActual.Buscar();
        }

        private void iniciarSesionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IniciarSesion();
        }

        private void desconectarMenuItem_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void conectarMenuItem_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void salirMenuItem_Click(object sender, EventArgs e)
        {
            if (_pantallaActual == null)
                this.Close();
            else if(_pantallaActual.ConfirmarCierre())
                this.Close();
        }

        #endregion

        #region Métodos auxiliares

        private void IniciarSesion()
        {
            InicioSesionForm inicioSesionDlg = new InicioSesionForm();

            if (inicioSesionDlg.ShowDialog() == DialogResult.OK)
            {
                conectarMenuItem.Enabled = false;
                desconectarMenuItem.Enabled = true;
                tablaIniciarSesion.Visible = false;

                MostrarPantalla(new PeliculasPanel());

                panelBotones.GenerarInformes();
            }
        }

        private void CerrarSesion()
        {
            MostrarPantalla(null);
            tablaIniciarSesion.Visible = true;
            conectarMenuItem.Enabled = true;
            desconectarMenuItem.Enabled = false;

        }

        private void MostrarPantalla(UserControl pantalla)
        {
            if (_pantallaActual != null)
            {
                if ((_pantallaActual.ComandosSoportados & (int)ComandosPantalla.Paginacion) > 0)
                {
                    _pantallaActual.MostrarInfoPaginacion -= new MostrarInfoPaginacionHandler(OnMostrarInfoPaginacion);
                }

                _pantallaActual.ConfirmarCierre();
                ((IDisposable)_pantallaActual).Dispose();
            }

            _pantallaActual = (IPantalla)pantalla;
            if (pantalla != null)
            {
                pantalla.Dock = DockStyle.Fill;
                pantalla.Parent = splitContainer1.Panel2;

                // Info de paginación
                if ((_pantallaActual.ComandosSoportados & (int)ComandosPantalla.Paginacion) > 0)
                {
                    _pantallaActual.MostrarInfoPaginacion += new MostrarInfoPaginacionHandler(OnMostrarInfoPaginacion);
                }

                // Botones y opciones de menú
                MostrarComandosSoportados(_pantallaActual.ComandosSoportados);

                _pantallaActual.Refrescar();
            }
            else
                MostrarComandosSoportados(0);
        }

        private void MostrarComandosSoportados(int comandosSoportados)
        {
            // Info de paginación
            if ((comandosSoportados & (int)ComandosPantalla.Paginacion) > 0)
            {
                _toolStripPaginacion.Visible = true;
            }
            else
            {
                _toolStripPaginacion.Visible = false;
            }

            // Botones y opciones de menú
            if ((comandosSoportados & (int)ComandosPantalla.Buscar) > 0)
            {
                buscarButton.Visible = true;
            }
            else
            {
                buscarButton.Visible = false;
            }

            if ((comandosSoportados & (int)ComandosPantalla.Eliminar) > 0)
            {
                eliminarButton.Visible = true;
                eliminarMenuItem.Enabled = true;
            }
            else
            {
                eliminarButton.Visible = false;
                eliminarMenuItem.Enabled = false;
            }

            if ((comandosSoportados & (int)ComandosPantalla.Guardar) > 0)
            {
                guardarButton.Visible = true;
                guardarMenuItem.Enabled = true;
            }
            else
            {
                guardarButton.Visible = false;
                guardarMenuItem.Enabled = false;
            }

            if ((comandosSoportados & (int)ComandosPantalla.Nuevo) > 0)
            {
                nuevoButton.Visible = true;
                nuevoMenuItem.Enabled = true;
            }
            else
            {
                nuevoButton.Visible = false;
                nuevoMenuItem.Enabled = false;
            }

            if ((comandosSoportados & (int)ComandosPantalla.Refrescar) > 0)
            {
                refrescarButton.Visible = true;
                refrescarMenuItem.Enabled = true;
            }
            else
            {
                refrescarButton.Visible = false;
                refrescarMenuItem.Enabled = false;
            }
        }

        #endregion

    }
}
