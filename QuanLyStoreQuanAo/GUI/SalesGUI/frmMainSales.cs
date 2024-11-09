using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace GUI.SalesGUI
{
    public partial class frmMainSales : Form
    {
        frmSales fSales = new frmSales("0911222333");
        frmProducts fProducts = new frmProducts();
        frmBill fBill = new frmBill();
        frmHomeSales fHomeSales = new frmHomeSales();

        public frmMainSales()
        {
            InitializeComponent();
            this.Load += FrmMainSales_Load;
            btnHome.Click += BtnHome_Click;
            btnSale.Click += BtnSale_Click;
            btnProduct.Click += BtnProduct_Click;
            btnBill.Click += BtnBill_Click;
            btnLogout.Click += BtnLogout_Click;
            btnExit.Click += BtnExit_Click;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            pnHome.Visible = true;
            pnSale.Visible = false;
            pnProduct.Visible = false;
            pnBill.Visible = false;

            fHomeSales = new frmHomeSales();
            pnBody.Controls.Clear();
            fHomeSales.TopLevel = false;
            pnBody.Controls.Add(fHomeSales);
            fHomeSales.Dock = DockStyle.Fill;
            fHomeSales.Show();
        }

        private void BtnSale_Click(object sender, EventArgs e)
        {
            pnSale.Visible = true;
            pnHome.Visible = false;
            pnProduct.Visible = false;
            pnBill.Visible = false;

            pnBody.Controls.Clear();
            fSales.TopLevel = false;
            pnBody.Controls.Add(fSales);
            fSales.Dock = DockStyle.Fill;
            fSales.Show();
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            pnProduct.Visible = true;
            pnSale.Visible = false;
            pnHome.Visible = false;
            pnBill.Visible = false;

            pnBody.Controls.Clear();
            fProducts.TopLevel = false;
            pnBody.Controls.Add(fProducts);
            fProducts.Dock = DockStyle.Fill;
            fProducts.Show();
        }

        private void BtnBill_Click(object sender, EventArgs e)
        {
            pnBill.Visible = true;
            pnSale.Visible = false;
            pnProduct.Visible = false;
            pnHome.Visible = false;

            fBill = new frmBill();
            pnBody.Controls.Clear();
            fBill.TopLevel = false;
            pnBody.Controls.Add(fBill);
            fBill.Dock = DockStyle.Fill;
            fBill.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fLogin = new frmLogin();
            fLogin.Show();
            this.Close();
        }

        private void FrmMainSales_Load(object sender, EventArgs e)
        {
            setSizeFrom();
            pnHome.Visible = true;
            pnSale.Visible = false;
            pnProduct.Visible = false;
            pnBill.Visible = false;

            pnBody.Controls.Clear();
            fSales.TopLevel = false;
            pnBody.Controls.Add(fSales);
            fSales.Dock = DockStyle.Fill;
            fSales.Show();

            pnBody.Controls.Clear();
            fHomeSales.TopLevel = false;
            pnBody.Controls.Add(fHomeSales);
            fHomeSales.Dock = DockStyle.Fill;
            fHomeSales.Show();
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
