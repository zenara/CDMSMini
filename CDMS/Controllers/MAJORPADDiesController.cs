using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CDMS.Entities;

namespace CDMS.Controllers
{
    public class MAJORPADDiesController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: MAJORPADDies
        public ActionResult Index()
        {
            var mAJORPADDies = db.MAJORPADDies.Include(m => m.AILIST).Include(m => m.MONTH).Include(m => m.VARIETY).Include(m => m.YEAR);
            return View(mAJORPADDies.ToList());
        }

        // GET: MAJORPADDies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAJORPADDY mAJORPADDY = db.MAJORPADDies.Find(id);
            if (mAJORPADDY == null)
            {
                return HttpNotFound();
            }
            return View(mAJORPADDY);
        }

        // GET: MAJORPADDies/Create
        public ActionResult Create()
        {
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange");
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname");
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname");
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid");
            return View();
        }

        // POST: MAJORPADDies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,aiid,yearid,monthid,varietyid,monthlytarget,monthlyprogress")] MAJORPADDY mAJORPADDY)
        {
            if (ModelState.IsValid)
            {
                db.MAJORPADDies.Add(mAJORPADDY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", mAJORPADDY.aiid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", mAJORPADDY.monthid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", mAJORPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", mAJORPADDY.yearid);
            return View(mAJORPADDY);
        }

        // GET: MAJORPADDies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAJORPADDY mAJORPADDY = db.MAJORPADDies.Find(id);
            if (mAJORPADDY == null)
            {
                return HttpNotFound();
            }
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", mAJORPADDY.aiid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", mAJORPADDY.monthid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", mAJORPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", mAJORPADDY.yearid);
            return View(mAJORPADDY);
        }

        // POST: MAJORPADDies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,aiid,yearid,monthid,varietyid,monthlytarget,monthlyprogress")] MAJORPADDY mAJORPADDY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAJORPADDY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", mAJORPADDY.aiid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", mAJORPADDY.monthid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", mAJORPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", mAJORPADDY.yearid);
            return View(mAJORPADDY);
        }

        // GET: MAJORPADDies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAJORPADDY mAJORPADDY = db.MAJORPADDies.Find(id);
            if (mAJORPADDY == null)
            {
                return HttpNotFound();
            }
            return View(mAJORPADDY);
        }

        // POST: MAJORPADDies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MAJORPADDY mAJORPADDY = db.MAJORPADDies.Find(id);
            db.MAJORPADDies.Remove(mAJORPADDY);
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
