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
    public partial class LookupControl : UserControl, IDataGridViewEditingControl
    {
        private DataGridView _dataGridView;
        private int _rowIndex;
        private bool _valueChanged;
        private Type _lookupDialogForm;
        private TypeConverter _entityConverter;
        private object _selectedObject;
        private bool _isObjectLookup;
        private IDisconnectedDataContext _lookupDataContext;

        public LookupControl()
        {
            InitializeComponent();
        }

        public Type LookupDialogForm
        {
            get 
            {
                return _lookupDialogForm; 
            }
            set 
            {
                _lookupDialogForm = value;
            }
        }

        public Type EntityConverter
        {
            get
            {
                return _entityConverter.GetType();
            }
            set
            {
                _entityConverter = (TypeConverter)Activator.CreateInstance(value);
            }
        }

        public IDisconnectedDataContext LookupDataContext
        {
            get
            {
                return _lookupDataContext;
            }
            set
            {
                _lookupDataContext = value;
            }
        }

        public bool IsObjectLookup
        {
            get
            {
                return _isObjectLookup;
            }
            set
            {
                _isObjectLookup = value;
                if (_isObjectLookup)
                {
                    // No mostramos TextBox
                    valueTxtBox.Visible = false;
                }
                else
                {
                    // No mostramos etiqueta
                    valueLabel.Visible = false;
                }
            }
        }

        public object Value
        {
            get 
            { 
                return _selectedObject; 
            }
            set 
            { 
                _selectedObject = value;
                valueTxtBox.Text = new DataGridViewLookupObjectValue(value, _entityConverter).ToString();
                valueLabel.Text = valueTxtBox.Text;
            }
        }



        #region IDataGridViewEditingControl Members

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            BackColor = dataGridViewCellStyle.BackColor;
            valueTxtBox.BackColor = BackColor;
            valueLabel.BackColor = BackColor;
            ForeColor = dataGridViewCellStyle.ForeColor;
            valueTxtBox.ForeColor = ForeColor;
            valueLabel.ForeColor = ForeColor;

            if (dataGridViewCellStyle.WrapMode == DataGridViewTriState.True)
            {
                valueTxtBox.WordWrap = true;
            }
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return _dataGridView;
            }
            set
            {
                _dataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return valueTxtBox.Text;
            }
            set
            {
                valueTxtBox.Text = value.ToString();
                valueLabel.Text = valueTxtBox.Text;
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return _valueChanged;
            }
            set
            {
                _valueChanged = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return true;
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return new DataGridViewLookupObjectValue(_selectedObject, _entityConverter);
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll)
                valueTxtBox.SelectAll();
            else
                valueTxtBox.SelectionStart = valueTxtBox.Text.Length;
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false;  }
        }

        #endregion

        private void LookupControl_Resize(object sender, EventArgs e)
        {
            valueTxtBox.Top = (int)((this.Height - valueTxtBox.Height) / 2);
            valueLabel.Top = (int)((this.Height - valueLabel.Height) / 2);
            lookUpButton.Top = (int)((this.Height - lookUpButton.Height) / 2);
        }

        private void lookUpButton_Click(object sender, EventArgs e)
        {
            ILookupDialog form;

            form = (ILookupDialog)Activator.CreateInstance(_lookupDialogForm);
            form.LookupDataContext = _lookupDataContext;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_isObjectLookup)
                {
                    if (!object.ReferenceEquals(_selectedObject, form.SelectedObject))
                    {
                        _selectedObject = form.SelectedObject;
                        valueLabel.Text = new DataGridViewLookupObjectValue(_selectedObject, _entityConverter).ToString();
                        valueTxtBox.Text = valueLabel.Text;
                        NotifyDataGridViewOfValueChange();
                    }
                }
                else
                {
                    _selectedObject = form.SelectedObject;
                    valueTxtBox.Text = _selectedObject.ToString();
                    valueLabel.Text = valueTxtBox.Text;
                }
            }
        }

        private void valueTxtBox_TextChanged(object sender, EventArgs e)
        {
            NotifyDataGridViewOfValueChange();
        }

        protected virtual void NotifyDataGridViewOfValueChange()
        {
            _valueChanged = true;
            if (_dataGridView != null)
            {
                _dataGridView.NotifyCurrentCellDirty(true);
            }
        }
    }
}
