using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assClevelNew.Models;

namespace assClevelNew.Controllers
{
    public class referencesController : Controller
    {
        private Database2Entities db = new Database2Entities();

        // GET: references
        public ActionResult Index()
        {
            return View(db.reference.ToList());
        }

        // GET: references/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reference reference = db.reference.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // GET: references/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: references/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,image,author")] reference reference)
        {
            if (ModelState.IsValid)
            {
                db.reference.Add(reference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reference);
        }

        // GET: references/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reference reference = db.reference.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // POST: references/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,image,author")] reference reference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reference);
        }

        // GET: references/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reference reference = db.reference.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // POST: references/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reference reference = db.reference.Find(id);
            db.reference.Remove(reference);
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
