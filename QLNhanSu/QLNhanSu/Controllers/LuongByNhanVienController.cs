using QLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLNhanSu.Controllers
{
    public class LuongByNhanVienController : Controller
    {
        private readonly NhanSuEntities db = new NhanSuEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(NhanVien data)
        {
            NhanSuEntities db = new NhanSuEntities();
            if (ModelState.IsValid)
            {
                Session["MaNV"] = data.MaNV;
                int count = db.NhanViens.Count(x => x.MaNV == data.MaNV && x.SDT == data.SDT);
                if (count == 1)
                {
                    // Đăng Nhập Thành Công
                    FormsAuthentication.SetAuthCookie(data.MaNV, false);
                    return RedirectToAction("GetLuongById", "LuongByNhanVien");
                }
                else
                {
                    // Đăng Nhập Thất Bại
                    ModelState.AddModelError("", "Tài Khoản Hoặc Mật Khẩu Không Đúng");
                }
            }
            return View(data);
        }

  
        public ActionResult GetLuongById()
        {
            var MaNV = Session["MaNV"];
            var nhanvien = db.BangLuongs.Find(MaNV);
            return View(nhanvien);
        }
    }
}