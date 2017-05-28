using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace MSDNVideo.Tienda
{
    class DataGridViewRatingCell : DataGridViewTextBoxCell
    {
        public override Type EditType
        {
            get
            {
                return null;
            }
        }

        protected override void  Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Bitmap estrellaBmp = MSDNVideo.Tienda.Properties.Resources.Estrella;
            Rectangle rectEstrella = new Rectangle(cellBounds.X, cellBounds.Y + 2, (int)(estrellaBmp.Width * (cellBounds.Height - 4) / estrellaBmp.Height), cellBounds.Height - 4);
            int i;
            int widthValue;

            if (value == null)
                widthValue = 0;
            else
                widthValue = (int)((double)((decimal)value) * cellBounds.Width / 10d);

            graphics.FillRectangle(Brushes.White, cellBounds);
            graphics.SetClip(new Rectangle(cellBounds.X, cellBounds.Y, widthValue, cellBounds.Height));
            for (i = 0; i <= (int)(widthValue / rectEstrella.Width);i++ )
            {
                graphics.DrawImage(estrellaBmp, rectEstrella, new Rectangle(0, 0, estrellaBmp.Width, estrellaBmp.Height), GraphicsUnit.Pixel);
                rectEstrella.X += rectEstrella.Width;
            }

            graphics.ResetClip();

            string valor;
            valor = String.Format("{0:F1}", value);
            SizeF sizeText = graphics.MeasureString(valor, cellStyle.Font);
            graphics.DrawString(valor, cellStyle.Font, Brushes.Black, new Rectangle(cellBounds.X + (int)((cellBounds.Width - sizeText.Width) / 2), cellBounds.Y + (int)((cellBounds.Height - sizeText.Height) / 2), (int)(sizeText.Width) + 1, (int)(sizeText.Height) + 1));

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.Border);
        }

        protected override void  OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
         	 base.OnMouseClick(e);

            decimal value;
            DataGridViewCell cell;

            cell = this.DataGridView[e.ColumnIndex, e.RowIndex];
            value = (decimal)(11 * (e.Location.X - 1) / DataGridView.Columns[cell.ColumnIndex].Width);

            cell.Value = value;
            this.DataGridView.NotifyCurrentCellDirty(true);
        }

    }
}
