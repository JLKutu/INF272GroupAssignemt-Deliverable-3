using System.Linq;
using System.Net;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core;
using GroupProjectDonation272.ViewModels;

namespace GroupProjectDonation272.Controllers
{
    public class BookTypesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: BookTypes
        public ActionResult Index()
        {
            var bookTypes = _db.BookTypes.ToList();
            return View(bookTypes);
        }

        // GET: BookTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bookType = _db.BookTypes.SingleOrDefault(bt => bt.Id == id);
            

            if (bookType == null)
            {
                return HttpNotFound();
            }

            var books = _db.Books.Where(book=> book.BookTypeId == bookType.Id).ToList();
            

            var detailsBookTypeViewModel = new DetailsBookTypeViewModel
            {
                BookType = bookType,
                Book = new Book(),
                Books = books
            };

            return View("Details", detailsBookTypeViewModel);
        }

        // GET: BookTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _db.BookTypes.Add(bookType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookType);
        }

        // GET: BookTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bookType = _db.BookTypes.SingleOrDefault(bt=>bt.Id == id);
            if (bookType == null)
            {
                return HttpNotFound();
            }
            return View(bookType);
        }

        // POST: BookTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //For changing the scaffolded  code, more details see https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#update-httppost-edit-method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                var bookTypeInDb = _db.BookTypes.Single(bt => bt.Id == bookType.Id);

                bookTypeInDb.Name = bookType.Name;
                bookTypeInDb.Description = bookType.Description;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookType);
        }

        // GET: BookTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bookType = _db.BookTypes.Find(id);
            if (bookType == null)
            {
                return HttpNotFound();
            }
            return View(bookType);
        }

        // POST: BookTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bookType = _db.BookTypes.Find(id);
            _db.BookTypes.Remove(bookType);
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
    }
}
