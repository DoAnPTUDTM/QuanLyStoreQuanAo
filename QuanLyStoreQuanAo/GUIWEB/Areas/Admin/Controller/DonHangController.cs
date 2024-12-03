using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIWEB.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        DonHang_BLL bll = new DonHang_BLL();
        List<DonHang> donhangs = new List<DonHang>();
        // GET: Admin/DonHang
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                donhangs = bll.GetDSDonHang();
                return View(donhangs);
            }
            else
            {
                donhangs = bll.SearchDonHangById(search);
                ViewBag.Search = search;
                return View(donhangs);
            }
        }

        
        public ActionResult SuaDonHang(string id)
        {
            var donHang = bll.GetDonHangById(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }

            return View(donHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDonHang(DonHang DonHang)
        {
            if (ModelState.IsValid)
            {
                bool kq = bll.SuaDonHang(DonHang);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Cập nhật đơn hàng thành công!";
                    return RedirectToAction("Index");
                }
            }

            return View(DonHang);
        }

        public ActionResult XoaDonHang(string id)
        {
            var donhang = bll.GetDonHangById(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }

            return View(donhang);
        }

        [HttpPost]
        [ActionName("XoaDonHang")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaKhachHang(string id)
        {
            var donhang = bll.GetDonHangById(id);
            if (donhang != null)
            {
                bool kq = bll.XoaDonHang(id);
                if (kq)
                {
                    TempData["SuccessMessage"] = "Xóa đơn hàng thành công!";
                }
                RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //
    }
}