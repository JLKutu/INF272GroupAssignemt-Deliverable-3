using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core.Operations;

namespace GroupProjectDonation272.Controllers.Operation
{
    public class OfferStationariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferStationaries
        public ActionResult Index()
        {
            var offerStationaries = db.OfferStationaries.Include(o => o.Center).Include(o => o.Donee).Include(o => o.Employee).Include(o => o.StationaryDonation);
            return View(offerStationaries.ToList());
        }

        // GET: OfferStationaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferStationary offerStationary = db.OfferStationaries.Find(id);
            if (offerStationary == null)
            {
                return HttpNotFound();
            }
            return View(offerStationary);
        }

        // GET: OfferStationaries/Create
        public ActionResult Create()
        {
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name");
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.StationaryDonationId = new SelectList(db.StationaryDonations, "Id", "Description");
            return View();
        }

        // POST: OfferStationaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonationDate,CenterId,EmployeeId,StationaryDonationId,DoneeId")] OfferStationary offerStationary)
        {
            if (ModelState.IsValid)
            {
                db.OfferStationaries.Add(offerStationary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerStationary.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerStationary.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerStationary.EmployeeId);
            ViewBag.StationaryDonationId = new SelectList(db.StationaryDonations, "Id", "Description", offerStationary.StationaryDonationId);
            return View(offerStationary);
        }

        // GET: OfferStationaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferStationary offerStationary = db.OfferStationaries.Find(id);
            if (offerStationary == null)
            {
                return HttpNotFound();
            }
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerStationary.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerStationary.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerStationary.EmployeeId);
            ViewBag.StationaryDonationId = new SelectList(db.StationaryDonations, "Id", "Description", offerStationary.StationaryDonationId);
            return View(offerStationary);
        }

        // POST: OfferStationaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonationDate,CenterId,EmployeeId,StationaryDonationId,DoneeId")] OfferStationary offerStationary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerStationary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerStationary.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerStationary.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerStationary.EmployeeId);
            ViewBag.StationaryDonationId = new SelectList(db.StationaryDonations, "Id", "Description", offerStationary.StationaryDonationId);
            return View(offerStationary);
        }

        // GET: OfferStationaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferStationary offerStationary = db.OfferStationaries.Find(id);
            if (offerStationary == null)
            {
                return HttpNotFound();
            }
            return View(offerStationary);
        }

        // POST: OfferStationaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferStationary offerStationary = db.OfferStationaries.Find(id);
            db.OfferStationaries.Remove(offerStationary);
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
