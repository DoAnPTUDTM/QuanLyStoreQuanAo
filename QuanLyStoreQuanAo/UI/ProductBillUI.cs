using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductBillUI : UserControl
    {
        public event EventHandler onSelect = null;

        public ProductBillUI()
        {
            InitializeComponent();
            this.Load += ProductBillUI_Load;
        }

        private void ProductBillUI_Load(object sender, EventArgs e)
        {
            HideLabel();
        }

        private string pMaSP;
        private Image pAnh;
        private string pTenSP;
        private string pGiaGiamSP;
        private string pGiaSP;
        private string pThanhTien;
        private string pSoLuong;
        private string pKhuyenMai;

        [Category("Custom Product")]
        public string PMaSP
        {
            get { return pMaSP; }
            set { pMaSP = value; }
        }

        [Category("Custom Product")]
        public Image PAnh
        {
            get { return pAnh; }
            set { pAnh = value; picProduct.Image = value; }
        }

        [Category("Custom Product")]
        public string PTenSp
        {
            get { return pTenSP; }
            set { pTenSP = value; lbTenSP.Text = value; }
        }

        [Category("Custom Product")]
        public string PGiaGiamSP
        {
            get { return pGiaGiamSP; }
            set { pGiaGiamSP = value; lbGiaTien.Text = value; }
        }

        public string PThanhTien
        {
            get { return pThanhTien; }
            set { pThanhTien = value; lbThanhTien.Text = value; }
        }

        public string PSoLuong
        {
            get { return pSoLuong; }
            set { pSoLuong = value; lbSoLuong.Text = value; }
        }

        public string PKhuyenMai
        {
            get { return pKhuyenMai; }
            set { pKhuyenMai = value; }
        }

        private void HideLabel()
        {
            //if (lbKhuyenMai.Text == string.Empty)
            //{
            //    lbGiaSP.Visible = false;
            //    lbKhuyenMai.Visible = false;
            //}
            //else
            //{
            //    lbGiaSP.Visible = true;
            //    lbKhuyenMai.Visible = true;
            //}
        }
    }
}
