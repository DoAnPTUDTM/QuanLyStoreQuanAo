using BLL;
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
    public partial class frmHomeSales : Form
    {
        SanPham_BLL sanpham_bll = new SanPham_BLL();
        DanhMucSanPham_BLL danhmucsanpham_bll = new DanhMucSanPham_BLL();
        HoaDon_BLL hoadon_bll = new HoaDon_BLL();
        public frmHomeSales()
        {
            InitializeComponent();
            this.Load += FrmHomeSales_Load;
        }

        private void FrmHomeSales_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string SoLuongSP = sanpham_bll.GetAllSanPham().Count().ToString();
            string SoLuongDanhMuc = danhmucsanpham_bll.GetAllDanhMucSP().Skip(1).Count().ToString();
            string SoLuongHDTheoNgay = hoadon_bll.GetHoaDonByDate(DateTime.Now).Count().ToString();
            string DoanhThu = hoadon_bll.TinhDoanhThuTheoNgay(DateTime.Now).ToString("#,#");

            lbSoLuongSP.Text = SoLuongSP;
            lbSoLuongDMSP.Text = SoLuongDanhMuc;
            lbSLuongBan.Text = SoLuongHDTheoNgay;
            if(!string.IsNullOrEmpty(DoanhThu))
            {
                lbDoanhThu.Text = DoanhThu+" VNĐ";
            }
            else
            {
                lbDoanhThu.Text = "0 VNĐ";
            }    
            
        }
    }
}
