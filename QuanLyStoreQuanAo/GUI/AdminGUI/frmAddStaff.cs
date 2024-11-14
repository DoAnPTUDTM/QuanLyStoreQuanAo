using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
namespace GUI.AdminGUI
{
    public partial class frmAddStaff : Form
    {
        NhanVien_BLL bus = new NhanVien_BLL();
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();

        public frmAddStaff()
        {
            InitializeComponent();
            this.Load += FrmAddStaff_Load;
            btnFinish.Click += BtnFinish_Click;
            btnthoat.Click += Btnthoat_Click;
            this.FormClosing += FrmAddStaff_FormClosing;
            txtEmail.TextChanged += TxtEmail_TextChanged;
            txtSDT.TextChanged += TxtSDT_TextChanged;
        }

        private void TxtSDT_TextChanged(object sender, EventArgs e)
        {
          lbltbsdt.Visible = false;
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            lbltbemail.Visible= false;
        }

        private void FrmAddStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát ", "Thoát ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r ==DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (checkAllTextbox())
            {
                DTO.NhanVien nv = new DTO.NhanVien();
                nv.MaNhanVien = String.Empty;
                nv.HoTen = txtHoTen.Text;
                nv.Email = txtEmail.Text;
                nv.MatKhau = txtMatKhau.Text;
                if (cboLoaiTK.SelectedItem.ToString() == "Nhân Viên Bán Hàng")
                {
                    nv.VaiTro = "BanHang";
                }

                nv.SoDienThoai = txtSDT.Text;
                string kq = bus.register(nv);
                switch (kq)
                {
                    case "mixed":
                        {
                            lbltbsdt.Visible = true;
                            lbltbemail.Visible = true;
                            break;
                        }
                    case "email":
                        {

                            lbltbemail.Visible = true;
                            break;
                        }
                    case "number":
                        {

                            lbltbsdt.Visible = true;
                            break;
                        }
                    case "true":
                        {
                            MessageBox.Show(txtSDT.Text, txtMatKhau.Text);
                            resetTextBox();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Có lôi xảy ra");
                            break;
                        }
                }
            }
            else
            {
                label1.Visible = true;
            }
        }

       public bool checkAllTextbox()
        {
            if(txtEmail.Text==string.Empty|| txtHoTen.Text == string.Empty || txtSDT.Text == string.Empty || txtMatKhau.Text == string.Empty )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void resetTextBox()
        {
            txtMatKhau.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
        private void FrmAddStaff_Load(object sender, EventArgs e)
        {
            cboLoaiTK.Items.Add("Nhân Viên Bán Hàng");
            cboLoaiTK.SelectedItem=cboLoaiTK.Items[0];
            lbltbemail.Visible=false;
            lbltbsdt.Visible = false;
            label1.Visible=false;
        }
    }
}
