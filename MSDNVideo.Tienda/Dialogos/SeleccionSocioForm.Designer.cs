namespace MSDNVideo.Tienda
{
    partial class SeleccionSocioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.etiquetaTitulo2 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.label3 = new System.Windows.Forms.Label();
            this.buscarTxtBox = new System.Windows.Forms.TextBox();
            this.buscarButton = new System.Windows.Forms.Button();
            this.etiquetaTitulo1 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.sociosGridView = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.socioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sociosGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.socioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // etiquetaTitulo2
            // 
            this.etiquetaTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo2.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo2.Image = null;
            this.etiquetaTitulo2.Location = new System.Drawing.Point(12, 12);
            this.etiquetaTitulo2.Name = "etiquetaTitulo2";
            this.etiquetaTitulo2.Size = new System.Drawing.Size(390, 20);
            this.etiquetaTitulo2.TabIndex = 25;
            this.etiquetaTitulo2.Titulo = "Búsqueda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Nombre:";
            // 
            // buscarTxtBox
            // 
            this.buscarTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarTxtBox.Location = new System.Drawing.Point(91, 38);
            this.buscarTxtBox.Name = "buscarTxtBox";
            this.buscarTxtBox.Size = new System.Drawing.Size(227, 23);
            this.buscarTxtBox.TabIndex = 31;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(327, 37);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 32;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo1.Image = null;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(12, 67);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(390, 20);
            this.etiquetaTitulo1.TabIndex = 33;
            this.etiquetaTitulo1.Titulo = "Resultados";
            // 
            // sociosGridView
            // 
            this.sociosGridView.AllowUserToAddRows = false;
            this.sociosGridView.AllowUserToDeleteRows = false;
            this.sociosGridView.AllowUserToResizeRows = false;
            this.sociosGridView.AutoGenerateColumns = false;
            this.sociosGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sociosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sociosGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.nIFDataGridViewTextBoxColumn});
            this.sociosGridView.DataSource = this.socioBindingSource;
            this.sociosGridView.Location = new System.Drawing.Point(12, 93);
            this.sociosGridView.Name = "sociosGridView";
            this.sociosGridView.ReadOnly = true;
            this.sociosGridView.RowHeadersVisible = false;
            this.sociosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sociosGridView.Size = new System.Drawing.Size(390, 162);
            this.sociosGridView.TabIndex = 34;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nIFDataGridViewTextBoxColumn
            // 
            this.nIFDataGridViewTextBoxColumn.DataPropertyName = "NIF";
            this.nIFDataGridViewTextBoxColumn.HeaderText = "NIF";
            this.nIFDataGridViewTextBoxColumn.Name = "nIFDataGridViewTextBoxColumn";
            this.nIFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // socioBindingSource
            // 
            this.socioBindingSource.DataSource = typeof(MSDNVideo.Comun.Socio);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(243, 261);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 35;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(327, 261);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 36;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // SeleccionSocioForm
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(414, 296);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.sociosGridView);
            this.Controls.Add(this.etiquetaTitulo1);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.buscarTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.etiquetaTitulo2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SeleccionSocioForm";
            this.Text = "Selección Socio";
            ((System.ComponentModel.ISupportInitialize)(this.sociosGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.socioBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EtiquetaTitulo etiquetaTitulo2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox buscarTxtBox;
        private System.Windows.Forms.Button buscarButton;
        private EtiquetaTitulo etiquetaTitulo1;
        private System.Windows.Forms.DataGridView sociosGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIFDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource socioBindingSource;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
    }
}