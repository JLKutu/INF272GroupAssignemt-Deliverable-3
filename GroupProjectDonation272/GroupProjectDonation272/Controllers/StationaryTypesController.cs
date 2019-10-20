using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDG_Education.Models;
using SDG_Education.Models.Core;
using SDG_Education.ViewModels;

namespace SDG_Education.Controllers
{
    public class StationaryTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StationaryTypes
        public ActionResult Index()
        {
            var stationaryTypes = db.StationaryTypes.ToList();
            return View(stationaryTypes);
        }

        // GET: StationaryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stationaryType = db.StationaryTypes.SingleOrDefault(st => st.Id==id);
            var stationaries = db.Stationaries.Where(s => s.StationaryTypeId == stationaryType.Id).ToList();
            if (stationaryType == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DetailsStationaryTypeViewModel
            {
                Stationary = new Stationary(),
                Stationaries = stationaries,
                StationaryType = stationaryType

            };
            return View(viewModel);
        }

        // GET: StationaryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StationaryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StationaryType stationaryType)
        {
            if (ModelState.IsValid)
            {
                db.StationaryTypes.Add(stationaryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stationaryType);
        }

        // GET: StationaryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stationaryType = db.StationaryTypes.SingleOrDefault(st => st.Id == id);
            if (stationaryType == null)
            {
                return HttpNotFound();
            }
            return View(stationaryType);
        }

        // POST: StationaryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StationaryType stationaryType)
        {
            if (ModelState.IsValid)
            {
                var stationaryTypeInDb = db.StationaryTypes.Single(st => st.Id == stationaryType.Id);

                stationaryTypeInDb.Name = stationaryType.Name;
                stationaryTypeInDb.Description = stationaryType.Description;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationaryType);
        }

        // GET: StationaryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var stationaryType = db.StationaryTypes.SingleOrDefault(st => st.Id == id);


                if (stationaryType == null)
                {
                    return HttpNotFound();
                }

                return View(stationaryType);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: StationaryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationaryType stationaryType = db.StationaryTypes.Find(id);
            db.StationaryTypes.Remove(stationaryType);
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
