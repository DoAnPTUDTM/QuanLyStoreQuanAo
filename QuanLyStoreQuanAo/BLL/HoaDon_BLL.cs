using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class HoaDon_BLL
    {

        HoaDon_DAL hoadon_dal = new HoaDon_DAL();
        public HoaDon_BLL()
        {

        }

        //Lấy tất cả hóa đơn
        public List<HoaDon> getAllHoaDon()
        {
            return hoadon_dal.getAllHoaDon();
        }


        //Lấy hóa đơn theo mã hóa đơn
        public HoaDon GetHoaDonByMaHD(string maHD)
        {
            return hoadon_dal.GetHoaDonByMaHD(maHD);
        }

        //Lấy hóa đơn cuối
        public HoaDon GetHoaDonCuoi()
        {
            return hoadon_dal.GetHoaDonCuoi();
        }

        //Thêm hóa đơn
        public bool AddHoaDon(HoaDon hoaDon)
        {
            return hoadon_dal.AddHoaDon(hoaDon);
        }

        //Lấy hóa đơn theo ngày
        public List<HoaDon> GetHoaDonByDate(DateTime Ngay)
        {
            return hoadon_dal.GetHoaDonByDate(Ngay);
        }

        //Tính doanh thu theo ngày
        public int TinhDoanhThuTheoNgay(DateTime Ngay)
        {
            return hoadon_dal.TinhDoanhThuTheoNgay(Ngay);
        }

        //Tính doanh thu theo tháng
        public int TinhDoanhThuTheoThang(int Thang, int Nam)
        {
            return hoadon_dal.TinhDoanhThuTheoThang(Thang, Nam);
        }
    }
}
