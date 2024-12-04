using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIWEB.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        NhanVien_BLL bll = new NhanVien_BLL();
        List<NhanVien> nhanviens = new List<NhanVien>();
        // GET: Admin/NhanVien
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                nhanviens = bll.GetDSNV();
                return View(nhanviens);
            }
            else
            {
                nhanviens = bll.SearchKhachHangByHoTen(search);
                ViewBag.Search = search;
                return View(nhanviens);
            }
        }

        public ActionResult ThemNhanVien()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemNhanVien(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                bool kq = bll.ThemNV(nv);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Thêm nhân viên  thành công!";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("ThemNhanVien");
                }
            }

            return View(nv);
        }


        public ActionResult SuaNhanVien(string id)
        {
            var nhanvien = bll.GetNVById(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }

            return View(nhanvien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaNhanVien(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                bool kq = bll.SuaNV(nv);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Cập nhật nhân viên thành công!";
                    return RedirectToAction("Index");
                }
            }

            return View(nv);
        }

        public ActionResult XoaNhanVien(string id)
        {
            var nhanvien = bll.GetNVById(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }

            return View(nhanvien);
        }

        [HttpPost]
        [ActionName("XoaNhanVien")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaNhanVien(string id)
        {
            var khachHang = bll.GetNVById(id);
            if (khachHang != null)
            {
                bool kq = bll.XoaNV(id);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Xóa nhân viên thành công!";
                }
                RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}