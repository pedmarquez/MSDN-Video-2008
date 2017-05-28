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
    public partial class SeleccionPeliculaForm : Form
    {
        private Pelicula _selectedPelicula;

        public SeleccionPeliculaForm()
        {
            InitializeComponent();
        }

        public Pelicula SelectedPelicula
        {
            get
            {
                return _selectedPelicula;
            }
        }

        private void codBarrasChkBox_CheckedChanged(object sender, EventArgs e)
        {
            codBarrasTxtBox.Enabled = codBarrasChkBox.Checked;
        }

        private void tituloChkBox_CheckedChanged(object sender, EventArgs e)
        {
            tituloTxtBox.Enabled = tituloChkBox.Checked;
        }

        private void generoChkBox_CheckedChanged(object sender, EventArgs e)
        {
            generoCmbBox.Enabled = generoChkBox.Checked;
        }

        private void clasificacionChkBox_CheckedChanged(object sender, EventArgs e)
        {
            clasificacionCmbBox.Enabled = clasificacionChkBox.Checked;
        }

        private void novedadesChkBox_CheckedChanged(object sender, EventArgs e)
        {
            novedadesCmbBox.Enabled = novedadesChkBox.Checked;
        }

        private void BuscarPeliculasForm_Load(object sender, EventArgs e)
        {
            generoCmbBox.SelectedIndex = 0;
            clasificacionCmbBox.SelectedIndex = 0;
            novedadesCmbBox.SelectedIndex = 0;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            FiltroPeliculas filtroPeliculas = new FiltroPeliculas();
            int total;

            filtroPeliculas.CamposFiltrado = 0;
            if (codBarrasChkBox.Checked)
            {
                filtroPeliculas.CamposFiltrado += (int)CamposFiltro.CodBarras;
                filtroPeliculas.CodBarras = codBarrasTxtBox.Text;
            }
            if (tituloChkBox.Checked)
            {
                filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Titulo;
                filtroPeliculas.Titulo = tituloTxtBox.Text;
            }
            if (generoChkBox.Checked)
            {
                filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Genero;
                filtroPeliculas.Genero = (Generos)generoCmbBox.SelectedIndex;
            }
            if (clasificacionChkBox.Checked)
            {
                filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Clasificacion;
                filtroPeliculas.Clasificacion = (Clasificaciones)clasificacionCmbBox.SelectedIndex;
            }
            if (novedadesChkBox.Checked)
            {
                filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Novedad;
                if (novedadesCmbBox.SelectedIndex == 0)
                    filtroPeliculas.Novedad = true;
                else
                    filtroPeliculas.Novedad = false;
            }

            BindingList<Pelicula> peliculas = ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculasPorFiltro(out total, filtroPeliculas, false, false);
            peliculaBindingSource.DataSource = peliculas;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            _selectedPelicula = (Pelicula)peliculaBindingSource.Current;

            if (_selectedPelicula == null)
            {
                MessageBox.Show("Seleccione una película existente", "MSDN Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
