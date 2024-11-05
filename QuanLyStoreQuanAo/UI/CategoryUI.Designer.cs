namespace UI
{
    partial class CategoryUI
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnSeen = new Guna.UI2.WinForms.Guna2Button();
            this.lbGiaSP = new System.Windows.Forms.Label();
            this.lbTenSP = new System.Windows.Forms.Label();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 8;
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientPanel2);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.SystemColors.MenuHighlight;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(5, 5);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(483, 128);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderRadius = 8;
            this.guna2GradientPanel2.Controls.Add(this.btnSeen);
            this.guna2GradientPanel2.Controls.Add(this.lbGiaSP);
            this.guna2GradientPanel2.Controls.Add(this.lbTenSP);
            this.guna2GradientPanel2.Controls.Add(this.picProduct);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel2.FillColor = System.Drawing.SystemColors.Info;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.SystemColors.Info;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(3, 3);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(477, 122);
            this.guna2GradientPanel2.TabIndex = 1;
            // 
            // btnSeen
            // 
            this.btnSeen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeen.BorderRadius = 10;
            this.btnSeen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSeen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSeen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSeen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSeen.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSeen.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSeen.Location = new System.Drawing.Point(336, 73);
            this.btnSeen.Name = "btnSeen";
            this.btnSeen.Size = new System.Drawing.Size(128, 40);
            this.btnSeen.TabIndex = 10;
            this.btnSeen.Text = "CHI TIẾT";
            // 
            // lbGiaSP
            // 
            this.lbGiaSP.AutoSize = true;
            this.lbGiaSP.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaSP.ForeColor = System.Drawing.Color.Brown;
            this.lbGiaSP.Location = new System.Drawing.Point(128, 82);
            this.lbGiaSP.Name = "lbGiaSP";
            this.lbGiaSP.Size = new System.Drawing.Size(90, 22);
            this.lbGiaSP.TabIndex = 9;
            this.lbGiaSP.Text = "280.000đ";
            // 
            // lbTenSP
            // 
            this.lbTenSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTenSP.AutoEllipsis = true;
            this.lbTenSP.Font = new System.Drawing.Font("Consolas", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSP.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbTenSP.Location = new System.Drawing.Point(128, 11);
            this.lbTenSP.Name = "lbTenSP";
            this.lbTenSP.Size = new System.Drawing.Size(336, 59);
            this.lbTenSP.TabIndex = 8;
            this.lbTenSP.Text = "Tên sản phẩm";
            // 
            // picProduct
            // 
            this.picProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picProduct.Location = new System.Drawing.Point(12, 9);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(110, 104);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProduct.TabIndex = 7;
            this.picProduct.TabStop = false;
            // 
            // CategoryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "CategoryUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(493, 138);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2Button btnSeen;
        private System.Windows.Forms.Label lbGiaSP;
        private System.Windows.Forms.Label lbTenSP;
        private System.Windows.Forms.PictureBox picProduct;
    }
}
