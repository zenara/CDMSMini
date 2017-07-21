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
    public class MINORPADDiesController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: MINORPADDies
        public ActionResult Index()
        {
            var mINORPADDies = db.MINORPADDies.Include(m => m.AILIST).Include(m => m.MONTH).Include(m => m.VARIETY).Include(m => m.YEAR);
            return View(mINORPADDies.ToList());
        }

        // GET: MINORPADDies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MINORPADDY mINORPADDY = db.MINORPADDies.Find(id);
            if (mINORPADDY == null)
            {
                return HttpNotFound();
            }
            return View(mINORPADDY);
        }

        // GET: MINORPADDies/Create
        public ActionResult Create()
        {
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange");
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname");
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname");
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid");
            return View();
        }

        // POST: MINORPADDies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,aiid,yearid,monthid,varietyid,monthlytarget,monthlyprogress")] MINORPADDY mINORPADDY)
        {
            if (ModelState.IsValid)
            {
                db.MINORPADDies.Add(mINORPADDY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", mINORPADDY.aiid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", mINORPADDY.monthid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", mINORPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", mINORPADDY.yearid);
            return View(mINORPADDY);
        }

        // GET: MINORPADDies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MINORPADDY mINORPADDY = db.MINORPADDies.Find(id);
            if (mINORPADDY == null)
            {
                return HttpNotFound();
            }
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", mINORPADDY.aiid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", mINORPADDY.monthid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", mINORPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", mINORPADDY.yearid);
            return View(mINORPADDY);
        }

        // POST: MINORPADDies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,aiid,yearid,monthid,varietyid,monthlytarget,monthlyprogress")] MINORPADDY mINORPADDY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mINORPADDY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", mINORPADDY.aiid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", mINORPADDY.monthid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", mINORPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", mINORPADDY.yearid);
            return View(mINORPADDY);
        }

        // GET: MINORPADDies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MINORPADDY mINORPADDY = db.MINORPADDies.Find(id);
            if (mINORPADDY == null)
            {
                return HttpNotFound();
            }
            return View(mINORPADDY);
        }

        // POST: MINORPADDies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MINORPADDY mINORPADDY = db.MINORPADDies.Find(id);
            db.MINORPADDies.Remove(mINORPADDY);
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
