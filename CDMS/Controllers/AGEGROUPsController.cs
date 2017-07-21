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
    public class AGEGROUPsController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: AGEGROUPs
        public ActionResult Index()
        {
            return View(db.AGEGROUPs.ToList());
        }

        // GET: AGEGROUPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGEGROUP aGEGROUP = db.AGEGROUPs.Find(id);
            if (aGEGROUP == null)
            {
                return HttpNotFound();
            }
            return View(aGEGROUP);
        }

        // GET: AGEGROUPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AGEGROUPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "agegroupid,agegroupname")] AGEGROUP aGEGROUP)
        {
            if (ModelState.IsValid)
            {
                db.AGEGROUPs.Add(aGEGROUP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aGEGROUP);
        }

        // GET: AGEGROUPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGEGROUP aGEGROUP = db.AGEGROUPs.Find(id);
            if (aGEGROUP == null)
            {
                return HttpNotFound();
            }
            return View(aGEGROUP);
        }

        // POST: AGEGROUPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "agegroupid,agegroupname")] AGEGROUP aGEGROUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aGEGROUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aGEGROUP);
        }

        // GET: AGEGROUPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGEGROUP aGEGROUP = db.AGEGROUPs.Find(id);
            if (aGEGROUP == null)
            {
                return HttpNotFound();
            }
            return View(aGEGROUP);
        }

        // POST: AGEGROUPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AGEGROUP aGEGROUP = db.AGEGROUPs.Find(id);
            db.AGEGROUPs.Remove(aGEGROUP);
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
