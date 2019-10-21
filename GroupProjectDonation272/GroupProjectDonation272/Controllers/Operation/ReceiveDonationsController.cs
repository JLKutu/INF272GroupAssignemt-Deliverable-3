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
    public class ReceiveDonationsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private bool _status;
        private int _start;
        private int _id;

        // GET: ReceiveDonations
        public ActionResult Index()
        {
            var receiveDonations = _db.ReceiveDonations.Include(r => r.Center).Include(r => r.Employee).Include(r => r.Sponsor);
            return View(receiveDonations.ToList());
        }

        // GET: ReceiveDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveDonation receiveDonation = _db.ReceiveDonations.Find(id);
            if (receiveDonation == null)
            {
                return HttpNotFound();
            }
            return View(receiveDonation);
        }

        // GET: ReceiveDonations/Create
        public ActionResult Create()
        {
            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name");
            ViewBag.SponsorId = new SelectList(_db.Sponsors, "Id", "Name");
            return View();
        }

        // POST: ReceiveDonations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ReceiveDonation receiveDonation)
        {
            receiveDonation.IsDeleted = false;
            if (ModelState.IsValid)
            {
                _db.ReceiveDonations.Add(receiveDonation);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", receiveDonation.CenterId);
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name", receiveDonation.EmployeeId);
            ViewBag.SponsorId = new SelectList(_db.Sponsors, "Id", "Name", receiveDonation.SponsorId);
            return View(receiveDonation);
        }

        // GET: ReceiveDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveDonation receiveDonation = _db.ReceiveDonations.Find(id);
            if (receiveDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", receiveDonation.CenterId);
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name", receiveDonation.EmployeeId);
            ViewBag.SponsorId = new SelectList(_db.Sponsors, "Id", "Name", receiveDonation.SponsorId);
            return View(receiveDonation);
        }

        // POST: ReceiveDonations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ReceiveDonation receiveDonation)
        {
            receiveDonation.IsDeleted = false;
            //[Bind(Include = "Id,IsDeleted,ReceiveDonationReference,DonationDate,Remarks,CenterId,EmployeeId,SponsorId")]
            if (ModelState.IsValid)
            {
                _db.Entry(receiveDonation).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Reference = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", receiveDonation.CenterId);
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Name", receiveDonation.EmployeeId);
            ViewBag.SponsorId = new SelectList(_db.Sponsors, "Id", "Name", receiveDonation.SponsorId);
            return View(receiveDonation);
        }

        // GET: ReceiveDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveDonation receiveDonation = _db.ReceiveDonations.Find(id);
            if (receiveDonation == null)
            {
                return HttpNotFound();
            }
            return View(receiveDonation);
        }

        // POST: ReceiveDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiveDonation receiveDonation = _db.ReceiveDonations.Find(id);
            _db.ReceiveDonations.Remove(receiveDonation);
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
            var lastCode = _db.ReceiveDonations.Max(item => item.ReceiveDonationReference);

            if (lastCode != null)
            {
                var resultString = Regex.Match(lastCode, @"\d+").Value;
                _start = Int32.Parse(resultString);

                autoCode = "ReceiveNo" + (_start + 1).ToString("000");
            }
            autoCode = "ReceiveNo" + (_start + 1).ToString("000");

            return autoCode;
        }
    }
}
