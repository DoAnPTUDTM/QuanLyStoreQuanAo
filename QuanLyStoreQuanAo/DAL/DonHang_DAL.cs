using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DonHang_DAL
    {
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public DonHang_DAL()
        {

        }

        //Tính số lượng đơn hàng trong ngày
        public int TinhSoLuongDHToday()
        {
            var dsdh = context.DonHangs.Where(d => d.NgayDatHang == DateTime.Now);
            if(dsdh != null)
            {
                return dsdh.Count();
            }
            return 0;
        }

        //Tính số lượng đơn hàng trong tháng
        public int TinhSoLuongDHTrongThang()
        {
            var monthCurrent = DateTime.Now.Month;
            var yearCurrent = DateTime.Now.Year;

            var firstDayOfMonth = new DateTime(yearCurrent, monthCurrent, 1);
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            var dsdh = context.DonHangs
                              .Where(d => d.NgayDatHang >= firstDayOfMonth && d.NgayDatHang < firstDayOfNextMonth);

            return dsdh.Count();
        }


        //Tính doanh thu trong ngày
        public int TinhDoanhThuNgay()
        {
            var today = DateTime.Today; 
            var tomorrow = today.AddDays(1); 

            
            var doanhThu = context.DonHangs
                                  .Where(d => d.NgayDatHang >= today && d.NgayDatHang < tomorrow)
                                  .Sum(d => (int?)d.TongTien) ?? 0; 

            return doanhThu;
        }

        public int TinhDoanhThuThang()
        {
            var monthCurrent = DateTime.Now.Month;
            var yearCurrent = DateTime.Now.Year;

            var firstDayOfMonth = new DateTime(yearCurrent, monthCurrent, 1);
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);


            var doanhThu = context.DonHangs
                              .Where(d => d.NgayDatHang >= firstDayOfMonth && d.NgayDatHang < firstDayOfNextMonth)
                              .Sum(d => (int?)d.TongTien) ?? 0;

            return doanhThu;
        }

        public List<DonHang> GetDSDonHang()
        {
            var dsdh = context.DonHangs.Select(dh => dh).ToList();
            return dsdh;
        }

        //Sua đơn hàng
        public bool SuaDonHang(DonHang dh)
        {
            if(dh == null)
            {
                return false;
            }
            else
            {
                var donhangdb = context.DonHangs.FirstOrDefault(d => d.MaDonHang == dh.MaDonHang);
                if(donhangdb == null)
                {
                    return false;
                }
                donhangdb.MaKhachHang = dh.MaKhachHang;
                donhangdb.NgayDatHang = dh.NgayDatHang;
                donhangdb.TrangThai = dh.TrangThai;
                donhangdb.TongTien = dh.TongTien;
                donhangdb.PhuongThucThanhToan = dh.PhuongThucThanhToan;
                donhangdb.DiaChiGiaoHang = dh.DiaChiGiaoHang;

                context.SubmitChanges();
                return true;
            }    
        }

        //Xóa đơn hàng
        public bool XoaDonHang(string maDH)
        {
            if (maDH == null)
            {
                return false;
            }
            else
            {
                var donhangdb = context.DonHangs.FirstOrDefault(d => d.MaDonHang == maDH);
                if (donhangdb == null)
                {
                    return false;
                }
                context.DonHangs.DeleteOnSubmit(donhangdb);
                context.SubmitChanges();
                return true;
            }
        }
        //Lấy đơn hàng by id
        public DonHang GetDonHangById(string madh)
        {
            if(madh == null)
            {
                return null;
            }
            else
            {
                var donhang = context.DonHangs.FirstOrDefault(d => d.MaDonHang.Equals(madh));
                return donhang;
            }    
        }
        public List<DonHang> SearchDonHangById(string search)
        {
            if(string.IsNullOrEmpty(search)) return null;
            var donhangs = context.DonHangs.Where(d => d.MaDonHang.Contains(search)).ToList();
            return donhangs;
        }
    }
}
