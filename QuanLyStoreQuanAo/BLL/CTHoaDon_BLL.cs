using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class CTHoaDon_BLL
    {
        CTHoaDon_DAL cthd_dal = new CTHoaDon_DAL();
        public CTHoaDon_BLL()
        {

        }

        //Lấy tất cả chi tiết hóa đơn
        public List<ChiTietHoaDon> GetAllCTHoaDon()
        {
            return cthd_dal.GetAllCTHoaDon();
        }

        //Lấy hóa đơn theo mã hóa đơn
        public List<ChiTietHoaDon> GetChiTietHoaDonByMaHD(string maHD)
        {
            return cthd_dal.GetChiTietHoaDonByMaHD(maHD);
        }

        //Lấy hóa đơn theo mã hóa đơn và mã sản phẩm
        public List<ChiTietHoaDon> GetChiTietHoaDonByMaHDVaMaSP(string maHD, string maSP)
        {
            return cthd_dal.GetChiTietHoaDonByMaHDVaMaSP(maHD, maSP);
        }

        //Thêm chi tiết hóa đơn
        public void AddChiTietHoaDon(ChiTietHoaDon cthd)
        {
            cthd_dal.AddChiTietHoaDon(cthd);
        }
    }
}
