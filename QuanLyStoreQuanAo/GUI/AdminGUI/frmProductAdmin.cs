using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using GUI.SalesGUI;
using UI;

namespace GUI.AdminGUI
{
    public partial class frmProductAdmin : Form
    {
        SanPham_BLL sanpham_bll = new SanPham_BLL();

        frmAddProduct fAddProduct;
        frmEditProduct fEditProduct;
        frmDetailProduct fDetailProduct;

        string pMaSP, pTenSP;


        public frmProductAdmin()
        {
            InitializeComponent();
            this.Load += FrmProductAdmin_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnAdd.Click += BtnAdd_Click;
            btnClearText.Click += BtnClearText_Click;
            btnEdit.Click += BtnEdit_Click;
            btnLoad.Click += BtnLoad_Click;
            btnRemove.Click += BtnRemove_Click;
            dgvProduct.CellMouseClick += DgvProduct_CellMouseClick;
        }

        private void DgvProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pMaSP = dgvProduct.CurrentRow.Cells[0].Value.ToString();

            fDetailProduct = new frmDetailProduct(pMaSP);
            fDetailProduct.ShowDialog();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaSP = dgvProduct.CurrentRow.Cells[0].Value.ToString();
            pTenSP = dgvProduct.CurrentRow.Cells[2].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA SẢN PHẨM " + pTenSP.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                sanpham_bll.removeSP(pMaSP);
                
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG SẢN PHẨM " + pTenSP.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
                    loadDataProduct();
                
                
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadDataProduct();
            
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pMaSP = dgvProduct.CurrentRow.Cells[0].Value.ToString();

            fEditProduct = new frmEditProduct(pMaSP);
            fEditProduct.ShowDialog();
            loadDataProduct();
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddProduct = new frmAddProduct();
            fAddProduct.ShowDialog();
            loadDataProduct();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

            
            dgvProduct.DataSource = sanpham_bll.GetSanPhamBySearch(txtSearch.Text);
            dgvProduct.Controls.Clear();
            dgvProduct.Columns[0].HeaderText = "MÃ SẢN PHẨM";
            dgvProduct.Columns[1].HeaderText = "TÊN SẢN PHẨM";
            dgvProduct.Columns[2].HeaderText = "MÃ DANH MỤC";
            dgvProduct.Columns[3].HeaderText = "SỐ LƯỢNG TỒN";
            dgvProduct.Columns[4].HeaderText = "GIÁ BÁN";
            dgvProduct.Columns[5].HeaderText = "HÃNG SẢN XUẤT";
            dgvProduct.Columns[6].HeaderText = "MÔ TẢ";
        }

        private void FrmProductAdmin_Load(object sender, EventArgs e)
        {
            loadDataProduct();
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {

        }

        private void loadDataProduct()
        {
            dgvProduct.DataSource = sanpham_bll.GetAllSanPham();

            dgvProduct.Columns[0].HeaderText = "MÃ SẢN PHẨM";
            dgvProduct.Columns[1].HeaderText = "TÊN SẢN PHẨM";
            dgvProduct.Columns[2].HeaderText = "MÃ DANH MỤC";
            dgvProduct.Columns[3].HeaderText = "SỐ LƯỢNG TỒN";
            dgvProduct.Columns[4].HeaderText = "GIÁ BÁN";
            dgvProduct.Columns[5].HeaderText = "HÃNG SẢN XUẤT";
            dgvProduct.Columns[6].HeaderText = "MÔ TẢ";




        }
    }
}
