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
    public class YEARsController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: YEARs
        public ActionResult Index()
        {
            return View(db.YEARS.ToList());
        }

        // GET: YEARs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YEAR yEAR = db.YEARS.Find(id);
            if (yEAR == null)
            {
                return HttpNotFound();
            }
            return View(yEAR);
        }

        // GET: YEARs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: YEARs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yearid,yearref")] YEAR yEAR)
        {
            if (ModelState.IsValid)
            {
                db.YEARS.Add(yEAR);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(yEAR);
        }

        // GET: YEARs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YEAR yEAR = db.YEARS.Find(id);
            if (yEAR == null)
            {
                return HttpNotFound();
            }
            return View(yEAR);
        }

        // POST: YEARs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "yearid,yearref")] YEAR yEAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yEAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yEAR);
        }

        // GET: YEARs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YEAR yEAR = db.YEARS.Find(id);
            if (yEAR == null)
            {
                return HttpNotFound();
            }
            return View(yEAR);
        }

        // POST: YEARs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YEAR yEAR = db.YEARS.Find(id);
            db.YEARS.Remove(yEAR);
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
