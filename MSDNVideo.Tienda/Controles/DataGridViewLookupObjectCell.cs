using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Comun;
using System.Drawing;
using System.ComponentModel;

namespace MSDNVideo.Tienda
{
    public class DataGridViewLookupObjectValue
    {
        public object Object;
        public string FormattedValue;
        public TypeConverter Converter;

        public DataGridViewLookupObjectValue(object obj, TypeConverter converter)
        {
            Object = obj;
            Converter = converter;
        }

        public override string ToString()
        {
            if (FormattedValue != null)
                return FormattedValue;
            else if (Object != null)
                return (string)Converter.ConvertTo(Object, typeof(string));
            else
                return string.Empty;
        }

    }

    public class DataGridViewLookupObjectCell : DataGridViewCell
    {
        public DataGridViewLookupObjectCell()
        {
        }

        public override void  InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            LookupControl lookUpControl;
            DataGridViewLookupColumn column;

 	        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            column = (DataGridViewLookupColumn)this.OwningColumn;

            lookUpControl = (LookupControl)(this.DataGridView.EditingControl);
            lookUpControl.LookupDialogForm = column.LookupDialogForm;
            lookUpControl.EntityConverter = column.EntityConverter;
            lookUpControl.IsObjectLookup = true;
            lookUpControl.LookupDataContext = column.LookupDataContext;

            lookUpControl.Value = this.Value;
        }


        public override Type EditType
        {
            get { return typeof(LookupControl); }
        }

        public override Type FormattedValueType
        {
            get
            {
                return typeof(DataGridViewLookupObjectValue);
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            DataGridViewLookupColumn column;

            column = (DataGridViewLookupColumn)this.OwningColumn;

            if (value != null)
            {
                if (!(value is DataGridViewLookupObjectValue))
                    return new DataGridViewLookupObjectValue(value, (TypeConverter)Activator.CreateInstance(column.EntityConverter));
                else
                    return value;
            }
            else
            {
                return new DataGridViewLookupObjectValue(null, (TypeConverter)Activator.CreateInstance(column.EntityConverter));
            }
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
        {
            if (formattedValue != null)
                return ((DataGridViewLookupObjectValue)formattedValue).Object;
            else
                return null;
        }

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            SolidBrush backBrush;
            Rectangle empty = Rectangle.Empty;
            string text;
            
            this.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);

            Rectangle rectangle2 = this.BorderWidths(advancedBorderStyle);
            Rectangle rect = cellBounds;
            rect.Offset(rectangle2.X, rectangle2.Y);
            rect.Width -= rectangle2.Right;
            rect.Height -= rectangle2.Bottom;
            Point currentCellAddress = base.DataGridView.CurrentCellAddress;
            bool flag = (currentCellAddress.X == base.ColumnIndex) && (currentCellAddress.Y == rowIndex);
            bool flag2 = flag && (base.DataGridView.EditingControl != null);
            bool flag3 = (cellState & DataGridViewElementStates.Selected) != DataGridViewElementStates.None;
            if (((paintParts & DataGridViewPaintParts.SelectionBackground) != DataGridViewPaintParts.None && flag3) && !flag2)
            {
                backBrush = new SolidBrush(cellStyle.SelectionBackColor);
            }
            else
            {
                backBrush = new SolidBrush(cellStyle.BackColor);
            }
            graphics.FillRectangle(backBrush, rect);

            if (cellStyle.Padding != Padding.Empty)
            {
                rect.Offset(cellStyle.Padding.Left, cellStyle.Padding.Top);
                rect.Width -= cellStyle.Padding.Horizontal;
                rect.Height -= cellStyle.Padding.Vertical;
            }
            Rectangle cellValueBounds = rect;

            if (formattedValue is DataGridViewLookupObjectValue && formattedValue != null)
                text = formattedValue.ToString();
            else
                text = null;

            if ((text != null) && !flag2)
            {
                int y = (cellStyle.WrapMode == DataGridViewTriState.True) ? 1 : 2;
                rect.Offset(0, y);
                rect.Width = rect.Width;
                rect.Height -= y + 1;
                if ((rect.Width > 0) && (rect.Height > 0))
                {
                    TextFormatFlags flags = ComputeTextFormatFlagsForCellStyleAlignment(cellStyle.Alignment, cellStyle.WrapMode);
                    if ((flags & TextFormatFlags.SingleLine) != TextFormatFlags.GlyphOverhangPadding)
                    {
                        flags |= TextFormatFlags.EndEllipsis;
                    }
                    TextRenderer.DrawText(graphics, text, cellStyle.Font, rect, flag3 ? cellStyle.SelectionForeColor : cellStyle.ForeColor, flags);
                }
            }
        }

        private TextFormatFlags ComputeTextFormatFlagsForCellStyleAlignment(DataGridViewContentAlignment alignment, DataGridViewTriState wrapMode)
        {
            TextFormatFlags glyphOverhangPadding;
            switch (alignment)
            {
                case DataGridViewContentAlignment.TopLeft:
                    glyphOverhangPadding = TextFormatFlags.GlyphOverhangPadding;
                    break;

                case DataGridViewContentAlignment.TopCenter:
                    glyphOverhangPadding = TextFormatFlags.HorizontalCenter;
                    break;

                case DataGridViewContentAlignment.TopRight:
                    glyphOverhangPadding = TextFormatFlags.GlyphOverhangPadding;
                    glyphOverhangPadding |= TextFormatFlags.Right;
                    break;

                case DataGridViewContentAlignment.MiddleLeft:
                    glyphOverhangPadding = TextFormatFlags.VerticalCenter;
                    break;

                case DataGridViewContentAlignment.MiddleCenter:
                    glyphOverhangPadding = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    break;

                case DataGridViewContentAlignment.BottomCenter:
                    glyphOverhangPadding = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;

                case DataGridViewContentAlignment.BottomRight:
                    glyphOverhangPadding = TextFormatFlags.Bottom;
                    break;

                case DataGridViewContentAlignment.MiddleRight:
                    glyphOverhangPadding = TextFormatFlags.VerticalCenter;
                    break;

                case DataGridViewContentAlignment.BottomLeft:
                    glyphOverhangPadding = TextFormatFlags.Bottom;
                    glyphOverhangPadding |= TextFormatFlags.Right;
                    break;

                default:
                    glyphOverhangPadding = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    break;
            }
            if (wrapMode == DataGridViewTriState.False)
            {
                glyphOverhangPadding |= TextFormatFlags.SingleLine;
            }
            else
            {
                glyphOverhangPadding |= TextFormatFlags.WordBreak;
            }
            glyphOverhangPadding |= TextFormatFlags.NoPrefix;
            glyphOverhangPadding |= TextFormatFlags.PreserveGraphicsClipping;

            return glyphOverhangPadding;
        }


        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            if (DataGridView != null)
            {
                Point currentCellAddress = base.DataGridView.CurrentCellAddress;
                if (((currentCellAddress.X == e.ColumnIndex) && (currentCellAddress.Y == e.RowIndex)) && (e.Button == MouseButtons.Left))
                {
                    if (DataGridView.EditMode != DataGridViewEditMode.EditProgrammatically)
                    {
                        DataGridView.BeginEdit(true);
                    }
                }
            }
        }

    }
}
