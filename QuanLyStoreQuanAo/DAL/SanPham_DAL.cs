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


        //thêm sản phẩm
        public void addSP(SanPhamDTO sp)
        {
            Random random = new Random();
            SanPham sps = new SanPham();
            HinhAnhSanPham hinhAnhSanPham = new HinhAnhSanPham();
            sps.MaSanPham = sp.MaSanPham;
            sps.TenSanPham = sp.TenSanPham;
            sps.MaDanhMuc = sp.TenDanhMuc;
            sps.SoLuongTon = sp.SoLuongTon;
            sps.GiaBan = sp.GiaBan;
            sps.HangSanXuat = sp.HangSanXuat;
            sps.MoTa = sp.MoTa;


            hinhAnhSanPham.MaHinhAnh = random.Next(1000000, 10000000);
            hinhAnhSanPham.MaSanPham = sp.MaSanPham;
            hinhAnhSanPham.DuongDanHinhAnh = sp.DuongDanHinhAnh;

            db.SanPhams.InsertOnSubmit(sps);
            db.HinhAnhSanPhams.InsertOnSubmit(hinhAnhSanPham);
            db.SubmitChanges();
        }

        //xóa sản phẩm 
        public bool removeSP(string pMaSP)
        {
          SanPham sp = db.SanPhams.Where(t => t.MaSanPham == pMaSP).FirstOrDefault();
            if (sp != null)
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        //sửa sản phầm
        public void editSP(SanPhamDTO sp)
        {
             SanPham  sps = db.SanPhams.Where(t => t.MaSanPham == sp.MaSanPham).FirstOrDefault();
            HinhAnhSanPham hinhAnh = db.HinhAnhSanPhams.Where(t => t.MaSanPham == sp.MaSanPham).FirstOrDefault();
            sps.MaSanPham = sp.MaSanPham;
            sps.TenSanPham = sp.TenSanPham;
            sps.MaDanhMuc = sp.TenDanhMuc;
            sps.SoLuongTon = sp.SoLuongTon;
            sps.GiaBan = sp.GiaBan;
            sps.HangSanXuat = sp.HangSanXuat;
            sps.MoTa = sp.MoTa;

            
            hinhAnh.MaHinhAnh = hinhAnh.MaHinhAnh;
            hinhAnh.MaSanPham = sp.MaSanPham;
            hinhAnh.DuongDanHinhAnh = sp.DuongDanHinhAnh;
            db.SubmitChanges();
        }
        // đếm số  sản phẩm
        public int countProduct()
        {
            var query = from sp in db.SanPhams select sp;
            return query.Count();
        }
        // kiểm tra trùng mã sản phẩm
        public bool checkPK(string pCode)
        {
            var query = from sp in db.SanPhams where sp.MaSanPham == pCode select sp;
            return query.Any();
        }

    }
}
