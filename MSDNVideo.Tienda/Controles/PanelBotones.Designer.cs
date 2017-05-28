namespace MSDNVideo.Tienda
{
    partial class PanelBotones
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
            this.etiquetaTitulo1 = new MSDNVideo.Tienda.EtiquetaTitulo();
            this.puntuacionesButton = new MSDNVideo.Tienda.BotonPanel();
            this.notificacionesButton = new MSDNVideo.Tienda.BotonPanel();
            this.recogidasButton = new MSDNVideo.Tienda.BotonPanel();
            this.ventasButton = new MSDNVideo.Tienda.BotonPanel();
            this.devolucionesButton = new MSDNVideo.Tienda.BotonPanel();
            this.sociosButton = new MSDNVideo.Tienda.BotonPanel();
            this.peliculasButton = new MSDNVideo.Tienda.BotonPanel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.informesControl1 = new MSDNVideo.InformesWPF.InformesControl();
            this.SuspendLayout();
            // 
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.etiquetaTitulo1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaTitulo1.Image = null;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(0, 0);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(216, 31);
            this.etiquetaTitulo1.TabIndex = 7;
            this.etiquetaTitulo1.Titulo = "Panel de Control";
            // 
            // puntuacionesButton
            // 
            this.puntuacionesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.puntuacionesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.puntuacionesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntuacionesButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Puntuaciones;
            this.puntuacionesButton.LineaInferior = false;
            this.puntuacionesButton.Location = new System.Drawing.Point(0, 219);
            this.puntuacionesButton.Name = "puntuacionesButton";
            this.puntuacionesButton.Size = new System.Drawing.Size(216, 34);
            this.puntuacionesButton.TabIndex = 6;
            this.puntuacionesButton.Tag = "6";
            this.puntuacionesButton.Text = "Puntuaciones";
            this.puntuacionesButton.UseVisualStyleBackColor = true;
            this.puntuacionesButton.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            // 
            // notificacionesButton
            // 
            this.notificacionesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notificacionesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.notificacionesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificacionesButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Notificaciones;
            this.notificacionesButton.LineaInferior = false;
            this.notificacionesButton.Location = new System.Drawing.Point(0, 253);
            this.notificacionesButton.Name = "notificacionesButton";
            this.notificacionesButton.Size = new System.Drawing.Size(216, 34);
            this.notificacionesButton.TabIndex = 5;
            this.notificacionesButton.Tag = "5";
            this.notificacionesButton.Text = "Notificaciones";
            this.notificacionesButton.UseVisualStyleBackColor = true;
            this.notificacionesButton.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            // 
            // recogidasButton
            // 
            this.recogidasButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recogidasButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.recogidasButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recogidasButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Recoger;
            this.recogidasButton.LineaInferior = false;
            this.recogidasButton.Location = new System.Drawing.Point(0, 287);
            this.recogidasButton.Name = "recogidasButton";
            this.recogidasButton.Size = new System.Drawing.Size(216, 34);
            this.recogidasButton.TabIndex = 4;
            this.recogidasButton.Tag = "4";
            this.recogidasButton.Text = "Recogidas";
            this.recogidasButton.UseVisualStyleBackColor = true;
            this.recogidasButton.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            // 
            // ventasButton
            // 
            this.ventasButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ventasButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ventasButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasButton.Image = global::MSDNVideo.Tienda.Properties.Resources.ComprasAlquileres;
            this.ventasButton.LineaInferior = false;
            this.ventasButton.Location = new System.Drawing.Point(0, 321);
            this.ventasButton.Name = "ventasButton";
            this.ventasButton.Size = new System.Drawing.Size(216, 34);
            this.ventasButton.TabIndex = 3;
            this.ventasButton.Tag = "3";
            this.ventasButton.Text = "Ventas y alquileres";
            this.ventasButton.UseVisualStyleBackColor = true;
            this.ventasButton.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            // 
            // devolucionesButton
            // 
            this.devolucionesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.devolucionesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.devolucionesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devolucionesButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Devolver;
            this.devolucionesButton.LineaInferior = false;
            this.devolucionesButton.Location = new System.Drawing.Point(0, 355);
            this.devolucionesButton.Name = "devolucionesButton";
            this.devolucionesButton.Size = new System.Drawing.Size(216, 34);
            this.devolucionesButton.TabIndex = 2;
            this.devolucionesButton.Tag = "2";
            this.devolucionesButton.Text = "Devoluciones";
            this.devolucionesButton.UseVisualStyleBackColor = true;
            this.devolucionesButton.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            // 
            // sociosButton
            // 
            this.sociosButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sociosButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sociosButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sociosButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Usuarios;
            this.sociosButton.LineaInferior = false;
            this.sociosButton.Location = new System.Drawing.Point(0, 389);
            this.sociosButton.Name = "sociosButton";
            this.sociosButton.Size = new System.Drawing.Size(216, 34);
            this.sociosButton.TabIndex = 1;
            this.sociosButton.Tag = "1";
            this.sociosButton.Text = "Socios";
            this.sociosButton.UseVisualStyleBackColor = true;
            this.sociosButton.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            // 
            // peliculasButton
            // 
            this.peliculasButton.Checked = true;
            this.peliculasButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peliculasButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.peliculasButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peliculasButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Peliculas;
            this.peliculasButton.LineaInferior = true;
            this.peliculasButton.Location = new System.Drawing.Point(0, 423);
            this.peliculasButton.Name = "peliculasButton";
            this.peliculasButton.Size = new System.Drawing.Size(216, 34);
            this.peliculasButton.TabIndex = 0;
            this.peliculasButton.TabStop = true;
            this.peliculasButton.Tag = "0";
            this.peliculasButton.Text = "Peliculas";
            this.peliculasButton.UseVisualStyleBackColor = true;
            this.peliculasButton.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 31);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(216, 188);
            this.elementHost1.TabIndex = 8;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.informesControl1;
            // 
            // PanelBotones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.etiquetaTitulo1);
            this.Controls.Add(this.puntuacionesButton);
            this.Controls.Add(this.notificacionesButton);
            this.Controls.Add(this.recogidasButton);
            this.Controls.Add(this.ventasButton);
            this.Controls.Add(this.devolucionesButton);
            this.Controls.Add(this.sociosButton);
            this.Controls.Add(this.peliculasButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PanelBotones";
            this.Size = new System.Drawing.Size(216, 457);
            this.ResumeLayout(false);

        }

        #endregion

        private BotonPanel peliculasButton;
        private BotonPanel sociosButton;
        private BotonPanel devolucionesButton;
        private BotonPanel ventasButton;
        private BotonPanel recogidasButton;
        private BotonPanel notificacionesButton;
        private BotonPanel puntuacionesButton;
        private EtiquetaTitulo etiquetaTitulo1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private MSDNVideo.InformesWPF.InformesControl informesControl1;

    }
}
