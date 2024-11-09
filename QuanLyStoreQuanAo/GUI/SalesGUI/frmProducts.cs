using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace GUI.SalesGUI
{
    public partial class frmProducts : Form
    {
        CategoryUI[] productItems = new CategoryUI[30];
        SanPham_BLL sanpham_bll = new SanPham_BLL();

        frmDetailProduct fDetailProduct;
        public frmProducts()
        {
            InitializeComponent();
            this.Load += FrmProducts_Load;
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            LoadAllSanPham();
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSanPhamBySearch(txtSearch.Text);
        }

        private void LoadSanPhamBySearch(string Search)
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.GetSanPhamBySearch(Search);

            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new CategoryUI();
                productItems[i].Width = 423;
                productItems[i].Margin = new Padding(3, 3, 0, 0);
                productItems[i].PMaSP = products[i].MaSanPham;
                productItems[i].PTenSp = products[i].TenSanPham;
                productItems[i].PGiaSP = products[i].GiaBan.ToString("#,#") + " vnđ";
                try
                {
                    Image image = Image.FromFile("imgs/" + products[i].DuongDanHinhAnh);
                    productItems[i].PAnh = new Bitmap(image);
                }
                catch (OutOfMemoryException)
                {

                }

                if (flpSanPham.Controls.Count < 0)
                {
                    flpSanPham.Controls.Clear();
                }
                else
                {
                    flpSanPham.Controls.Add(productItems[i]);
                }

                productItems[i].onSelect += (ss, ee) =>
                {
                    var wdg = (CategoryUI)ss;

                    fDetailProduct = new frmDetailProduct(wdg.PMaSP);
                    fDetailProduct.ShowDialog();
                };
            }
        }

        private void LoadAllSanPham()
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.GetAllSanPham();

            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new CategoryUI();
                productItems[i].Width = 423;
                productItems[i].Margin = new Padding(3, 3, 0, 0);
                productItems[i].PMaSP = products[i].MaSanPham;
                productItems[i].PTenSp = products[i].TenSanPham;
                productItems[i].PGiaSP = products[i].GiaBan.ToString("#,#") + " vnđ";
                try
                {
                    Image image = Image.FromFile("imgs/" + products[i].DuongDanHinhAnh);
                    productItems[i].PAnh = new Bitmap(image);
                }
                catch (OutOfMemoryException)
                {

                }

                if (flpSanPham.Controls.Count < 0)
                {
                    flpSanPham.Controls.Clear();
                }
                else
                {
                    flpSanPham.Controls.Add(productItems[i]);
                }

                productItems[i].onSelect += (ss, ee) =>
                {
                    var wdg = (CategoryUI)ss;

                    fDetailProduct = new frmDetailProduct(wdg.PMaSP);
                    fDetailProduct.ShowDialog();
                };
            }
        }
    }
}
