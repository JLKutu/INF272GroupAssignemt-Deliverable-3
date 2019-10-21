using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core.Operations;

namespace GroupProjectDonation272.Controllers.Operation
{
    public class OfferDonationsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private bool _status;
        private int _start;
        private int _id;


        // GET: OfferDonations
        public ActionResult Index()
        {
            var offerDonations = _db.OfferDonations.Include(o => o.Center).Include(o => o.Donee).Include(o => o.Employee);
            return View(offerDonations.ToList());
        }

        // GET: OfferDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonation offerDonation = _db.OfferDonations.Find(id);
            if (offerDonation == null)
            {
                return HttpNotFound();
            }
            return View(offerDonation);
        }

        // GET: OfferDonations/Create
        public ActionResult Create()
        {
            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name");
            ViewBag.DoneeId = new SelectList(_db.Donees, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name");
            return View();
        }

        // POST: OfferDonations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferDonation offerDonation)
        {
            //[Bind(Include = "Id,IsDeleted,OfferDonationReference,DonationDate,CenterId,EmployeeId,DoneeId")] 
            offerDonation.IsDeleted = false;
           
            if (ModelState.IsValid)
            {
                _db.OfferDonations.Add(offerDonation);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", offerDonation.CenterId);
            ViewBag.DoneeId = new SelectList(_db.Donees, "Id", "Name", offerDonation.DoneeId);
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name", offerDonation.EmployeeId);
            return View(offerDonation);
        }

        // GET: OfferDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonation offerDonation = _db.OfferDonations.Find(id);
            if (offerDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", offerDonation.CenterId);
            ViewBag.DoneeId = new SelectList(_db.Donees, "Id", "Name", offerDonation.DoneeId);
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name", offerDonation.EmployeeId);
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
                _db.Entry(offerDonation).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", offerDonation.CenterId);
            ViewBag.DoneeId = new SelectList(_db.Donees, "Id", "Name", offerDonation.DoneeId);
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name", offerDonation.EmployeeId);
            return View(offerDonation);
        }

        // GET: OfferDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDonation offerDonation = _db.OfferDonations.Find(id);
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
            OfferDonation offerDonation = _db.OfferDonations.Find(id);
            _db.OfferDonations.Remove(offerDonation);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GenerateAutoCode()
        {
            var autoCode = "";
            var lastCode = _db.OfferDonations.Max(item => item.OfferDonationReference);

            if (lastCode != null)
            {
                var resultString = Regex.Match(lastCode, @"\d+").Value;
                _start = Int32.Parse(resultString);

                autoCode = "OfferNo" + (_start + 1).ToString("000");
            }
            autoCode = "OfferNo" + (_start + 1).ToString("000");

            return autoCode;
        }


       


    }
}
