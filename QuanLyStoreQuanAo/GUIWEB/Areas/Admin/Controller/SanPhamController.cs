using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace GUIWEB.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        DanhMucSanPham_BLL dm_bll = new DanhMucSanPham_BLL();
        SanPham_BLL sp_bll = new SanPham_BLL();

        List<DanhMucSanPham> danhmucsanphams = new List<DanhMucSanPham>();
        List<SanPhamDTOWEB> sanphams = new List<SanPhamDTOWEB>();
        // GET: Admin/SanPham
        //Hiển thị danh sách 
        public ActionResult SanPham(string search)
        {
            if (search == null)
            {
                sanphams = sp_bll.GetDSSP();
                return View(sanphams);
            }
            else
            {
                sanphams = sp_bll.SearchSanPhamByHoTen(search);
                ViewBag.Search = search;
                return View(sanphams);
            }
        }

        //Thêm sản phẩm
        public ActionResult ThemSanPham()
        {
            var danhMucList = dm_bll.GetDSDanhMuc();

            ViewBag.DanhMucList = danhMucList.Select(dm => new SelectListItem
            {
                Value = dm.MaDanhMuc,
                Text = dm.TenDanhMuc   
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSanPham(SanPhamDTOWEB sanPham, HttpPostedFileBase[] hinhAnhFiles)
        {
            if (ModelState.IsValid)
            {
                var sanPhamMoi = new SanPham
                {
                    MaSanPham = sp_bll.TaoMaSPTuDong(),
                    TenSanPham = sanPham.TenSanPham,
                    MaDanhMuc = sanPham.MaDanhMuc,
                    SoLuongTon = sanPham.SoLuongTon,
                    GiaBan = sanPham.GiaBan,
                    HangSanXuat = sanPham.HangSanXuat,
                    MoTa = sanPham.MoTa
                };

                // Xử lý file ảnh
                var hinhAnhSanPhams = new List<HinhAnhSanPham>();
                if (hinhAnhFiles != null)
                {
                    foreach (var file in hinhAnhFiles)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Server.MapPath("~/Areas/Admin/Data/imgs"), fileName);
                            file.SaveAs(filePath);

                            // Thêm vào danh sách hình ảnh
                            hinhAnhSanPhams.Add(new HinhAnhSanPham
                            {
                                DuongDanHinhAnh = fileName
                            });
                        }
                    }
                }

                // Gọi hàm DAL để thêm sản phẩm
                var success = sp_bll.ThemSP(sanPhamMoi, hinhAnhSanPhams);
                if (success)
                {
                    return RedirectToAction("SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi thêm sản phẩm vào cơ sở dữ liệu.");
                }
            }

            return View(sanPham);
        }

        public ActionResult SuaSanPham(string id)
        {
            var sanPham = sp_bll.GetSanPhamDTOById(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            ViewBag.DanhMucList = dm_bll.GetDSDanhMuc().Select(dm => new SelectListItem
            {
                Value = dm.MaDanhMuc.ToString(),
                Text = dm.TenDanhMuc
            }).ToList();

            ViewBag.HinhAnhList = sp_bll.GetHinhAnhSanPham(id);

            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham(SanPhamDTOWEB sanPham, HttpPostedFileBase[] hinhAnhFiles)
        {
            if (ModelState.IsValid)
            {
                var danhSachHinhAnh = new List<HinhAnhSanPham>();

                if (hinhAnhFiles != null && hinhAnhFiles.Length > 0)
                {
                    foreach (var file in hinhAnhFiles)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Server.MapPath("~/Areas/Admin/Data/imgs"), fileName);
                            file.SaveAs(filePath);

                            danhSachHinhAnh.Add(new HinhAnhSanPham
                            {
                                DuongDanHinhAnh = fileName
                            });
                        }
                    }
                }
                var sp = new SanPham
                {
                    MaSanPham = sanPham.MaSanPham,
                    TenSanPham = sanPham.TenSanPham,
                    MaDanhMuc = sanPham.MaDanhMuc,
                    SoLuongTon = sanPham.SoLuongTon,
                    GiaBan = sanPham.GiaBan,
                    HangSanXuat = sanPham.HangSanXuat,
                    MoTa = sanPham.MoTa
                };

                bool success = sp_bll.SuaSP(sp, danhSachHinhAnh);

                if (success)
                {
                    return RedirectToAction("SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi khi cập nhật sản phẩm.");
                }
            }

            ViewBag.DanhMucList = dm_bll.GetDSDanhMuc().Select(dm => new SelectListItem
            {
                Value = dm.MaDanhMuc.ToString(),
                Text = dm.TenDanhMuc
            }).ToList();

            ViewBag.HinhAnhList = sp_bll.GetHinhAnhSanPham(sanPham.MaSanPham);

            return View(sanPham);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SuaSanPham(SanPhamDTO sanPham, HttpPostedFileBase[] hinhAnhFiles)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Danh sách hình ảnh mới
        //        var danhSachHinhAnh = new List<HinhAnhSanPham>();

        //        // Kiểm tra nếu người dùng có tải lên hình ảnh mới
        //        if (hinhAnhFiles != null && hinhAnhFiles.Length > 0)
        //        {
        //            foreach (var file in hinhAnhFiles)
        //            {
        //                if (file != null && file.ContentLength > 0)
        //                {
        //                    var fileName = Path.GetFileName(file.FileName);
        //                    var filePath = Path.Combine(Server.MapPath("~/Areas/Admin/Data/imgs"), fileName);
        //                    file.SaveAs(filePath);

        //                    danhSachHinhAnh.Add(new HinhAnhSanPham
        //                    {
        //                        DuongDanHinhAnh = fileName
        //                    });
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // Nếu không tải lên file mới, lấy danh sách hình ảnh cũ từ cơ sở dữ liệu
        //            danhSachHinhAnh = sp_bll.GetHinhAnhSanPham(sanPham.MaSanPham)
        //                .Select(ha => new HinhAnhSanPham
        //                {
        //                    DuongDanHinhAnh = ha.DuongDanHinhAnh
        //                })
        //                .ToList();
        //        }

        //        // Tạo đối tượng sản phẩm để cập nhật
        //        var sp = new SanPham
        //        {
        //            MaSanPham = sanPham.MaSanPham,
        //            TenSanPham = sanPham.TenSanPham,
        //            MaDanhMuc = sanPham.MaDanhMuc,
        //            SoLuongTon = sanPham.SoLuongTon,
        //            GiaBan = sanPham.GiaBan,
        //            HangSanXuat = sanPham.HangSanXuat,
        //            MoTa = sanPham.MoTa
        //        };

        //        // Cập nhật sản phẩm và danh sách hình ảnh
        //        bool success = sp_bll.SuaSP(sp, danhSachHinhAnh);

        //        if (success)
        //        {
        //            return RedirectToAction("SanPham");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Lỗi khi cập nhật sản phẩm.");
        //        }
        //    }

        //    // Lấy danh sách danh mục để hiển thị lại form
        //    ViewBag.DanhMucList = dm_bll.GetDSDanhMuc().Select(dm => new SelectListItem
        //    {
        //        Value = dm.MaDanhMuc.ToString(),
        //        Text = dm.TenDanhMuc
        //    }).ToList();

        //    // Lấy danh sách hình ảnh cũ nếu không cập nhật được
        //    ViewBag.HinhAnhList = sp_bll.GetHinhAnhSanPham(sanPham.MaSanPham);

        //    return View(sanPham);
        //}


        //Xóa sản phẩm
        public ActionResult XoaSanPham(string id)
        {
            
            var sanPham = sp_bll.GetSanPhamById(id);
            if (sanPham == null)
            {
                return HttpNotFound(); 
            }

            return View(sanPham);
        }

        
        [HttpPost, ActionName("XoaSanPham")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaSanPham(string id)
        {
            var sanPham = sp_bll.GetSanPhamById(id);
            if (sanPham == null)
            {
                return HttpNotFound(); 
            }

            //var hinhAnhList = sp_bll.GetHinhAnhSanPham(id);
            //foreach (var hinhAnh in hinhAnhList)
            //{
            //    var filePath = Path.Combine(Server.MapPath("~/Areas/Admin/Data/imgs"), hinhAnh.DuongDanHinhAnh);
            //    if (System.IO.File.Exists(filePath))
            //    {
            //        System.IO.File.Delete(filePath); 
            //    }
            //    sp_bll.XoaAnhSanPham(id);
            //}

            // Xóa sản phẩm
            bool kq = sp_bll.XoaSP(id);
            if(kq)
            {
                return RedirectToAction("SanPham");
            }
            return View(sanPham);
        }

        //Hiển thị danh mục sản phẩm
        public ActionResult DanhMucSanPham(string search)
        {
            if (search == null)
            {
                danhmucsanphams = dm_bll.GetDSDanhMuc();
                return View(danhmucsanphams);
            }
            else
            {
                danhmucsanphams = dm_bll.SearchDanhMucByTenDanhMuc(search);
                ViewBag.Search = search;
                return View(danhmucsanphams);
            }
        }

        public ActionResult ThemDanhMucSanPham()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDanhMucSanPham(DanhMucSanPham dm)
        {
            if (ModelState.IsValid)
            {
                bool kq = dm_bll.ThemDMSP(dm);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Thêm danh mục sản phẩm thành công!";
                    return RedirectToAction("DanhMucSanPham");
                }
                else
                {
                    return RedirectToAction("ThemDanhMucSanPham");
                }
            }

            return View(dm);
        }

        public ActionResult SuaDanhMucSanPham(string id)
        {
            var dm = dm_bll.GetDanhMucSanPham(id);
            if (dm == null)
            {
                return HttpNotFound();
            }

            return View(dm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDanhMucSanPham(DanhMucSanPham dm)
        {
            if (ModelState.IsValid)
            {
                bool kq = dm_bll.SuaDMSP(dm);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Cập nhật danh mục sản phẩm thành công!";
                    return RedirectToAction("DanhMucSanPham");
                }
            }

            return View(dm);
        }

        public ActionResult XoaDanhMucSanPham(string id)
        {
            var dm = dm_bll.GetDanhMucSanPham(id);
            if (dm == null)
            {
                return HttpNotFound();
            }

            return View(dm);
        }

        [HttpPost]
        [ActionName("XoaDanhMucSanPham")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaDanhMucSanPham(string id)
        {
            var dm = dm_bll.GetDanhMucSanPham(id);
            if (dm != null)
            {
                bool kq = dm_bll.XoaDMSP(id);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Xóa danh mục sản phẩm thành công!";
                }
                RedirectToAction("DanhMucSanPham");
            }

            return RedirectToAction("DanhMucSanPham");
        }
    }
}