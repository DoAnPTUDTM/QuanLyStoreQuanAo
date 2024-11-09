using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class NhanVien_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public NhanVien_DAL()
        {

        }

        public NhanVien GetNhanVienByMaNV(string maNV)
        {
            return db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien.Equals(maNV));
        }
        //Lấy nhân viên bằng Email
        public NhanVien GetNhanVienByEmail(string email)
        {
            return db.NhanViens.FirstOrDefault(nv => nv.Email.Equals(email));
        }
        //Lấy mã nhân viên bằng SDT
        public string GetMaNVBySDT(string sdt)
        {
            var nhanvien = db.NhanViens.FirstOrDefault(nv => nv.SoDienThoai.Equals(sdt));
            return nhanvien.MaNhanVien;
        }
            
    }
}
