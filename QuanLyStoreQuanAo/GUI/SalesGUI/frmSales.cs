using AForge.Video.DirectShow;
using AForge.Video;
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
using UI;
using ZXing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace GUI.SalesGUI
{
    public partial class frmSales : Form
    {
        DanhMucSanPham_BLL dmsp_bll = new DanhMucSanPham_BLL();
        SanPham_BLL sanpham_bll = new SanPham_BLL();
        KhachHang_BLL khachhang_bll = new KhachHang_BLL();
        HoaDon_BLL hoadon_bll = new HoaDon_BLL();
        CTHoaDon_BLL chitiethoadon_bll = new CTHoaDon_BLL();
        NhanVien_BLL nhanvien_bll = new NhanVien_BLL();

        HoaDon hd = new HoaDon();
        //KhachHang kh = new KhachHang();
        ProductsUI[] productItems = new ProductsUI[50];
        string _manv,_mahd, _masp;

        public frmSales(string sdt)
        {
            InitializeComponent();
            this.Load += FrmSales_Load;
            _manv = nhanvien_bll.GetMaNVBySDT(sdt);
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            LoadCboDanhMucSanPham();
            LoadAllSanPham();
            btnClearAll.Click += BtnClearAll_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cboDMSP.SelectedIndexChanged += CboDMSP_SelectedIndexChanged;
            txtTienKhachDua.TextChanged += TxtTienKhachDua_TextChanged;
            btnThanhToan.Click += BtnThanhToan_Click;
            HienThiLbTenNV();
            pdBill.PrintPage += PdBill_PrintPage;
        }

        private void PdBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var hoadon = hoadon_bll.GetHoaDonByMaHD(_mahd);
            var chitiethoadon = chitiethoadon_bll.GetChiTietHoaDonByMaHD(_mahd);

            var w = pdBill.DefaultPageSettings.PaperSize.Width;

            //VẼ HEADER CỦA BILL
            //TÊN CỬA HÀNG 
            e.Graphics.DrawString("PHIẾU THANH TOÁN FASHION STORE", new Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, new Point(130, 20));
            e.Graphics.DrawString("Số CT:" + hoadon.MaHoaDon + "-" + hoadon.NgayXuatHoaDon + "-NV:" + hoadon.MaNhanVien, new Font("Segoe UI", 13, FontStyle.Regular), Brushes.Black, new Point(220, 50));

            //VẼ LINE
            Pen blackPen = new Pen(Color.Black, 1);

            var y = 100;

            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //VẼ BODY CỦA BILL
            //TỰA ĐỀ
            e.Graphics.DrawString("SL", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(100, 120));
            e.Graphics.DrawString("Giá bán (có VAT)", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(300, 120));
            e.Graphics.DrawString("Thành tiền", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(700, 120));

            //TÊN SẢN PHẨM
            y = 150;
            for (int i = 0; i < chitiethoadon.Count; i++)
            {
                var sanpham = sanpham_bll.GetSanPhamById(chitiethoadon[i].MaSanPham);
                
                e.Graphics.DrawString(sanpham.TenSanPham.ToUpper(), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(70, y));
                e.Graphics.DrawString(chitiethoadon[i].SoLuong.ToString(), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(100, y + 30));
                e.Graphics.DrawString(sanpham.GiaBan.ToString(), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(370, y + 30));
                e.Graphics.DrawString(chitiethoadon[i].ThanhTien.ToString(), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(700, y + 30));

                y += 60;
            }

            //VẼ LINE
            y += 20;
            blackPen = new Pen(Color.Black, 1);

            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //TIỀN THANH TOÁN
            y += 20;
            e.Graphics.DrawString("Phải thanh toán", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(70, y));
            e.Graphics.DrawString(hoadon.TongTien.ToString(), new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(700, y));

            //VẼ LINE
            y += 40;
            blackPen = new Pen(Color.Black, 1);

            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //TIỀN KHÁCH TRẢ
            y += 20;
            e.Graphics.DrawString("Tiền khách đưa", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(70, y));
            e.Graphics.DrawString(txtTienKhachDua.Text, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(700, y));

            e.Graphics.DrawString("Tiền thối lại", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(70, y + 30));
            e.Graphics.DrawString(lbTienThoi.Text.Replace(" vnđ", ""), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(700, y + 30));
        }

        private void HienThiLbTenNV()
        {
            var nhanvien = nhanvien_bll.GetNhanVienByMaNV(_manv);
            lbHoTenNV.Text = nhanvien.HoTen;
        }

        //private void BtnThanhToan_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (guna2DataGridView1.RowCount == 0)
        //        {
        //            MessageBox.Show("Không có sản phẩm nào để thanh toán !!!");
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(txtTienKhachDua.Text))
        //        {
        //            MessageBox.Show("Nhập tiền khách đưa vào !!!");
        //            return;
        //        }

        //        if (lbTienThoi.Text == "Không đủ để thanh toán")
        //        {
        //            MessageBox.Show("Không đủ tiền để thanh toán !!!");
        //            return;
        //        }

        //        hd.MaHoaDon = TaoMaHoaDonAuto();
        //        hd.NgayXuatHoaDon = DateTime.Now;
        //        hd.TongTien = int.Parse(lbTotal.Text.Replace(" VNĐ", "").Replace(",", ""));
        //        //hd.MaNhanVien = _manv;
        //        hd.MaNhanVien = "NV001"; // Lấy mã nhân viên login
        //        hd.TrangThai = true;

        //        //Kiểm tra SDT  
        //        if (string.IsNullOrEmpty(txtPhone.Text) == false)
        //        {
        //            bool kt = khachhang_bll.CheckSDTKH(txtPhone.Text);
        //            if (kt)
        //            {
        //                hd.MaKhachHang = khachhang_bll.GetMaKHBySDT(txtPhone.Text);
        //            }
        //            else
        //            {
        //                KhachHang kh = new KhachHang();
        //                string makh = TaoMaKhachHangAuto();
        //                hd.MaKhachHang = makh;
        //                kh.MaKhachHang = makh;
        //                kh.HoTen = string.Empty;
        //                kh.Email = string.Empty;
        //                kh.MatKhau = string.Empty;
        //                kh.SoDienThoai = txtPhone.Text;

        //                bool kq = khachhang_bll.AddKhachHang(kh);
        //                if(kq)
        //                {
        //                    // Tạo hóa đơn
        //                    bool kq1 = hoadon_bll.AddHoaDon(hd);
        //                    if (kq1)
        //                    {

        //                        foreach (DataGridViewRow item in guna2DataGridView1.Rows)
        //                        {

        //                            ChiTietHoaDon cthd = new ChiTietHoaDon();

        //                            string MaSP = sanpham_bll.GetMaSPByTenSP(item.Cells["TenSP"].Value.ToString());
        //                            cthd.MaHoaDon = hd.MaHoaDon;
        //                            cthd.MaSanPham = MaSP;
        //                            cthd.SoLuong = int.Parse(item.Cells["SoLuong"].Value.ToString());
        //                            cthd.DonGia = int.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" VNĐ", "").Replace(",", ""));
        //                            cthd.ThanhTien = int.Parse(item.Cells["SoTien"].Value.ToString().Replace(" VNĐ", "").Replace(",", ""));

        //                            //Thêm chi tiết hóa đơn
        //                            chitiethoadon_bll.AddChiTietHoaDon(cthd);
        //                            sanpham_bll.CapNhatSoLuongTon(MaSP, int.Parse(item.Cells["SoLuong"].Value.ToString()));
        //                        }


        //                        guna2DataGridView1.Rows.Clear();
        //                        lbTotal.Text = lbTotalTemp.Text = "0 VNĐ";

        //                        _mahd = hd.MaHoaDon;
        //                        exportBill();
        //                        MessageBox.Show("Thanh toán sản phẩm thành công!!!");
        //                        LoadAllSanPham();
        //                        resetInput();
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Thanh toán không thành công !!!");
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Tạo khách hàng thất bại !!!");
        //                }    
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Nhập số điện thoại vào !!!");
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Thanh toán không thành công !!!\nLỗi: {ex.Message}");
        //    }

        //}

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.RowCount == 0)
                {
                    MessageBox.Show("Không có sản phẩm nào để thanh toán !!!");
                    return;
                }

                if (string.IsNullOrEmpty(txtTienKhachDua.Text))
                {
                    MessageBox.Show("Nhập tiền khách đưa vào !!!");
                    return;
                }

                if (lbTienThoi.Text == "Không đủ để thanh toán")
                {
                    MessageBox.Show("Không đủ tiền để thanh toán !!!");
                    return;
                }

                if (!int.TryParse(lbTotal.Text.Replace(" VNĐ", "").Replace(",", ""), out int tongTien))
                {
                    MessageBox.Show("Tổng tiền không hợp lệ!");
                    return;
                }

                if (string.IsNullOrEmpty(txtPhone.Text) || !Regex.IsMatch(txtPhone.Text, @"^\d{10,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!");
                    return;
                }

                hd.MaHoaDon = TaoMaHoaDonAuto();
                hd.NgayXuatHoaDon = DateTime.Now;
                hd.TongTien = tongTien;
                //hd.MaNhanVien = _manv;
                hd.MaNhanVien = "NV001"; // Lấy mã nhân viên từ hệ thống đăng nhập
                hd.TrangThai = true;

                // Kiểm tra và tạo khách hàng nếu cần
                if (!khachhang_bll.CheckSDTKH(txtPhone.Text))
                {
                    if (!TaoKhachHangMoi(txtPhone.Text, out string maKhachHang))
                    {
                        MessageBox.Show("Tạo khách hàng thất bại !!!");
                        return;
                    }
                    hd.MaKhachHang = maKhachHang;
                }
                else
                {
                    hd.MaKhachHang = khachhang_bll.GetMaKHBySDT(txtPhone.Text);
                }

                if (hoadon_bll.AddHoaDon(hd))
                {
                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        ChiTietHoaDon cthd = new ChiTietHoaDon
                        {
                            MaHoaDon = hd.MaHoaDon,
                            MaSanPham = sanpham_bll.GetMaSPByTenSP(item.Cells["TenSP"].Value.ToString()),
                            SoLuong = int.Parse(item.Cells["SoLuong"].Value.ToString()),
                            DonGia = int.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" VNĐ", "").Replace(",", "")),
                            ThanhTien = int.Parse(item.Cells["SoTien"].Value.ToString().Replace(" VNĐ", "").Replace(",", ""))
                        };

                        chitiethoadon_bll.AddChiTietHoaDon(cthd);
                        sanpham_bll.CapNhatSoLuongTon(cthd.MaSanPham, cthd?.SoLuong ?? 0);
                    }

                    _mahd = hd.MaHoaDon;
                    exportBill();
                    MessageBox.Show("Thanh toán sản phẩm thành công!!!");
                    LoadAllSanPham();
                    resetInput();
                }
                else
                {
                    MessageBox.Show("Thanh toán không thành công !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thanh toán không thành công !!!\nLỗi: {ex.Message}");
            }
        }

        //Tạo khách hàng mới
        private bool TaoKhachHangMoi(string soDienThoai, out string maKhachHang)
        {
            try
            {
                // Tạo mã khách hàng tự động
                maKhachHang = TaoMaKhachHangAuto();

                // Tạo đối tượng khách hàng mới
                KhachHang khachHang = new KhachHang
                {
                    MaKhachHang = maKhachHang,
                    SoDienThoai = soDienThoai,
                    HoTen = string.Empty, // Có thể yêu cầu nhập thông tin khác nếu cần
                    Email = string.Empty,
                    MatKhau = string.Empty
                };

                // Thêm khách hàng vào database
                bool ketQua = khachhang_bll.AddKhachHang(khachHang);

                return ketQua; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tạo khách hàng mới !!!\nLỗi: {ex.Message}");
                maKhachHang = null;
                return false; // Trả về false nếu có lỗi
            }
        }

        private void TxtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            string money = txtTienKhachDua.Text.Replace(",", "");

            decimal number;
            if (Decimal.TryParse(money, out number))
            {
                if (txtTienKhachDua.Text == string.Empty)
                {
                    lbTienThoi.Text = "0 VNĐ";
                }
                else
                {
                    decimal temp = number - decimal.Parse(lbTotal.Text.Replace(" VNĐ", "").ToString().Replace(",", ""));
                    if (temp < 0)
                    {
                        lbTienThoi.Text = "Không đủ để thanh toán";
                    }
                    else
                    {
                        lbTienThoi.Text = temp.ToString("N0") + " VNĐ";
                    }
                }

                txtTienKhachDua.Text = number.ToString("N0");
                txtTienKhachDua.SelectionStart = txtTienKhachDua.Text.Length;
            }
        }

        private void CboDMSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboDMSP.SelectedIndex == 0)
            {
                LoadAllSanPham();
            }    
            else
            {
                string madm = cboDMSP.SelectedValue.ToString();
                LoadSanPhamByCategory(madm);
            }    
        }

        private void LoadSanPhamByCategory(string madm)
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.GetSanPhamByCategory(madm);


            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductsUI();
                productItems[i].Width = 203;
                productItems[i].Margin = new Padding(6, 10, 10, 6);
                productItems[i].PMaSP = products[i].MaSanPham;
                productItems[i].PTenSp = products[i].TenSanPham;
                productItems[i].PSLTon = products[i].SoLuongTon.ToString();
                productItems[i].PGiaSP = products[i].GiaBan.ToString("#,#");
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
                    var wdg = (ProductsUI)ss;

                    if (sanpham_bll.GetSLT(wdg.PMaSP) != 0)
                    {
                        bool flag = false;

                        foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                        {
                            if (item.Cells["TenSP"].Value.ToString() == wdg.PTenSp)
                            {
                                item.Cells["SoLuong"].Value = (int.Parse(item.Cells["SoLuong"].Value.ToString()) + 1).ToString();
                                item.Cells["SoTien"].Value = (double.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" VNĐ", "")) * int.Parse(item.Cells["SoLuong"].Value.ToString())).ToString("#,#") + " VNĐ";
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            guna2DataGridView1.Rows.Add(new object[] { wdg.PTenSp, 1, wdg.PGiaSP, wdg.PGiaSP });
                        }
                        tinhThanhTien();
                    }
                    else
                    {
                        MessageBox.Show("SẢN PHẨM ĐÃ HẾT HÀNG", "FASHION STORE");
                    }
                };
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == string.Empty)
            {
                LoadAllSanPham();
            }
            else
            {
                LoadSanPhamBySearch(txtSearch.Text);
            }    
        }

        private void LoadSanPhamBySearch(string Search)
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.GetSanPhamBySearch(Search);


            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductsUI();
                productItems[i].Width = 203;
                productItems[i].Margin = new Padding(6, 10, 10, 6);
                productItems[i].PMaSP = products[i].MaSanPham;
                productItems[i].PTenSp = products[i].TenSanPham;
                productItems[i].PSLTon = products[i].SoLuongTon.ToString();
                productItems[i].PGiaSP = products[i].GiaBan.ToString("#,#");
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
                    var wdg = (ProductsUI)ss;

                    if (sanpham_bll.GetSLT(wdg.PMaSP) != 0)
                    {
                        bool flag = false;

                        foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                        {
                            if (item.Cells["TenSP"].Value.ToString() == wdg.PTenSp)
                            {
                                item.Cells["SoLuong"].Value = (int.Parse(item.Cells["SoLuong"].Value.ToString()) + 1).ToString();
                                item.Cells["SoTien"].Value = (double.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" VNĐ", "")) * int.Parse(item.Cells["SoLuong"].Value.ToString())).ToString("#,#") + " VNĐ";
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            guna2DataGridView1.Rows.Add(new object[] { wdg.PTenSp, 1, wdg.PGiaSP, wdg.PGiaSP });
                        }
                        tinhThanhTien();
                    }
                    else
                    {
                        MessageBox.Show("SẢN PHẨM ĐÃ HẾT HÀNG", "FASHION STORE");
                    }
                };
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            resetInput();
        }

        private void LoadAllSanPham()
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.GetAllSanPham();


            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductsUI();
                productItems[i].Width = 203;
                productItems[i].Margin = new Padding(6, 10, 10, 6);
                productItems[i].PMaSP = products[i].MaSanPham;
                productItems[i].PTenSp = products[i].TenSanPham;
                productItems[i].PSLTon = products[i].SoLuongTon.ToString();
                productItems[i].PGiaSP = products[i].GiaBan.ToString("#,#");
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
                    var wdg = (ProductsUI)ss;

                    if (sanpham_bll.GetSLT(wdg.PMaSP) != 0)
                    {
                        bool flag = false;

                        foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                        {
                            if (item.Cells["TenSP"].Value.ToString() == wdg.PTenSp)
                            {
                                item.Cells["SoLuong"].Value = (int.Parse(item.Cells["SoLuong"].Value.ToString()) + 1).ToString();
                                item.Cells["SoTien"].Value = (double.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" VNĐ", "")) * int.Parse(item.Cells["SoLuong"].Value.ToString())).ToString("#,#") + " VNĐ";
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            guna2DataGridView1.Rows.Add(new object[] { wdg.PTenSp, 1, wdg.PGiaSP, wdg.PGiaSP });
                        }
                        tinhThanhTien();
                    }
                    else
                    {
                        MessageBox.Show("SẢN PHẨM ĐÃ HẾT HÀNG", "FASHION STORE");
                    }
                };
            }
        }

        private void resetInput()
        {
            guna2DataGridView1.Rows.Clear();
            lbTotal.Text = lbTotalTemp.Text = lbTienThoi.Text = "0 VNĐ";
            txtPhone.ResetText();
            txtTienKhachDua.ResetText();
        }

        private void tinhThanhTien()
        {
            double total = 0;
            double lamTron = 0;
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += Convert.ToDouble(item.Cells["SoTien"].Value.ToString().Replace(" VNĐ", "").ToString().Replace(",", ""));
            }

            lbTotalTemp.Text = total.ToString("N0") + " VNĐ";
            lamTron = Math.Round(total);
            lbTotal.Text = lamTron.ToString("N0") + " VNĐ";
        }
        private void LoadCboDanhMucSanPham()
        {
            cboDMSP.DataSource = dmsp_bll.GetAllDanhMucSP();
            cboDMSP.DisplayMember = "TenDanhMuc";
            cboDMSP.ValueMember = "MaDanhMuc";
            cboDMSP.SelectedIndex = 0;
        }
        private string TaoMaHoaDonAuto()
        {
            var ListHoaDon = hoadon_bll.getAllHoaDon();
            if (ListHoaDon.Count == 0)
            {
                return "HD001";
            }
            else
            {
                var HDCuoi = hoadon_bll.GetHoaDonCuoi();
                string maHDCuoi = HDCuoi.MaHoaDon;
                int socuoi = int.Parse(maHDCuoi.Substring(2));
                int somoi = socuoi + 1;
                return "HD" + somoi.ToString("D3");
            }
        }
        private string TaoMaKhachHangAuto()
        {
            var ListKhachhang = khachhang_bll.GetAllKhachHang();
            if(ListKhachhang.Count == 0)
            {
                return "KH001";
            }
            else
            {
                var KHCuoi = khachhang_bll.GetLastKhachHang();
                string maKHCuoi = KHCuoi.MaKhachHang;
                int socuoi = int.Parse(maKHCuoi.Substring(2));
                int somoi = socuoi + 1;
                return "KH" + somoi.ToString("D3");
            }    
        }

        

        private void exportBill()
        {
            ppdBill.Document = pdBill;
            ppdBill.ShowDialog();
        }
    }
}
