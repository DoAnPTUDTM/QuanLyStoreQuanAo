using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHang_BLL
    {
        KhachHang_DAL khachhang_dal = new KhachHang_DAL();
        public KhachHang_BLL()
        {

        }

        //Lấy tất cả khách hàng
        public List<KhachHang> GetAllKhachHang()
        {
            return khachhang_dal.GetAllKhachHang();
        }

        //Lấy Khách hàng cuối
        public KhachHang GetLastKhachHang()
        {
            return khachhang_dal.GetLastKhachHang();
        }
        
        //Lấy mã khách hàng bằng số điện thoại
        public string GetMaKHBySDT(string sdt)
        {
            return khachhang_dal.GetMaKHBySDT(sdt);
        }

        //Kiểm tra SDT khách hàng
        public bool CheckSDTKH(string sdt)
        {
            return khachhang_dal.CheckSDTKH(sdt);
        }
        //Thêm khách hàng
        public bool AddKhachHang(KhachHang kh)
        {
            return khachhang_dal.AddKhachHang(kh);
        }

    }
}
