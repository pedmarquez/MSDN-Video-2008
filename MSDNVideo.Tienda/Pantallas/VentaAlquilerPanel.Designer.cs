namespace MSDNVideo.Tienda
{
    partial class VentaAlquilerPanel
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
            this.peliculaDataGridView = new System.Windows.Forms.DataGridView();
            this.codBarrasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peliculasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.clienteRecogeChkBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.caratulaPicture = new System.Windows.Forms.PictureBox();
            this.alquilarButton = new System.Windows.Forms.Button();
            this.comprarButton = new System.Windows.Forms.Button();
            this.disponibleAlquilerTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.disponibleVentaTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saldoTxtBox = new System.Windows.Forms.TextBox();
            this.socioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.nombreTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selSocioButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nifTxtBox = new System.Windows.Forms.TextBox();
            this.etiquetaTitulo3 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.etiquetaTitulo2 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.label1 = new System.Windows.Forms.Label();
            this.sinopsisTxtBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tituloTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.codBarrasTxtBox = new System.Windows.Forms.TextBox();
            this.etiquetaTitulo5 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculasBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caratulaPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.socioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.etiquetaTitulo1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.etiquetaTitulo1.Image = global::MSDNVideo.Tienda.Properties.Resources.ComprasAlquileres;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(0, 0);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(773, 28);
            this.etiquetaTitulo1.TabIndex = 2;
            this.etiquetaTitulo1.Titulo = "Ventas y alquileres";
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
            this.splitContainer1.Panel1.Controls.Add(this.peliculaDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(773, 552);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 3;
            // 
            // peliculaDataGridView
            // 
            this.peliculaDataGridView.AllowUserToAddRows = false;
            this.peliculaDataGridView.AllowUserToDeleteRows = false;
            this.peliculaDataGridView.AllowUserToResizeRows = false;
            this.peliculaDataGridView.AutoGenerateColumns = false;
            this.peliculaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.peliculaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peliculaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codBarrasDataGridViewTextBoxColumn,
            this.tituloDataGridViewTextBoxColumn,
            this.clasificacionDataGridViewTextBoxColumn,
            this.generoDataGridViewTextBoxColumn});
            this.peliculaDataGridView.DataSource = this.peliculasBindingSource;
            this.peliculaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peliculaDataGridView.Location = new System.Drawing.Point(0, 0);
            this.peliculaDataGridView.Name = "peliculaDataGridView";
            this.peliculaDataGridView.ReadOnly = true;
            this.peliculaDataGridView.RowHeadersVisible = false;
            this.peliculaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.peliculaDataGridView.Size = new System.Drawing.Size(773, 173);
            this.peliculaDataGridView.TabIndex = 1;
            // 
            // codBarrasDataGridViewTextBoxColumn
            // 
            this.codBarrasDataGridViewTextBoxColumn.DataPropertyName = "CodBarras";
            this.codBarrasDataGridViewTextBoxColumn.FillWeight = 66.53861F;
            this.codBarrasDataGridViewTextBoxColumn.HeaderText = "CodBarras";
            this.codBarrasDataGridViewTextBoxColumn.Name = "codBarrasDataGridViewTextBoxColumn";
            this.codBarrasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            this.tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            this.tituloDataGridViewTextBoxColumn.FillWeight = 203.0457F;
            this.tituloDataGridViewTextBoxColumn.HeaderText = "Titulo";
            this.tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            this.tituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clasificacionDataGridViewTextBoxColumn
            // 
            this.clasificacionDataGridViewTextBoxColumn.DataPropertyName = "Clasificacion";
            this.clasificacionDataGridViewTextBoxColumn.FillWeight = 65.20786F;
            this.clasificacionDataGridViewTextBoxColumn.HeaderText = "Clasificacion";
            this.clasificacionDataGridViewTextBoxColumn.Name = "clasificacionDataGridViewTextBoxColumn";
            this.clasificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generoDataGridViewTextBoxColumn
            // 
            this.generoDataGridViewTextBoxColumn.DataPropertyName = "Genero";
            this.generoDataGridViewTextBoxColumn.FillWeight = 65.20786F;
            this.generoDataGridViewTextBoxColumn.HeaderText = "Genero";
            this.generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            this.generoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // peliculasBindingSource
            // 
            this.peliculasBindingSource.DataSource = typeof(MSDNVideo.Comun.Pelicula);
            this.peliculasBindingSource.CurrentChanged += new System.EventHandler(this.peliculasBindingSource_CurrentChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.clienteRecogeChkBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.caratulaPicture);
            this.panel1.Controls.Add(this.alquilarButton);
            this.panel1.Controls.Add(this.comprarButton);
            this.panel1.Controls.Add(this.disponibleAlquilerTxtBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.disponibleVentaTxtBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.saldoTxtBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nombreTxtBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.selSocioButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nifTxtBox);
            this.panel1.Controls.Add(this.etiquetaTitulo3);
            this.panel1.Controls.Add(this.etiquetaTitulo2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sinopsisTxtBox);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.tituloTxtBox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.codBarrasTxtBox);
            this.panel1.Controls.Add(this.etiquetaTitulo5);
            this.panel1.Location = new System.Drawing.Point(12, 14);
            this.panel1.MinimumSize = new System.Drawing.Size(667, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 347);
            this.panel1.TabIndex = 2;
            // 
            // clienteRecogeChkBox
            // 
            this.clienteRecogeChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clienteRecogeChkBox.AutoSize = true;
            this.clienteRecogeChkBox.Checked = true;
            this.clienteRecogeChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clienteRecogeChkBox.Location = new System.Drawing.Point(636, 289);
            this.clienteRecogeChkBox.Name = "clienteRecogeChkBox";
            this.clienteRecogeChkBox.Size = new System.Drawing.Size(15, 14);
            this.clienteRecogeChkBox.TabIndex = 42;
            this.clienteRecogeChkBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(426, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Recogida inmediata:";
            // 
            // caratulaPicture
            // 
            this.caratulaPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.caratulaPicture.Location = new System.Drawing.Point(12, 34);
            this.caratulaPicture.Name = "caratulaPicture";
            this.caratulaPicture.Size = new System.Drawing.Size(140, 161);
            this.caratulaPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caratulaPicture.TabIndex = 40;
            this.caratulaPicture.TabStop = false;
            // 
            // alquilarButton
            // 
            this.alquilarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alquilarButton.Location = new System.Drawing.Point(574, 312);
            this.alquilarButton.Name = "alquilarButton";
            this.alquilarButton.Size = new System.Drawing.Size(75, 23);
            this.alquilarButton.TabIndex = 38;
            this.alquilarButton.Text = "Alquilar";
            this.alquilarButton.UseVisualStyleBackColor = true;
            this.alquilarButton.Click += new System.EventHandler(this.alquilarButton_Click);
            // 
            // comprarButton
            // 
            this.comprarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comprarButton.Location = new System.Drawing.Point(655, 312);
            this.comprarButton.Name = "comprarButton";
            this.comprarButton.Size = new System.Drawing.Size(75, 23);
            this.comprarButton.TabIndex = 37;
            this.comprarButton.Text = "Comprar";
            this.comprarButton.UseVisualStyleBackColor = true;
            this.comprarButton.Click += new System.EventHandler(this.comprarButton_Click);
            // 
            // disponibleAlquilerTxtBox
            // 
            this.disponibleAlquilerTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disponibleAlquilerTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peliculasBindingSource, "DisponibleAlquiler", true));
            this.disponibleAlquilerTxtBox.Location = new System.Drawing.Point(636, 256);
            this.disponibleAlquilerTxtBox.Name = "disponibleAlquilerTxtBox";
            this.disponibleAlquilerTxtBox.ReadOnly = true;
            this.disponibleAlquilerTxtBox.Size = new System.Drawing.Size(94, 23);
            this.disponibleAlquilerTxtBox.TabIndex = 36;
            this.disponibleAlquilerTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(426, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Disponible alquiler:";
            // 
            // disponibleVentaTxtBox
            // 
            this.disponibleVentaTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disponibleVentaTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peliculasBindingSource, "DisponibleVenta", true));
            this.disponibleVentaTxtBox.Location = new System.Drawing.Point(636, 227);
            this.disponibleVentaTxtBox.Name = "disponibleVentaTxtBox";
            this.disponibleVentaTxtBox.ReadOnly = true;
            this.disponibleVentaTxtBox.Size = new System.Drawing.Size(94, 23);
            this.disponibleVentaTxtBox.TabIndex = 34;
            this.disponibleVentaTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(426, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Disponible venta:";
            // 
            // saldoTxtBox
            // 
            this.saldoTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.socioBindingSource, "Saldo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.saldoTxtBox.Location = new System.Drawing.Point(113, 285);
            this.saldoTxtBox.Name = "saldoTxtBox";
            this.saldoTxtBox.ReadOnly = true;
            this.saldoTxtBox.Size = new System.Drawing.Size(116, 23);
            this.saldoTxtBox.TabIndex = 32;
            // 
            // socioBindingSource
            // 
            this.socioBindingSource.DataSource = typeof(MSDNVideo.Comun.Socio);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Saldo:";
            // 
            // nombreTxtBox
            // 
            this.nombreTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nombreTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.socioBindingSource, "Nombre", true));
            this.nombreTxtBox.Location = new System.Drawing.Point(113, 256);
            this.nombreTxtBox.Name = "nombreTxtBox";
            this.nombreTxtBox.ReadOnly = true;
            this.nombreTxtBox.Size = new System.Drawing.Size(296, 23);
            this.nombreTxtBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nombre:";
            // 
            // selSocioButton
            // 
            this.selSocioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selSocioButton.Location = new System.Drawing.Point(376, 226);
            this.selSocioButton.Name = "selSocioButton";
            this.selSocioButton.Size = new System.Drawing.Size(33, 23);
            this.selSocioButton.TabIndex = 28;
            this.selSocioButton.Text = "...";
            this.selSocioButton.UseVisualStyleBackColor = true;
            this.selSocioButton.Click += new System.EventHandler(this.selSocioButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "NIF:";
            // 
            // nifTxtBox
            // 
            this.nifTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nifTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.socioBindingSource, "NIF", true));
            this.nifTxtBox.Location = new System.Drawing.Point(113, 227);
            this.nifTxtBox.Name = "nifTxtBox";
            this.nifTxtBox.Size = new System.Drawing.Size(257, 23);
            this.nifTxtBox.TabIndex = 26;
            this.nifTxtBox.Leave += new System.EventHandler(this.nifTxtBox_Leave);
            // 
            // etiquetaTitulo3
            // 
            this.etiquetaTitulo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo3.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo3.Image = null;
            this.etiquetaTitulo3.Location = new System.Drawing.Point(429, 201);
            this.etiquetaTitulo3.Name = "etiquetaTitulo3";
            this.etiquetaTitulo3.Size = new System.Drawing.Size(301, 20);
            this.etiquetaTitulo3.TabIndex = 25;
            this.etiquetaTitulo3.Titulo = "Stock";
            // 
            // etiquetaTitulo2
            // 
            this.etiquetaTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo2.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo2.Image = null;
            this.etiquetaTitulo2.Location = new System.Drawing.Point(12, 201);
            this.etiquetaTitulo2.Name = "etiquetaTitulo2";
            this.etiquetaTitulo2.Size = new System.Drawing.Size(397, 20);
            this.etiquetaTitulo2.TabIndex = 24;
            this.etiquetaTitulo2.Titulo = "Socio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Sinopsis:";
            // 
            // sinopsisTxtBox
            // 
            this.sinopsisTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sinopsisTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peliculasBindingSource, "Sinopsis", true));
            this.sinopsisTxtBox.Location = new System.Drawing.Point(268, 92);
            this.sinopsisTxtBox.Multiline = true;
            this.sinopsisTxtBox.Name = "sinopsisTxtBox";
            this.sinopsisTxtBox.ReadOnly = true;
            this.sinopsisTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sinopsisTxtBox.Size = new System.Drawing.Size(462, 103);
            this.sinopsisTxtBox.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(158, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "Título:";
            // 
            // tituloTxtBox
            // 
            this.tituloTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peliculasBindingSource, "Titulo", true));
            this.tituloTxtBox.Location = new System.Drawing.Point(268, 63);
            this.tituloTxtBox.Name = "tituloTxtBox";
            this.tituloTxtBox.ReadOnly = true;
            this.tituloTxtBox.Size = new System.Drawing.Size(462, 23);
            this.tituloTxtBox.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(158, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Código Barras:";
            // 
            // codBarrasTxtBox
            // 
            this.codBarrasTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peliculasBindingSource, "CodBarras", true));
            this.codBarrasTxtBox.Location = new System.Drawing.Point(268, 34);
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
            this.etiquetaTitulo5.Location = new System.Drawing.Point(12, 8);
            this.etiquetaTitulo5.Name = "etiquetaTitulo5";
            this.etiquetaTitulo5.Size = new System.Drawing.Size(718, 20);
            this.etiquetaTitulo5.TabIndex = 2;
            this.etiquetaTitulo5.Titulo = "Película";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // VentaAlquilerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.etiquetaTitulo1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "VentaAlquilerPanel";
            this.Size = new System.Drawing.Size(773, 580);
            this.Load += new System.EventHandler(this.VentaAlquilerPanel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peliculaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculasBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caratulaPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.socioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EtiquetaTitulo etiquetaTitulo1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView peliculaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codBarrasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource peliculasBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tituloTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox codBarrasTxtBox;
        private EtiquetaTitulo etiquetaTitulo5;
        private System.Windows.Forms.TextBox disponibleVentaTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox saldoTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombreTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selSocioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nifTxtBox;
        private EtiquetaTitulo etiquetaTitulo3;
        private EtiquetaTitulo etiquetaTitulo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sinopsisTxtBox;
        private System.Windows.Forms.Button alquilarButton;
        private System.Windows.Forms.Button comprarButton;
        private System.Windows.Forms.TextBox disponibleAlquilerTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox caratulaPicture;
        private System.Windows.Forms.BindingSource socioBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox clienteRecogeChkBox;
        private System.Windows.Forms.Label label7;
    }
}
