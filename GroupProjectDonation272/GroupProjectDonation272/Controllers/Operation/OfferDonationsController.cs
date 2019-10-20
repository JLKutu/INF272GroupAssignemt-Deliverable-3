using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDG_Education.Models;
using SDG_Education.Models.Core.Operations;

namespace SDG_Education.Controllers
{
    public class OfferDonationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferDonations
        public ActionResult Index()
        {
            var offerDonations = db.OfferDonations.Include(o => o.Center).Include(o => o.Donee).Include(o => o.Employee);
            return View(offerDonations.ToList());
        }

        // GET: OfferDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonation offerDonation = db.OfferDonations.Find(id);
            if (offerDonation == null)
            {
                return HttpNotFound();
            }
            return View(offerDonation);
        }

        // GET: OfferDonations/Create
        public ActionResult Create()
        {
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name");
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            return View();
        }

        // POST: OfferDonations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsDeleted,OfferDonationReference,DonationDate,CenterId,EmployeeId,DoneeId")] OfferDonation offerDonation)
        {
            if (ModelState.IsValid)
            {
                db.OfferDonations.Add(offerDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerDonation.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerDonation.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerDonation.EmployeeId);
            return View(offerDonation);
        }

        // GET: OfferDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonation offerDonation = db.OfferDonations.Find(id);
            if (offerDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerDonation.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerDonation.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerDonation.EmployeeId);
            return View(offerDonation);
        }

        // POST: OfferDonations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsDeleted,OfferDonationReference,DonationDate,CenterId,EmployeeId,DoneeId")] OfferDonation offerDonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerDonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerDonation.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerDonation.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerDonation.EmployeeId);
            return View(offerDonation);
        }

        // GET: OfferDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonation offerDonation = db.OfferDonations.Find(id);
            if (offerDonation == null)
            {
                return HttpNotFound();
            }
            return View(offerDonation);
        }

        // POST: OfferDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferDonation offerDonation = db.OfferDonations.Find(id);
            db.OfferDonations.Remove(offerDonation);
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
