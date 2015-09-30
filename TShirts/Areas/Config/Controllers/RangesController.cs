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
        private Entities db = new Entities();

        // GET: /Config/Ranges/
        public ActionResult Index()
        {
            return View(db.ProductRanges.ToList());
        }

        // GET: /Config/Ranges/Create
        public ActionResult Create()
        {
            ViewBag.GarmentTypes = new SelectList(db.GarmentTypes, "ID", "Name");
            return View();
        }

        // POST: /Config/Ranges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,GarmentTypeID,Name,SortOrder,Webpage,Available")] ProductRange range)
        {
            if (ModelState.IsValid)
            {
                db.ProductRanges.Add(range);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarmentTypes = new SelectList(db.GarmentTypes, "ID", "Name");
            return View(range);
        }

        // GET: /Config/Ranges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRange range = db.ProductRanges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.GarmentTypes = new SelectList(db.GarmentTypes, "ID", "Name");
            return View(range);
        }

        // POST: /Config/Ranges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GarmentTypeID,Name,SortOrder,Webpage,Available")] ProductRange range)
        {
            if (ModelState.IsValid)
            {
                db.Entry(range).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarmentTypes = new SelectList(db.GarmentTypes, "ID", "Name");
            return View(range);
        }

        // GET: /Config/Ranges/ColorsSizes/5
        public ActionResult ColorsSizes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRange range = db.ProductRanges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }

            ViewBag.Colors = db.ProductColors.Where(x => x.ProductRangeID == range.ID);

            var allSizes = db.ProductSizes.Where(x => x.ProductColor.ProductRangeID == range.ID).OrderBy(x => x.SortOrder).ThenBy(x => x.Name).Select(x => x.Name);
            ViewBag.Sizes = GetDistinctPreserveOrder(allSizes);

            return View(range);
        }

        private static List<T> GetDistinctPreserveOrder<T>(IEnumerable<T> sourceValues)
        {
            var sortedValues = new List<T>();
            var uniqueValues = new SortedSet<T>();

            foreach (var value in sourceValues)
            {
                if (uniqueValues.Contains(value))
                    continue;

                sortedValues.Add(value);
                uniqueValues.Add(value);
            }
            return sortedValues;
        }

        // POST: /Config/Ranges/ColorsSizes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ColorsSizes([Bind(Include = "ID,GarmentTypeID,Name,SortOrder,Webpage,Available")] ProductRange range)
        {
            /*
            if (ModelState.IsValid)
            {
                db.Entry(range).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarmentTypes = new SelectList(db.GarmentTypes, "ID", "Name");
            */
            return View(range);
        }

        // GET: /Config/Ranges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRange range = db.ProductRanges.Find(id);
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
            ProductRange range = db.ProductRanges.Find(id);
            db.ProductRanges.Remove(range);
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
