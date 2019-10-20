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
    public class OfferDonationDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferDonationDetails
        public ActionResult Index()
        {
            var offerDonationDetails = db.OfferDonationDetails.Include(o => o.Book).Include(o => o.OfferDonation).Include(o => o.Stationary);
            return View(offerDonationDetails.ToList());
        }

        // GET: OfferDonationDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonationDetail offerDonationDetail = db.OfferDonationDetails.Find(id);
            if (offerDonationDetail == null)
            {
                return HttpNotFound();
            }
            return View(offerDonationDetail);
        }

        // GET: OfferDonationDetails/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title");
            ViewBag.OfferDonationId = new SelectList(db.OfferDonations, "Id", "OfferDonationReference");
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name");
            return View();
        }

        // POST: OfferDonationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsDeleted,Quantity,StationaryId,BookId,OfferDonationId")] OfferDonationDetail offerDonationDetail)
        {
            if (ModelState.IsValid)
            {
                db.OfferDonationDetails.Add(offerDonationDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", offerDonationDetail.BookId);
            ViewBag.OfferDonationId = new SelectList(db.OfferDonations, "Id", "OfferDonationReference", offerDonationDetail.OfferDonationId);
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name", offerDonationDetail.StationaryId);
            return View(offerDonationDetail);
        }

        // GET: OfferDonationDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonationDetail offerDonationDetail = db.OfferDonationDetails.Find(id);
            if (offerDonationDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", offerDonationDetail.BookId);
            ViewBag.OfferDonationId = new SelectList(db.OfferDonations, "Id", "OfferDonationReference", offerDonationDetail.OfferDonationId);
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name", offerDonationDetail.StationaryId);
            return View(offerDonationDetail);
        }

        // POST: OfferDonationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsDeleted,Quantity,StationaryId,BookId,OfferDonationId")] OfferDonationDetail offerDonationDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerDonationDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", offerDonationDetail.BookId);
            ViewBag.OfferDonationId = new SelectList(db.OfferDonations, "Id", "OfferDonationReference", offerDonationDetail.OfferDonationId);
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name", offerDonationDetail.StationaryId);
            return View(offerDonationDetail);
        }

        // GET: OfferDonationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonationDetail offerDonationDetail = db.OfferDonationDetails.Find(id);
            if (offerDonationDetail == null)
            {
                return HttpNotFound();
            }
            return View(offerDonationDetail);
        }

        // POST: OfferDonationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferDonationDetail offerDonationDetail = db.OfferDonationDetails.Find(id);
            db.OfferDonationDetails.Remove(offerDonationDetail);
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
