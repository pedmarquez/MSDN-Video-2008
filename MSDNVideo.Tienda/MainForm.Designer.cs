namespace MSDNVideo.Tienda
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refrescarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuevoButton = new System.Windows.Forms.ToolStripButton();
            this.eliminarButton = new System.Windows.Forms.ToolStripButton();
            this.refrescarButton = new System.Windows.Forms.ToolStripButton();
            this.guardarButton = new System.Windows.Forms.ToolStripButton();
            this.buscarButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelBotones = new MSDNVideo.Tienda.PanelBotones();
            this.tablaIniciarSesion = new System.Windows.Forms.TableLayoutPanel();
            this.iniciarSesionLink = new System.Windows.Forms.LinkLabel();
            this.panelBotones1 = new MSDNVideo.Tienda.PanelBotones();
            this.mainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tablaIniciarSesion.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(984, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desconectarMenuItem,
            this.conectarMenuItem,
            this.refrescarMenuItem,
            this.salirMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // desconectarMenuItem
            // 
            this.desconectarMenuItem.Image = global::MSDNVideo.Tienda.Properties.Resources.Desconectar;
            this.desconectarMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.desconectarMenuItem.Name = "desconectarMenuItem";
            this.desconectarMenuItem.Size = new System.Drawing.Size(176, 22);
            this.desconectarMenuItem.Text = "&Desconectar";
            this.desconectarMenuItem.Click += new System.EventHandler(this.desconectarMenuItem_Click);
            // 
            // conectarMenuItem
            // 
            this.conectarMenuItem.Image = global::MSDNVideo.Tienda.Properties.Resources.Conectar;
            this.conectarMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.conectarMenuItem.Name = "conectarMenuItem";
            this.conectarMenuItem.Size = new System.Drawing.Size(176, 22);
            this.conectarMenuItem.Text = "&Conectar a servidor";
            this.conectarMenuItem.Click += new System.EventHandler(this.conectarMenuItem_Click);
            // 
            // refrescarMenuItem
            // 
            this.refrescarMenuItem.Image = global::MSDNVideo.Tienda.Properties.Resources.Refrescar;
            this.refrescarMenuItem.Name = "refrescarMenuItem";
            this.refrescarMenuItem.Size = new System.Drawing.Size(176, 22);
            this.refrescarMenuItem.Text = "&Refrescar";
            // 
            // salirMenuItem
            // 
            this.salirMenuItem.Name = "salirMenuItem";
            this.salirMenuItem.Size = new System.Drawing.Size(176, 22);
            this.salirMenuItem.Text = "&Salir";
            this.salirMenuItem.Click += new System.EventHandler(this.salirMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoMenuItem,
            this.eliminarMenuItem,
            this.guardarMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "&Editar";
            // 
            // nuevoMenuItem
            // 
            this.nuevoMenuItem.Image = global::MSDNVideo.Tienda.Properties.Resources.Nuevo;
            this.nuevoMenuItem.Name = "nuevoMenuItem";
            this.nuevoMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevoMenuItem.Text = "&Nuevo";
            this.nuevoMenuItem.Click += new System.EventHandler(this.nuevoButton_Click);
            // 
            // eliminarMenuItem
            // 
            this.eliminarMenuItem.Image = global::MSDNVideo.Tienda.Properties.Resources.Eliminar;
            this.eliminarMenuItem.Name = "eliminarMenuItem";
            this.eliminarMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarMenuItem.Text = "&Eliminar";
            this.eliminarMenuItem.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // guardarMenuItem
            // 
            this.guardarMenuItem.Image = global::MSDNVideo.Tienda.Properties.Resources.Guardar;
            this.guardarMenuItem.Name = "guardarMenuItem";
            this.guardarMenuItem.Size = new System.Drawing.Size(117, 22);
            this.guardarMenuItem.Text = "&Guardar";
            this.guardarMenuItem.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // acercaDeMenuItem
            // 
            this.acercaDeMenuItem.Name = "acercaDeMenuItem";
            this.acercaDeMenuItem.Size = new System.Drawing.Size(126, 22);
            this.acercaDeMenuItem.Text = "&Acerca de";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoButton,
            this.eliminarButton,
            this.refrescarButton,
            this.guardarButton,
            this.buscarButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuevoButton
            // 
            this.nuevoButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Nuevo;
            this.nuevoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoButton.Name = "nuevoButton";
            this.nuevoButton.Size = new System.Drawing.Size(62, 22);
            this.nuevoButton.Text = "Nuevo";
            this.nuevoButton.Click += new System.EventHandler(this.nuevoButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Eliminar;
            this.eliminarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(70, 22);
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // refrescarButton
            // 
            this.refrescarButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Refrescar;
            this.refrescarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refrescarButton.Name = "refrescarButton";
            this.refrescarButton.Size = new System.Drawing.Size(75, 22);
            this.refrescarButton.Text = "Refrescar";
            // 
            // guardarButton
            // 
            this.guardarButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Guardar;
            this.guardarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(69, 22);
            this.guardarButton.Text = "Guardar";
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // buscarButton
            // 
            this.buscarButton.Image = global::MSDNVideo.Tienda.Properties.Resources.Buscar;
            this.buscarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(62, 22);
            this.buscarButton.Text = "Buscar";
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelBotones);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitContainer1.Panel2.Controls.Add(this.tablaIniciarSesion);
            this.splitContainer1.Size = new System.Drawing.Size(984, 579);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panelBotones.Location = new System.Drawing.Point(0, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(241, 579);
            this.panelBotones.TabIndex = 0;
            this.panelBotones.BotonClicked += new MSDNVideo.Tienda.BotonClickedEventHandler(this.panelBotones_BotonClicked);
            // 
            // tablaIniciarSesion
            // 
            this.tablaIniciarSesion.ColumnCount = 1;
            this.tablaIniciarSesion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaIniciarSesion.Controls.Add(this.iniciarSesionLink, 0, 0);
            this.tablaIniciarSesion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaIniciarSesion.Location = new System.Drawing.Point(0, 0);
            this.tablaIniciarSesion.Name = "tablaIniciarSesion";
            this.tablaIniciarSesion.RowCount = 1;
            this.tablaIniciarSesion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaIniciarSesion.Size = new System.Drawing.Size(739, 579);
            this.tablaIniciarSesion.TabIndex = 1;
            // 
            // iniciarSesionLink
            // 
            this.iniciarSesionLink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iniciarSesionLink.AutoSize = true;
            this.iniciarSesionLink.Location = new System.Drawing.Point(332, 282);
            this.iniciarSesionLink.Name = "iniciarSesionLink";
            this.iniciarSesionLink.Size = new System.Drawing.Size(75, 15);
            this.iniciarSesionLink.TabIndex = 0;
            this.iniciarSesionLink.TabStop = true;
            this.iniciarSesionLink.Text = "Iniciar sesión";
            this.iniciarSesionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iniciarSesionLink_LinkClicked);
            // 
            // panelBotones1
            // 
            this.panelBotones1.BackColor = System.Drawing.Color.White;
            this.panelBotones1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotones1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panelBotones1.Location = new System.Drawing.Point(0, 0);
            this.panelBotones1.Name = "panelBotones1";
            this.panelBotones1.Size = new System.Drawing.Size(229, 579);
            this.panelBotones1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(984, 628);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MSDNVideo - Tienda";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tablaIniciarSesion.ResumeLayout(false);
            this.tablaIniciarSesion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconectarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refrescarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuevoButton;
        private System.Windows.Forms.ToolStripButton eliminarButton;
        private System.Windows.Forms.ToolStripButton refrescarButton;
        private System.Windows.Forms.ToolStripButton guardarButton;
        private System.Windows.Forms.ToolStripButton buscarButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PanelBotones panelBotones1;
        private PanelBotones panelBotones;
        internal System.Windows.Forms.TableLayoutPanel tablaIniciarSesion;
        internal System.Windows.Forms.LinkLabel iniciarSesionLink;

    }
}

