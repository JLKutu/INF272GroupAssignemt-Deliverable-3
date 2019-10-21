using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core.Operations;

namespace GroupProjectDonation272.Controllers.Operation
{
    public class BookDonationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookDonations
        public ActionResult Index()
        {
            var bookDonations = db.BookDonations.Include(b => b.BookType).Include(b => b.Center).Include(b => b.Sponsor);
            return View(bookDonations.ToList());
        }

        // GET: BookDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDonation bookDonation = db.BookDonations.Find(id);
            if (bookDonation == null)
            {
                return HttpNotFound();
            }
            return View(bookDonation);
        }

        // GET: BookDonations/Create
        public ActionResult Create()
        {
            ViewBag.BookTypeId = new SelectList(db.BookTypes, "Id", "Name");
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name");
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name");
            return View();
        }

        // POST: BookDonations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookTitle,BookAuthor,BookPublisher,BookPublicationYear,Quantity,BookTypeId,CenterId,SponsorId")] BookDonation bookDonation)
        {
            if (ModelState.IsValid)
            {
                db.BookDonations.Add(bookDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookTypeId = new SelectList(db.BookTypes, "Id", "Name", bookDonation.BookTypeId);
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", bookDonation.CenterId);
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name", bookDonation.SponsorId);
            return View(bookDonation);
        }

        // GET: BookDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDonation bookDonation = db.BookDonations.Find(id);
            if (bookDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookTypeId = new SelectList(db.BookTypes, "Id", "Name", bookDonation.BookTypeId);
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", bookDonation.CenterId);
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name", bookDonation.SponsorId);
            return View(bookDonation);
        }

        // POST: BookDonations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookTitle,BookAuthor,BookPublisher,BookPublicationYear,Quantity,BookTypeId,CenterId,SponsorId")] BookDonation bookDonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookDonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookTypeId = new SelectList(db.BookTypes, "Id", "Name", bookDonation.BookTypeId);
            ViewBag.CenterId = new SelectList(db.Centers, "Id", "Name", bookDonation.CenterId);
            ViewBag.SponsorId = new SelectList(db.Sponsors, "Id", "Name", bookDonation.SponsorId);
            return View(bookDonation);
        }

        // GET: BookDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDonation bookDonation = db.BookDonations.Find(id);
            if (bookDonation == null)
            {
                return HttpNotFound();
            }
            return View(bookDonation);
        }

        // POST: BookDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookDonation bookDonation = db.BookDonations.Find(id);
            db.BookDonations.Remove(bookDonation);
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
