using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupProjectDonation272.Models;

namespace GroupProjectDonation272.Controllers
{
    public class StationariesController : Controller
    {
        private DonationFinalEntities db = new DonationFinalEntities();

        // GET: Stationaries
        public ActionResult Index()
        {
            var stationaries = db.Stationaries.Include(s => s.Donation).Include(s => s.SponsorType);
            return View(stationaries.ToList());
        }

        // GET: Stationaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stationary stationary = db.Stationaries.Find(id);
            if (stationary == null)
            {
                return HttpNotFound();
            }
            return View(stationary);
        }

        // GET: Stationaries/Create
        public ActionResult Create()
        {
            ViewBag.StationaryID = new SelectList(db.Donations, "DonationID", "DonationName");
            ViewBag.StationaryID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription");
            return View();
        }

        // POST: Stationaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationaryID,StationaryDescription,Quantity")] Stationary stationary)
        {
            if (ModelState.IsValid)
            {
                db.Stationaries.Add(stationary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StationaryID = new SelectList(db.Donations, "DonationID", "DonationName", stationary.StationaryID);
            ViewBag.StationaryID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription", stationary.StationaryID);
            return View(stationary);
        }

        // GET: Stationaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stationary stationary = db.Stationaries.Find(id);
            if (stationary == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationaryID = new SelectList(db.Donations, "DonationID", "DonationName", stationary.StationaryID);
            ViewBag.StationaryID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription", stationary.StationaryID);
            return View(stationary);
        }

        // POST: Stationaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationaryID,StationaryDescription,Quantity")] Stationary stationary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationaryID = new SelectList(db.Donations, "DonationID", "DonationName", stationary.StationaryID);
            ViewBag.StationaryID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription", stationary.StationaryID);
            return View(stationary);
        }

        // GET: Stationaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stationary stationary = db.Stationaries.Find(id);
            if (stationary == null)
            {
                return HttpNotFound();
            }
            return View(stationary);
        }

        // POST: Stationaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stationary stationary = db.Stationaries.Find(id);
            db.Stationaries.Remove(stationary);
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
