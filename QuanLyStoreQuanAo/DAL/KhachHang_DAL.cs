using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHang_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public KhachHang_DAL()
        {

        }

        //Lấy tất cả khách hàng
        public List<KhachHang> GetAllKhachHang()
        {
            return db.KhachHangs.Select(kh => kh).ToList();
        }

        //Lấy Khách hàng cuối
        public KhachHang GetLastKhachHang()
        {
            return db.KhachHangs.OrderByDescending(kh => kh.MaKhachHang).FirstOrDefault();
        }

        //Lấy mã khách hàng bằng số điện thoại
        public string GetMaKHBySDT(string sdt)
        {
            var khachhang = db.KhachHangs.FirstOrDefault(kh => kh.SoDienThoai.Equals(sdt));
            return khachhang.MaKhachHang;
        }

        //Check SDT khách hàng
        public bool CheckSDTKH(string sdt)
        {
            return db.KhachHangs.Any(kh => kh.SoDienThoai.Equals(sdt));
        }
        //Thêm khách hàng
        public bool AddKhachHang(KhachHang kh)
        {
            if(kh == null)
            {
                return false;
            }    
            
            if (!KiemTraTonTai(kh.MaKhachHang))
            {
                try
                {
                    KhachHang khachhang = new KhachHang
                    {
                        MaKhachHang = kh.MaKhachHang,
                        HoTen = kh.HoTen,
                        Email = kh.Email,
                        MatKhau = kh.MatKhau,
                        SoDienThoai = kh.SoDienThoai,
                    };
                    db.KhachHangs.InsertOnSubmit(khachhang);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }    
        }
        //Kiem tra khach hang ton tai
        public bool KiemTraTonTai(string maKH)
        {
            return db.KhachHangs.Any(kh => kh.MaKhachHang == maKH);
        }
    }
}
