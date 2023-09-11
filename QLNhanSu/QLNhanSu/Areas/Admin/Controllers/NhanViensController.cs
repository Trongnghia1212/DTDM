using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNhanSu.Models;

namespace QLNhanSu.Areas.Admin.Controllers
{
    [Authorize]
    public class NhanViensController : Controller
    {
       
        private NhanSuEntities db = new NhanSuEntities();

        // GET: Admin/NhanViens
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.BangLuong).Include(n => n.BoPhann).Include(n => n.ChucVu).Include(n => n.HopDong).Include(n => n.Phong);
            return View(nhanViens.ToList());
        }

        // GET: Admin/NhanViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.BangLuongs, "MaNV", "MaNV");
            ViewBag.MaBoPhan = new SelectList(db.BoPhanns, "MaBoPhan", "TenBoPhan");
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV");
            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "TenHD");
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong");
            return View();
        }

        // POST: Admin/NhanViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,GioiTinh,NgaySinh,Email,DiaChi,SDT,CMT,MaCV,MaHD,HSL,MaPhong,MaBoPhan")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.BangLuongs, "MaNV", "MaNV", nhanVien.MaNV);
            ViewBag.MaBoPhan = new SelectList(db.BoPhanns, "MaBoPhan", "TenBoPhan", nhanVien.MaBoPhan);
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "TenHD", nhanVien.MaHD);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", nhanVien.MaPhong);
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.BangLuongs, "MaNV", "MaNV", nhanVien.MaNV);
            ViewBag.MaBoPhan = new SelectList(db.BoPhanns, "MaBoPhan", "TenBoPhan", nhanVien.MaBoPhan);
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "TenHD", nhanVien.MaHD);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", nhanVien.MaPhong);
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,GioiTinh,NgaySinh,Email,DiaChi,SDT,CMT,MaCV,MaHD,HSL,MaPhong,MaBoPhan")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.BangLuongs, "MaNV", "MaNV", nhanVien.MaNV);
            ViewBag.MaBoPhan = new SelectList(db.BoPhanns, "MaBoPhan", "TenBoPhan", nhanVien.MaBoPhan);
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "TenHD", nhanVien.MaHD);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", nhanVien.MaPhong);
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
