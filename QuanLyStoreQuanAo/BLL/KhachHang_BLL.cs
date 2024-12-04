using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        public KhachHang GetKHById(string id)
        {
            return khachhang_dal.GetKhById(id);
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
        public bool SuaKH(KhachHang kh)
        {
            if (kh == null) { return false; }
            khachhang_dal.SuaKH(kh);
            return true;
        }
        public List<KhachHang> SearchKhachHangByHoTen(string search)
        {
            return khachhang_dal.SearchKhachHangByHoTen(search);
        }

        

        public bool login(string username, string password)
        {
            return khachhang_dal.login(username, password);
        }

        public string register(KhachHang nv)
        {
            return khachhang_dal.register(nv);
        }
    }
}
