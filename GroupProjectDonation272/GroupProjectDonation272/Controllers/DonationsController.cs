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
    public class DonationsController : Controller
    {
        private DonationFinalEntities db = new DonationFinalEntities();

        // GET: Donations
        public ActionResult Index()
        {
            var donations = db.Donations.Include(d => d.Book).Include(d => d.Donee).Include(d => d.Employee).Include(d => d.Stationary);
            return View(donations.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.DonationID = new SelectList(db.Books, "BookID", "BookTitle");
            ViewBag.DonationID = new SelectList(db.Donees, "DoneeID", "Name");
            ViewBag.DonationID = new SelectList(db.Employees, "EmployeeID", "Name");
            ViewBag.DonationID = new SelectList(db.Stationaries, "StationaryID", "StationaryDescription");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,DonationName")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonationID = new SelectList(db.Books, "BookID", "BookTitle", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Donees, "DoneeID", "Name", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Employees, "EmployeeID", "Name", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Stationaries, "StationaryID", "StationaryDescription", donation.DonationID);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonationID = new SelectList(db.Books, "BookID", "BookTitle", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Donees, "DoneeID", "Name", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Employees, "EmployeeID", "Name", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Stationaries, "StationaryID", "StationaryDescription", donation.DonationID);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,DonationName")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonationID = new SelectList(db.Books, "BookID", "BookTitle", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Donees, "DoneeID", "Name", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Employees, "EmployeeID", "Name", donation.DonationID);
            ViewBag.DonationID = new SelectList(db.Stationaries, "StationaryID", "StationaryDescription", donation.DonationID);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
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
