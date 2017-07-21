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
    public class DSTRCTsController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: DSTRCTs
        public ActionResult Index()
        {
            var dSTRCTs = db.DSTRCTs.Include(d => d.ADA);
            return View(dSTRCTs.ToList());
        }

        // GET: DSTRCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSTRCT dSTRCT = db.DSTRCTs.Find(id);
            if (dSTRCT == null)
            {
                return HttpNotFound();
            }
            return View(dSTRCT);
        }

        // GET: DSTRCTs/Create
        public ActionResult Create()
        {
            ViewBag.adaid = new SelectList(db.ADAs, "adaid", "adaname");
            return View();
        }

        // POST: DSTRCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "districtid,adaid,districtname")] DSTRCT dSTRCT)
        {
            if (ModelState.IsValid)
            {
                db.DSTRCTs.Add(dSTRCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adaid = new SelectList(db.ADAs, "adaid", "adaname", dSTRCT.adaid);
            return View(dSTRCT);
        }

        // GET: DSTRCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSTRCT dSTRCT = db.DSTRCTs.Find(id);
            if (dSTRCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.adaid = new SelectList(db.ADAs, "adaid", "adaname", dSTRCT.adaid);
            return View(dSTRCT);
        }

        // POST: DSTRCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "districtid,adaid,districtname")] DSTRCT dSTRCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dSTRCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adaid = new SelectList(db.ADAs, "adaid", "adaname", dSTRCT.adaid);
            return View(dSTRCT);
        }

        // GET: DSTRCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSTRCT dSTRCT = db.DSTRCTs.Find(id);
            if (dSTRCT == null)
            {
                return HttpNotFound();
            }
            return View(dSTRCT);
        }

        // POST: DSTRCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DSTRCT dSTRCT = db.DSTRCTs.Find(id);
            db.DSTRCTs.Remove(dSTRCT);
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
