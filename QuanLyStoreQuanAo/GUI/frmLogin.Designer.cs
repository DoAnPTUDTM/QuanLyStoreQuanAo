namespace GUI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.txtSDT = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblthongbao = new ReaLTaiizor.Controls.MoonLabel();
            this.moonLabel1 = new ReaLTaiizor.Controls.MoonLabel();
            this.txtPS = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbError = new ReaLTaiizor.Controls.CrownLabel();
            this.moonLabel2 = new ReaLTaiizor.Controls.MoonLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.btnLogin = new ReaLTaiizor.Controls.Button();
            this.btnShowPS = new ReaLTaiizor.Controls.ParrotPictureBox();
            this.btnPAS = new ReaLTaiizor.Controls.AloneButton();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 7);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(499, 498);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(499, 498);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.btnPAS);
            this.metroPanel2.Controls.Add(this.txtSDT);
            this.metroPanel2.Controls.Add(this.lblthongbao);
            this.metroPanel2.Controls.Add(this.moonLabel1);
            this.metroPanel2.Controls.Add(this.btnShowPS);
            this.metroPanel2.Controls.Add(this.txtPS);
            this.metroPanel2.Controls.Add(this.lbError);
            this.metroPanel2.Controls.Add(this.moonLabel2);
            this.metroPanel2.Controls.Add(this.bigLabel1);
            this.metroPanel2.Controls.Add(this.btnLogin);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(497, 74);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(555, 431);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 11;
            this.metroPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.metroPanel2_Paint);
            // 
            // txtSDT
            // 
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.DefaultText = "";
            this.txtSDT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSDT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSDT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.ForeColor = System.Drawing.Color.DimGray;
            this.txtSDT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Location = new System.Drawing.Point(201, 140);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(5);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PasswordChar = '\0';
            this.txtSDT.PlaceholderText = "";
            this.txtSDT.SelectedText = "";
            this.txtSDT.Size = new System.Drawing.Size(304, 46);
            this.txtSDT.TabIndex = 22;
            // 
            // lblthongbao
            // 
            this.lblthongbao.AutoSize = true;
            this.lblthongbao.BackColor = System.Drawing.Color.Transparent;
            this.lblthongbao.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblthongbao.ForeColor = System.Drawing.Color.Red;
            this.lblthongbao.Location = new System.Drawing.Point(146, 289);
            this.lblthongbao.Name = "lblthongbao";
            this.lblthongbao.Size = new System.Drawing.Size(351, 20);
            this.lblthongbao.TabIndex = 21;
            this.lblthongbao.Text = "Số điện thoại hoặc mật khẩu không đúng";
            // 
            // moonLabel1
            // 
            this.moonLabel1.AutoSize = true;
            this.moonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moonLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel1.Location = new System.Drawing.Point(8, 153);
            this.moonLabel1.Name = "moonLabel1";
            this.moonLabel1.Size = new System.Drawing.Size(164, 23);
            this.moonLabel1.TabIndex = 20;
            this.moonLabel1.Text = "SỐ ĐIỆN THOẠI:";
            // 
            // txtPS
            // 
            this.txtPS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPS.DefaultText = "";
            this.txtPS.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPS.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPS.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPS.ForeColor = System.Drawing.Color.DimGray;
            this.txtPS.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPS.Location = new System.Drawing.Point(201, 213);
            this.txtPS.Margin = new System.Windows.Forms.Padding(5);
            this.txtPS.Name = "txtPS";
            this.txtPS.PasswordChar = '\0';
            this.txtPS.PlaceholderText = "";
            this.txtPS.SelectedText = "";
            this.txtPS.Size = new System.Drawing.Size(252, 46);
            this.txtPS.TabIndex = 16;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbError.Location = new System.Drawing.Point(193, 260);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 16);
            this.lbError.TabIndex = 14;
            // 
            // moonLabel2
            // 
            this.moonLabel2.AutoSize = true;
            this.moonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moonLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel2.Location = new System.Drawing.Point(63, 224);
            this.moonLabel2.Name = "moonLabel2";
            this.moonLabel2.Size = new System.Drawing.Size(109, 23);
            this.moonLabel2.TabIndex = 4;
            this.moonLabel2.Text = "MẬT KHẨU:";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bigLabel1.Location = new System.Drawing.Point(65, 18);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(432, 93);
            this.bigLabel1.TabIndex = 3;
            this.bigLabel1.Text = "WELCOME";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.EnteredBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.EnteredColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Image = null;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.InactiveColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLogin.Location = new System.Drawing.Point(161, 340);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.PressedColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Size = new System.Drawing.Size(263, 66);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnShowPS
            // 
            this.btnShowPS.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPS.ColorLeft = System.Drawing.Color.Transparent;
            this.btnShowPS.ColorRight = System.Drawing.Color.Transparent;
            this.btnShowPS.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.btnShowPS.FilterAlpha = 200;
            this.btnShowPS.FilterEnabled = true;
            this.btnShowPS.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPS.Image")));
            this.btnShowPS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btnShowPS.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.btnShowPS.IsElipse = false;
            this.btnShowPS.IsParallax = false;
            this.btnShowPS.Location = new System.Drawing.Point(461, 365);
            this.btnShowPS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowPS.Name = "btnShowPS";
            this.btnShowPS.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.btnShowPS.Size = new System.Drawing.Size(44, 41);
            this.btnShowPS.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.btnShowPS.TabIndex = 17;
            this.btnShowPS.Tag = "closePS";
            this.btnShowPS.Text = "parrotPictureBox1";
            this.btnShowPS.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnShowPS.Click += new System.EventHandler(this.btnShowPS_Click_1);
            // 
            // btnPAS
            // 
            this.btnPAS.BackgroundImage = global::GUI.Properties.Resources.close_eyes_32;
            this.btnPAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPAS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPAS.EnabledCalc = true;
            this.btnPAS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPAS.ForeColor = System.Drawing.Color.White;
            this.btnPAS.Location = new System.Drawing.Point(461, 213);
            this.btnPAS.Name = "btnPAS";
            this.btnPAS.Size = new System.Drawing.Size(44, 46);
            this.btnPAS.TabIndex = 24;
            this.btnPAS.Click += new ReaLTaiizor.Controls.AloneButton.ClickEventHandler(this.btnPAS_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 505);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(0, 74, 0, 0);
            this.Text = "                  ";
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private ReaLTaiizor.Controls.Button btnLogin;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.MoonLabel moonLabel2;
        private ReaLTaiizor.Controls.CrownLabel lbError;
        private Guna.UI2.WinForms.Guna2TextBox txtPS;
        private ReaLTaiizor.Controls.MoonLabel moonLabel1;
        private ReaLTaiizor.Controls.MoonLabel lblthongbao;
        private Guna.UI2.WinForms.Guna2TextBox txtSDT;
        private ReaLTaiizor.Controls.ParrotPictureBox btnShowPS;
        private ReaLTaiizor.Controls.AloneButton btnPAS;
    }
}

