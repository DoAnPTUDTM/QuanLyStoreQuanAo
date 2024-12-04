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

namespace GUI.AdminGUI
{
    public partial class frmAddCategory : Form
    {
        DanhMucSanPham_DTO lsp_dto = new DanhMucSanPham_DTO();

        DanhMucSanPham_BLL loaisanpham_bll = new DanhMucSanPham_BLL();

        public frmAddCategory()
        {
            InitializeComponent();
            this.Load += FrmAddCategory_Load;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                lsp_dto.MaDanhMuc = createCodeProduct();
                lsp_dto.TenDanhMuc = txtTenDanhMucSP.Text;
                lsp_dto.MoTa = txtMoTaDanhMuc.Text;
                loaisanpham_bll.addLSP(lsp_dto);
                MessageBox.Show("DANH MỤC  SẢN PHẨM " + txtTenDanhMucSP.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
            }
        }

        private void FrmAddCategory_Load(object sender, EventArgs e)
        {
            
        }

        private string createCodeProduct()
        {
            Random random = new Random();
            string pCode;

            while (true)
            {
                int randomNumber = random.Next(1000000, 10000000);
                pCode = randomNumber.ToString("D7");


                return pCode;
            }
        }
    }
}
