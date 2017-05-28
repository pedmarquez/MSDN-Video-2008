namespace MSDNVideo.Tienda
{
    partial class LookupControl
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
            this.valueTxtBox = new System.Windows.Forms.TextBox();
            this.lookUpButton = new System.Windows.Forms.Button();
            this.valueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // valueTxtBox
            // 
            this.valueTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.valueTxtBox.Location = new System.Drawing.Point(0, 2);
            this.valueTxtBox.Name = "valueTxtBox";
            this.valueTxtBox.Size = new System.Drawing.Size(164, 13);
            this.valueTxtBox.TabIndex = 1;
            this.valueTxtBox.TextChanged += new System.EventHandler(this.valueTxtBox_TextChanged);
            // 
            // lookUpButton
            // 
            this.lookUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpButton.Location = new System.Drawing.Point(166, 0);
            this.lookUpButton.Name = "lookUpButton";
            this.lookUpButton.Size = new System.Drawing.Size(27, 19);
            this.lookUpButton.TabIndex = 2;
            this.lookUpButton.Text = "...";
            this.lookUpButton.UseVisualStyleBackColor = true;
            this.lookUpButton.Click += new System.EventHandler(this.lookUpButton_Click);
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.valueLabel.AutoEllipsis = true;
            this.valueLabel.Location = new System.Drawing.Point(0, 2);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(164, 13);
            this.valueLabel.TabIndex = 3;
            // 
            // LookupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.lookUpButton);
            this.Controls.Add(this.valueTxtBox);
            this.Name = "LookupControl";
            this.Size = new System.Drawing.Size(194, 19);
            this.Resize += new System.EventHandler(this.LookupControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox valueTxtBox;
        internal System.Windows.Forms.Button lookUpButton;
        private System.Windows.Forms.Label valueLabel;

    }
}
