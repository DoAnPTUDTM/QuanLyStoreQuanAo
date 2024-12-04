using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVien_BLL
    {
        NhanVien_DAL nhanvien_dal = new NhanVien_DAL();
        public NhanVien_BLL()
        {

        }

        public NhanVien GetNhanVienByMaNV(string maNV)
        {
            return nhanvien_dal.GetNhanVienByMaNV(maNV);
        }

        public NhanVien GetNhanVienByEmail(string email)
        {
            return nhanvien_dal.GetNhanVienByEmail(email);
        }
        //Lấy mã nhân viên bằng SDT
        public string GetMaNVBySDT(string sdt)
        {
            return nhanvien_dal.GetMaNVBySDT(sdt);
        }
    }
}
