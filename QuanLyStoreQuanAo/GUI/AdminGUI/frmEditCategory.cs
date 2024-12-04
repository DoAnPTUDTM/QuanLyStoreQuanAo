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
    public partial class frmEditCategory : Form
    {
        string pMaLSP;

        DanhMucSanPham_DTO lsp_dto = new DanhMucSanPham_DTO();

        DanhMucSanPham_BLL loaisanpham_bll = new DanhMucSanPham_BLL();
        List<DanhMucSanPham_DTO> lst_lsp = new List<DanhMucSanPham_DTO>();

        


        public frmEditCategory(string _malsp)
        {
            InitializeComponent();
            pMaLSP = _malsp;
            this.Load += FrmEditCategory_Load;
            btnFinish.Click += BtnFinish_Click;
            
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {

                lsp_dto.MaDanhMuc = pMaLSP;
                lsp_dto.TenDanhMuc = txtTenDanhMucSanPham.Text;
                lsp_dto.MoTa = txtMoTaDanhMuc.Text;
                loaisanpham_bll.editLSP(lsp_dto);
                MessageBox.Show("DANH MỤC  SẢN PHẨM " + lsp_dto.TenDanhMuc.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
            }

            loadData();
        }

        private void FrmEditCategory_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lst_lsp = loaisanpham_bll.getDanhMucSanPhamID(pMaLSP);


            txtTenDanhMucSanPham.Text = lst_lsp[0].TenDanhMuc;
            txtMoTaDanhMuc.Text = lst_lsp[0].MoTa;
        }
    }
}
