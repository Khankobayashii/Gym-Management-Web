using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63134295.Models;

namespace Project_63134295.Controllers
{
    public class LichTrinhTaps_63134295Controller : Controller
    {
        private Project_63134295Entities db = new Project_63134295Entities();

        // GET: LichTrinhTaps_63134295
        public ActionResult Index()
        {
            var lichTrinhTaps = db.LichTrinhTaps.Include(l => l.GoiTap).Include(l => l.KhachHang);
            return View(lichTrinhTaps.ToList());
        }

        // GET: LichTrinhTaps_63134295/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichTrinhTap lichTrinhTap = db.LichTrinhTaps.Find(id);
            if (lichTrinhTap == null)
            {
                return HttpNotFound();
            }
            return View(lichTrinhTap);
        }

        // GET: LichTrinhTaps_63134295/Create
        public ActionResult Create()
        {
            ViewBag.MaGoi = new SelectList(db.GoiTaps, "MaGoi", "TenGoi");
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH");
            return View();
        }

        // POST: LichTrinhTaps_63134295/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLichTrinh,MaKH,MaGoi,NgayBatDau,NgayKetThuc")] LichTrinhTap lichTrinhTap)
        {
            if (ModelState.IsValid)
            {
                db.LichTrinhTaps.Add(lichTrinhTap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGoi = new SelectList(db.GoiTaps, "MaGoi", "TenGoi", lichTrinhTap.MaGoi);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", lichTrinhTap.MaKH);
            return View(lichTrinhTap);
        }

        // GET: LichTrinhTaps_63134295/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichTrinhTap lichTrinhTap = db.LichTrinhTaps.Find(id);
            if (lichTrinhTap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGoi = new SelectList(db.GoiTaps, "MaGoi", "TenGoi", lichTrinhTap.MaGoi);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", lichTrinhTap.MaKH);
            return View(lichTrinhTap);
        }

        // POST: LichTrinhTaps_63134295/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLichTrinh,MaKH,MaGoi,NgayBatDau,NgayKetThuc")] LichTrinhTap lichTrinhTap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichTrinhTap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGoi = new SelectList(db.GoiTaps, "MaGoi", "TenGoi", lichTrinhTap.MaGoi);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", lichTrinhTap.MaKH);
            return View(lichTrinhTap);
        }

        // GET: LichTrinhTaps_63134295/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichTrinhTap lichTrinhTap = db.LichTrinhTaps.Find(id);
            if (lichTrinhTap == null)
            {
                return HttpNotFound();
            }
            return View(lichTrinhTap);
        }

        // POST: LichTrinhTaps_63134295/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichTrinhTap lichTrinhTap = db.LichTrinhTaps.Find(id);
            db.LichTrinhTaps.Remove(lichTrinhTap);
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
