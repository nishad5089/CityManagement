using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CountryCityMangement.Models;

namespace CountryCityMangement.Controllers
{
    public class CountryEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CountryEntries
        

        // GET: CountryEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryEntry countryEntry = db.CountryEntries.Find(id);
            if (countryEntry == null)
            {
                return HttpNotFound();
            }
            return View(countryEntry);
        }

        // GET: CountryEntries/Create
        public ActionResult Create()
        {
            if (TempData["Massage"] != null)
            {
                ViewBag.Massage = TempData["Massage"];
                ViewBag.MassageType = TempData["MassageType"];
            }
            ViewBag.countrys = db.CountryEntries.ToList();
            return View();
        }

        // POST: CountryEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryEntry countryEntry)
        {
            if (ModelState.IsValid)
            {
               

                db.CountryEntries.Add(countryEntry);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["Massage"] = string.Format("( {0} ) Saved", countryEntry.CountyName);
                    TempData["MassageType"] = "success";
                }
                
                return RedirectToAction("Create");
            }

            return View(countryEntry);
        }


        [HttpGet]
        public JsonResult IsCountryExist(CountryEntry country)
        {
            return Json(!db.CountryEntries.Any(m => m.CountyName.Trim() == country.CountyName.Trim()), JsonRequestBehavior.AllowGet);

        }

        // GET: CountryEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryEntry countryEntry = db.CountryEntries.Find(id);
            if (countryEntry == null)
            {
                return HttpNotFound();
            }
            return View(countryEntry);
        }

        // POST: CountryEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CountyName,About")] CountryEntry countryEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryEntry);
        }

        // GET: CountryEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryEntry countryEntry = db.CountryEntries.Find(id);
            if (countryEntry == null)
            {
                return HttpNotFound();
            }
            return View(countryEntry);
        }

        // POST: CountryEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryEntry countryEntry = db.CountryEntries.Find(id);
            db.CountryEntries.Remove(countryEntry);
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

        [HttpGet]
        public ActionResult Serch()
        {
            
            ViewBag.countrys = db.CountryEntries.ToList();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Serch(CountryEntry country)
        {
            ViewBag.countrys = db.CountryEntries.Where(c => c.CountyName.Trim() == country.CountyName.Trim()).ToList();
            TempData["countyName"] = country.CountyName;
            ViewBag.countryName = TempData["countyName"];
            return View("Index");
        }
    }
}
