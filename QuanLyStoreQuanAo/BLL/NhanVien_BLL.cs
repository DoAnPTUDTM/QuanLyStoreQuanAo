using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVien_BLL
    {
        NhanVien_DAL dal = new NhanVien_DAL();
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public NhanVien_BLL()
        {

        }
        public bool login(string username, string password)
        {
            string passwordhash = dal.dangNhap(username);
            if (passwordhash == null)
            {
                return false;
            }
            else
            {
                bool rs = ValidatePassword(password, passwordhash);
                return rs;
            }

        }
        
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;


            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            var phonePattern = @"^\d{10,11}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
        public static string GenerateEmployeeCode(List<string> existingCodes)
        {

            var maxCode = existingCodes
                .Select(code => code.Substring(2))
                .Select(int.Parse)
                .DefaultIfEmpty(1)
                .Max();


            int newCodeNumber = maxCode + 1;
            return $"NV{newCodeNumber:D3}";
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Chuyển đổi byte sang hex
                }
                return builder.ToString();
            }
        }
        public static bool ValidatePassword(string inputPassword, string storedHash)
        {
            string hashOfInput = HashPassword(inputPassword);
            return hashOfInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            //return hashOfInput;
        }
        public string register(NhanVien nv)
        {
            var lstMa = context.NhanViens.Select(n => n.MaNhanVien).ToList();
            nv.MaNhanVien = GenerateEmployeeCode(lstMa);
            bool q = !IsValidEmail(nv.Email);
            bool k = !IsValidPhoneNumber(nv.SoDienThoai);
            if (!IsValidEmail(nv.Email) && !IsValidPhoneNumber(nv.SoDienThoai))
        {
                return "mixed";
        }
            else
            {


                if (!IsValidEmail(nv.Email))
                {
                    return "email";

                }
                else
                {
                    if (!IsValidPhoneNumber(nv.SoDienThoai))
                    {
                        return "number";
                    }
                    else
                    {
                        nv.MatKhau = HashPassword(nv.MatKhau);
                        bool kq = dal.dangKi(nv);
                        if (kq)
                        {
                            return "true";
                        }
                        else
                        {
                            return "false";
                        }
                    }
                }
            }

        }

        //Get nhân viên by id
        public NhanVien GetNVById(string id)
        {
            return dal.GetNVById(id); 
        }
        //Get DSNV
        public List<NhanVien> GetDSNV()
        {
            return dal.GetDSNV();
        }
        //ThenNV
        public bool ThemNV(NhanVien nv)
        {
            if (nv == null)
            { return false; }
            dal.ThemNVMoi(nv);
            return true;
        }
        //SuaNV
        public bool SuaNV(NhanVien nv)
        {
            if (nv == null) { return false; }
            dal.SuaNV(nv);
            return true;
        }
        //XoaNV
        public bool XoaNV(string maNV)
        {
            if (maNV == null) { return false; }
            dal.XoaNV(maNV);
            return true;
        }

        //Tìm kiếm nhân viên bằng họ tên
        public List<NhanVien> SearchKhachHangByHoTen(string search)
        {
            return dal.SearchKhachHangByHoTen(search);
        }
        public NhanVien GetNhanVienByMaNV(string maNV)
        {
            return dal.GetNhanVienByMaNV(maNV);
        }

        public NhanVien GetNhanVienByEmail(string email)
        {
            return dal.GetNhanVienByEmail(email);
        }
        //Lấy mã nhân viên bằng SDT
        public string GetMaNVBySDT(string sdt)
        {
            return dal.GetMaNVBySDT(sdt);
        }
    }
}
