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
    public class BoPhannController : Controller
    {
        
        private NhanSuEntities db = new NhanSuEntities();

        // GET: Admin/BoPhann
        public ActionResult Index()
        {
            return View(db.BoPhanns.ToList());
        }

        // GET: Admin/BoPhann/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoPhann boPhann = db.BoPhanns.Find(id);
            if (boPhann == null)
            {
                return HttpNotFound();
            }
            return View(boPhann);
        }

        // GET: Admin/BoPhann/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BoPhann/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBoPhan,TenBoPhan")] BoPhann boPhann)
        {
            if (ModelState.IsValid)
            {
                db.BoPhanns.Add(boPhann);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boPhann);
        }

        // GET: Admin/BoPhann/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoPhann boPhann = db.BoPhanns.Find(id);
            if (boPhann == null)
            {
                return HttpNotFound();
            }
            return View(boPhann);
        }

        // POST: Admin/BoPhann/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBoPhan,TenBoPhan")] BoPhann boPhann)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boPhann).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boPhann);
        }

        // GET: Admin/BoPhann/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoPhann boPhann = db.BoPhanns.Find(id);
            if (boPhann == null)
            {
                return HttpNotFound();
            }
            return View(boPhann);
        }

        // POST: Admin/BoPhann/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BoPhann boPhann = db.BoPhanns.Find(id);
            db.BoPhanns.Remove(boPhann);
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
