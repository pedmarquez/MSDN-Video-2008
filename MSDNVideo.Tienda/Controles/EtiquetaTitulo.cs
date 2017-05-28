using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MSDNVideo.Tienda
{
    public partial class EtiquetaTitulo : UserControl
    {
        public EtiquetaTitulo()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public Image Image
        {
            get
            {
                return iconoPicture.Image;
            }
            set
            {
                iconoPicture.Image = value;
            }
        }

        public string Titulo
        {
            get
            {
                return tituloLabel.Text;
            }
            set
            {
                tituloLabel.Text = value;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = this.ClientRectangle;

            // Colores
            Color gradientBegin = Color.FromArgb(89, 135, 214);
            Color gradientEnd = Color.FromArgb(0, 45, 150);

            using (LinearGradientBrush b = new LinearGradientBrush(bounds, gradientBegin, gradientEnd, LinearGradientMode.Vertical))
            {
                g.FillRectangle(b, bounds);
            }
        }
    }
}
