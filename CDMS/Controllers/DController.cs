using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CDMS.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CDMS.Controllers
{
    public class DController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: D
        public ActionResult Index()
        {
            var dS = db.DS.Include(d => d.DSTRCT);
            return View(dS.ToList());
        }

        // GET: D/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            D d = db.DS.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);
        }

        // GET: D/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.districtid = new SelectList(db.DSTRCTs, "districtid", "districtname");
            return View();
        }

        // POST: D/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dsid,districtid,dsname")] D d)
        {
            if (ModelState.IsValid)
            {
                db.DS.Add(d);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.districtid = new SelectList(db.DSTRCTs, "districtid", "districtname", d.districtid);
            return View(d);
        }

        // GET: D/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            D d = db.DS.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            ViewBag.districtid = new SelectList(db.DSTRCTs, "districtid", "districtname", d.districtid);
            return View(d);
        }

        // POST: D/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dsid,districtid,dsname")] D d)
        {
            if (ModelState.IsValid)
            {
                db.Entry(d).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.districtid = new SelectList(db.DSTRCTs, "districtid", "districtname", d.districtid);
            return View(d);
        }

        // GET: D/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            D d = db.DS.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);
        }

        // POST: D/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            D d = db.DS.Find(id);
            db.DS.Remove(d);
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
