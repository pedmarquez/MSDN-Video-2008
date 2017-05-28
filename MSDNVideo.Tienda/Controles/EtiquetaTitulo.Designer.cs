namespace MSDNVideo.Tienda
{
    partial class EtiquetaTitulo
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
            this.tituloLabel = new System.Windows.Forms.Label();
            this.iconoPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // tituloLabel
            // 
            this.tituloLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloLabel.BackColor = System.Drawing.Color.Transparent;
            this.tituloLabel.ForeColor = System.Drawing.Color.White;
            this.tituloLabel.Location = new System.Drawing.Point(4, 2);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(386, 28);
            this.tituloLabel.TabIndex = 0;
            this.tituloLabel.Text = "Título";
            this.tituloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconoPicture
            // 
            this.iconoPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.iconoPicture.BackColor = System.Drawing.Color.Transparent;
            this.iconoPicture.Location = new System.Drawing.Point(396, 0);
            this.iconoPicture.Name = "iconoPicture";
            this.iconoPicture.Size = new System.Drawing.Size(25, 33);
            this.iconoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconoPicture.TabIndex = 1;
            this.iconoPicture.TabStop = false;
            // 
            // EtiquetaTitulo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.Controls.Add(this.iconoPicture);
            this.Controls.Add(this.tituloLabel);
            this.Name = "EtiquetaTitulo";
            this.Size = new System.Drawing.Size(424, 33);
            ((System.ComponentModel.ISupportInitialize)(this.iconoPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.PictureBox iconoPicture;
    }
}
