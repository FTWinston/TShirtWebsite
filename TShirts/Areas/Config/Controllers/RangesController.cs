using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TShirts.Models;

namespace TShirts.Areas.Config.Controllers
{
    public class RangesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Config/Ranges/
        public ActionResult Index()
        {
            return View(db.Ranges.ToList());
        }

        // GET: /Config/Ranges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // GET: /Config/Ranges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Config/Ranges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,SortOrder")] Range range)
        {
            if (ModelState.IsValid)
            {
                db.Ranges.Add(range);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(range);
        }

        // GET: /Config/Ranges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // POST: /Config/Ranges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,SortOrder")] Range range)
        {
            if (ModelState.IsValid)
            {
                db.Entry(range).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(range);
        }

        // GET: /Config/Ranges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // POST: /Config/Ranges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Range range = db.Ranges.Find(id);
            db.Ranges.Remove(range);
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
