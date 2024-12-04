using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;

namespace GUIWEB.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        SanPham_BLL sp_bll = new SanPham_BLL();
        DanhMucSanPham_BLL dm_bll = new DanhMucSanPham_BLL();
        DonHang_BLL dh_bll = new DonHang_BLL();
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        // GET: Admin/Home
        public ActionResult Dashboard()
        {
            var soluongsp = sp_bll.GetDSSP().Count();
            var soluongdm = dm_bll.GetDSDanhMuc().Count();
            var soluongdhtoday = dh_bll.TinhSoLuongDHToday();
            var soluongdhthang = dh_bll.TinhSoLuongDHTrongThang();
            var doanhthungay = dh_bll.TinhDoanhThuNgay();
            var doanhthuthang = dh_bll.TinhDoanhThuThang();


            ViewBag.totalsp = soluongsp.ToString() + " Sản phẩm";
            ViewBag.totaldm = soluongdm.ToString() + " Loại";
            ViewBag.soluongdhtoday = soluongdhtoday.ToString() + " Đơn";
            ViewBag.soluongdhthang = soluongdhthang.ToString() + " Đơn";

            if (doanhthungay > 0)
            {
                ViewBag.doanhthungay = String.Format("{0:N0}", doanhthungay) + " VNĐ";
            }
            else
            {
                ViewBag.doanhthungay = "0 VNĐ";
            }

            if (doanhthuthang > 0)
            {
                ViewBag.doanhthuthang = String.Format("{0:N0}", doanhthuthang) + " VNĐ";
            }
            else
            {
                ViewBag.doanhthuthang = "0 VNĐ";
            }

            return View();
        }
    }
}