namespace MSDNVideo.Tienda
{
    partial class SeleccionPeliculaForm
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
            this.buscarButton = new System.Windows.Forms.Button();
            this.novedadesCmbBox = new System.Windows.Forms.ComboBox();
            this.novedadesChkBox = new System.Windows.Forms.CheckBox();
            this.clasificacionCmbBox = new System.Windows.Forms.ComboBox();
            this.clasificacionChkBox = new System.Windows.Forms.CheckBox();
            this.generoCmbBox = new System.Windows.Forms.ComboBox();
            this.generoChkBox = new System.Windows.Forms.CheckBox();
            this.etiquetaTitulo1 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.etiquetaTitulo5 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.tituloTxtBox = new System.Windows.Forms.TextBox();
            this.tituloChkBox = new System.Windows.Forms.CheckBox();
            this.codBarrasTxtBox = new System.Windows.Forms.TextBox();
            this.codBarrasChkBox = new System.Windows.Forms.CheckBox();
            this.sociosGridView = new System.Windows.Forms.DataGridView();
            this.codBarrasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peliculaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.etiquetaTitulo2 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.aceptarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sociosGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buscarButton
            // 
            this.buscarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarButton.Location = new System.Drawing.Point(333, 215);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 88;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // novedadesCmbBox
            // 
            this.novedadesCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.novedadesCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.novedadesCmbBox.Enabled = false;
            this.novedadesCmbBox.FormattingEnabled = true;
            this.novedadesCmbBox.Items.AddRange(new object[] {
            "Última novedad",
            "No última novedad"});
            this.novedadesCmbBox.Location = new System.Drawing.Point(216, 186);
            this.novedadesCmbBox.Name = "novedadesCmbBox";
            this.novedadesCmbBox.Size = new System.Drawing.Size(192, 23);
            this.novedadesCmbBox.TabIndex = 86;
            // 
            // novedadesChkBox
            // 
            this.novedadesChkBox.AutoSize = true;
            this.novedadesChkBox.Location = new System.Drawing.Point(12, 188);
            this.novedadesChkBox.Name = "novedadesChkBox";
            this.novedadesChkBox.Size = new System.Drawing.Size(179, 19);
            this.novedadesChkBox.TabIndex = 91;
            this.novedadesChkBox.Text = "Filtrar por últimas novedades";
            this.novedadesChkBox.UseVisualStyleBackColor = true;
            this.novedadesChkBox.CheckedChanged += new System.EventHandler(this.novedadesChkBox_CheckedChanged);
            // 
            // clasificacionCmbBox
            // 
            this.clasificacionCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clasificacionCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clasificacionCmbBox.Enabled = false;
            this.clasificacionCmbBox.FormattingEnabled = true;
            this.clasificacionCmbBox.Items.AddRange(new object[] {
            "Apta",
            "NR < 7",
            "NR < 13",
            "NR < 18"});
            this.clasificacionCmbBox.Location = new System.Drawing.Point(216, 159);
            this.clasificacionCmbBox.Name = "clasificacionCmbBox";
            this.clasificacionCmbBox.Size = new System.Drawing.Size(192, 23);
            this.clasificacionCmbBox.TabIndex = 85;
            // 
            // clasificacionChkBox
            // 
            this.clasificacionChkBox.AutoSize = true;
            this.clasificacionChkBox.Location = new System.Drawing.Point(12, 161);
            this.clasificacionChkBox.Name = "clasificacionChkBox";
            this.clasificacionChkBox.Size = new System.Drawing.Size(145, 19);
            this.clasificacionChkBox.TabIndex = 90;
            this.clasificacionChkBox.Text = "Filtrar por clasificación";
            this.clasificacionChkBox.UseVisualStyleBackColor = true;
            this.clasificacionChkBox.CheckedChanged += new System.EventHandler(this.clasificacionChkBox_CheckedChanged);
            // 
            // generoCmbBox
            // 
            this.generoCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.generoCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generoCmbBox.Enabled = false;
            this.generoCmbBox.FormattingEnabled = true;
            this.generoCmbBox.Items.AddRange(new object[] {
            "Romántica",
            "Drama",
            "Comedia",
            "Thriller",
            "Terror",
            "Acción"});
            this.generoCmbBox.Location = new System.Drawing.Point(216, 132);
            this.generoCmbBox.Name = "generoCmbBox";
            this.generoCmbBox.Size = new System.Drawing.Size(192, 23);
            this.generoCmbBox.TabIndex = 84;
            // 
            // generoChkBox
            // 
            this.generoChkBox.AutoSize = true;
            this.generoChkBox.Location = new System.Drawing.Point(12, 134);
            this.generoChkBox.Name = "generoChkBox";
            this.generoChkBox.Size = new System.Drawing.Size(117, 19);
            this.generoChkBox.TabIndex = 89;
            this.generoChkBox.Text = "Filtrar por género";
            this.generoChkBox.UseVisualStyleBackColor = true;
            this.generoChkBox.CheckedChanged += new System.EventHandler(this.generoChkBox_CheckedChanged);
            // 
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo1.Image = null;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(12, 106);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(396, 20);
            this.etiquetaTitulo1.TabIndex = 83;
            this.etiquetaTitulo1.Titulo = "Características";
            // 
            // etiquetaTitulo5
            // 
            this.etiquetaTitulo5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo5.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo5.Image = null;
            this.etiquetaTitulo5.Location = new System.Drawing.Point(12, 12);
            this.etiquetaTitulo5.Name = "etiquetaTitulo5";
            this.etiquetaTitulo5.Size = new System.Drawing.Size(396, 20);
            this.etiquetaTitulo5.TabIndex = 82;
            this.etiquetaTitulo5.Titulo = "Datos principales";
            // 
            // tituloTxtBox
            // 
            this.tituloTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloTxtBox.Enabled = false;
            this.tituloTxtBox.Location = new System.Drawing.Point(242, 67);
            this.tituloTxtBox.Name = "tituloTxtBox";
            this.tituloTxtBox.Size = new System.Drawing.Size(166, 23);
            this.tituloTxtBox.TabIndex = 79;
            // 
            // tituloChkBox
            // 
            this.tituloChkBox.AutoSize = true;
            this.tituloChkBox.Location = new System.Drawing.Point(12, 69);
            this.tituloChkBox.Name = "tituloChkBox";
            this.tituloChkBox.Size = new System.Drawing.Size(108, 19);
            this.tituloChkBox.TabIndex = 81;
            this.tituloChkBox.Text = "Filtrar por título";
            this.tituloChkBox.UseVisualStyleBackColor = true;
            this.tituloChkBox.CheckedChanged += new System.EventHandler(this.tituloChkBox_CheckedChanged);
            // 
            // codBarrasTxtBox
            // 
            this.codBarrasTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codBarrasTxtBox.Enabled = false;
            this.codBarrasTxtBox.Location = new System.Drawing.Point(242, 38);
            this.codBarrasTxtBox.Name = "codBarrasTxtBox";
            this.codBarrasTxtBox.Size = new System.Drawing.Size(166, 23);
            this.codBarrasTxtBox.TabIndex = 78;
            // 
            // codBarrasChkBox
            // 
            this.codBarrasChkBox.AutoSize = true;
            this.codBarrasChkBox.Location = new System.Drawing.Point(12, 40);
            this.codBarrasChkBox.Name = "codBarrasChkBox";
            this.codBarrasChkBox.Size = new System.Drawing.Size(168, 19);
            this.codBarrasChkBox.TabIndex = 80;
            this.codBarrasChkBox.Text = "Filtrar por código de barras";
            this.codBarrasChkBox.UseVisualStyleBackColor = true;
            this.codBarrasChkBox.CheckedChanged += new System.EventHandler(this.codBarrasChkBox_CheckedChanged);
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
            this.codBarrasDataGridViewTextBoxColumn,
            this.tituloDataGridViewTextBoxColumn});
            this.sociosGridView.DataSource = this.peliculaBindingSource;
            this.sociosGridView.Location = new System.Drawing.Point(12, 270);
            this.sociosGridView.Name = "sociosGridView";
            this.sociosGridView.ReadOnly = true;
            this.sociosGridView.RowHeadersVisible = false;
            this.sociosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sociosGridView.Size = new System.Drawing.Size(396, 162);
            this.sociosGridView.TabIndex = 93;
            // 
            // codBarrasDataGridViewTextBoxColumn
            // 
            this.codBarrasDataGridViewTextBoxColumn.DataPropertyName = "CodBarras";
            this.codBarrasDataGridViewTextBoxColumn.HeaderText = "Código barras";
            this.codBarrasDataGridViewTextBoxColumn.Name = "codBarrasDataGridViewTextBoxColumn";
            this.codBarrasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            this.tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            this.tituloDataGridViewTextBoxColumn.HeaderText = "Título";
            this.tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            this.tituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // peliculaBindingSource
            // 
            this.peliculaBindingSource.DataSource = typeof(MSDNVideo.Comun.Pelicula);
            // 
            // etiquetaTitulo2
            // 
            this.etiquetaTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo2.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo2.Image = null;
            this.etiquetaTitulo2.Location = new System.Drawing.Point(12, 244);
            this.etiquetaTitulo2.Name = "etiquetaTitulo2";
            this.etiquetaTitulo2.Size = new System.Drawing.Size(396, 20);
            this.etiquetaTitulo2.TabIndex = 92;
            this.etiquetaTitulo2.Titulo = "Resultados";
            // 
            // cancelarButton
            // 
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(333, 438);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 95;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(249, 438);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 94;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // SeleccionPeliculaForm
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(420, 468);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.sociosGridView);
            this.Controls.Add(this.etiquetaTitulo2);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.novedadesCmbBox);
            this.Controls.Add(this.novedadesChkBox);
            this.Controls.Add(this.clasificacionCmbBox);
            this.Controls.Add(this.clasificacionChkBox);
            this.Controls.Add(this.generoCmbBox);
            this.Controls.Add(this.generoChkBox);
            this.Controls.Add(this.etiquetaTitulo1);
            this.Controls.Add(this.etiquetaTitulo5);
            this.Controls.Add(this.tituloTxtBox);
            this.Controls.Add(this.tituloChkBox);
            this.Controls.Add(this.codBarrasTxtBox);
            this.Controls.Add(this.codBarrasChkBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SeleccionPeliculaForm";
            this.Text = "Selección Película";
            this.Load += new System.EventHandler(this.BuscarPeliculasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sociosGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button buscarButton;
        internal System.Windows.Forms.ComboBox novedadesCmbBox;
        internal System.Windows.Forms.CheckBox novedadesChkBox;
        internal System.Windows.Forms.ComboBox clasificacionCmbBox;
        internal System.Windows.Forms.CheckBox clasificacionChkBox;
        internal System.Windows.Forms.ComboBox generoCmbBox;
        internal System.Windows.Forms.CheckBox generoChkBox;
        private EtiquetaTitulo etiquetaTitulo1;
        private EtiquetaTitulo etiquetaTitulo5;
        internal System.Windows.Forms.TextBox tituloTxtBox;
        internal System.Windows.Forms.CheckBox tituloChkBox;
        internal System.Windows.Forms.TextBox codBarrasTxtBox;
        internal System.Windows.Forms.CheckBox codBarrasChkBox;
        private System.Windows.Forms.DataGridView sociosGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codBarrasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource peliculaBindingSource;
        private EtiquetaTitulo etiquetaTitulo2;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button aceptarButton;
    }
}