using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace GUIWEB.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        KhachHang_BLL bus = new KhachHang_BLL();
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            if (bus.login(username, password))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        //public ActionResult Register(FormCollection form)
        //{
        //    var khachHang = new KhachHang
        //    {

        //        HoTen = form["HoTen"],
        //        Email = form["Email"],
        //        SoDienThoai = form["SoDienThoai"],
        //        MatKhau= form["MatKhau"],

        //    };

        //    var confirmPassword = form["confirmpassword"];
        //    if (confirmPassword != khachHang.MatKhau)
        //    {
        //        ModelState.AddModelError("ConfirmPassword", "Mật khẩu không khớp.");
        //      return View();
        //    }
        //   string kq= bus.register(khachHang);
        //    if (kq == "true")
        //    {
        //        return RedirectToAction("Customer", "SignIn");
        //    }
        //    else if(kq == "number") 
        //    {
        //        ModelState.AddModelError("SoDienThoai", "Số điện thoại không hợp lệ");
        //        return View();
        //    }
        //}


    }
}