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
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public SanPham_DAL()
        {

        }

        //Lấy sản phẩm SanPhamDTO
        public SanPhamDTO GetSanPhamDTOById(string id)
        {
            try
            {
                var sanPham = (from sp in context.SanPhams
                               where sp.MaSanPham == id
                               select new SanPhamDTO
                               {
                                   MaSanPham = sp.MaSanPham,
                                   TenSanPham = sp.TenSanPham,
                                   MaDanhMuc = sp.MaDanhMuc,
                                   SoLuongTon = sp.SoLuongTon ?? 0,
                                   GiaBan = sp.GiaBan ?? 0,
                                   HangSanXuat = sp.HangSanXuat,
                                   MoTa = sp.MoTa,
                                  
                                   HinhAnhSanPhams = (from ha in context.HinhAnhSanPhams
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
            hinhanhs = context.HinhAnhSanPhams.Where(s => s.MaSanPham == id).ToList();
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
        public SanPham GetSanPhamById(string id)
        {
            if (id == null)
            {
                return null;
            }    
            else
            {
                var sanpham = context.SanPhams.FirstOrDefault(s => s.MaSanPham == id);
                if (sanpham == null)
                {
                    return null;
                }
                return sanpham;
            }
        }
        
        //Lấy Danh sách sp
        public List<SanPhamDTO> GetDSSP()
        {
            try
            {
                // Truy vấn danh sách sản phẩm kèm hình ảnh
                var danhSachSanPham = (from sp in context.SanPhams
                                       select new SanPhamDTO
                                       {
                                           MaSanPham = sp.MaSanPham,
                                           TenSanPham = sp.TenSanPham,
                                           MaDanhMuc = sp.MaDanhMuc,
                                           SoLuongTon = sp.SoLuongTon ?? 0,
                                           GiaBan = sp.GiaBan ?? 0,
                                           HangSanXuat = sp.HangSanXuat,
                                           MoTa = sp.MoTa,
                                           HinhAnhSanPhams = (from ha in context.HinhAnhSanPhams
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
                context.SanPhams.InsertOnSubmit(sanPham);
                context.SubmitChanges();

                // Thêm các hình ảnh liên quan đến sản phẩm (nếu có)
                foreach (var hinhAnh in hinhAnhSanPhams)
                {
                    hinhAnh.MaSanPham = sanPham.MaSanPham;
                    context.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
                }

                context.SubmitChanges();
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
                var sanPham = context.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
                if (sanPham == null)
                {
                    return false;
                }


                var hinhAnhs = context.HinhAnhSanPhams.Where(ha => ha.MaSanPham == maSanPham).ToList();
                context.HinhAnhSanPhams.DeleteAllOnSubmit(hinhAnhs);


                context.SanPhams.DeleteOnSubmit(sanPham);

                context.SubmitChanges();
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
        //        var sanPhamCu = context.SanPhams.FirstOrDefault(sp => sp.MaSanPham == sanPham.MaSanPham);
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

        //        var hinhAnhsCu = context.HinhAnhSanPhams.Where(ha => ha.MaSanPham == sanPham.MaSanPham).ToList();
        //        context.HinhAnhSanPhams.DeleteAllOnSubmit(hinhAnhsCu);

        //        foreach (var hinhAnh in hinhAnhSanPhams)
        //        {
        //            hinhAnh.MaSanPham = sanPham.MaSanPham;
        //            context.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
        //        }

        //        context.SubmitChanges();

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
                var sanPhamCu = context.SanPhams.SingleOrDefault(sp => sp.MaSanPham.Equals(sanPham.MaSanPham));
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
                var hinhAnhsCu = context.HinhAnhSanPhams.Where(ha => ha.MaSanPham.Equals(sanPham.MaSanPham)).ToList();
                if (hinhAnhSanPhams != null)
                {
                    // Xóa những ảnh không có trong danh sách mới
                    var hinhAnhXoa = hinhAnhsCu.Where(ha => !hinhAnhSanPhams.Any(haNew => haNew.DuongDanHinhAnh == ha.DuongDanHinhAnh)).ToList();
                    context.HinhAnhSanPhams.DeleteAllOnSubmit(hinhAnhXoa);

                    // Thêm ảnh mới
                    foreach (var hinhAnh in hinhAnhSanPhams)
                    {
                        hinhAnh.MaSanPham = sanPham.MaSanPham;
                        context.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
                        context.SubmitChanges();
                    }
                }
                //else
                //{
                //    //Thêm ảnh cũ
                //    foreach (var hinhAnh in hinhAnhsCu)
                //    {
                //        hinhAnh.MaSanPham = sanPham.MaSanPham;
                //        context.HinhAnhSanPhams.InsertOnSubmit(hinhAnh);
                //    }
                //}    

                
                //// Lưu lại các thay đổi
                //context.SubmitChanges();

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
            var hinhanhs = context.HinhAnhSanPhams.Where(s => s.MaSanPham == id).ToList();
            if(hinhanhs.Count == 0) return null;
            return hinhanhs;
        }
        //Hàm Tạo Mã sản phẩm tự động
        public string TaoMaSPTuDong()
        {
            try
            {
                var maSPDB = context.SanPhams.OrderByDescending(s => s.MaSanPham)
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
        public List<SanPhamDTO> SearchSanPhamByHoTen(string search)
        {
            if (string.IsNullOrEmpty(search)) return null;

            var sanphams = (from sp in context.SanPhams
                            where sp.TenSanPham.Contains(search)
                            select new SanPhamDTO
                            {
                                MaSanPham = sp.MaSanPham,
                                TenSanPham = sp.TenSanPham,
                                MaDanhMuc = sp.MaDanhMuc,
                                SoLuongTon = sp.SoLuongTon ?? 0,
                                GiaBan = sp.GiaBan ?? 0,
                                HangSanXuat = sp.HangSanXuat,
                                MoTa = sp.MoTa,
                                HinhAnhSanPhams = (from ha in context.HinhAnhSanPhams
                                                   where ha.MaSanPham == sp.MaSanPham
                                                   select ha.DuongDanHinhAnh).ToList()
                            }).ToList();

            return sanphams;
        }
    }
}
