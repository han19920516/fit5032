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
    public class journalistsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: journalists
        public ActionResult Index()
        {
            var journalist = db.journalist.Include(j => j.article);
            return View(journalist.ToList());
        }

        // GET: journalists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journalist journalist = db.journalist.Find(id);
            if (journalist == null)
            {
                return HttpNotFound();
            }
            return View(journalist);
        }

        // GET: journalists/Create
        public ActionResult Create()
        {
            ViewBag.articleid = new SelectList(db.article, "articleid", "aname");
            return View();
        }

        // POST: journalists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "journalistid,jname,jphone,jemail,jtitle,articleid")] journalist journalist)
        {
            if (ModelState.IsValid)
            {
                db.journalist.Add(journalist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.articleid = new SelectList(db.article, "articleid", "aname", journalist.articleid);
            return View(journalist);
        }

        // GET: journalists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journalist journalist = db.journalist.Find(id);
            if (journalist == null)
            {
                return HttpNotFound();
            }
            ViewBag.articleid = new SelectList(db.article, "articleid", "aname", journalist.articleid);
            return View(journalist);
        }

        // POST: journalists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "journalistid,jname,jphone,jemail,jtitle,articleid")] journalist journalist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journalist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.articleid = new SelectList(db.article, "articleid", "aname", journalist.articleid);
            return View(journalist);
        }

        // GET: journalists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journalist journalist = db.journalist.Find(id);
            if (journalist == null)
            {
                return HttpNotFound();
            }
            return View(journalist);
        }

        // POST: journalists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            journalist journalist = db.journalist.Find(id);
            db.journalist.Remove(journalist);
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
