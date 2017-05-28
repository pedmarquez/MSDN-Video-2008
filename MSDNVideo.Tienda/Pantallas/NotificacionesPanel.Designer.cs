namespace MSDNVideo.Tienda
{
    partial class NotificacionesPanel
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.peliculaDataGridView = new System.Windows.Forms.DataGridView();
            this.notificacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.direccionTxtBox = new System.Windows.Forms.TextBox();
            this.selPeliculaButton = new System.Windows.Forms.Button();
            this.tipoNotificacionCmbBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.caratulaPicture = new System.Windows.Forms.PictureBox();
            this.direccionNotificacionLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saldoTxtBox = new System.Windows.Forms.TextBox();
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
            this.etiquetaTitulo1 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.socioDataGridViewTextBoxColumn = new MSDNVideo.Tienda.DataGridViewLookupColumn();
            this.peliculaDataGridViewTextBoxColumn = new MSDNVideo.Tienda.DataGridViewLookupColumn();
            this.tipoNotificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAltaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificacionBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caratulaPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.socioDataGridViewTextBoxColumn,
            this.peliculaDataGridViewTextBoxColumn,
            this.tipoNotificacionDataGridViewTextBoxColumn,
            this.fechaAltaDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn});
            this.peliculaDataGridView.DataSource = this.notificacionBindingSource;
            this.peliculaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peliculaDataGridView.Location = new System.Drawing.Point(0, 0);
            this.peliculaDataGridView.Name = "peliculaDataGridView";
            this.peliculaDataGridView.ReadOnly = true;
            this.peliculaDataGridView.RowHeadersVisible = false;
            this.peliculaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.peliculaDataGridView.Size = new System.Drawing.Size(773, 173);
            this.peliculaDataGridView.TabIndex = 2;
            // 
            // notificacionBindingSource
            // 
            this.notificacionBindingSource.DataSource = typeof(MSDNVideo.Comun.Notificacion);
            this.notificacionBindingSource.CurrentChanged += new System.EventHandler(this.notificacionBindingSource_CurrentChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.direccionTxtBox);
            this.panel1.Controls.Add(this.selPeliculaButton);
            this.panel1.Controls.Add(this.tipoNotificacionCmbBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.emailTxtBox);
            this.panel1.Controls.Add(this.caratulaPicture);
            this.panel1.Controls.Add(this.direccionNotificacionLbl);
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
            this.panel1.TabIndex = 3;
            // 
            // direccionTxtBox
            // 
            this.direccionTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.direccionTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Direccion", true));
            this.direccionTxtBox.Location = new System.Drawing.Point(554, 256);
            this.direccionTxtBox.Name = "direccionTxtBox";
            this.direccionTxtBox.Size = new System.Drawing.Size(176, 23);
            this.direccionTxtBox.TabIndex = 47;
            // 
            // selPeliculaButton
            // 
            this.selPeliculaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selPeliculaButton.Location = new System.Drawing.Point(465, 34);
            this.selPeliculaButton.Name = "selPeliculaButton";
            this.selPeliculaButton.Size = new System.Drawing.Size(33, 23);
            this.selPeliculaButton.TabIndex = 46;
            this.selPeliculaButton.Text = "...";
            this.selPeliculaButton.UseVisualStyleBackColor = true;
            this.selPeliculaButton.Click += new System.EventHandler(this.selPeliculaButton_Click);
            // 
            // tipoNotificacionCmbBox
            // 
            this.tipoNotificacionCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoNotificacionCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoNotificacionCmbBox.FormattingEnabled = true;
            this.tipoNotificacionCmbBox.Items.AddRange(new object[] {
            "Email",
            "SMS",
            "Messenger"});
            this.tipoNotificacionCmbBox.Location = new System.Drawing.Point(554, 226);
            this.tipoNotificacionCmbBox.Name = "tipoNotificacionCmbBox";
            this.tipoNotificacionCmbBox.Size = new System.Drawing.Size(176, 23);
            this.tipoNotificacionCmbBox.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 44;
            this.label8.Text = "Email:";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Socio.Email", true));
            this.emailTxtBox.Location = new System.Drawing.Point(113, 314);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.ReadOnly = true;
            this.emailTxtBox.Size = new System.Drawing.Size(296, 23);
            this.emailTxtBox.TabIndex = 43;
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
            // direccionNotificacionLbl
            // 
            this.direccionNotificacionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.direccionNotificacionLbl.AutoSize = true;
            this.direccionNotificacionLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionNotificacionLbl.Location = new System.Drawing.Point(426, 259);
            this.direccionNotificacionLbl.Name = "direccionNotificacionLbl";
            this.direccionNotificacionLbl.Size = new System.Drawing.Size(63, 15);
            this.direccionNotificacionLbl.TabIndex = 35;
            this.direccionNotificacionLbl.Text = "Dirección:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(426, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tipo:";
            // 
            // saldoTxtBox
            // 
            this.saldoTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Socio.Telefono", true));
            this.saldoTxtBox.Location = new System.Drawing.Point(113, 285);
            this.saldoTxtBox.Name = "saldoTxtBox";
            this.saldoTxtBox.ReadOnly = true;
            this.saldoTxtBox.Size = new System.Drawing.Size(116, 23);
            this.saldoTxtBox.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Teléfono:";
            // 
            // nombreTxtBox
            // 
            this.nombreTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nombreTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Socio.Nombre", true));
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
            this.nifTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Socio.NIF", true));
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
            this.etiquetaTitulo3.Titulo = "Datos notificación";
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
            this.sinopsisTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Pelicula.Sinopsis", true));
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
            this.tituloTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Pelicula.Titulo", true));
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
            this.codBarrasTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notificacionBindingSource, "Pelicula.CodBarras", true));
            this.codBarrasTxtBox.Location = new System.Drawing.Point(268, 34);
            this.codBarrasTxtBox.Name = "codBarrasTxtBox";
            this.codBarrasTxtBox.Size = new System.Drawing.Size(191, 23);
            this.codBarrasTxtBox.TabIndex = 1;
            this.codBarrasTxtBox.Leave += new System.EventHandler(this.codBarrasTxtBox_Leave);
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
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.etiquetaTitulo1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.etiquetaTitulo1.Image = global::MSDNVideo.Tienda.Properties.Resources.Notificaciones;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(0, 0);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(773, 28);
            this.etiquetaTitulo1.TabIndex = 2;
            this.etiquetaTitulo1.Titulo = "Notificaciones";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.notificacionBindingSource;
            // 
            // socioDataGridViewTextBoxColumn
            // 
            this.socioDataGridViewTextBoxColumn.DataPropertyName = "Socio";
            this.socioDataGridViewTextBoxColumn.EntityConverter = null;
            this.socioDataGridViewTextBoxColumn.HeaderText = "Socio";
            this.socioDataGridViewTextBoxColumn.LookupDataContext = null;
            this.socioDataGridViewTextBoxColumn.LookupDialogForm = null;
            this.socioDataGridViewTextBoxColumn.Name = "socioDataGridViewTextBoxColumn";
            this.socioDataGridViewTextBoxColumn.ReadOnly = true;
            this.socioDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.socioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // peliculaDataGridViewTextBoxColumn
            // 
            this.peliculaDataGridViewTextBoxColumn.DataPropertyName = "Pelicula";
            this.peliculaDataGridViewTextBoxColumn.EntityConverter = null;
            this.peliculaDataGridViewTextBoxColumn.HeaderText = "Película";
            this.peliculaDataGridViewTextBoxColumn.LookupDataContext = null;
            this.peliculaDataGridViewTextBoxColumn.LookupDialogForm = null;
            this.peliculaDataGridViewTextBoxColumn.Name = "peliculaDataGridViewTextBoxColumn";
            this.peliculaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoNotificacionDataGridViewTextBoxColumn
            // 
            this.tipoNotificacionDataGridViewTextBoxColumn.DataPropertyName = "TipoNotificacion";
            this.tipoNotificacionDataGridViewTextBoxColumn.HeaderText = "Tipo notificación";
            this.tipoNotificacionDataGridViewTextBoxColumn.Name = "tipoNotificacionDataGridViewTextBoxColumn";
            this.tipoNotificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaAltaDataGridViewTextBoxColumn
            // 
            this.fechaAltaDataGridViewTextBoxColumn.DataPropertyName = "FechaAlta";
            this.fechaAltaDataGridViewTextBoxColumn.HeaderText = "Fecha alta";
            this.fechaAltaDataGridViewTextBoxColumn.Name = "fechaAltaDataGridViewTextBoxColumn";
            this.fechaAltaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Dirección";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NotificacionesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.etiquetaTitulo1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NotificacionesPanel";
            this.Size = new System.Drawing.Size(773, 580);
            this.Load += new System.EventHandler(this.NotificacionesPanel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peliculaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificacionBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caratulaPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EtiquetaTitulo etiquetaTitulo1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView peliculaDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox tipoNotificacionCmbBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.PictureBox caratulaPicture;
        private System.Windows.Forms.Label direccionNotificacionLbl;
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tituloTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox codBarrasTxtBox;
        private EtiquetaTitulo etiquetaTitulo5;
        private System.Windows.Forms.BindingSource notificacionBindingSource;
        private System.Windows.Forms.Button selPeliculaButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox direccionTxtBox;
        private DataGridViewLookupColumn socioDataGridViewTextBoxColumn;
        private DataGridViewLookupColumn peliculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoNotificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAltaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
    }
}
