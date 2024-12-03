using DTO;
using System.Linq;
using System.Data.Linq;
using System;
using System.Collections.Generic;
namespace DAL
{
    public class NhanVien_DAL
    {
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public NhanVien_DAL()
        {

        }
        public string dangNhap(string username)
        {
            var nv = context.NhanViens.Where(n => n.SoDienThoai == username).FirstOrDefault();
            if (nv == null)
            {
                return string.Empty;
            }
            else
            {

                return nv.MatKhau;

            }

        }
        public bool dangKi(NhanVien nv)
        {
            var nvvalid = context.NhanViens.Where(n => n.MaNhanVien == nv.MaNhanVien).FirstOrDefault();
            if (nvvalid != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.NhanViens.InsertOnSubmit(nv);
                    context.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        //Get nhân viên by id
        public NhanVien GetNVById(string id)
        {
            if(id == null)
            {
                return null;
            }
            return context.NhanViens.FirstOrDefault(n => n.MaNhanVien == id);  
        }

        //Lấy ds nhân viên
        public List<NhanVien> GetDSNV()
        {
            return context.NhanViens.ToList();
        }
        //Thêm nhân viên
        public bool ThemNVMoi(NhanVien nv)
        {
            if (nv == null)
            {
                return false;
            }

            try
            {
                nv.MaNhanVien = TaoMaNVTuDong();

                context.NhanViens.InsertOnSubmit(nv);
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        //Hàm Tạo Mã nhân viên tự động
        public string TaoMaNVTuDong()
        {
            try
            {
                var maNVDB = context.NhanViens.OrderByDescending(nv => nv.MaNhanVien)
                                                  .Select(nv => nv.MaNhanVien)
                                                  .FirstOrDefault();

                if (string.IsNullOrEmpty(maNVDB))
                {
                    return "NV001";
                }
                string phanSo = maNVDB.Substring(2);
                int soMoi = int.Parse(phanSo) + 1;
                return "NV" + soMoi.ToString("D3");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo mã nhân viên tự động: " + ex.Message);
                return null;
            }
        }

        //Sửa khách hàng
        public bool SuaNV(NhanVien nv)
        {
            if (nv == null)
            {
                return false;
            }

            try
            {
                var nhanvien = context.NhanViens.FirstOrDefault(n => n.MaNhanVien == nv.MaNhanVien);
                if (nhanvien == null)
                {
                    return false;
                }
                nhanvien.HoTen = nv.HoTen;
                nhanvien.Email = nv.Email;
                nhanvien.MatKhau = nv.MatKhau;
                nhanvien.SoDienThoai = nv.SoDienThoai;
                nhanvien.VaiTro = nv.VaiTro;

                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        //Xóa Khách hàng
        public bool XoaNV(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
            {
                return false;
            }

            try
            {
                var nhanvien = context.NhanViens.FirstOrDefault(n => n.MaNhanVien == maNV);
                if (nhanvien == null)
                {
                    return false;
                }

                context.NhanViens.DeleteOnSubmit(nhanvien);
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa nhân viên: " + ex.Message);
                return false;
            }
        }

        //Tìm kiếm nhân viên bằng họ tên
        public List<NhanVien> SearchKhachHangByHoTen(string search)
        {
            if (string.IsNullOrEmpty(search)) return null;
            var nhanviens = context.NhanViens.Where(n => n.HoTen.Contains(search)).ToList();
            return nhanviens;
        }
    }
}
