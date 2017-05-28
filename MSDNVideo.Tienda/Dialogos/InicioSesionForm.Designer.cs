namespace MSDNVideo.Tienda
{
    partial class InicioSesionForm
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
            this.lnkDetalles = new System.Windows.Forms.LinkLabel();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.nifTxtBox = new System.Windows.Forms.TextBox();
            this.claveTxtBox = new System.Windows.Forms.TextBox();
            this.servidorTxtBox = new System.Windows.Forms.TextBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkDetalles
            // 
            this.lnkDetalles.AutoSize = true;
            this.lnkDetalles.Location = new System.Drawing.Point(158, 173);
            this.lnkDetalles.Name = "lnkDetalles";
            this.lnkDetalles.Size = new System.Drawing.Size(57, 15);
            this.lnkDetalles.TabIndex = 22;
            this.lnkDetalles.TabStop = true;
            this.lnkDetalles.Text = "Detalles...";
            this.lnkDetalles.Visible = false;
            this.lnkDetalles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetalles_LinkClicked);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(271, 114);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 15);
            this.Label5.TabIndex = 21;
            this.Label5.Text = "(12345)";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(271, 88);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 15);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "(99999999R)";
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(7, 173);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(217, 18);
            this.lblError.TabIndex = 19;
            // 
            // nifTxtBox
            // 
            this.nifTxtBox.Location = new System.Drawing.Point(101, 85);
            this.nifTxtBox.Name = "nifTxtBox";
            this.nifTxtBox.Size = new System.Drawing.Size(146, 23);
            this.nifTxtBox.TabIndex = 10;
            this.nifTxtBox.Text = "99999999R";
            // 
            // claveTxtBox
            // 
            this.claveTxtBox.Location = new System.Drawing.Point(101, 111);
            this.claveTxtBox.Name = "claveTxtBox";
            this.claveTxtBox.Size = new System.Drawing.Size(146, 23);
            this.claveTxtBox.TabIndex = 12;
            this.claveTxtBox.Text = "12345";
            this.claveTxtBox.UseSystemPasswordChar = true;
            // 
            // servidorTxtBox
            // 
            this.servidorTxtBox.Location = new System.Drawing.Point(101, 137);
            this.servidorTxtBox.Name = "servidorTxtBox";
            this.servidorTxtBox.Size = new System.Drawing.Size(292, 23);
            this.servidorTxtBox.TabIndex = 15;
            this.servidorTxtBox.Text = "http://localhost:52442/MSDNVideoServices.svc/ws";
            // 
            // cancelarButton
            // 
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(318, 168);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 18;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(237, 168);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 16;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 138);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(53, 15);
            this.Label3.TabIndex = 17;
            this.Label3.Text = "Servidor:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 113);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(39, 15);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Clave:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 88);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 15);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "NIF:";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::MSDNVideo.Tienda.Properties.Resources.BannerLogin;
            this.PictureBox1.Location = new System.Drawing.Point(1, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(406, 70);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 11;
            this.PictureBox1.TabStop = false;
            // 
            // InicioSesionForm
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(405, 199);
            this.Controls.Add(this.lnkDetalles);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.nifTxtBox);
            this.Controls.Add(this.claveTxtBox);
            this.Controls.Add(this.servidorTxtBox);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InicioSesionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inicio sesión";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.LinkLabel lnkDetalles;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblError;
        internal System.Windows.Forms.TextBox nifTxtBox;
        internal System.Windows.Forms.TextBox claveTxtBox;
        internal System.Windows.Forms.TextBox servidorTxtBox;
        internal System.Windows.Forms.Button cancelarButton;
        internal System.Windows.Forms.Button aceptarButton;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}