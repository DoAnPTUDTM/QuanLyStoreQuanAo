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

namespace GUI.AdminGUI
{
    public partial class frmCategory : Form
    {
        DanhMucSanPham_BLL loaisanpham_bll = new DanhMucSanPham_BLL();

        frmAddCategory fAddCategory;
        frmEditCategory fEditCategory;

        string pMaLSP, pTenLSP;

        public frmCategory()
        {
            InitializeComponent();
            this.Load += FrmCategory_Load;
            btnAdd.Click += BtnAdd_Click;
            btnClearText.Click += BtnClearText_Click;
            btnEdit.Click += BtnEdit_Click;
            btnRemove.Click += BtnRemove_Click;
            btnLoad.Click += BtnLoad_Click;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadDataCategory();
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaLSP = dgvCategory.CurrentRow.Cells[0].Value.ToString();
            pTenLSP = dgvCategory.CurrentRow.Cells[1].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA LOẠI SẢN PHẨM " + pTenLSP.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                if (loaisanpham_bll.removeLSP(pMaLSP))
                {
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG DANH MỤC  SẢN PHẨM " + pTenLSP.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO ");
                    loadDataCategory();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pMaLSP = dgvCategory.CurrentRow.Cells[0].Value.ToString();

            fEditCategory = new frmEditCategory(pMaLSP);
            fEditCategory.ShowDialog();
            loadDataCategory();
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddCategory = new frmAddCategory();
            fAddCategory.ShowDialog();
            loadDataCategory();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            loadDataCategory();
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

            dgvCategory.DataSource = loaisanpham_bll.getDanhMucSanPhamTen(txtSearch.Text);

            dgvCategory.Columns[0].HeaderText = "MÃ DANH MỤC";
            dgvCategory.Columns[1].HeaderText = "TÊN DANH MỤC";
            dgvCategory.Columns[2].HeaderText = "MÔ TẢ";
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {

        }

        private void loadDataCategory()
        {
            dgvCategory.DataSource = loaisanpham_bll.GetAllDanhMucSP();

            dgvCategory.Columns[0].HeaderText = "MÃ DANH MỤC";
            dgvCategory.Columns[1].HeaderText = "TÊN DANH MỤC";
            dgvCategory.Columns[2].HeaderText = "MÔ TẢ";

        }
    }
}
