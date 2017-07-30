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
    public class AILISTsController : Controller
    {
        private CDMSEntities2 db = new CDMSEntities2();

        // GET: AILISTs
        public ActionResult Index()
        {
            var aILISTs = db.AILISTs.Include(a => a.ASC);
            return View(aILISTs.ToList());
        }

        // GET: AILISTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AILIST aILIST = db.AILISTs.Find(id);
            if (aILIST == null)
            {
                return HttpNotFound();
            }
            return View(aILIST);
        }

        // GET: AILISTs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ascid = new SelectList(db.ASCs, "ascid", "ascname");
            return View();
        }

        // POST: AILISTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aiid,ascid,airange,ainame,nic,telephone,email")] AILIST aILIST)
        {
            if (ModelState.IsValid)
            {
                db.AILISTs.Add(aILIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ascid = new SelectList(db.ASCs, "ascid", "ascname", aILIST.ascid);
            return View(aILIST);
        }

        // GET: AILISTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AILIST aILIST = db.AILISTs.Find(id);
            if (aILIST == null)
            {
                return HttpNotFound();
            }
            ViewBag.ascid = new SelectList(db.ASCs, "ascid", "ascname", aILIST.ascid);
            return View(aILIST);
        }

        // POST: AILISTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aiid,ascid,airange,ainame,nic,telephone,email")] AILIST aILIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aILIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ascid = new SelectList(db.ASCs, "ascid", "ascname", aILIST.ascid);
            return View(aILIST);
        }

        // GET: AILISTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AILIST aILIST = db.AILISTs.Find(id);
            if (aILIST == null)
            {
                return HttpNotFound();
            }
            return View(aILIST);
        }

        // POST: AILISTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AILIST aILIST = db.AILISTs.Find(id);
            db.AILISTs.Remove(aILIST);
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
