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
    public class ADAsController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: ADAs
        public ActionResult Index()
        {
            return View(db.ADAs.ToList());
        }

        // GET: ADAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADA aDA = db.ADAs.Find(id);
            if (aDA == null)
            {
                return HttpNotFound();
            }
            return View(aDA);
        }

        // GET: ADAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adaid,adaname")] ADA aDA)
        {
            if (ModelState.IsValid)
            {
                db.ADAs.Add(aDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDA);
        }

        // GET: ADAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADA aDA = db.ADAs.Find(id);
            if (aDA == null)
            {
                return HttpNotFound();
            }
            return View(aDA);
        }

        // POST: ADAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adaid,adaname")] ADA aDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDA);
        }

        // GET: ADAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADA aDA = db.ADAs.Find(id);
            if (aDA == null)
            {
                return HttpNotFound();
            }
            return View(aDA);
        }

        // POST: ADAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADA aDA = db.ADAs.Find(id);
            db.ADAs.Remove(aDA);
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
