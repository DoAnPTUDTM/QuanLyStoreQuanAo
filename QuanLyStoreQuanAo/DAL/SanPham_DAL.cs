using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SanPham_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public SanPham_DAL() 
        { 

        }

        //Lấy sản phẩm SanPhamDTO
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
        public SanPhamDTOWEB GetSanPhamDTOById(string id)
        {
            try
            {
                var sanPham = (from sp in db.SanPhams
                               where sp.MaSanPham == id
                               select new SanPhamDTOWEB
                               {
                                   MaSanPham = sp.MaSanPham,
                                   TenSanPham = sp.TenSanPham,
                                   MaDanhMuc = sp.MaDanhMuc,
                                   SoLuongTon = sp.SoLuongTon ?? 0,
                                   GiaBan = sp.GiaBan ?? 0,
                                   HangSanXuat = sp.HangSanXuat,
                                   MoTa = sp.MoTa,

                                   HinhAnhSanPhams = (from ha in db.HinhAnhSanPhams
                                                      where ha.MaSanPham == id
                                                      select ha.DuongDanHinhAnh).ToList()
                               }).FirstOrDefault();

                return sanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy sản phẩm: " + ex.Message);
                return null;
            }
        }
        //Xóa ảnh
        public bool XoaAnhSanPham(string id)
        {
            if (id == null) return false;
            List<HinhAnhSanPham> hinhanhs = new List<HinhAnhSanPham>();
            hinhanhs = db.HinhAnhSanPhams.Where(s => s.MaSanPham == id).ToList();
            if (hinhanhs.Count > 0)
            {
                foreach (var h in hinhanhs)
                {
                    hinhanhs.Remove(h);
                }
                return true;
            }
            return false;
        }
        //Lấy sản phẩm by id
        public SanPham GetSanPhamByIdAdmin(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                var sanpham = db.SanPhams.FirstOrDefault(s => s.MaSanPham == id);
                if (sanpham == null)
                {
                    return null;
                }
                return sanpham;
            }
        }

        //Lấy Danh sách sp
        public List<SanPhamDTOWEB> GetDSSP()
        {
            try
            {
                // Truy vấn danh sách sản phẩm kèm hình ảnh
                var danhSachSanPham = (from sp in db.SanPhams
                                       select new SanPhamDTOWEB
                                       {
                                           MaSanPham = sp.MaSanPham,
                                           TenSanPham = sp.TenSanPham,
                                           MaDanhMuc = sp.MaDanhMuc,
                                           SoLuongTon = sp.SoLuongTon ?? 0,
                                           GiaBan = sp.GiaBan ?? 0,
                                           HangSanXuat = sp.HangSanXuat,
                                           MoTa = sp.MoTa,
                                           HinhAnhSanPhams = (from ha in db.HinhAnhSanPhams
                                                              where ha.MaSanPham == sp.MaSanPham
                                                              select ha.DuongDanHinhAnh).ToList()
                                       }).ToList();

                return danhSachSanPham;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách sản phẩm: " + ex.Message);
                return null;
            }
        }
        //Thêm sản phẩm
        public bool ThemSanPhamMoi(SanPham sanPham, List<HinhAnhSanPham> hinhAnhSanPhams)
        {
            if (sanPham == null || hinhAnhSanPhams == null)
            {
                return false;
            }

            try
            {
                // Thêm sản phẩm
                sanPham.MaSanPham = TaoMaSPTuDong();
                db.SanPhams.InsertOnSubmit(sanPham);
                db.SubmitChanges();

                // Thêm các hình ảnh liên quan đến sản phẩm (nếu có)
                foreach (var hinhAnh in hinhAnhSanPhams)
                {
                    hinhAnh.MaSanPham = sanPham.MaSanPham;
                    db.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
                }

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm sản phẩm: " + ex.Message);
                return false;
            }
        }

        //Hàm xóa sản phẩm
        public bool XoaSanPham(string maSanPham)
        {
            if (string.IsNullOrEmpty(maSanPham))
            {
                return false;
            }

            try
            {
                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
                if (sanPham == null)
                {
                    return false;
                }


                var hinhAnhs = db.HinhAnhSanPhams.Where(ha => ha.MaSanPham == maSanPham).ToList();
                db.HinhAnhSanPhams.DeleteAllOnSubmit(hinhAnhs);


                db.SanPhams.DeleteOnSubmit(sanPham);

                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa sản phẩm: " + ex.Message);
                return false;
            }
        }

        //public bool SuaSanPham(SanPham sanPham, List<HinhAnhSanPham> hinhAnhSanPhams)
        //{
        //    if (sanPham == null || hinhAnhSanPhams == null || hinhAnhSanPhams.Count != 2)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        var sanPhamCu = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == sanPham.MaSanPham);
        //        if (sanPhamCu == null)
        //        {
        //            return false;
        //        }

        //        sanPhamCu.TenSanPham = sanPham.TenSanPham;
        //        sanPhamCu.MaDanhMuc = sanPham.MaDanhMuc;
        //        sanPhamCu.SoLuongTon = sanPham.SoLuongTon;
        //        sanPhamCu.GiaBan = sanPham.GiaBan;
        //        sanPhamCu.HangSanXuat = sanPham.HangSanXuat;
        //        sanPhamCu.MoTa = sanPham.MoTa;

        //        var hinhAnhsCu = db.HinhAnhSanPhams.Where(ha => ha.MaSanPham == sanPham.MaSanPham).ToList();
        //        db.HinhAnhSanPhams.DeleteAllOnSubmit(hinhAnhsCu);

        //        foreach (var hinhAnh in hinhAnhSanPhams)
        //        {
        //            hinhAnh.MaSanPham = sanPham.MaSanPham;
        //            db.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
        //        }

        //        db.SubmitChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi sửa sản phẩm: " + ex.Message);
        //        return false;
        //    }
        //}

        public bool SuaSanPham(SanPham sanPham, List<HinhAnhSanPham> hinhAnhSanPhams)
        {
            if (sanPham == null)
            {
                return false;  // Kiểm tra nếu không có ảnh hoặc sản phẩm null.
            }

            try
            {
                // Tìm sản phẩm cũ, sử dụng SingleOrDefault để đảm bảo chỉ có 1 sản phẩm.
                var sanPhamCu = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham.Equals(sanPham.MaSanPham));
                if (sanPhamCu == null)
                {
                    return false;  // Nếu không tìm thấy sản phẩm
                }

                // Cập nhật thông tin sản phẩm
                sanPhamCu.TenSanPham = sanPham.TenSanPham;
                sanPhamCu.MaDanhMuc = sanPham.MaDanhMuc;
                sanPhamCu.SoLuongTon = sanPham.SoLuongTon;
                sanPhamCu.GiaBan = sanPham.GiaBan;
                sanPhamCu.HangSanXuat = sanPham.HangSanXuat;
                sanPhamCu.MoTa = sanPham.MoTa;

                // Lấy danh sách ảnh cũ để xóa
                var hinhAnhsCu = db.HinhAnhSanPhams.Where(ha => ha.MaSanPham.Equals(sanPham.MaSanPham)).ToList();
                if (hinhAnhSanPhams != null)
                {
                    // Xóa những ảnh không có trong danh sách mới
                    var hinhAnhXoa = hinhAnhsCu.Where(ha => !hinhAnhSanPhams.Any(haNew => haNew.DuongDanHinhAnh == ha.DuongDanHinhAnh)).ToList();
                    db.HinhAnhSanPhams.DeleteAllOnSubmit(hinhAnhXoa);

                    // Thêm ảnh mới
                    foreach (var hinhAnh in hinhAnhSanPhams)
                    {
                        hinhAnh.MaSanPham = sanPham.MaSanPham;
                        db.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
                        db.SubmitChanges();
                    }
                }
                //else
                //{
                //    //Thêm ảnh cũ
                //    foreach (var hinhAnh in hinhAnhsCu)
                //    {
                //        hinhAnh.MaSanPham = sanPham.MaSanPham;
                //        db.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
                //    }
                //}    


                //// Lưu lại các thay đổi
                //db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Lấy ds HinhAnh by id
        public List<HinhAnhSanPham> GetHinhAnhSanPham(string id)
        {
            if (id == null) return null;
            var hinhanhs = db.HinhAnhSanPhams.Where(s => s.MaSanPham == id).ToList();
            if (hinhanhs.Count == 0) return null;
            return hinhanhs;
        }
        //Hàm Tạo Mã sản phẩm tự động
        public string TaoMaSPTuDong()
        {
            try
            {
                var maSPDB = db.SanPhams.OrderByDescending(s => s.MaSanPham)
                                                  .Select(s => s.MaSanPham)
                                                  .FirstOrDefault();

                if (string.IsNullOrEmpty(maSPDB))
                {
                    return "SP001";
                }
                string phanSo = maSPDB.Substring(2);
                int soMoi = int.Parse(phanSo) + 1;
                return "SP" + soMoi.ToString("D3");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo mã sản phẩm tự động: " + ex.Message);
                return null;
            }
        }

        //Tìm kiếm sản phẩm theo tên sp
        public List<SanPhamDTOWEB> SearchSanPhamByHoTen(string search)
        {
            if (string.IsNullOrEmpty(search)) return null;

            var sanphams = (from sp in db.SanPhams
                            where sp.TenSanPham.Contains(search)
                            select new SanPhamDTOWEB
                            {
                                MaSanPham = sp.MaSanPham,
                                TenSanPham = sp.TenSanPham,
                                MaDanhMuc = sp.MaDanhMuc,
                                SoLuongTon = sp.SoLuongTon ?? 0,
                                GiaBan = sp.GiaBan ?? 0,
                                HangSanXuat = sp.HangSanXuat,
                                MoTa = sp.MoTa,
                                HinhAnhSanPhams = (from ha in db.HinhAnhSanPhams
                                                   where ha.MaSanPham == sp.MaSanPham
                                                   select ha.DuongDanHinhAnh).ToList()
                            }).ToList();

            return sanphams;
        }

    }
}
