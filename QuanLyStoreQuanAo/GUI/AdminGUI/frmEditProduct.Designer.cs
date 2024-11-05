namespace GUI.AdminGUI
{
    partial class frmEditProduct
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
            this.btnGetPicture = new Guna.UI2.WinForms.Guna2Button();
            this.btnFinish = new Guna.UI2.WinForms.Guna2Button();
            this.cboCTLSP = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMota = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSLT = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.picProduct = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenSP = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbFrmName = new ReaLTaiizor.Controls.BigLabel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bigLabel14 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel11 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel10 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel12 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel9 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel8 = new ReaLTaiizor.Controls.BigLabel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.guna2GradientPanel3.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetPicture
            // 
            this.btnGetPicture.BorderRadius = 10;
            this.btnGetPicture.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGetPicture.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGetPicture.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGetPicture.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGetPicture.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGetPicture.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPicture.ForeColor = System.Drawing.Color.White;
            this.btnGetPicture.Location = new System.Drawing.Point(301, 574);
            this.btnGetPicture.Name = "btnGetPicture";
            this.btnGetPicture.Size = new System.Drawing.Size(162, 42);
            this.btnGetPicture.TabIndex = 28;
            this.btnGetPicture.Text = "Chọn ảnh";
            // 
            // btnFinish
            // 
            this.btnFinish.BorderRadius = 10;
            this.btnFinish.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFinish.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFinish.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFinish.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFinish.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFinish.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(854, 863);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(290, 69);
            this.btnFinish.TabIndex = 27;
            this.btnFinish.Text = "HOÀN TẤT";
            // 
            // cboCTLSP
            // 
            this.cboCTLSP.BackColor = System.Drawing.Color.Transparent;
            this.cboCTLSP.BorderRadius = 5;
            this.cboCTLSP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCTLSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCTLSP.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCTLSP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCTLSP.Font = new System.Drawing.Font("Consolas", 13.8F);
            this.cboCTLSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCTLSP.ItemHeight = 30;
            this.cboCTLSP.Location = new System.Drawing.Point(280, 118);
            this.cboCTLSP.Name = "cboCTLSP";
            this.cboCTLSP.Size = new System.Drawing.Size(324, 36);
            this.cboCTLSP.TabIndex = 26;
            // 
            // txtMota
            // 
            this.txtMota.BorderRadius = 5;
            this.txtMota.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMota.DefaultText = "";
            this.txtMota.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMota.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMota.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMota.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMota.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMota.Font = new System.Drawing.Font("Consolas", 13.8F);
            this.txtMota.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMota.Location = new System.Drawing.Point(854, 289);
            this.txtMota.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.PasswordChar = '\0';
            this.txtMota.PlaceholderText = "";
            this.txtMota.SelectedText = "";
            this.txtMota.Size = new System.Drawing.Size(324, 232);
            this.txtMota.TabIndex = 22;
            // 
            // txtSLT
            // 
            this.txtSLT.BackColor = System.Drawing.Color.Transparent;
            this.txtSLT.BorderRadius = 5;
            this.txtSLT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSLT.Enabled = false;
            this.txtSLT.Font = new System.Drawing.Font("Consolas", 13.8F);
            this.txtSLT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtSLT.Location = new System.Drawing.Point(854, 111);
            this.txtSLT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSLT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSLT.Name = "txtSLT";
            this.txtSLT.Size = new System.Drawing.Size(324, 43);
            this.txtSLT.TabIndex = 21;
            this.txtSLT.UpDownButtonFillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtSLT.UpDownButtonForeColor = System.Drawing.SystemColors.MenuHighlight;
            // 
            // picProduct
            // 
            this.picProduct.ImageRotate = 0F;
            this.picProduct.Location = new System.Drawing.Point(239, 289);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(270, 270);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProduct.TabIndex = 20;
            this.picProduct.TabStop = false;
            // 
            // txtGia
            // 
            this.txtGia.BorderRadius = 5;
            this.txtGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGia.DefaultText = "";
            this.txtGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGia.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGia.Location = new System.Drawing.Point(854, 31);
            this.txtGia.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtGia.Name = "txtGia";
            this.txtGia.PasswordChar = '\0';
            this.txtGia.PlaceholderText = "";
            this.txtGia.SelectedText = "";
            this.txtGia.Size = new System.Drawing.Size(324, 43);
            this.txtGia.TabIndex = 16;
            // 
            // txtTenSP
            // 
            this.txtTenSP.BorderRadius = 5;
            this.txtTenSP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenSP.DefaultText = "";
            this.txtTenSP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenSP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenSP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenSP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenSP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenSP.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenSP.Location = new System.Drawing.Point(280, 31);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.PasswordChar = '\0';
            this.txtTenSP.PlaceholderText = "";
            this.txtTenSP.SelectedText = "";
            this.txtTenSP.Size = new System.Drawing.Size(324, 43);
            this.txtTenSP.TabIndex = 15;
            // 
            // lbFrmName
            // 
            this.lbFrmName.AutoSize = true;
            this.lbFrmName.BackColor = System.Drawing.Color.Transparent;
            this.lbFrmName.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrmName.ForeColor = System.Drawing.Color.White;
            this.lbFrmName.Location = new System.Drawing.Point(26, 15);
            this.lbFrmName.Name = "lbFrmName";
            this.lbFrmName.Size = new System.Drawing.Size(168, 27);
            this.lbFrmName.TabIndex = 6;
            this.lbFrmName.Text = "SỬA SẢN PHẨM";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Animated = true;
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1112, 0);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(60, 49);
            this.guna2ControlBox1.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Animated = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnExit.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.btnExit.Location = new System.Drawing.Point(1172, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 49);
            this.btnExit.TabIndex = 2;
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.AutoScroll = true;
            this.guna2GradientPanel3.Controls.Add(this.guna2TextBox1);
            this.guna2GradientPanel3.Controls.Add(this.btnGetPicture);
            this.guna2GradientPanel3.Controls.Add(this.btnFinish);
            this.guna2GradientPanel3.Controls.Add(this.cboCTLSP);
            this.guna2GradientPanel3.Controls.Add(this.txtMota);
            this.guna2GradientPanel3.Controls.Add(this.txtSLT);
            this.guna2GradientPanel3.Controls.Add(this.picProduct);
            this.guna2GradientPanel3.Controls.Add(this.txtGia);
            this.guna2GradientPanel3.Controls.Add(this.txtTenSP);
            this.guna2GradientPanel3.Controls.Add(this.panel1);
            this.guna2GradientPanel3.Controls.Add(this.bigLabel14);
            this.guna2GradientPanel3.Controls.Add(this.bigLabel11);
            this.guna2GradientPanel3.Controls.Add(this.bigLabel10);
            this.guna2GradientPanel3.Controls.Add(this.bigLabel12);
            this.guna2GradientPanel3.Controls.Add(this.bigLabel3);
            this.guna2GradientPanel3.Controls.Add(this.bigLabel9);
            this.guna2GradientPanel3.Controls.Add(this.bigLabel8);
            this.guna2GradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel3.Location = new System.Drawing.Point(10, 0);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Size = new System.Drawing.Size(1212, 974);
            this.guna2GradientPanel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(908, 938);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 34);
            this.panel1.TabIndex = 7;
            // 
            // bigLabel14
            // 
            this.bigLabel14.AutoSize = true;
            this.bigLabel14.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel14.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel14.Location = new System.Drawing.Point(28, 127);
            this.bigLabel14.Name = "bigLabel14";
            this.bigLabel14.Size = new System.Drawing.Size(246, 27);
            this.bigLabel14.TabIndex = 0;
            this.bigLabel14.Text = "Danh mục sản phẩm:";
            // 
            // bigLabel11
            // 
            this.bigLabel11.AutoSize = true;
            this.bigLabel11.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel11.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel11.Location = new System.Drawing.Point(731, 289);
            this.bigLabel11.Name = "bigLabel11";
            this.bigLabel11.Size = new System.Drawing.Size(90, 27);
            this.bigLabel11.TabIndex = 0;
            this.bigLabel11.Text = "Mô tả:";
            // 
            // bigLabel10
            // 
            this.bigLabel10.AutoSize = true;
            this.bigLabel10.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel10.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel10.Location = new System.Drawing.Point(38, 415);
            this.bigLabel10.Name = "bigLabel10";
            this.bigLabel10.Size = new System.Drawing.Size(64, 27);
            this.bigLabel10.TabIndex = 0;
            this.bigLabel10.Text = "Ảnh:";
            // 
            // bigLabel12
            // 
            this.bigLabel12.AutoSize = true;
            this.bigLabel12.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel12.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel12.Location = new System.Drawing.Point(640, 215);
            this.bigLabel12.Name = "bigLabel12";
            this.bigLabel12.Size = new System.Drawing.Size(181, 27);
            this.bigLabel12.TabIndex = 0;
            this.bigLabel12.Text = "Nhà cung cấp:";
            // 
            // bigLabel3
            // 
            this.bigLabel3.AutoSize = true;
            this.bigLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel3.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel3.Location = new System.Drawing.Point(28, 47);
            this.bigLabel3.Name = "bigLabel3";
            this.bigLabel3.Size = new System.Drawing.Size(181, 27);
            this.bigLabel3.TabIndex = 0;
            this.bigLabel3.Text = "Tên sản phẩm:";
            // 
            // bigLabel9
            // 
            this.bigLabel9.AutoSize = true;
            this.bigLabel9.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel9.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel9.Location = new System.Drawing.Point(640, 127);
            this.bigLabel9.Name = "bigLabel9";
            this.bigLabel9.Size = new System.Drawing.Size(181, 27);
            this.bigLabel9.TabIndex = 0;
            this.bigLabel9.Text = "Số lượng tồn:";
            // 
            // bigLabel8
            // 
            this.bigLabel8.AutoSize = true;
            this.bigLabel8.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel8.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel8.Location = new System.Drawing.Point(757, 47);
            this.bigLabel8.Name = "bigLabel8";
            this.bigLabel8.Size = new System.Drawing.Size(64, 27);
            this.bigLabel8.TabIndex = 0;
            this.bigLabel8.Text = "Giá:";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientPanel3);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.SystemColors.MenuHighlight;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 49);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1232, 984);
            this.guna2GradientPanel1.TabIndex = 7;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.lbFrmName);
            this.guna2GradientPanel2.Controls.Add(this.guna2ControlBox1);
            this.guna2GradientPanel2.Controls.Add(this.btnExit);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel2.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.SystemColors.MenuHighlight;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(1232, 49);
            this.guna2GradientPanel2.TabIndex = 6;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderRadius = 5;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(854, 199);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(324, 43);
            this.guna2TextBox1.TabIndex = 29;
            // 
            // frmEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 1033);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.guna2GradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditProduct";
            ((System.ComponentModel.ISupportInitialize)(this.txtSLT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnGetPicture;
        private Guna.UI2.WinForms.Guna2Button btnFinish;
        private Guna.UI2.WinForms.Guna2ComboBox cboCTLSP;
        private Guna.UI2.WinForms.Guna2TextBox txtMota;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtSLT;
        private Guna.UI2.WinForms.Guna2PictureBox picProduct;
        private Guna.UI2.WinForms.Guna2TextBox txtGia;
        private Guna.UI2.WinForms.Guna2TextBox txtTenSP;
        private ReaLTaiizor.Controls.BigLabel lbFrmName;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel14;
        private ReaLTaiizor.Controls.BigLabel bigLabel11;
        private ReaLTaiizor.Controls.BigLabel bigLabel10;
        private ReaLTaiizor.Controls.BigLabel bigLabel12;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.BigLabel bigLabel9;
        private ReaLTaiizor.Controls.BigLabel bigLabel8;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}