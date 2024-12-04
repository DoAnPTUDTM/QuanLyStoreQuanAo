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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI.AdminGUI
{
    public partial class frmEditProduct : Form
    {
        string pMaSP;
        private string fileAddress;

        SanPhamDTO sp_dto = new SanPhamDTO();
        List<SanPhamDTO> lst_sp = new List<SanPhamDTO>();
        DanhMucSanPham_BLL DanhMucSanPhamBLL = new DanhMucSanPham_BLL();
        SanPham_BLL sanpham_bll = new SanPham_BLL();



        public frmEditProduct(string _masp)
        {
            InitializeComponent();
            pMaSP = _masp;
            this.Load += FrmEditProduct_Load    ;
            btnFinish.Click += BtnFinish_Click;
            btnGetPicture.Click += BtnGetPicture_Click;


        }

        private void BtnGetPicture_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                
                sp_dto.TenSanPham = txtTenSP.Text;
                sp_dto.HangSanXuat = guna2TextBox1.Text;
                sp_dto.SoLuongTon = int.Parse(txtSLT.Text);
                sp_dto.MoTa = txtMota.Text;
                sp_dto.DuongDanHinhAnh = fileAddress.Replace("C:\\Users\\ACER\\Desktop\\QuanLyStoreQuanAo\\QuanLyStoreQuanAo\\GUI\\imgs", "");
                sp_dto.GiaBan = int.Parse(txtGia.Text);
                
                sp_dto.TenDanhMuc = cboCTLSP.SelectedValue.ToString();


                sanpham_bll.editSP(sp_dto);
                MessageBox.Show("SẢN PHẨM " + txtTenSP.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
            }

        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {
            loadData();
            loadDanhMucSanPham();
        }

        private void loadData()
        {
            sp_dto = sanpham_bll.GetSanPhamById(pMaSP);

            txtTenSP.Text = sp_dto.TenSanPham;
            txtGia.Text = sp_dto.GiaBan.ToString("#,#");
            guna2TextBox1.Text = sp_dto.HangSanXuat;
            txtSLT.Text = sp_dto.SoLuongTon.ToString();
            fileAddress = "imgs/" + sp_dto.DuongDanHinhAnh;
            System.Drawing.Image image = System.Drawing.Image.FromFile("imgs/" + sp_dto.DuongDanHinhAnh);
            picProduct.Image = new Bitmap(image);

           
            txtMota.Text = sp_dto.MoTa;
            cboCTLSP.SelectedValue = sp_dto.TenDanhMuc.ToString();


        }

        private void loadDanhMucSanPham()
        {
            cboCTLSP.DataSource = DanhMucSanPhamBLL.GetAllDanhMucSP();
            cboCTLSP.ValueMember = "MaDanhMuc";
            cboCTLSP.DisplayMember = "TenDanhMuc";
        }

        private void cboCTLSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OpenImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "CHỌN ẢNH SẢN PHẨM";

            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                picProduct.Image = System.Drawing.Image.FromFile(fileAddress);
                picProduct.ImageLocation = fileAddress;
            }
        }
    }
}
