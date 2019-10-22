using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core;
using GroupProjectDonation272.ViewModels;

namespace GroupProjectDonation272.Controllers
{
    public class StationariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stationaries
        public ActionResult Index()
        {
            var stationaries = db.Stationaries.Include(s => s.StationaryType).ToList();
            return View(stationaries);
        }

        // GET: Stationaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var stationary = db.Stationaries.SingleOrDefault(s => s.Id == id);
            if (stationary == null)
            {
                return HttpNotFound();
            }
            return View(stationary);
        }

        // GET: Stationaries/Create
        public ActionResult Create()
        {
            //ViewBag.StationaryTypeId = new SelectList(db.StationaryTypes, "Id", "Name");

            var stationaryTypes = db.StationaryTypes.ToList();
            var viewModel = new StationaryViewModel
            {
                StationaryTypes = stationaryTypes
            };
            return View(viewModel);
        }

        // POST: Stationaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stationary stationary)
        {
            //[Bind(Include = "Id,Name,StationaryTypeId")]
            if (ModelState.IsValid)
            {
              
                db.Stationaries.Add(stationary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

         

            var stationaryTypes = db.StationaryTypes.ToList();
            var viewModel = new StationaryViewModel
            {
                StationaryTypes = stationaryTypes
            };
            return View(viewModel);
        }

        // GET: Stationaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var stationary = db.Stationaries.Find(id);
                if (stationary == null)
                {
                    return HttpNotFound();
                }
              

                var stationaryTypes = db.StationaryTypes.ToList();
                var viewModel = new StationaryViewModel
                {
                    Stationary = stationary,
                    StationaryTypes = stationaryTypes
                };
                return View(viewModel);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Stationaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Stationary stationary)
        {
            if (ModelState.IsValid)
            {
                var stationaryInDb = db.Stationaries.Single(s => s.Id == stationary.Id);

                stationaryInDb.Name = stationary.Name;
                stationaryInDb.StationaryTypeId = stationary.StationaryTypeId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var stationaryTypes = db.StationaryTypes.ToList();
            var viewModel = new StationaryViewModel
            {
                Stationary = stationary,
                StationaryTypes = stationaryTypes
            };
            return View(viewModel);
        }

        // GET: Stationaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stationary stationary = db.Stationaries.Find(id);
            if (stationary == null)
            {
                return HttpNotFound();
            }
            return View(stationary);
        }

        // POST: Stationaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stationary stationary = db.Stationaries.Find(id);
            db.Stationaries.Remove(stationary);
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
