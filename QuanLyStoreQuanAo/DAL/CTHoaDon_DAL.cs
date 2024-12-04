using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class CTHoaDon_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public CTHoaDon_DAL()
        {
            
        }

        //Lấy tất cả chi tiết hóa đơn
        public List<ChiTietHoaDon> GetAllCTHoaDon()
        {
            return db.ChiTietHoaDons.Select(cthd => cthd).ToList();
        }

        //Lấy hóa đơn theo mã hóa đơn
        public List<ChiTietHoaDon> GetChiTietHoaDonByMaHD(string maHD)
        {
            List<ChiTietHoaDon> listcthd = new List<ChiTietHoaDon>();
            var cthds = from cthd in db.ChiTietHoaDons where cthd.MaHoaDon.Equals(maHD) select cthd;
            listcthd = cthds.ToList();
            return listcthd;
        }

        //Lấy hóa đơn theo mã hóa đơn và mã sản phẩm
        public List<ChiTietHoaDon> GetChiTietHoaDonByMaHDVaMaSP(string maHD, string maSP)
        {
            List<ChiTietHoaDon> listcthd = new List<ChiTietHoaDon>();
            var cthds = from cthd in db.ChiTietHoaDons where cthd.MaHoaDon.Equals(maHD) && cthd.MaSanPham.Equals(maSP) select cthd;
            listcthd = cthds.ToList();
            return listcthd;
        }

        //Thêm chi tiết hóa đơn
        public void AddChiTietHoaDon(ChiTietHoaDon cthd)
        {
            if(cthd != null)
            {
                db.ChiTietHoaDons.InsertOnSubmit(cthd);
                db.SubmitChanges();
            }
        }
    }
}
