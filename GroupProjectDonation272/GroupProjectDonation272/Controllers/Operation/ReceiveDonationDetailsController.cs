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
    public class ReceiveDonationDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReceiveDonationDetails
        public ActionResult Index()
        {
            var receiveDonationDetails = db.ReceiveDonationDetails.Include(r => r.Book).Include(r => r.ReceiveDonation).Include(r => r.Stationary);
            return View(receiveDonationDetails.ToList());
        }

        // GET: ReceiveDonationDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveDonationDetail receiveDonationDetail = db.ReceiveDonationDetails.Find(id);
            if (receiveDonationDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiveDonationDetail);
        }

        // GET: ReceiveDonationDetails/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title");
            ViewBag.ReceiveDonationId = new SelectList(db.ReceiveDonations, "Id", "ReceiveDonationReference");
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name");
            return View();
        }

        // POST: ReceiveDonationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReceiveDonationDetail receiveDonationDetail)
        {
            receiveDonationDetail.IsDeleted = false;
            if (ModelState.IsValid)
            {
                db.ReceiveDonationDetails.Add(receiveDonationDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", receiveDonationDetail.BookId);
            ViewBag.ReceiveDonationId = new SelectList(db.ReceiveDonations, "Id", "ReceiveDonationReference", receiveDonationDetail.ReceiveDonationId);
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name", receiveDonationDetail.StationaryId);
            return View(receiveDonationDetail);
        }

        // GET: ReceiveDonationDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveDonationDetail receiveDonationDetail = db.ReceiveDonationDetails.Find(id);
            if (receiveDonationDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", receiveDonationDetail.BookId);
            ViewBag.ReceiveDonationId = new SelectList(db.ReceiveDonations, "Id", "ReceiveDonationReference", receiveDonationDetail.ReceiveDonationId);
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name", receiveDonationDetail.StationaryId);
            return View(receiveDonationDetail);
        }

        // POST: ReceiveDonationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsDeleted,Quantity,StationaryId,BookId,ReceiveDonationId")] ReceiveDonationDetail receiveDonationDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiveDonationDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", receiveDonationDetail.BookId);
            ViewBag.ReceiveDonationId = new SelectList(db.ReceiveDonations, "Id", "ReceiveDonationReference", receiveDonationDetail.ReceiveDonationId);
            ViewBag.StationaryId = new SelectList(db.Stationaries, "Id", "Name", receiveDonationDetail.StationaryId);
            return View(receiveDonationDetail);
        }

        // GET: ReceiveDonationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveDonationDetail receiveDonationDetail = db.ReceiveDonationDetails.Find(id);
            if (receiveDonationDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiveDonationDetail);
        }

        // POST: ReceiveDonationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiveDonationDetail receiveDonationDetail = db.ReceiveDonationDetails.Find(id);
            db.ReceiveDonationDetails.Remove(receiveDonationDetail);
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
