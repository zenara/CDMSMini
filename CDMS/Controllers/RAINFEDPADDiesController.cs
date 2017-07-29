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
    public class RAINFEDPADDiesController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: RAINFEDPADDies
        public ActionResult Index()
        {
            var rAINFEDPADDies = db.RAINFEDPADDies.Include(r => r.AILIST).Include(r => r.VARIETY).Include(r => r.YEAR).Include(r => r.MONTH);
            return View(rAINFEDPADDies.ToList());
        }

        // GET: RAINFEDPADDies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAINFEDPADDY rAINFEDPADDY = db.RAINFEDPADDies.Find(id);
            if (rAINFEDPADDY == null)
            {
                return HttpNotFound();
            }
            return View(rAINFEDPADDY);
        }

        // GET: RAINFEDPADDies/Create
        public ActionResult Create()
        {
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange");
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname");
            ViewBag.yearid = new SelectList(db.YEARS.OrderByDescending(e => e.yearid), "yearid", "yearref");
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname");
            return View();
        }

        // POST: RAINFEDPADDies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,aiid,yearid,monthid,varietyid,monthlytarget,monthlyprogress")] RAINFEDPADDY rAINFEDPADDY)
        {
            if (ModelState.IsValid)
            {
                db.RAINFEDPADDies.Add(rAINFEDPADDY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", rAINFEDPADDY.aiid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", rAINFEDPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", rAINFEDPADDY.yearid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", rAINFEDPADDY.monthid);
            return View(rAINFEDPADDY);
        }

        // GET: RAINFEDPADDies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAINFEDPADDY rAINFEDPADDY = db.RAINFEDPADDies.Find(id);
            if (rAINFEDPADDY == null)
            {
                return HttpNotFound();
            }
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", rAINFEDPADDY.aiid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", rAINFEDPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", rAINFEDPADDY.yearid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", rAINFEDPADDY.monthid);
            return View(rAINFEDPADDY);
        }

        // POST: RAINFEDPADDies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,aiid,yearid,monthid,varietyid,monthlytarget,monthlyprogress")] RAINFEDPADDY rAINFEDPADDY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAINFEDPADDY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aiid = new SelectList(db.AILISTs, "aiid", "airange", rAINFEDPADDY.aiid);
            ViewBag.varietyid = new SelectList(db.VARIETies, "varietyid", "varietyname", rAINFEDPADDY.varietyid);
            ViewBag.yearid = new SelectList(db.YEARS, "yearid", "yearid", rAINFEDPADDY.yearid);
            ViewBag.monthid = new SelectList(db.MONTHS, "monthid", "monthname", rAINFEDPADDY.monthid);
            return View(rAINFEDPADDY);
        }

        // GET: RAINFEDPADDies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAINFEDPADDY rAINFEDPADDY = db.RAINFEDPADDies.Find(id);
            if (rAINFEDPADDY == null)
            {
                return HttpNotFound();
            }
            return View(rAINFEDPADDY);
        }

        // POST: RAINFEDPADDies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAINFEDPADDY rAINFEDPADDY = db.RAINFEDPADDies.Find(id);
            db.RAINFEDPADDies.Remove(rAINFEDPADDY);
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
