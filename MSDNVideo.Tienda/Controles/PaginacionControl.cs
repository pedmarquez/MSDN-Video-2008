using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSDNVideo.Tienda
{
    public delegate void PaginateChangeHandler(int first);

    public partial class PaginacionControl : UserControl
    {
        int _inicioPagina;
        int _registrosPagina;
        int _totalRegistros;

        public event PaginateChangeHandler PaginateChange;

        public PaginacionControl()
        {
            InitializeComponent();
        }

        public int InicioPagina
        {
            get
            {
                return _inicioPagina;
            }
            set
            {
                _inicioPagina = value;
                UpdateValues();
            }
        }

        public int RegistrosPagina
        {
            get
            {
                return _registrosPagina;
            }
            set
            {
                _registrosPagina = value;
                UpdateValues();
            }
        }

        public int TotalRegistros
        {
            get
            {
                return _totalRegistros;
            }
            set
            {
                _totalRegistros = value;
                UpdateValues();
            }
        }

        private void UpdateValues()
        {
            int al;

            al = _inicioPagina + _registrosPagina;
            if (al > _totalRegistros)
                al = _totalRegistros;

            firstTxtBox.Text = _inicioPagina.ToString();
            paginaLbl.Text = "al " + al.ToString() + " de " + _totalRegistros.ToString();
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            _inicioPagina = 0;
            RaisePaginationEvent();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            _inicioPagina -= _registrosPagina;
            if (_inicioPagina < 0)
                _inicioPagina = 0;

            RaisePaginationEvent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _inicioPagina += _registrosPagina;
            if (_inicioPagina > _totalRegistros)
                _inicioPagina -= _registrosPagina;

            RaisePaginationEvent();
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            _inicioPagina = _totalRegistros - _registrosPagina;
            if (_inicioPagina < 0)
                _inicioPagina = 0;

            RaisePaginationEvent();
        }

        private void RaisePaginationEvent()
        {
            if (PaginateChange != null)
                PaginateChange(_inicioPagina);
        }

        private void firstTxtBox_Leave(object sender, EventArgs e)
        {
            int first;

            if (int.TryParse(firstTxtBox.Text, out first))
            {
                if (first > _totalRegistros)
                    first = _totalRegistros - _registrosPagina;
                if (first < 0)
                    first = 0;

                _inicioPagina = first;
                RaisePaginationEvent();
            }
        }
    }
}
