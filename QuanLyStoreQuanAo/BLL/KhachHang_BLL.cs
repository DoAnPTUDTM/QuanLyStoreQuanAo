using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace BLL
{
    public class KhachHang_BLL
    {
        KhachHang_DAL dal = new KhachHang_DAL();
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public KhachHang_BLL()
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
            return $"KH{newCodeNumber:D3}";
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
        }
        public string register(KhachHang nv)
        {
            var lstMa = context.KhachHangs.Select(n => n.MaKhachHang).ToList();
            nv.MaKhachHang = GenerateEmployeeCode(lstMa);
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
        //Lấy khach hang by id
        public KhachHang GetKHById(string id)
        {
            return dal.GetKhById(id);
        }
        //Lấy danh sách khách hàng
        public List<KhachHang> GetDSKH()
        {
            return dal.GetDSKH();
        }

        //Thêm khách hàng
        public bool ThemKH(KhachHang kh)
        {
            if(kh == null) { return false; }
            dal.ThemKHMoi(kh);
            return true;
        }
        //Sửa khách hàng
        public bool SuaKH(KhachHang kh)
        {
            if (kh == null) { return false; }
            dal.SuaKH(kh);
            return true;
        }
        //Xóa khách hàng
        public bool XoaKH(string makh)
        {
            if (makh == null)
            {
                return false;
            }
            dal.XoaKhachHang(makh);
            return true;
        }
        //Search khách hàng
        public List<KhachHang> SearchKhachHangByHoTen(string search)
        {
            return dal.SearchKhachHangByHoTen(search);
        }
    }
}
