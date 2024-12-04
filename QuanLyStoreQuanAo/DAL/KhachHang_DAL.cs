using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHang_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public KhachHang_DAL()
        {

        }

        //Lấy tất cả khách hàng
        public List<KhachHang> GetAllKhachHang()
        {
            return db.KhachHangs.Select(kh => kh).ToList();
        }

        //Lấy Khách hàng cuối
        public KhachHang GetLastKhachHang()
        {
            return db.KhachHangs.OrderByDescending(kh => kh.MaKhachHang).FirstOrDefault();
        }

        //Lấy mã khách hàng bằng số điện thoại
        public string GetMaKHBySDT(string sdt)
        {
            var khachhang = db.KhachHangs.FirstOrDefault(kh => kh.SoDienThoai.Equals(sdt));
            return khachhang.MaKhachHang;
        }

        //Check SDT khách hàng
        public bool CheckSDTKH(string sdt)
        {
            return db.KhachHangs.Any(kh => kh.SoDienThoai.Equals(sdt));
        }
        //Thêm khách hàng
        public bool AddKhachHang(KhachHang kh)
        {
            if(kh == null)
            {
                return false;
            }    
            
            if (!KiemTraTonTai(kh.MaKhachHang))
            {
                try
                {
                    KhachHang khachhang = new KhachHang
                    {
                        MaKhachHang = kh.MaKhachHang,
                        HoTen = kh.HoTen,
                        Email = kh.Email,
                        MatKhau = kh.MatKhau,
                        SoDienThoai = kh.SoDienThoai,
                    };
                    db.KhachHangs.InsertOnSubmit(khachhang);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }    
        }

        public bool SuaKH(KhachHang kh)
        {
            if (kh == null)
            {
                return false;
            }

            try
            {
                var khachhang = db.KhachHangs.FirstOrDefault(k => k.MaKhachHang == kh.MaKhachHang);
                if (kh == null)
                {
                    return false;
                }
                khachhang.HoTen = kh.HoTen;
                khachhang.Email = kh.Email;
                khachhang.MatKhau = kh.MatKhau;
                khachhang.SoDienThoai = kh.SoDienThoai;

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        public bool XoaKhachHang(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
            {
                return false;
            }

            try
            {
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang == null)
                {
                    return false;
                }

                db.KhachHangs.DeleteOnSubmit(khachHang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa khách hàng: " + ex.Message);
                return false;
            }
        }
        //Kiem tra khach hang ton tai
        public bool KiemTraTonTai(string maKH)
        {
            return db.KhachHangs.Any(kh => kh.MaKhachHang == maKH);
        }
        public List<KhachHang> SearchKhachHangByHoTen(string search)
        {
            if (string.IsNullOrEmpty(search)) return null;
            var khachhangs = db.KhachHangs.Where(k => k.HoTen.Contains(search)).ToList();
            return khachhangs;
        }
        public KhachHang GetKhById(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                var khachhang = db.KhachHangs.FirstOrDefault(k => k.MaKhachHang == id);
                if (khachhang == null)
                {
                    return null;
                }
                return khachhang;
            }
        }

    

        public string dangNhap(string username)
        {
            var nv = db.KhachHangs.Where(n => n.SoDienThoai == username).FirstOrDefault();
            if (nv == null)
            {
                return string.Empty;
            }
            else
            {

                return nv.MatKhau;

            }
           
        }
        public bool dangKi(KhachHang nv)
        {
            var nvvalid = db.KhachHangs.Where(n => n.MaKhachHang == nv.MaKhachHang).FirstOrDefault();
            if (nvvalid != null)
            {
                return false;
            }
            else
            {
                try
                {
                    db.KhachHangs.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
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
        public string register(KhachHang nv)
        {
            var lstMa = db.KhachHangs.Select(n => n.MaKhachHang).ToList(); nv.MaKhachHang = GenerateEmployeeCode(lstMa);
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
                    bool kq = dangKi(nv);
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
        public static bool ValidatePassword(string inputPassword, string storedHash)
        {
            string hashOfInput = HashPassword(inputPassword);
            return hashOfInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool login(string username, string password)
        {
            string passwordhash = dangNhap(username);

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
    }
}
