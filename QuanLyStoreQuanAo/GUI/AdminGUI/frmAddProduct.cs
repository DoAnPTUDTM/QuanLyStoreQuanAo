using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.AdminGUI
{
    public partial class frmAddProduct : Form
    {
        private string fileAddress;
        SanPhamDTO sp_dto = new SanPhamDTO();

        SanPham_BLL sanpham_bll = new SanPham_BLL();
        DanhMucSanPham_BLL DanhMucSanPhamBLL = new DanhMucSanPham_BLL();


        public frmAddProduct()
        {
            InitializeComponent();
            this.Load += FrmAddProduct_Load;
            btnGetPicture.Click += BtnGetPicture_Click;
            btnFinish.Click += BtnFinish_Click;

        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                sp_dto.MaSanPham = createCodeProduct();
                sp_dto.TenSanPham = txtTenSP.Text;
                sp_dto.HangSanXuat = txtNSX.Text;
                sp_dto.SoLuongTon = int.Parse(txtSLT.Text);
                sp_dto.MoTa = txtMota.Text;
                sp_dto.DuongDanHinhAnh = fileAddress.Replace("C:\\Users\\ACER\\Desktop\\QuanLyStoreQuanAo\\QuanLyStoreQuanAo\\GUI\\imgs\\", "");
                sp_dto.GiaBan = int.Parse(txtGia.Text);
               
                sp_dto.TenDanhMuc = cboDanhMucSP.SelectedValue.ToString();
               

                sanpham_bll.addSP(sp_dto);
                MessageBox.Show("SẢN PHẨM " + txtTenSP.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG QUẦN ÁO");
            }
        }

        private void BtnGetPicture_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {

            loadDanhMucSanPham();
        }

        private void loadDanhMucSanPham()
        {
            cboDanhMucSP.DataSource = DanhMucSanPhamBLL.GetAllDanhMucSP();
            cboDanhMucSP.ValueMember = "MaDanhMuc";
            cboDanhMucSP.DisplayMember = "TenDanhMuc";
        }

        private void OpenImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "CHỌN ẢNH SẢN PHẨM";

            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                picProduct.Image = Image.FromFile(fileAddress);
                picProduct.ImageLocation = fileAddress;
            }
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
