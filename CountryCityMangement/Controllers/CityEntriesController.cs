using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CountryCityMangement.Models;
using Microsoft.Ajax.Utilities;

namespace CountryCityMangement.Controllers
{
    public class CityEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CityEntries
        public ActionResult Index()
        {

            ViewBag.country = db.CountryEntries.ToList();
            ViewBag.cityes = db.CityEntries.Include(c => c.CoutEntry).OrderBy(c => c.CityName);
            //return View(cityEntries.ToList());
            return View();
        }
        [HttpPost]
        public ActionResult Serch(CityViewModel serching)

        {

            ViewBag.cityes = db.CityEntries.Include(c => c.CoutEntry).OrderBy(c => c.CityName);
            ViewBag.country = db.CountryEntries.ToList();
            if (serching.SerchedValue == "cityName")
                {
                    ViewBag.cityes = db.CityEntries.Where(m => m.CityName.Trim() == serching.CityName.Trim()).ToList();
                }
                else
                {
                    ViewBag.cityes = db.CityEntries.Where(m => m.CoutEntryId == serching.CoutEntryId).ToList();
                }

          
         

            return View("Index");
        }

        // GET: CityEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityEntry cityEntry = db.CityEntries.Find(id);
            if (cityEntry == null)
            {
                return HttpNotFound();
            }
            return View(cityEntry);
        }



        // GET: CityEntries/Create
        public ActionResult Create()
        {
            ViewBag.CoutEntryId = new SelectList(db.CountryEntries, "Id", "CountyName");
            ViewBag.cityes = db.CityEntries.Include(c => c.CoutEntry).OrderBy(c => c.CityName);
            return View();
        }

        // POST: CityEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CityName,About,NoOfDweller,Location,Weather,CoutEntryId")] CityEntry cityEntry)
        {
            if (ModelState.IsValid)
            {
                db.CityEntries.Add(cityEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoutEntryId = new SelectList(db.CountryEntries, "Id", "CountyName", cityEntry.CoutEntryId);
            return View(cityEntry);
        }

        [HttpGet]
        public JsonResult IsCityExist(CityEntry city)
        {
            return Json(!db.CityEntries.Any(m => m.CityName.Trim() == city.CityName.Trim()), JsonRequestBehavior.AllowGet);

        }

        // GET: CityEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityEntry cityEntry = db.CityEntries.Find(id);
            if (cityEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoutEntryId = new SelectList(db.CountryEntries, "Id", "CountyName", cityEntry.CoutEntryId);
            return View(cityEntry);
        }

        // POST: CityEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CityName,About,NoOfDweller,Location,Weather,CoutEntryId")] CityEntry cityEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoutEntryId = new SelectList(db.CountryEntries, "Id", "CountyName", cityEntry.CoutEntryId);
            return View(cityEntry);
        }

        // GET: CityEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityEntry cityEntry = db.CityEntries.Find(id);
            if (cityEntry == null)
            {
                return HttpNotFound();
            }
            return View(cityEntry);
        }

        // POST: CityEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityEntry cityEntry = db.CityEntries.Find(id);
            db.CityEntries.Remove(cityEntry);
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
