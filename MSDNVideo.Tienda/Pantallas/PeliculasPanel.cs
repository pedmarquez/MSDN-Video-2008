using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Tienda.MSDNVideoServices;
using MSDNVideo.Comun;
using System.IO;
using System.Drawing.Imaging;

namespace MSDNVideo.Tienda
{
    public partial class PeliculasPanel : UserControl, IPantalla
    {
        #region Campos

        private DisconnectedDataContext<EntidadesDataContext>   _disconnectedDataContext;
        private Dictionary<Pelicula, Bitmap>                    _nuevasCaratulas = new Dictionary<Pelicula,Bitmap>();
        private FiltroPeliculas                                 _filtroActual;
        private const int                                       _registrosPorPagina = 10;

        #endregion

        #region Constructor

        public PeliculasPanel()
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
                        (int)ComandosPantalla.Eliminar |
                        (int)ComandosPantalla.Guardar |
                        (int)ComandosPantalla.Nuevo |
                        (int)ComandosPantalla.Paginacion |
                        (int)ComandosPantalla.Refrescar;
            }
        }

        public void Guardar()
        {
            peliculasBindingSource.EndEdit();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (changeSet.Validate())
            {
                if (changeSet.HayCambios || _nuevasCaratulas.Count > 0)
                {
                    // Guardo el changeset
                    ConnectionHelper.ServiceClient.ChangeSet_ActualizarChangeSet(changeSet);

                    // Almacenamos carátulas
                    foreach(KeyValuePair<Pelicula, Bitmap> entry in _nuevasCaratulas)
                    {
                        MemoryStream stream = new MemoryStream();
                        entry.Value.Save(stream, ImageFormat.Jpeg);
                        ConnectionHelper.ServiceClient.Peliculas_ModificarCaratula(stream.ToArray(), entry.Key.CodBarras);
                    }

                    // Refrescamos
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show("Corrija la información no válida antes de guardar", "MSDN Video",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Nuevo()
        {
            peliculasBindingSource.AddNew();
            caratulaPicture.Image = null;
        }

        public void Eliminar()
        {
            peliculasBindingSource.RemoveCurrent();
        }

        public void Refrescar()
        {
            BindingList<Pelicula> peliculas;
            int total;

            peliculas = ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculasPorFiltro(out total, _filtroActual, true, false);
            peliculasBindingSource.DataSource = peliculas;
            _nuevasCaratulas.Clear();

            // Escuchamos los cambios en un DataContext desconectado
            _disconnectedDataContext = new DisconnectedDataContext<EntidadesDataContext>();
            _disconnectedDataContext.AttachList(peliculas);

            actorDataGridViewTextBoxColumn.LookupDataContext = _disconnectedDataContext;

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
            peliculasBindingSource.EndEdit();

            DisconnectedChangeSet changeSet = _disconnectedDataContext.GetChangeSet();
            if (_nuevasCaratulas.Count > 0 || changeSet.HayCambios)
            {
                DialogResult dlgResult;
                dlgResult = MessageBox.Show("Ha realizado modificaciones en la lista de películas. ¿Desea guardarlas?",
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

        private void PeliculasPanel_Load(object sender, EventArgs e)
        {
            // Filtro por defecto
            _filtroActual = new FiltroPeliculas();
            _filtroActual.InicioPagina = 0;
            _filtroActual.PeliculasPagina = _registrosPorPagina;
            _filtroActual.IncluirTotal = true;

            // Binding de ComboBoxes
            clasificacionCmbBox.DataBindings.Add(new Binding("SelectedIndex", peliculasBindingSource, "Clasificacion"));
            generoCmbBox.DataBindings.Add(new Binding("SelectedIndex", peliculasBindingSource, "Genero"));

            // Inicialización de diálogos Lookup en las rejillas
            actorDataGridViewTextBoxColumn.LookupDialogForm = typeof(SeleccionActorForm);
            actorDataGridViewTextBoxColumn.EntityConverter = typeof(ActorConverter);
        }

        private void peliculaDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            // Cambiamos carátula película
            Pelicula pelicula = (Pelicula)peliculasBindingSource.Current;

            if(_nuevasCaratulas.ContainsKey(pelicula))
            {
                // La caratúla está modificada
                caratulaPicture.Image = _nuevasCaratulas[pelicula];
            }
            else
            {
                // La carátula no está modificada, la buscamos en el servidor
                string codBarras;

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
        }

        private void caratulaButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "ficheros jpg (*.jpg)|*.jpg";
            
            if(fileDlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(fileDlg.FileName);
                caratulaPicture.Image = bmp;

                Pelicula pelicula = (Pelicula)peliculasBindingSource.Current;
                if(_nuevasCaratulas.ContainsKey(pelicula))
                    _nuevasCaratulas[pelicula] = bmp;
                else
                    _nuevasCaratulas.Add(pelicula, bmp);
            }
        }

        #endregion

        #region Convertidores para rejilla

        public class ActorConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                return ((Actor)value).Nombre;
            }
        }

        #endregion

    }
}
