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
    public class Stock_issueController : Controller
    {
        private db_nccEntities db = new db_nccEntities();

        // GET: Stock_issue
        public ActionResult Index()
        {
            var stock_issue = db.stock_issue.Include(s => s.cadet).Include(s => s.stock);
            return View(stock_issue.ToList());
        }

        // GET: Stock_issue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_issue stock_issue = db.stock_issue.Find(id);
            if (stock_issue == null)
            {
                return HttpNotFound();
            }
            return View(stock_issue);
        }

        // GET: Stock_issue/Create
        public ActionResult Create()
        {
            ViewBag.cadetid = new SelectList(db.cadets, "cadetid", "nccregno");
            ViewBag.stockissueid = new SelectList(db.stocks, "stockid", "stockname");
            return View();
        }

        // POST: Stock_issue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stockissueid,cadetid,issuedate,issueqty,stockid")] stock_issue stock_issue)
        {
            if (ModelState.IsValid)
            {
                db.stock_issue.Add(stock_issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cadetid = new SelectList(db.cadets, "cadetid", "nccregno", stock_issue.cadetid);
            ViewBag.stockissueid = new SelectList(db.stocks, "stockid", "stockname", stock_issue.stockissueid);
            return View(stock_issue);
        }

        // GET: Stock_issue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_issue stock_issue = db.stock_issue.Find(id);
            if (stock_issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.cadetid = new SelectList(db.cadets, "cadetid", "nccregno", stock_issue.cadetid);
            ViewBag.stockissueid = new SelectList(db.stocks, "stockid", "stockname", stock_issue.stockissueid);
            return View(stock_issue);
        }

        // POST: Stock_issue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stockissueid,cadetid,issuedate,issueqty,stockid")] stock_issue stock_issue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock_issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cadetid = new SelectList(db.cadets, "cadetid", "nccregno", stock_issue.cadetid);
            ViewBag.stockissueid = new SelectList(db.stocks, "stockid", "stockname", stock_issue.stockissueid);
            return View(stock_issue);
        }

        // GET: Stock_issue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_issue stock_issue = db.stock_issue.Find(id);
            if (stock_issue == null)
            {
                return HttpNotFound();
            }
            return View(stock_issue);
        }

        // POST: Stock_issue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock_issue stock_issue = db.stock_issue.Find(id);
            db.stock_issue.Remove(stock_issue);
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
