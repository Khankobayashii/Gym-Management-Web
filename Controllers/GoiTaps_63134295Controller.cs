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
    public class GoiTaps_63134295Controller : Controller
    {
        private Project_63134295Entities db = new Project_63134295Entities();

        // GET: GoiTaps_63134295
        public ActionResult Index()
        {
            return View(db.GoiTaps.ToList());
        }

        // GET: GoiTaps_63134295/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiTap goiTap = db.GoiTaps.Find(id);
            if (goiTap == null)
            {
                return HttpNotFound();
            }
            return View(goiTap);
        }
        public ActionResult DangKy()
        {
            return View(); 
        }
        [HttpGet]

        public ActionResult TimKiemNC(string maGoi = "", string tenGoi = "", string giaMin = "", string giaMax = "")
        {
            string min = giaMin, max = giaMax;
            if (giaMin == "")
            {
                ViewBag.luongMin = "";
                min = "0";
            }
            else
            {
                ViewBag.giaMin = giaMin;
                min = giaMin;
            }
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.luongMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.luongMax = giaMax;
                max = giaMax;
            }
            var goiTaps = db.GoiTaps.SqlQuery("GoiTap_TimKiem '" + maGoi + "', '" + tenGoi + "', '" + min + "', '" + max + "'");
            if (goiTaps.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(goiTaps.ToList());
        }

        // GET: GoiTaps_63134295/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoiTaps_63134295/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGoi,TenGoi,MoTa,Gia")] GoiTap goiTap)
        {
            if (ModelState.IsValid)
            {
                db.GoiTaps.Add(goiTap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goiTap);
        }

        // GET: GoiTaps_63134295/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiTap goiTap = db.GoiTaps.Find(id);
            if (goiTap == null)
            {
                return HttpNotFound();
            }
            return View(goiTap);
        }

        // POST: GoiTaps_63134295/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGoi,TenGoi,MoTa,Gia")] GoiTap goiTap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goiTap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goiTap);
        }

        // GET: GoiTaps_63134295/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiTap goiTap = db.GoiTaps.Find(id);
            if (goiTap == null)
            {
                return HttpNotFound();
            }
            return View(goiTap);
        }

        // POST: GoiTaps_63134295/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GoiTap goiTap = db.GoiTaps.Find(id);
            db.GoiTaps.Remove(goiTap);
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
