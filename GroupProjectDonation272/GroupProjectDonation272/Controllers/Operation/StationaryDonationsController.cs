using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core.Operations;

namespace GroupProjectDonation272.Controllers.Operation
{
    public class StationaryDonationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StationaryDonations
        public ActionResult Index()
        {
            var stationaryDonations = db.StationaryDonations.Include(s => s.Center).Include(s => s.Sponsor).Include(s => s.StationaryType);
            return View(stationaryDonations.ToList());
        }

        // GET: StationaryDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationaryDonation stationaryDonation = db.StationaryDonations.Find(id);
            if (stationaryDonation == null)
            {
                return HttpNotFound();
            }
            return View(stationaryDonation);
        }

        // GET: StationaryDonations/Create
        public ActionResult Create()
        {
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name");
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name");
            ViewBag.StationaryTypeId = new SelectList(db.StationaryTypes, "Id", "Name");
            return View();
        }

        // POST: StationaryDonations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,Description,StationaryTypeId,CenterId,SponsorId")] StationaryDonation stationaryDonation)
        {
            if (ModelState.IsValid)
            {
                db.StationaryDonations.Add(stationaryDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", stationaryDonation.CenterId);
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name", stationaryDonation.SponsorId);
            ViewBag.StationaryTypeId = new SelectList(db.StationaryTypes, "Id", "Name", stationaryDonation.StationaryTypeId);
            return View(stationaryDonation);
        }

        // GET: StationaryDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationaryDonation stationaryDonation = db.StationaryDonations.Find(id);
            if (stationaryDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", stationaryDonation.CenterId);
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name", stationaryDonation.SponsorId);
            ViewBag.StationaryTypeId = new SelectList(db.StationaryTypes, "Id", "Name", stationaryDonation.StationaryTypeId);
            return View(stationaryDonation);
        }

        // POST: StationaryDonations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,Description,StationaryTypeId,CenterId,SponsorId")] StationaryDonation stationaryDonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationaryDonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", stationaryDonation.CenterId);
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name", stationaryDonation.SponsorId);
            ViewBag.StationaryTypeId = new SelectList(db.StationaryTypes, "Id", "Name", stationaryDonation.StationaryTypeId);
            return View(stationaryDonation);
        }

        // GET: StationaryDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationaryDonation stationaryDonation = db.StationaryDonations.Find(id);
            if (stationaryDonation == null)
            {
                return HttpNotFound();
            }
            return View(stationaryDonation);
        }

        // POST: StationaryDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationaryDonation stationaryDonation = db.StationaryDonations.Find(id);
            db.StationaryDonations.Remove(stationaryDonation);
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
