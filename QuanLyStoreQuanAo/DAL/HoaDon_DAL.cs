using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDon_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public HoaDon_DAL()
        {

        }

        //Lấy tất cả hóa đơn
        public List<HoaDon> getAllHoaDon()
        {
            return db.HoaDons.Select(hd => hd).ToList();
        }


        //Lấy hóa đơn theo mã hóa đơn
        public HoaDon GetHoaDonByMaHD(string maHD)
        {
            return db.HoaDons.FirstOrDefault(hd => hd.MaHoaDon.Equals(maHD));
        }

        //Lấy hóa đơn cuối
        public HoaDon GetHoaDonCuoi()
        {
            return db.HoaDons.OrderByDescending(hd => hd.MaHoaDon).FirstOrDefault();
        }

        //Thêm hóa đơn
        public bool AddHoaDon(HoaDon hd)
        {
            if(hd == null)
            {
                return false;
            }    

            if(!KiemTraTonTai(hd.MaHoaDon))
            {
                HoaDon hoadon = new HoaDon
                {
                    MaHoaDon = hd.MaHoaDon,
                    MaKhachHang = hd.MaKhachHang,
                    MaNhanVien = hd.MaNhanVien,
                    NgayXuatHoaDon = hd.NgayXuatHoaDon,
                    TongTien = hd.TongTien,
                    TrangThai = hd.TrangThai
                };
                db.HoaDons.InsertOnSubmit(hoadon);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }    
        }

        //kiểm tra tồn tại
        public bool KiemTraTonTai(string maHD)
        {
            return db.HoaDons.Any(hd => hd.MaHoaDon.Equals(maHD));
        }

        //Lấy hóa đơn theo ngày
        public List<HoaDon> GetHoaDonByDate(DateTime Ngay)
        {
            return db.HoaDons.Where(h => h.NgayXuatHoaDon == Ngay).ToList();
        }



        //Tính doanh thu theo ngày
        public int TinhDoanhThuTheoNgay(DateTime Ngay)
        {
            return Convert.ToInt32(db.HoaDons.Where(h => h.NgayXuatHoaDon == Ngay.Date).Sum(h => (int?)h.TongTien) ?? 0);
        }

        //Tính doanh thu theo tháng
        public int TinhDoanhThuTheoThang(int thang, int nam)
        {
            var hoaDons = db.HoaDons.Where(h => h.NgayXuatHoaDon.HasValue).ToList();

            return hoaDons
                .Where(h => h.NgayXuatHoaDon.Value.Month == thang && h.NgayXuatHoaDon.Value.Year == nam)
                .Sum(h => (int?)h.TongTien) ?? 0;
        }

    }
}
