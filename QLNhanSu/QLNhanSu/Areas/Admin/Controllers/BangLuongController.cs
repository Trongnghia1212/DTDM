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
    public class BangLuongController : Controller
    {
        private NhanSuEntities db = new NhanSuEntities();

        // GET: Admin/BangLuong
        public ActionResult Index()
        {
            var bangLuongs = db.BangLuongs.Include(b => b.NhanVien);
            return View(bangLuongs.ToList());
        }

        // GET: Admin/BangLuong/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangLuong bangLuong = db.BangLuongs.Find(id);
            if (bangLuong == null)
            {
                return HttpNotFound();
            }
            return View(bangLuong);
        }

        // GET: Admin/BangLuong/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            return View();
        }

        // POST: Admin/BangLuong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,SoNgayCong")] BangLuong bangLuong)
        {
            if (ModelState.IsValid)
            {
                db.BangLuongs.Add(bangLuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", bangLuong.MaNV);
            return View(bangLuong);
        }

        // GET: Admin/BangLuong/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangLuong bangLuong = db.BangLuongs.Find(id);
            if (bangLuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", bangLuong.MaNV);
            return View(bangLuong);
        }

        // POST: Admin/BangLuong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,SoNgayCong")] BangLuong bangLuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangLuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", bangLuong.MaNV);
            return View(bangLuong);
        }

        // GET: Admin/BangLuong/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangLuong bangLuong = db.BangLuongs.Find(id);
            if (bangLuong == null)
            {
                return HttpNotFound();
            }
            return View(bangLuong);
        }

        // POST: Admin/BangLuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BangLuong bangLuong = db.BangLuongs.Find(id);
            db.BangLuongs.Remove(bangLuong);
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
