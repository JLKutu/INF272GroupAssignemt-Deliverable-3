using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core.Operations;

namespace GroupProjectDonation272.Controllers.Operation
{
    public class OfferBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferBooks
        public ActionResult Index()
        {
            var offerBooks = db.OfferBooks.Include(o => o.BookDonation).Include(o => o.Center).Include(o => o.Donee).Include(o => o.Employee);
            return View(offerBooks.ToList());
        }

        // GET: OfferBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferBook offerBook = db.OfferBooks.Find(id);
            if (offerBook == null)
            {
                return HttpNotFound();
            }
            return View(offerBook);
        }

        // GET: OfferBooks/Create
        public ActionResult Create()
        {
            ViewBag.BookDonationId = new SelectList(db.BookDonations, "Id", "BookTitle");
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name");
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            return View();
        }

        // POST: OfferBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonationDate,CenterId,EmployeeId,BookDonationId,DoneeId")] OfferBook offerBook)
        {
            if (ModelState.IsValid)
            {
                db.OfferBooks.Add(offerBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookDonationId = new SelectList(db.BookDonations, "Id", "BookTitle", offerBook.BookDonationId);
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerBook.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerBook.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerBook.EmployeeId);
            return View(offerBook);
        }

        // GET: OfferBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferBook offerBook = db.OfferBooks.Find(id);
            if (offerBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookDonationId = new SelectList(db.BookDonations, "Id", "BookTitle", offerBook.BookDonationId);
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerBook.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerBook.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerBook.EmployeeId);
            return View(offerBook);
        }

        // POST: OfferBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonationDate,CenterId,EmployeeId,BookDonationId,DoneeId")] OfferBook offerBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookDonationId = new SelectList(db.BookDonations, "Id", "BookTitle", offerBook.BookDonationId);
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", offerBook.CenterId);
            ViewBag.DoneeId = new SelectList(db.Donees, "Id", "Name", offerBook.DoneeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", offerBook.EmployeeId);
            return View(offerBook);
        }

        // GET: OfferBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferBook offerBook = db.OfferBooks.Find(id);
            if (offerBook == null)
            {
                return HttpNotFound();
            }
            return View(offerBook);
        }

        // POST: OfferBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferBook offerBook = db.OfferBooks.Find(id);
            db.OfferBooks.Remove(offerBook);
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
