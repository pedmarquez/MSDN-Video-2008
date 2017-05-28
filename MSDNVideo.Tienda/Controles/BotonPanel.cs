using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MSDNVideo.Tienda
{
    public partial class BotonPanel : RadioButton
    {
        private bool _isMouseOver = false;
        private bool _lineaInferior = false;

        public BotonPanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Cursor = Cursors.Hand;
        }

        [Category("Appearance")]
        public bool LineaInferior
        {
            get { return _lineaInferior; }
            set { _lineaInferior = value; }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            Rectangle bounds = this.ClientRectangle;
            Pen p;

            // Colores
            Color gradientStop0 = Color.FromArgb(227, 239, 255);
            Color gradientStop1 = Color.FromArgb(196, 221, 255);
            Color gradientStop2 = Color.FromArgb(173, 209, 255);
            Color gradientStop3 = Color.FromArgb(192, 219, 255);

            if (this.Checked)
            {
                gradientStop0 = Color.FromArgb(255, 217, 170);
                gradientStop1 = Color.FromArgb(255, 187, 110);
                gradientStop2 = Color.FromArgb(255, 171, 63);
                gradientStop3 = Color.FromArgb(254, 225, 122);
            }
            else if (_isMouseOver)
            {
                gradientStop0 = Color.FromArgb(255, 254, 228);
                gradientStop1 = Color.FromArgb(255, 232, 167);
                gradientStop2 = Color.FromArgb(255, 215, 103);
                gradientStop3 = Color.FromArgb(255, 230, 158);
            }

            // Fondo
            using (LinearGradientBrush b = new LinearGradientBrush(bounds, gradientStop0, gradientStop2, LinearGradientMode.Vertical))
            {
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { gradientStop0, gradientStop1, gradientStop2, gradientStop3 };
                blend.Positions = new float[] { 0, .38f, .39f, 1 };

                b.InterpolationColors = blend;

                g.FillRectangle(b, bounds);
            }

            // Bordes
            using (p = new Pen(Color.FromArgb(101, 147, 207), 1))
            {
                g.DrawLine(p, bounds.X, bounds.Y, bounds.Width - 1, bounds.Y);
                
                if(_lineaInferior)
                    g.DrawLine(p, bounds.X, bounds.Y + bounds.Height - 1, bounds.Width - 1, bounds.Y + bounds.Height - 1);

                g.DrawLine(p, bounds.X, bounds.Y, bounds.X, bounds.Y + bounds.Height - 1);
                g.DrawLine(p, bounds.Width - 1, bounds.Y, bounds.Width - 1, bounds.Y + bounds.Height - 1);
            }

            // Imagen
            if (Image != null)
            {
                Rectangle imageBounds = new Rectangle(0, 0, Image.Width, Image.Height);
                imageBounds.X = this.Margin.Left;
                imageBounds.Y = (int)((bounds.Height - Image.Height) / 2);
                g.DrawImage(Image, imageBounds, new Rectangle(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
            }

            // Etiqueta
            using (SolidBrush b = new SolidBrush(ForeColor))
            {
                SizeF textSize = g.MeasureString(Text, Font);
                RectangleF textBounds = new RectangleF();
                textBounds.X = Margin.Left;
                textBounds.Y = (bounds.Height - textSize.Height) / 2;

                if (Image != null)
                    textBounds.X += Image.Width + 5;

                textBounds.Width = bounds.Width - textBounds.X;
                textBounds.Height = textSize.Height;

                StringFormat format = new StringFormat(StringFormatFlags.NoClip);
                format.Trimming = StringTrimming.EllipsisCharacter;
                g.DrawString(Text, Font, b, textBounds, format);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            _isMouseOver = true;
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            _isMouseOver = false;
        }
    }
}
