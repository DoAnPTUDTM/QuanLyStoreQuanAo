using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Runtime.Remoting.Contexts;

namespace BLL
{
    public class DonHang_BLL
    {
        DonHang_DAL dal = new DonHang_DAL();
        public DonHang_BLL()
        {

        }

        //Lấy ds
        public List<DonHang> GetDSDonHang()
        {
            return dal.GetDSDonHang();
        }
        //Lấy đơn hàng by id
        public DonHang GetDonHangById(string id)
        {
            return dal.GetDonHangById(id);
        }
        //Sua don hang
        public bool SuaDonHang(DonHang dh)
        {
            if(dh == null)
            {
                return false;
            }    
            dal.SuaDonHang(dh);
            return true;
        }
        //Xoa don hang
        public bool XoaDonHang(string madh)
        {
            if(madh == null)
            {
                return false;
            }    
            dal.XoaDonHang(madh);
            return true;
        }
        //Search đon hang
        public List<DonHang> SearchDonHangById(string search)
        {
            if(search == null)
            {
                return null;
            }   
            else
            {
                return dal.SearchDonHangById(search);
            }    
        }
        //Tính số đơn hàng trong ngày
        public int TinhSoLuongDHToday()
        {
            return dal.TinhSoLuongDHToday();
        }

        //Tính số đơn hàng trong tháng
        public int TinhSoLuongDHTrongThang()
        {
            return dal.TinhSoLuongDHTrongThang();
        }

        //tính số đơn hàng ngày
        public int TinhDoanhThuNgay()
        {
            return dal.TinhDoanhThuNgay();
        }
        //tính số đơn hàng tháng
        public int TinhDoanhThuThang()
        {
            return dal.TinhDoanhThuThang();
        }
    }
}
