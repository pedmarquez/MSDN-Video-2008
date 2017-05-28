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
    public partial class PuntuacionesPanel : UserControl, IPantalla
    {
        #region Campos

        private DisconnectedDataContext<EntidadesDataContext>   _disconnectedDataContext;
        private FiltroPeliculas                                 _filtroActual;
        private const int                                       _registrosPorPagina = 10;

        #endregion

        #region Constructor

        public PuntuacionesPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Interfaz IPantalla

        public int ComandosSoportados
        {
            get
            {
                return (int)ComandosPantalla.Buscar |
                        (int)ComandosPantalla.ConfirmarCierre |
                        (int)ComandosPantalla.Guardar |
                        (int)ComandosPantalla.Paginacion |
                        (int)ComandosPantalla.Refrescar;
            }
        }

        public void Guardar()
        {
            peliculaBindingSource.EndEdit();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (changeSet.Validate())
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

            peliculas = ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculasPorFiltro(out total, _filtroActual, false, true);
            peliculaBindingSource.DataSource = peliculas;

            // Escuchamos los cambios en un DataContext desconectado
            _disconnectedDataContext = new DisconnectedDataContext<EntidadesDataContext>();
            _disconnectedDataContext.AttachList(peliculas);
            usuarioDataGridViewTextBoxColumn.LookupDataContext = _disconnectedDataContext;

            // Actualizamos info de paginación
            if (MostrarInfoPaginacion != null)
                MostrarInfoPaginacion(_filtroActual.InicioPagina, _registrosPorPagina, total);
        }

        public void Buscar()
        {
            BuscarPeliculasForm dlg = new BuscarPeliculasForm(_filtroActual);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _filtroActual = dlg.FiltroPeliculas;
                _filtroActual.PeliculasPagina = _registrosPorPagina;
            }

            Refrescar();
        }

        public bool ConfirmarCierre()
        {
            peliculaBindingSource.EndEdit();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (changeSet.HayCambios)
            {
                DialogResult dlgResult;
                dlgResult = MessageBox.Show("Ha realizado modificaciones en la lista de puntuaciones. ¿Desea guardarlas?",
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
            _filtroActual.InicioPagina = primerRegistro;
            Refrescar();
        }

        public event MostrarInfoPaginacionHandler MostrarInfoPaginacion;

        #endregion

        #region Tratamiento de eventos

        private void PuntuacionesPanel_Load(object sender, EventArgs e)
        {
            // Filtro por defecto
            _filtroActual = new FiltroPeliculas();
            _filtroActual.InicioPagina = 0;
            _filtroActual.PeliculasPagina = _registrosPorPagina;
            _filtroActual.IncluirTotal = true;

            usuarioDataGridViewTextBoxColumn.EntityConverter = typeof(SocioConverter);
            usuarioDataGridViewTextBoxColumn.LookupDialogForm = typeof(SeleccionSocioForm);

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

        #endregion

    }
}
