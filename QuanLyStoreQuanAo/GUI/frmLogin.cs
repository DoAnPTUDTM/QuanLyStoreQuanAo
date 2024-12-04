using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        NhanVien_BLL bus =new NhanVien_BLL();

        public frmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
            this.btnShowPS.Click += BtnShowPS_Click;
            this.btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtSDT.Text;
            string password = txtPS.Text;
            bool kq = bus.login(username, password);
            //MessageBox.Show(bus.login(username, password));
            if (!kq)
            {
                lblthongbao.Visible = true;
            }
            else
            {
               frmProduct frm=new frmProduct();
                frm.Show();
               
            }
        }

        private void BtnShowPS_Click(object sender, EventArgs e)
        {
           txtPS.UseSystemPasswordChar= true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblthongbao.Visible = false;
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowPS_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPAS_Click(object sender, EventArgs e)
        {
            if (txtPS.UseSystemPasswordChar)
            {
                 txtPS.UseSystemPasswordChar = false;

            }
            else
            {
                txtPS.UseSystemPasswordChar = true;
            }
        }
    }
}
