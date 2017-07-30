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
    public class VARIETiesController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: VARIETies
        public ActionResult Index()
        {
            var vARIETies = db.VARIETies.Include(v => v.AGEGROUP);
            return View(vARIETies.ToList());
        }

        // GET: VARIETies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VARIETY vARIETY = db.VARIETies.Find(id);
            if (vARIETY == null)
            {
                return HttpNotFound();
            }
            return View(vARIETY);
        }

        // GET: VARIETies/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.agegroupid = new SelectList(db.AGEGROUPs, "agegroupid", "agegroupname");
            return View();
        }

        // POST: VARIETies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "varietyid,varietyname,agegroupid")] VARIETY vARIETY)
        {
            if (ModelState.IsValid)
            {
                db.VARIETies.Add(vARIETY);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.agegroupid = new SelectList(db.AGEGROUPs, "agegroupid", "agegroupname", vARIETY.agegroupid);
            return View(vARIETY);
        }

        // GET: VARIETies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VARIETY vARIETY = db.VARIETies.Find(id);
            if (vARIETY == null)
            {
                return HttpNotFound();
            }
            ViewBag.agegroupid = new SelectList(db.AGEGROUPs, "agegroupid", "agegroupname", vARIETY.agegroupid);
            return View(vARIETY);
        }

        // POST: VARIETies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "varietyid,varietyname,agegroupid")] VARIETY vARIETY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vARIETY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.agegroupid = new SelectList(db.AGEGROUPs, "agegroupid", "agegroupname", vARIETY.agegroupid);
            return View(vARIETY);
        }

        // GET: VARIETies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VARIETY vARIETY = db.VARIETies.Find(id);
            if (vARIETY == null)
            {
                return HttpNotFound();
            }
            return View(vARIETY);
        }

        // POST: VARIETies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VARIETY vARIETY = db.VARIETies.Find(id);
            db.VARIETies.Remove(vARIETY);
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
