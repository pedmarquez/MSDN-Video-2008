namespace MSDNVideo.Tienda
{
    partial class RecogidasPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.etiquetaTitulo1 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.alquileresDataGridView = new System.Windows.Forms.DataGridView();
            this.usuarioDataGridViewTextBoxColumn = new MSDNVideo.Tienda.DataGridViewLookupColumn();
            this.peliculaDataGridViewTextBoxColumn = new MSDNVideo.Tienda.DataGridViewLookupColumn();
            this.fechaAlquilerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alquilerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.caratulaPicture = new System.Windows.Forms.PictureBox();
            this.recogerButton = new System.Windows.Forms.Button();
            this.fechaAlquilerTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saldoTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nombreTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nifTxtBox = new System.Windows.Forms.TextBox();
            this.etiquetaTitulo3 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.etiquetaTitulo2 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.label14 = new System.Windows.Forms.Label();
            this.tituloTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.codBarrasTxtBox = new System.Windows.Forms.TextBox();
            this.etiquetaTitulo5 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.usuarioNotificacionDataGridViewTextBoxColumn = new MSDNVideo.Tienda.DataGridViewLookupColumn();
            this.tipoNotificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAltaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alquileresDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alquilerBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caratulaPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.etiquetaTitulo1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.etiquetaTitulo1.Image = global::MSDNVideo.Tienda.Properties.Resources.Recoger;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(0, 0);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(773, 28);
            this.etiquetaTitulo1.TabIndex = 4;
            this.etiquetaTitulo1.Titulo = "Recogidas";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.alquileresDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(773, 552);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 5;
            // 
            // alquileresDataGridView
            // 
            this.alquileresDataGridView.AllowUserToAddRows = false;
            this.alquileresDataGridView.AllowUserToDeleteRows = false;
            this.alquileresDataGridView.AllowUserToResizeRows = false;
            this.alquileresDataGridView.AutoGenerateColumns = false;
            this.alquileresDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.alquileresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alquileresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuarioDataGridViewTextBoxColumn,
            this.peliculaDataGridViewTextBoxColumn,
            this.fechaAlquilerDataGridViewTextBoxColumn});
            this.alquileresDataGridView.DataSource = this.alquilerBindingSource;
            this.alquileresDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alquileresDataGridView.Location = new System.Drawing.Point(0, 0);
            this.alquileresDataGridView.Name = "alquileresDataGridView";
            this.alquileresDataGridView.ReadOnly = true;
            this.alquileresDataGridView.RowHeadersVisible = false;
            this.alquileresDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.alquileresDataGridView.Size = new System.Drawing.Size(773, 173);
            this.alquileresDataGridView.TabIndex = 3;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.EntityConverter = null;
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Socio";
            this.usuarioDataGridViewTextBoxColumn.LookupDataContext = null;
            this.usuarioDataGridViewTextBoxColumn.LookupDialogForm = null;
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.usuarioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // peliculaDataGridViewTextBoxColumn
            // 
            this.peliculaDataGridViewTextBoxColumn.DataPropertyName = "Pelicula";
            this.peliculaDataGridViewTextBoxColumn.EntityConverter = null;
            this.peliculaDataGridViewTextBoxColumn.HeaderText = "Pelicula";
            this.peliculaDataGridViewTextBoxColumn.LookupDataContext = null;
            this.peliculaDataGridViewTextBoxColumn.LookupDialogForm = null;
            this.peliculaDataGridViewTextBoxColumn.Name = "peliculaDataGridViewTextBoxColumn";
            this.peliculaDataGridViewTextBoxColumn.ReadOnly = true;
            this.peliculaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.peliculaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fechaAlquilerDataGridViewTextBoxColumn
            // 
            this.fechaAlquilerDataGridViewTextBoxColumn.DataPropertyName = "FechaAlquiler";
            this.fechaAlquilerDataGridViewTextBoxColumn.HeaderText = "Fecha alquiler";
            this.fechaAlquilerDataGridViewTextBoxColumn.Name = "fechaAlquilerDataGridViewTextBoxColumn";
            this.fechaAlquilerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alquilerBindingSource
            // 
            this.alquilerBindingSource.DataSource = typeof(MSDNVideo.Comun.Alquiler);
            this.alquilerBindingSource.CurrentChanged += new System.EventHandler(this.alquilerBindingSource_CurrentChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.caratulaPicture);
            this.panel1.Controls.Add(this.recogerButton);
            this.panel1.Controls.Add(this.fechaAlquilerTxtBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.saldoTxtBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nombreTxtBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nifTxtBox);
            this.panel1.Controls.Add(this.etiquetaTitulo3);
            this.panel1.Controls.Add(this.etiquetaTitulo2);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.tituloTxtBox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.codBarrasTxtBox);
            this.panel1.Controls.Add(this.etiquetaTitulo5);
            this.panel1.Location = new System.Drawing.Point(12, 14);
            this.panel1.MinimumSize = new System.Drawing.Size(667, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 347);
            this.panel1.TabIndex = 4;
            // 
            // caratulaPicture
            // 
            this.caratulaPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.caratulaPicture.Location = new System.Drawing.Point(14, 15);
            this.caratulaPicture.Name = "caratulaPicture";
            this.caratulaPicture.Size = new System.Drawing.Size(210, 246);
            this.caratulaPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caratulaPicture.TabIndex = 40;
            this.caratulaPicture.TabStop = false;
            // 
            // recogerButton
            // 
            this.recogerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recogerButton.Enabled = false;
            this.recogerButton.Location = new System.Drawing.Point(655, 312);
            this.recogerButton.Name = "recogerButton";
            this.recogerButton.Size = new System.Drawing.Size(75, 23);
            this.recogerButton.TabIndex = 37;
            this.recogerButton.Text = "Recoger";
            this.recogerButton.UseVisualStyleBackColor = true;
            this.recogerButton.Click += new System.EventHandler(this.recogerButton_Click);
            // 
            // fechaAlquilerTxtBox
            // 
            this.fechaAlquilerTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alquilerBindingSource, "FechaAlquiler", true));
            this.fechaAlquilerTxtBox.Location = new System.Drawing.Point(357, 238);
            this.fechaAlquilerTxtBox.Name = "fechaAlquilerTxtBox";
            this.fechaAlquilerTxtBox.ReadOnly = true;
            this.fechaAlquilerTxtBox.Size = new System.Drawing.Size(116, 23);
            this.fechaAlquilerTxtBox.TabIndex = 34;
            this.fechaAlquilerTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(244, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Fecha alquiler:";
            // 
            // saldoTxtBox
            // 
            this.saldoTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alquilerBindingSource, "Socio.Saldo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.saldoTxtBox.Location = new System.Drawing.Point(357, 183);
            this.saldoTxtBox.Name = "saldoTxtBox";
            this.saldoTxtBox.ReadOnly = true;
            this.saldoTxtBox.Size = new System.Drawing.Size(116, 23);
            this.saldoTxtBox.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Saldo:";
            // 
            // nombreTxtBox
            // 
            this.nombreTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nombreTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alquilerBindingSource, "Socio.Nombre", true));
            this.nombreTxtBox.Location = new System.Drawing.Point(357, 154);
            this.nombreTxtBox.Name = "nombreTxtBox";
            this.nombreTxtBox.ReadOnly = true;
            this.nombreTxtBox.Size = new System.Drawing.Size(373, 23);
            this.nombreTxtBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(244, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "NIF:";
            // 
            // nifTxtBox
            // 
            this.nifTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alquilerBindingSource, "Socio.NIF", true));
            this.nifTxtBox.Location = new System.Drawing.Point(357, 125);
            this.nifTxtBox.Name = "nifTxtBox";
            this.nifTxtBox.ReadOnly = true;
            this.nifTxtBox.Size = new System.Drawing.Size(116, 23);
            this.nifTxtBox.TabIndex = 26;
            // 
            // etiquetaTitulo3
            // 
            this.etiquetaTitulo3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo3.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo3.Image = null;
            this.etiquetaTitulo3.Location = new System.Drawing.Point(247, 212);
            this.etiquetaTitulo3.Name = "etiquetaTitulo3";
            this.etiquetaTitulo3.Size = new System.Drawing.Size(483, 20);
            this.etiquetaTitulo3.TabIndex = 25;
            this.etiquetaTitulo3.Titulo = "Datos alquiler";
            // 
            // etiquetaTitulo2
            // 
            this.etiquetaTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo2.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo2.Image = null;
            this.etiquetaTitulo2.Location = new System.Drawing.Point(246, 99);
            this.etiquetaTitulo2.Name = "etiquetaTitulo2";
            this.etiquetaTitulo2.Size = new System.Drawing.Size(484, 20);
            this.etiquetaTitulo2.TabIndex = 24;
            this.etiquetaTitulo2.Titulo = "Socio";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(243, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "Título:";
            // 
            // tituloTxtBox
            // 
            this.tituloTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alquilerBindingSource, "Pelicula.Titulo", true));
            this.tituloTxtBox.Location = new System.Drawing.Point(357, 70);
            this.tituloTxtBox.Name = "tituloTxtBox";
            this.tituloTxtBox.ReadOnly = true;
            this.tituloTxtBox.Size = new System.Drawing.Size(373, 23);
            this.tituloTxtBox.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(243, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Código Barras:";
            // 
            // codBarrasTxtBox
            // 
            this.codBarrasTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alquilerBindingSource, "Pelicula.CodBarras", true));
            this.codBarrasTxtBox.Location = new System.Drawing.Point(357, 41);
            this.codBarrasTxtBox.Name = "codBarrasTxtBox";
            this.codBarrasTxtBox.ReadOnly = true;
            this.codBarrasTxtBox.Size = new System.Drawing.Size(191, 23);
            this.codBarrasTxtBox.TabIndex = 1;
            // 
            // etiquetaTitulo5
            // 
            this.etiquetaTitulo5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo5.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo5.Image = null;
            this.etiquetaTitulo5.Location = new System.Drawing.Point(246, 15);
            this.etiquetaTitulo5.Name = "etiquetaTitulo5";
            this.etiquetaTitulo5.Size = new System.Drawing.Size(484, 20);
            this.etiquetaTitulo5.TabIndex = 2;
            this.etiquetaTitulo5.Titulo = "Película";
            // 
            // usuarioNotificacionDataGridViewTextBoxColumn
            // 
            this.usuarioNotificacionDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioNotificacionDataGridViewTextBoxColumn.EntityConverter = null;
            this.usuarioNotificacionDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioNotificacionDataGridViewTextBoxColumn.LookupDataContext = null;
            this.usuarioNotificacionDataGridViewTextBoxColumn.LookupDialogForm = null;
            this.usuarioNotificacionDataGridViewTextBoxColumn.Name = "usuarioNotificacionDataGridViewTextBoxColumn";
            this.usuarioNotificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioNotificacionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.usuarioNotificacionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tipoNotificacionDataGridViewTextBoxColumn
            // 
            this.tipoNotificacionDataGridViewTextBoxColumn.DataPropertyName = "TipoNotificacion";
            this.tipoNotificacionDataGridViewTextBoxColumn.HeaderText = "TipoNotificacion";
            this.tipoNotificacionDataGridViewTextBoxColumn.Name = "tipoNotificacionDataGridViewTextBoxColumn";
            this.tipoNotificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaAltaDataGridViewTextBoxColumn
            // 
            this.fechaAltaDataGridViewTextBoxColumn.DataPropertyName = "FechaAlta";
            this.fechaAltaDataGridViewTextBoxColumn.HeaderText = "FechaAlta";
            this.fechaAltaDataGridViewTextBoxColumn.Name = "fechaAltaDataGridViewTextBoxColumn";
            this.fechaAltaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RecogidasPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.etiquetaTitulo1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RecogidasPanel";
            this.Size = new System.Drawing.Size(773, 580);
            this.Load += new System.EventHandler(this.RecogidasPanel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alquileresDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alquilerBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caratulaPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EtiquetaTitulo etiquetaTitulo1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView alquileresDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox caratulaPicture;
        private System.Windows.Forms.Button recogerButton;
        private System.Windows.Forms.TextBox fechaAlquilerTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox saldoTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombreTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nifTxtBox;
        private EtiquetaTitulo etiquetaTitulo3;
        private EtiquetaTitulo etiquetaTitulo2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tituloTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox codBarrasTxtBox;
        private EtiquetaTitulo etiquetaTitulo5;
        private DataGridViewLookupColumn usuarioNotificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoNotificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAltaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource alquilerBindingSource;
        private DataGridViewLookupColumn usuarioDataGridViewTextBoxColumn;
        private DataGridViewLookupColumn peliculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAlquilerDataGridViewTextBoxColumn;
    }
}
