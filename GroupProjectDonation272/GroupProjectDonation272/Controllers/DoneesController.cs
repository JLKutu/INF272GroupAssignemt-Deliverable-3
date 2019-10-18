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
    public class DoneesController : Controller
    {
        private DonationFinalEntities db = new DonationFinalEntities();

        // GET: Donees
        public ActionResult Index()
        {
            var donees = db.Donees.Include(d => d.Donation);
            var donees=db.Donees.OrderByDesceding(d=>d.Doation);
            var donees=db.Donee.OrderBy(d=>d.DonationID);
            return View(donees.ToList());
        }

        // GET: Donees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donee donee = db.Donees.Find(id);
            if (donee == null)
            {
                return HttpNotFound();
            }
            return View(donee);
        }

        // GET: Donees/Create
        public ActionResult Create()
        {
            ViewBag.DoneeID = new SelectList(db.Donations, "DonationID", "DonationName");
            return View();
        }

        // POST: Donees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoneeID,Name,PhysicalAddress,ContactNumber")] Donee donee)
        {
            if (ModelState.IsValid)
            {
                db.Donees.Add(donee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoneeID = new SelectList(db.Donations, "DonationID", "DonationName", donee.DoneeID);
            return View(donee);
        }

        // GET: Donees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donee donee = db.Donees.Find(id);
            if (donee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoneeID = new SelectList(db.Donations, "DonationID", "DonationName", donee.DoneeID);
            return View(donee);
        }

        // POST: Donees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoneeID,Name,PhysicalAddress,ContactNumber")] Donee donee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoneeID = new SelectList(db.Donations, "DonationID", "DonationName", donee.DoneeID);
            return View(donee);
        }

        // GET: Donees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donee donee = db.Donees.Find(id);
            if (donee == null)
            {
                return HttpNotFound();
            }
            return View(donee);
        }

        // POST: Donees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donee donee = db.Donees.Find(id);
            db.Donees.Remove(donee);
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
