using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class KhachHang_DAL
    {
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public KhachHang_DAL()
        {

        }
        public string dangNhap(string username)
        {
            var nv = context.KhachHangs.Where(n => n.SoDienThoai == username).FirstOrDefault();
            if (nv == null)
            {
                return string.Empty;
            }
            else
            {

                return nv.MatKhau;

            }
            //return string.Empty;
        }
        public bool dangKi(KhachHang nv)
        {
            var nvvalid = context.KhachHangs.Where(n => n.MaKhachHang == nv.MaKhachHang).FirstOrDefault();
            if (nvvalid != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.KhachHangs.InsertOnSubmit(nv);
                    context.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        //Lấy khách hàng by id
        public KhachHang GetKhById(string id)
        {
            if(id == null)
            {
                return null;
            }    
            else
            {
                var khachhang = context.KhachHangs.FirstOrDefault(k => k.MaKhachHang == id);
                if(khachhang == null)
                {
                    return null;
                }
                return khachhang;
            }    
        }
        //Lấy danh sách khách hàng
        public List<KhachHang> GetDSKH()
        {
            return context.KhachHangs.ToList();
        }

        //Thêm khách hàng
        public bool ThemKHMoi(KhachHang kh)
        {
            if (kh == null)
            {
                return false;
            }

            try
            {
                kh.MaKhachHang = TaoMaKHTuDong();

                context.KhachHangs.InsertOnSubmit(kh);
                context.SubmitChanges();
                return true;    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        //Hàm Tạo Mã KH tự động
        public string TaoMaKHTuDong()
        {
            try
            {
                var maKhachHangDB = context.KhachHangs
                                                  .OrderByDescending(kh => kh.MaKhachHang)
                                                  .Select(kh => kh.MaKhachHang)
                                                  .FirstOrDefault();

                if (string.IsNullOrEmpty(maKhachHangDB))
                {
                    return "KH001";
                }
                string phanSo = maKhachHangDB.Substring(2);
                int soMoi = int.Parse(phanSo) + 1;
                return "KH" + soMoi.ToString("D3");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo mã khách hàng tự động: " + ex.Message);
                return null;
            }
        }

        //Sửa khách hàng
        public bool SuaKH(KhachHang kh)
        {
            if (kh == null)
            {
                return false;
            }

            try
            {
                var khachhang = context.KhachHangs.FirstOrDefault(k => k.MaKhachHang == kh.MaKhachHang);
                if(kh == null)
                {
                    return false;
                }   
                khachhang.HoTen = kh.HoTen;
                khachhang.Email = kh.Email;
                khachhang.MatKhau = kh.MatKhau;
                khachhang.SoDienThoai = kh.SoDienThoai;

                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        //Xóa Khách hàng
        public bool XoaKhachHang(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
            {
                return false;
            }

            try
            {
                var khachHang = context.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang == null)
                {
                    return false;
                }

                context.KhachHangs.DeleteOnSubmit(khachHang);
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa khách hàng: " + ex.Message);
                return false;
            }
        }

        //Tìm kiếm khách hàng bằng họ tên
        public List<KhachHang> SearchKhachHangByHoTen(string search)
        {
            if (string.IsNullOrEmpty(search)) return null;
            var khachhangs = context.KhachHangs.Where(k => k.HoTen.Contains(search)).ToList();
            return khachhangs;
        }

    }
}
