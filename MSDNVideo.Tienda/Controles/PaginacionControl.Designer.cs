namespace MSDNVideo.Tienda
{
    partial class PaginacionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginacionControl));
            this.firstButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            this.firstTxtBox = new System.Windows.Forms.TextBox();
            this.paginaLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstButton
            // 
            this.firstButton.Image = ((System.Drawing.Image)(resources.GetObject("firstButton.Image")));
            this.firstButton.Location = new System.Drawing.Point(3, 0);
            this.firstButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(25, 20);
            this.firstButton.TabIndex = 1;
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Image = global::MSDNVideo.Tienda.Properties.Resources.previous;
            this.previousButton.Location = new System.Drawing.Point(34, 0);
            this.previousButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(25, 20);
            this.previousButton.TabIndex = 2;
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Image = global::MSDNVideo.Tienda.Properties.Resources.next;
            this.nextButton.Location = new System.Drawing.Point(195, 0);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(25, 20);
            this.nextButton.TabIndex = 3;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // lastButton
            // 
            this.lastButton.Image = global::MSDNVideo.Tienda.Properties.Resources.last;
            this.lastButton.Location = new System.Drawing.Point(226, 0);
            this.lastButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(25, 20);
            this.lastButton.TabIndex = 4;
            this.lastButton.UseVisualStyleBackColor = true;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // firstTxtBox
            // 
            this.firstTxtBox.Location = new System.Drawing.Point(65, 0);
            this.firstTxtBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.firstTxtBox.Multiline = true;
            this.firstTxtBox.Name = "firstTxtBox";
            this.firstTxtBox.Size = new System.Drawing.Size(32, 20);
            this.firstTxtBox.TabIndex = 5;
            this.firstTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.firstTxtBox.Leave += new System.EventHandler(this.firstTxtBox_Leave);
            // 
            // paginaLbl
            // 
            this.paginaLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.paginaLbl.AutoSize = true;
            this.paginaLbl.Location = new System.Drawing.Point(103, 0);
            this.paginaLbl.Name = "paginaLbl";
            this.paginaLbl.Size = new System.Drawing.Size(86, 20);
            this.paginaLbl.TabIndex = 6;
            this.paginaLbl.Text = "al 1000 de 1000";
            this.paginaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.firstTxtBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lastButton, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.paginaLbl, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.firstButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.previousButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-3, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 20);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // PaginacionControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PaginacionControl";
            this.Size = new System.Drawing.Size(257, 20);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.TextBox firstTxtBox;
        private System.Windows.Forms.Label paginaLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}
