using QLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLNhanSu.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(NguoiDung data)
        {
            NhanSuEntities db = new NhanSuEntities();
            if (ModelState.IsValid)
            {
                int count = db.NguoiDungs.Count(x => x.TaiKhoan == data.TaiKhoan && x.MatKhau == data.MatKhau);
                if (count == 1)
                {
                    // Đăng Nhập Thành Công
                    FormsAuthentication.SetAuthCookie(data.TaiKhoan, false);
                    return RedirectToAction("Index", "Home");
                   
                    
                }
                else
                {
                    // Đăng Nhập Thất Bại
                    ModelState.AddModelError("", "Tài Khoản Hoặc Mật Khẩu Không Đúng");
                }
            }
            return View(data);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}