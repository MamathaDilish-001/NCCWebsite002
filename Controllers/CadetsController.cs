using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NCCWebsite002;

namespace NCCWebsite002.Controllers
{
    public class CadetsController : Controller
    {
        private db_nccEntities db = new db_nccEntities();

        // GET: Cadets
        public ActionResult Index()
        {
            return View(db.cadets.ToList());
        }

        // GET: Cadets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadet cadet = db.cadets.Find(id);
            if (cadet == null)
            {
                return HttpNotFound();
            }
            return View(cadet);
        }

        // GET: Cadets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cadetid,nccregno,cadetname,gender,email,phoneno,course")] cadet cadet)
        {
            if (ModelState.IsValid)
            {
                db.cadets.Add(cadet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadet);
        }

        // GET: Cadets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadet cadet = db.cadets.Find(id);
            if (cadet == null)
            {
                return HttpNotFound();
            }
            return View(cadet);
        }

        // POST: Cadets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cadetid,nccregno,cadetname,gender,email,phoneno,course")] cadet cadet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadet);
        }

        // GET: Cadets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadet cadet = db.cadets.Find(id);
            if (cadet == null)
            {
                return HttpNotFound();
            }
            return View(cadet);
        }

        // POST: Cadets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cadet cadet = db.cadets.Find(id);
            db.cadets.Remove(cadet);
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
