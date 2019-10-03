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
    public class SponsorsController : Controller
    {
        private DonationFinalEntities db = new DonationFinalEntities();

        // GET: Sponsors
        public ActionResult Index()
        {
            var sponsors = db.Sponsors.Include(s => s.Employee).Include(s => s.SponsorType);
            return View(sponsors.ToList());
        }

        // GET: Sponsors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // GET: Sponsors/Create
        public ActionResult Create()
        {
            ViewBag.SponsorID = new SelectList(db.Employees, "EmployeeID", "Name");
            ViewBag.SponsorID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription");
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SponsorID,Name,Surname,EmailAddress,PhysicalAddress,ContactNumber,DateOfDelivery")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Sponsors.Add(sponsor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SponsorID = new SelectList(db.Employees, "EmployeeID", "Name", sponsor.SponsorID);
            ViewBag.SponsorID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription", sponsor.SponsorID);
            return View(sponsor);
        }

        // GET: Sponsors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            ViewBag.SponsorID = new SelectList(db.Employees, "EmployeeID", "Name", sponsor.SponsorID);
            ViewBag.SponsorID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription", sponsor.SponsorID);
            return View(sponsor);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SponsorID,Name,Surname,EmailAddress,PhysicalAddress,ContactNumber,DateOfDelivery")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SponsorID = new SelectList(db.Employees, "EmployeeID", "Name", sponsor.SponsorID);
            ViewBag.SponsorID = new SelectList(db.SponsorTypes, "SponsorTypeID", "SponsorTypeDescription", sponsor.SponsorID);
            return View(sponsor);
        }

        // GET: Sponsors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            db.Sponsors.Remove(sponsor);
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
