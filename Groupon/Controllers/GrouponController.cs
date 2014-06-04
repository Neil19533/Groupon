using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Groupon.Models;

namespace Groupon.Controllers
{
    public class GrouponController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Groupon/
        public ActionResult Index()
        {
            return View(db.GrouponPages.ToList());
        }

        // GET: /Groupon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrouponPage grouponpage = db.GrouponPages.Find(id);
            if (grouponpage == null)
            {
                return HttpNotFound();
            }
            return View(grouponpage);
        }

        // GET: /Groupon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Groupon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GrouponPageId,Url")] GrouponPage grouponpage)
        {
            if (ModelState.IsValid)
            {
                db.GrouponPages.Add(grouponpage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grouponpage);
        }

        // GET: /Groupon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrouponPage grouponpage = db.GrouponPages.Find(id);
            if (grouponpage == null)
            {
                return HttpNotFound();
            }
            return View(grouponpage);
        }

        // POST: /Groupon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GrouponPageId,Url")] GrouponPage grouponpage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grouponpage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grouponpage);
        }

        // GET: /Groupon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrouponPage grouponpage = db.GrouponPages.Find(id);
            if (grouponpage == null)
            {
                return HttpNotFound();
            }
            return View(grouponpage);
        }

        // POST: /Groupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrouponPage grouponpage = db.GrouponPages.Find(id);
            db.GrouponPages.Remove(grouponpage);
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
