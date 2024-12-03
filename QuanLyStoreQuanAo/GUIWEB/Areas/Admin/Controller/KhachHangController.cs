using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIWEB.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        KhachHang_BLL bll = new KhachHang_BLL();
        List<KhachHang> khachhangs = new List<KhachHang>();
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                khachhangs = bll.GetDSKH();
                return View(khachhangs);
            }
            else
            {
                khachhangs = bll.SearchKhachHangByHoTen(search);
                ViewBag.Search = search;
                return View(khachhangs);
            }
        }

        public ActionResult ThemKhachHang()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemKhachHang(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                bool kq = bll.ThemKH(kh);
                if(kq)
                {
                    TempData["SuccessMessage"] = "Thêm khách hàng thành công!";
                    return RedirectToAction("Index");
                }    
                else
                {
                    return RedirectToAction("ThemKhachHang");
                }    
            }

            return View(kh);
        }


        public ActionResult SuaKhachHang(string id)
        {
            var khachHang = bll.GetKHById(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }

            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaKhachHang(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                bool kq = bll.SuaKH(khachHang);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Cập nhật khách hàng thành công!";
                    return RedirectToAction("Index");
                }
            }

            return View(khachHang);
        }

        public ActionResult XoaKhachHang(string id)
        {
            var khachHang = bll.GetKHById(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }

            return View(khachHang);
        }

        [HttpPost]
        [ActionName("XoaKhachHang")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaKhachHang(string id)
        {
            var khachHang = bll.GetKHById(id);
            if (khachHang != null)
            {
                bool kq = bll.XoaKH(id);
                if(kq)
                {
                    TempData["SuccessMessage"] = "Xóa khách hàng thành công!";
                }    
                RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}