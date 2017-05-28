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
    public partial class BuscarPeliculasForm : Form
    {
        private FiltroPeliculas _filtroPeliculas;

        public BuscarPeliculasForm(FiltroPeliculas filtroPeliculas)
        {
            InitializeComponent();

            _filtroPeliculas = new FiltroPeliculas();
            _filtroPeliculas.CodBarras = filtroPeliculas.CodBarras;
            _filtroPeliculas.Titulo = filtroPeliculas.Titulo;
            _filtroPeliculas.Genero = filtroPeliculas.Genero;
            _filtroPeliculas.Clasificacion = filtroPeliculas.Clasificacion;
            _filtroPeliculas.Novedad = filtroPeliculas.Novedad;
            _filtroPeliculas.CamposFiltrado = filtroPeliculas.CamposFiltrado;
            _filtroPeliculas.IncluirTotal = filtroPeliculas.IncluirTotal;
            _filtroPeliculas.InicioPagina = 0;
        }

        public FiltroPeliculas FiltroPeliculas
        {
            get
            {
                return _filtroPeliculas;
            }
        }

        private void UpdateValues()
        {
            if ((_filtroPeliculas.CamposFiltrado & (int)CamposFiltro.CodBarras) > 0)
            {
                codBarrasChkBox.Checked = true;
                codBarrasTxtBox.Text = _filtroPeliculas.CodBarras;
            }

            if ((_filtroPeliculas.CamposFiltrado & (int)CamposFiltro.Titulo) > 0)
            {
                tituloChkBox.Checked = true;
                tituloTxtBox.Text = _filtroPeliculas.Titulo;
            }

            if ((_filtroPeliculas.CamposFiltrado & (int)CamposFiltro.Genero) > 0)
            {
                generoChkBox.Checked = true;
                generoCmbBox.SelectedIndex = (int)_filtroPeliculas.Genero;
            }

            if ((_filtroPeliculas.CamposFiltrado & (int)CamposFiltro.Clasificacion) > 0)
            {
                clasificacionChkBox.Checked = true;
                clasificacionCmbBox.SelectedIndex = (int)_filtroPeliculas.Clasificacion;
            }

            if ((_filtroPeliculas.CamposFiltrado & (int)CamposFiltro.Novedad) > 0)
            {
                novedadesChkBox.Checked = true;
                if (_filtroPeliculas.Novedad)
                    novedadesCmbBox.SelectedIndex = 0;
                else
                    novedadesCmbBox.SelectedIndex = 1;
            }
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            _filtroPeliculas.CamposFiltrado = 0;
            if (codBarrasChkBox.Checked)
            {
                _filtroPeliculas.CamposFiltrado += (int)CamposFiltro.CodBarras;
                _filtroPeliculas.CodBarras = codBarrasTxtBox.Text;
            }
            if (tituloChkBox.Checked)
            {
                _filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Titulo;
                _filtroPeliculas.Titulo = tituloTxtBox.Text;
            }
            if (generoChkBox.Checked)
            {
                _filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Genero;
                _filtroPeliculas.Genero = (Generos)generoCmbBox.SelectedIndex;
            }
            if (clasificacionChkBox.Checked)
            {
                _filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Clasificacion;
                _filtroPeliculas.Clasificacion = (Clasificaciones)clasificacionCmbBox.SelectedIndex;
            }
            if (novedadesChkBox.Checked)
            {
                _filtroPeliculas.CamposFiltrado += (int)CamposFiltro.Novedad;
                if(novedadesCmbBox.SelectedIndex == 0)
                    _filtroPeliculas.Novedad = true;
                else
                    _filtroPeliculas.Novedad = false;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
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
            UpdateValues();

            generoCmbBox.SelectedIndex = 0;
            clasificacionCmbBox.SelectedIndex = 0;
            novedadesCmbBox.SelectedIndex = 0;
        }
    }
}
