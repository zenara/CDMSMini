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
    public class ASCsController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: ASCs
        public ActionResult Index()
        {
            var aSCs = db.ASCs.Include(a => a.D);
            return View(aSCs.ToList());
        }

        // GET: ASCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASC aSC = db.ASCs.Find(id);
            if (aSC == null)
            {
                return HttpNotFound();
            }
            return View(aSC);
        }

        // GET: ASCs/Create
        public ActionResult Create()
        {
            ViewBag.dsid = new SelectList(db.DS, "dsid", "dsname");
            return View();
        }

        // POST: ASCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ascid,dsid,ascname")] ASC aSC)
        {
            if (ModelState.IsValid)
            {
                db.ASCs.Add(aSC);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.dsid = new SelectList(db.DS, "dsid", "dsname", aSC.dsid);
            return View(aSC);
        }

        // GET: ASCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASC aSC = db.ASCs.Find(id);
            if (aSC == null)
            {
                return HttpNotFound();
            }
            ViewBag.dsid = new SelectList(db.DS, "dsid", "dsname", aSC.dsid);
            return View(aSC);
        }

        // POST: ASCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ascid,dsid,ascname")] ASC aSC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dsid = new SelectList(db.DS, "dsid", "dsname", aSC.dsid);
            return View(aSC);
        }

        // GET: ASCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASC aSC = db.ASCs.Find(id);
            if (aSC == null)
            {
                return HttpNotFound();
            }
            return View(aSC);
        }

        // POST: ASCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASC aSC = db.ASCs.Find(id);
            db.ASCs.Remove(aSC);
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
