using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPham_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public SanPham_DAL() 
        { 

        }

        //Lấy tất cả sản phẩm
        public List<SanPhamDTO> GetAllSanPham()
        {
            var danhSachSanPham = (from sp in db.SanPhams
                                   join dm in db.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                                   select new SanPhamDTO
                                   {
                                       MaSanPham = sp.MaSanPham,
                                       TenSanPham = sp.TenSanPham,  
                                       TenDanhMuc = dm.TenDanhMuc,
                                       SoLuongTon = sp.SoLuongTon ?? 0,  
                                       GiaBan = sp.GiaBan ?? 0,
                                       HangSanXuat = sp.HangSanXuat,
                                       MoTa = sp.MoTa,
                                       DuongDanHinhAnh = db.HinhAnhSanPhams
                                                          .Where(ha => ha.MaSanPham == sp.MaSanPham)
                                                          .Select(ha => ha.DuongDanHinhAnh)
                                                          .FirstOrDefault()
                                   }).ToList();

            return danhSachSanPham;
        }
        //Lấy sản phẩm theo MaSP
        public SanPhamDTO GetSanPhamById(string maSP)
        {
            var sanpham = (from sp in db.SanPhams
                           join dm in db.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                           where sp.MaSanPham == maSP
                           select new SanPhamDTO
                           {
                               MaSanPham = sp.MaSanPham,
                               TenSanPham = sp.TenSanPham,
                               TenDanhMuc = dm.TenDanhMuc,
                               SoLuongTon = sp.SoLuongTon ?? 0,
                               GiaBan = sp.GiaBan ?? 0,
                               HangSanXuat = sp.HangSanXuat,
                               MoTa = sp.MoTa,
                               DuongDanHinhAnh = db.HinhAnhSanPhams
                                                  .Where(ha => ha.MaSanPham == sp.MaSanPham)
                                                  .Select(ha => ha.DuongDanHinhAnh)
                                                  .FirstOrDefault()
                           }).FirstOrDefault();

            return sanpham;
        }
        //Lấy sản phẩm theo danh mục
        public List<SanPhamDTO> GetSanPhamByCategory(string maDanhMuc)
        {
            var listsanpham = (from sp in db.SanPhams
                           join dm in db.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                           where dm.MaDanhMuc == maDanhMuc
                           select new SanPhamDTO
                           {
                               MaSanPham = sp.MaSanPham,
                               TenSanPham = sp.TenSanPham,
                               TenDanhMuc = dm.TenDanhMuc,
                               SoLuongTon = sp.SoLuongTon ?? 0,
                               GiaBan = sp.GiaBan ?? 0,
                               HangSanXuat = sp.HangSanXuat,
                               MoTa = sp.MoTa,
                               DuongDanHinhAnh = db.HinhAnhSanPhams
                                                  .Where(ha => ha.MaSanPham == sp.MaSanPham)
                                                  .Select(ha => ha.DuongDanHinhAnh)
                                                  .FirstOrDefault()
                           }).ToList();

            return listsanpham;
        }
        //Lấy sản phẩm theo Search
        public List<SanPhamDTO> GetSanPhamBySearch(string search)
        {
            var listsanpham = (from sp in db.SanPhams
                               join dm in db.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                               where sp.TenSanPham.Contains(search) && sp.SoLuongTon > 0
                               select new SanPhamDTO
                               {
                                   MaSanPham = sp.MaSanPham,
                                   TenSanPham = sp.TenSanPham,
                                   TenDanhMuc = dm.TenDanhMuc,
                                   SoLuongTon = sp.SoLuongTon ?? 0,
                                   GiaBan = sp.GiaBan ?? 0,
                                   HangSanXuat = sp.HangSanXuat,
                                   MoTa = sp.MoTa,
                                   DuongDanHinhAnh = db.HinhAnhSanPhams
                                                      .Where(ha => ha.MaSanPham == sp.MaSanPham)
                                                      .Select(ha => ha.DuongDanHinhAnh)
                                                      .FirstOrDefault()
                               }).ToList();

            return listsanpham;
        }

        //Lấy mã sản phẩm theo tên sản phẩm
        public string GetMaSPByTenSP(string tenSP)
        {
            var sanpham = db.SanPhams.FirstOrDefault(sp => sp.TenSanPham.Equals(tenSP));
            return sanpham.MaSanPham;
        }
        //Cập nhật số lượng tồn 
        public void CapNhatSoLuongTon(string maSP, int soLuong)
        {
            SanPham sp = db.SanPhams.Where(t => t.MaSanPham == maSP).FirstOrDefault();

            sp.SoLuongTon -= soLuong;
            db.SubmitChanges();
        }
        //Lấy số lượng tồn
        public int getSLT(string pMaSP)
        {
            var query = from sp in db.SanPhams where sp.MaSanPham == pMaSP select sp.SoLuongTon;
            return (int)query.FirstOrDefault();
        }

    }
}
