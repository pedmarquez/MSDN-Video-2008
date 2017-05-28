namespace MSDNVideo.Tienda
{
    partial class BuscarPeliculasForm
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
            this.tituloTxtBox = new System.Windows.Forms.TextBox();
            this.tituloChkBox = new System.Windows.Forms.CheckBox();
            this.codBarrasTxtBox = new System.Windows.Forms.TextBox();
            this.codBarrasChkBox = new System.Windows.Forms.CheckBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.novedadesCmbBox = new System.Windows.Forms.ComboBox();
            this.novedadesChkBox = new System.Windows.Forms.CheckBox();
            this.clasificacionCmbBox = new System.Windows.Forms.ComboBox();
            this.clasificacionChkBox = new System.Windows.Forms.CheckBox();
            this.generoCmbBox = new System.Windows.Forms.ComboBox();
            this.generoChkBox = new System.Windows.Forms.CheckBox();
            this.etiquetaTitulo1 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.etiquetaTitulo5 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.SuspendLayout();
            // 
            // tituloTxtBox
            // 
            this.tituloTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloTxtBox.Enabled = false;
            this.tituloTxtBox.Location = new System.Drawing.Point(239, 67);
            this.tituloTxtBox.Name = "tituloTxtBox";
            this.tituloTxtBox.Size = new System.Drawing.Size(167, 23);
            this.tituloTxtBox.TabIndex = 64;
            // 
            // tituloChkBox
            // 
            this.tituloChkBox.AutoSize = true;
            this.tituloChkBox.Location = new System.Drawing.Point(9, 69);
            this.tituloChkBox.Name = "tituloChkBox";
            this.tituloChkBox.Size = new System.Drawing.Size(108, 19);
            this.tituloChkBox.TabIndex = 66;
            this.tituloChkBox.Text = "Filtrar por título";
            this.tituloChkBox.UseVisualStyleBackColor = true;
            this.tituloChkBox.CheckedChanged += new System.EventHandler(this.tituloChkBox_CheckedChanged);
            // 
            // codBarrasTxtBox
            // 
            this.codBarrasTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codBarrasTxtBox.Enabled = false;
            this.codBarrasTxtBox.Location = new System.Drawing.Point(239, 38);
            this.codBarrasTxtBox.Name = "codBarrasTxtBox";
            this.codBarrasTxtBox.Size = new System.Drawing.Size(167, 23);
            this.codBarrasTxtBox.TabIndex = 63;
            // 
            // codBarrasChkBox
            // 
            this.codBarrasChkBox.AutoSize = true;
            this.codBarrasChkBox.Location = new System.Drawing.Point(9, 40);
            this.codBarrasChkBox.Name = "codBarrasChkBox";
            this.codBarrasChkBox.Size = new System.Drawing.Size(168, 19);
            this.codBarrasChkBox.TabIndex = 65;
            this.codBarrasChkBox.Text = "Filtrar por código de barras";
            this.codBarrasChkBox.UseVisualStyleBackColor = true;
            this.codBarrasChkBox.CheckedChanged += new System.EventHandler(this.codBarrasChkBox_CheckedChanged);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptarButton.Location = new System.Drawing.Point(250, 224);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 73;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(331, 224);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 74;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
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
            this.novedadesCmbBox.Location = new System.Drawing.Point(213, 186);
            this.novedadesCmbBox.Name = "novedadesCmbBox";
            this.novedadesCmbBox.Size = new System.Drawing.Size(193, 23);
            this.novedadesCmbBox.TabIndex = 72;
            // 
            // novedadesChkBox
            // 
            this.novedadesChkBox.AutoSize = true;
            this.novedadesChkBox.Location = new System.Drawing.Point(9, 188);
            this.novedadesChkBox.Name = "novedadesChkBox";
            this.novedadesChkBox.Size = new System.Drawing.Size(179, 19);
            this.novedadesChkBox.TabIndex = 77;
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
            this.clasificacionCmbBox.Location = new System.Drawing.Point(213, 159);
            this.clasificacionCmbBox.Name = "clasificacionCmbBox";
            this.clasificacionCmbBox.Size = new System.Drawing.Size(193, 23);
            this.clasificacionCmbBox.TabIndex = 71;
            // 
            // clasificacionChkBox
            // 
            this.clasificacionChkBox.AutoSize = true;
            this.clasificacionChkBox.Location = new System.Drawing.Point(9, 161);
            this.clasificacionChkBox.Name = "clasificacionChkBox";
            this.clasificacionChkBox.Size = new System.Drawing.Size(145, 19);
            this.clasificacionChkBox.TabIndex = 76;
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
            this.generoCmbBox.Location = new System.Drawing.Point(213, 132);
            this.generoCmbBox.Name = "generoCmbBox";
            this.generoCmbBox.Size = new System.Drawing.Size(193, 23);
            this.generoCmbBox.TabIndex = 70;
            // 
            // generoChkBox
            // 
            this.generoChkBox.AutoSize = true;
            this.generoChkBox.Location = new System.Drawing.Point(9, 134);
            this.generoChkBox.Name = "generoChkBox";
            this.generoChkBox.Size = new System.Drawing.Size(117, 19);
            this.generoChkBox.TabIndex = 75;
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
            this.etiquetaTitulo1.Location = new System.Drawing.Point(9, 106);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(397, 20);
            this.etiquetaTitulo1.TabIndex = 68;
            this.etiquetaTitulo1.Titulo = "Características";
            // 
            // etiquetaTitulo5
            // 
            this.etiquetaTitulo5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo5.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo5.Image = null;
            this.etiquetaTitulo5.Location = new System.Drawing.Point(9, 12);
            this.etiquetaTitulo5.Name = "etiquetaTitulo5";
            this.etiquetaTitulo5.Size = new System.Drawing.Size(397, 20);
            this.etiquetaTitulo5.TabIndex = 67;
            this.etiquetaTitulo5.Titulo = "Datos principales";
            // 
            // BuscarPeliculasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 259);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.cancelarButton);
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
            this.Name = "BuscarPeliculasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Películas";
            this.Load += new System.EventHandler(this.BuscarPeliculasForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tituloTxtBox;
        internal System.Windows.Forms.CheckBox tituloChkBox;
        internal System.Windows.Forms.TextBox codBarrasTxtBox;
        internal System.Windows.Forms.CheckBox codBarrasChkBox;
        private EtiquetaTitulo etiquetaTitulo5;
        private EtiquetaTitulo etiquetaTitulo1;
        internal System.Windows.Forms.Button aceptarButton;
        internal System.Windows.Forms.Button cancelarButton;
        internal System.Windows.Forms.ComboBox novedadesCmbBox;
        internal System.Windows.Forms.CheckBox novedadesChkBox;
        internal System.Windows.Forms.ComboBox clasificacionCmbBox;
        internal System.Windows.Forms.CheckBox clasificacionChkBox;
        internal System.Windows.Forms.ComboBox generoCmbBox;
        internal System.Windows.Forms.CheckBox generoChkBox;
    }
}