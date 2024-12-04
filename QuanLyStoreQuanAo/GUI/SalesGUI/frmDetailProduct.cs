using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.SalesGUI
{
    public partial class frmDetailProduct : Form
    {
        string pMaSP;
        SanPhamDTO sanpham = new SanPhamDTO();
        SanPham_BLL sanpham_bll = new SanPham_BLL();
        public frmDetailProduct(string _masp)
        {
            InitializeComponent();
            pMaSP = _masp;
            this.Load += FrmDetailProduct_Load;
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDetailProduct_Load(object sender, EventArgs e)
        {
            sanpham = sanpham_bll.GetSanPhamById(pMaSP);

            lbMaSP.Text = sanpham.MaSanPham;
            lbTenSP.Text = sanpham.TenSanPham;
            lbLSP.Text = sanpham.TenDanhMuc;
            lbGia.Text = sanpham.GiaBan.ToString("#,#");
            lbNSX.Text = sanpham.HangSanXuat;
          
            Image image = Image.FromFile("imgs/" + sanpham.DuongDanHinhAnh);
            picProduct.Image = new Bitmap(image);

            lbSLT.Text = sanpham.SoLuongTon.ToString();
            lbMoTa.Text = sanpham.MoTa;
        }
    }
}
