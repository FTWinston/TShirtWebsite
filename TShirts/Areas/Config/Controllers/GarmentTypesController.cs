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
    public class GarmentTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Config/GarmentTypes/
        public ActionResult Index()
        {
            return View(db.GarmentTypes.ToList());
        }

        // GET: /Config/GarmentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarmentType garmenttype = db.GarmentTypes.Find(id);
            if (garmenttype == null)
            {
                return HttpNotFound();
            }
            return View(garmenttype);
        }

        // GET: /Config/GarmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Config/GarmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,SortOrder,Available")] GarmentType garmenttype)
        {
            if (ModelState.IsValid)
            {
                db.GarmentTypes.Add(garmenttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garmenttype);
        }

        // GET: /Config/GarmentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarmentType garmenttype = db.GarmentTypes.Find(id);
            if (garmenttype == null)
            {
                return HttpNotFound();
            }
            return View(garmenttype);
        }

        // POST: /Config/GarmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,SortOrder,Available")] GarmentType garmenttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garmenttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garmenttype);
        }

        // GET: /Config/GarmentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarmentType garmenttype = db.GarmentTypes.Find(id);
            if (garmenttype == null)
            {
                return HttpNotFound();
            }
            return View(garmenttype);
        }

        // POST: /Config/GarmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GarmentType garmenttype = db.GarmentTypes.Find(id);
            db.GarmentTypes.Remove(garmenttype);
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
