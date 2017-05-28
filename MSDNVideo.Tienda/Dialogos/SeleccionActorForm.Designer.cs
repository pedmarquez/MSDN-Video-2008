namespace MSDNVideo.Tienda
{
    partial class SeleccionActorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buscarTxtBox = new System.Windows.Forms.TextBox();
            this.buscarButton = new System.Windows.Forms.Button();
            this.actoresGridView = new System.Windows.Forms.DataGridView();
            this.seleccionarExistenteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nombreTxtBox = new System.Windows.Forms.TextBox();
            this.urlTxtBox = new System.Windows.Forms.TextBox();
            this.agregarButton = new System.Windows.Forms.Button();
            this.actorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.etiquetaTitulo1 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.etiquetaTitulo2 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlPersonalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlPersonalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.actoresGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar por nombre:";
            // 
            // buscarTxtBox
            // 
            this.buscarTxtBox.Location = new System.Drawing.Point(126, 38);
            this.buscarTxtBox.Name = "buscarTxtBox";
            this.buscarTxtBox.Size = new System.Drawing.Size(158, 23);
            this.buscarTxtBox.TabIndex = 0;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(290, 37);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 1;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // actoresGridView
            // 
            this.actoresGridView.AllowUserToAddRows = false;
            this.actoresGridView.AllowUserToDeleteRows = false;
            this.actoresGridView.AllowUserToResizeRows = false;
            this.actoresGridView.AutoGenerateColumns = false;
            this.actoresGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.actoresGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actoresGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1,
            this.urlPersonalDataGridViewTextBoxColumn1});
            this.actoresGridView.DataSource = this.actorBindingSource;
            this.actoresGridView.Location = new System.Drawing.Point(12, 67);
            this.actoresGridView.Name = "actoresGridView";
            this.actoresGridView.ReadOnly = true;
            this.actoresGridView.RowHeadersVisible = false;
            this.actoresGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.actoresGridView.Size = new System.Drawing.Size(353, 135);
            this.actoresGridView.TabIndex = 2;
            // 
            // seleccionarExistenteButton
            // 
            this.seleccionarExistenteButton.Location = new System.Drawing.Point(290, 208);
            this.seleccionarExistenteButton.Name = "seleccionarExistenteButton";
            this.seleccionarExistenteButton.Size = new System.Drawing.Size(75, 23);
            this.seleccionarExistenteButton.TabIndex = 3;
            this.seleccionarExistenteButton.Text = "Seleccionar";
            this.seleccionarExistenteButton.UseVisualStyleBackColor = true;
            this.seleccionarExistenteButton.Click += new System.EventHandler(this.seleccionarExistenteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "URL personal:";
            // 
            // nombreTxtBox
            // 
            this.nombreTxtBox.Location = new System.Drawing.Point(126, 268);
            this.nombreTxtBox.Name = "nombreTxtBox";
            this.nombreTxtBox.Size = new System.Drawing.Size(239, 23);
            this.nombreTxtBox.TabIndex = 4;
            // 
            // urlTxtBox
            // 
            this.urlTxtBox.Location = new System.Drawing.Point(126, 297);
            this.urlTxtBox.Name = "urlTxtBox";
            this.urlTxtBox.Size = new System.Drawing.Size(239, 23);
            this.urlTxtBox.TabIndex = 5;
            // 
            // agregarButton
            // 
            this.agregarButton.Location = new System.Drawing.Point(290, 332);
            this.agregarButton.Name = "agregarButton";
            this.agregarButton.Size = new System.Drawing.Size(75, 23);
            this.agregarButton.TabIndex = 6;
            this.agregarButton.Text = "Añadir";
            this.agregarButton.UseVisualStyleBackColor = true;
            this.agregarButton.Click += new System.EventHandler(this.agregarButton_Click);
            // 
            // actorBindingSource
            // 
            this.actorBindingSource.DataSource = typeof(MSDNVideo.Comun.Actor);
            // 
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo1.Image = null;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(12, 242);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(353, 20);
            this.etiquetaTitulo1.TabIndex = 3;
            this.etiquetaTitulo1.Titulo = "Nuevo actor";
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
            this.etiquetaTitulo2.Size = new System.Drawing.Size(353, 20);
            this.etiquetaTitulo2.TabIndex = 2;
            this.etiquetaTitulo2.Titulo = "Actor existente";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // urlPersonalDataGridViewTextBoxColumn
            // 
            this.urlPersonalDataGridViewTextBoxColumn.DataPropertyName = "UrlPersonal";
            this.urlPersonalDataGridViewTextBoxColumn.HeaderText = "UrlPersonal";
            this.urlPersonalDataGridViewTextBoxColumn.Name = "urlPersonalDataGridViewTextBoxColumn";
            this.urlPersonalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            this.nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            this.nombreDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // urlPersonalDataGridViewTextBoxColumn1
            // 
            this.urlPersonalDataGridViewTextBoxColumn1.DataPropertyName = "UrlPersonal";
            this.urlPersonalDataGridViewTextBoxColumn1.HeaderText = "URL Personal";
            this.urlPersonalDataGridViewTextBoxColumn1.Name = "urlPersonalDataGridViewTextBoxColumn1";
            this.urlPersonalDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // SeleccionActorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 367);
            this.Controls.Add(this.agregarButton);
            this.Controls.Add(this.urlTxtBox);
            this.Controls.Add(this.nombreTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seleccionarExistenteButton);
            this.Controls.Add(this.actoresGridView);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.buscarTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.etiquetaTitulo1);
            this.Controls.Add(this.etiquetaTitulo2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SeleccionActorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selección actor";
            ((System.ComponentModel.ISupportInitialize)(this.actoresGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EtiquetaTitulo etiquetaTitulo2;
        private EtiquetaTitulo etiquetaTitulo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox buscarTxtBox;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.DataGridView actoresGridView;
        private System.Windows.Forms.Button seleccionarExistenteButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nombreTxtBox;
        private System.Windows.Forms.TextBox urlTxtBox;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.BindingSource actorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlPersonalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlPersonalDataGridViewTextBoxColumn1;
    }
}