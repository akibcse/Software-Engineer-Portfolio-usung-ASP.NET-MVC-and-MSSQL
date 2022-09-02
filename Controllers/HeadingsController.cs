using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class HeadingsController : Controller
    {
        private MyPortfolioMVCEntities db = new MyPortfolioMVCEntities();

        // GET: Headings
        public ActionResult Index()
        {
            return View(db.Headings.ToList());
        }

        // GET: Headings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heading heading = db.Headings.Find(id);
            if (heading == null)
            {
                return HttpNotFound();
            }
            return View(heading);
        }

        // GET: Headings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Headings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Status")] Heading heading)
        {
            if (ModelState.IsValid)
            {
                db.Headings.Add(heading);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heading);
        }

        // GET: Headings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heading heading = db.Headings.Find(id);
            if (heading == null)
            {
                return HttpNotFound();
            }
            return View(heading);
        }

        // POST: Headings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Status")] Heading heading)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heading).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heading);
        }

        // GET: Headings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heading heading = db.Headings.Find(id);
            if (heading == null)
            {
                return HttpNotFound();
            }
            return View(heading);
        }

        // POST: Headings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heading heading = db.Headings.Find(id);
            db.Headings.Remove(heading);
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
