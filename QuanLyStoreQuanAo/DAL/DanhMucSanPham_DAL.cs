using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DanhMucSanPham_DAL
    {
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public DanhMucSanPham_DAL()
        {

        }

        //Lấy danh mục sản phẩm by id
        public DanhMucSanPham GetDanhMucSanPhamById(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                var dm = context.DanhMucSanPhams.FirstOrDefault(d => d.MaDanhMuc == id);
                if (dm == null)
                {
                    return null;
                }
                return dm;
            }
        }

        //Lấy danh sách danh mục
        public List<DanhMucSanPham> GetDanhSachDM()
        {
            return context.DanhMucSanPhams.Skip(1).ToList();
        }

        //Thêm danh mục sản phẩm
        public bool ThemDanhMucSanPhamMoi(DanhMucSanPham dm)
        {
            if (dm == null)
            {
                return false;
            }

            try
            {
                dm.MaDanhMuc = TaoMaDMTuDong();
                context.DanhMucSanPhams.InsertOnSubmit(dm);
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm danh mục sản phẩm: " + ex.Message);
                return false;
            }
        }

        //Hàm xóa sản phẩm
        public bool XoaDanhMucSanPham(string MaDM)
        {
            if (string.IsNullOrEmpty(MaDM))
            {
                return false;
            }

            try
            {
                var danhmuc = context.DanhMucSanPhams.FirstOrDefault(dm => dm.MaDanhMuc == MaDM);
                if (danhmuc == null)
                {
                    return false;
                }
                context.DanhMucSanPhams.DeleteOnSubmit(danhmuc);
                context.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa danh mục sản phẩm: " + ex.Message);
                return false;
            }
        }

        public bool SuaDanhMucSanPham(DanhMucSanPham dm)
        {
            if (dm == null)
            {
                return false;
            }

            try
            {
                var dmdb = context.DanhMucSanPhams.FirstOrDefault(d => d.MaDanhMuc == dm.MaDanhMuc);
                if (dmdb == null)
                {
                    return false; 
                }

                dmdb.TenDanhMuc = dm.TenDanhMuc;
                dmdb.MoTa = dm.MoTa;
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi sửa danh mục sản phẩm: " + ex.Message);
                return false;
            }
        }

        //Hàm Tạo Mã sản phẩm tự động
        public string TaoMaDMTuDong()
        {
            try
            {
                var maDMDB = context.DanhMucSanPhams.OrderByDescending(m => m.MaDanhMuc)
                                                  .Select(m => m.MaDanhMuc)
                                                  .FirstOrDefault();

                if (string.IsNullOrEmpty(maDMDB))
                {
                    return "DM001";
                }
                string phanSo = maDMDB.Substring(2);
                int soMoi = int.Parse(phanSo) + 1;
                return "DM" + soMoi.ToString("D3");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo mã danh mục sản phẩm tự động: " + ex.Message);
                return null;
            }
        }

        //Tìm kiếm danh mục theo tên danh mục
        public List<DanhMucSanPham> SearchDanhMucByTenDanhMuc(string search)
        {
            if (search == null) return null;
            return context.DanhMucSanPhams.Where(d => d.TenDanhMuc.Contains(search)).Skip(1).ToList();
        }

    }
}
