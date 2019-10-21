using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using GroupProjectDonation272.Models.Core;

namespace GroupProjectDonation272.Controllers
{
    public class CentersController : Controller
    {

        private ApplicationDbContext _db = new ApplicationDbContext();
        private bool _status;
        private int _start;
        private int _id;


        // GET: Centers
        public ActionResult Index()
        {
            var centers = _db.Centers.Include(c => c.CenterType);
            return View(centers.ToList());
        }

        // GET: Centers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = _db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // GET: Centers/Create
        public ActionResult Create()
        {
            ViewBag.Code = GenerateAutoCode();
            ViewBag.CenterTypeId = new SelectList(_db.CenterTypes, "Id", "Name");
            return View();
        }

        // POST: Centers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,ContactNo,Address,CenterTypeId")] Center center)
        {
            if (ModelState.IsValid)
            {
                _db.Centers.Add(center);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Code = GenerateAutoCode();
            ViewBag.CenterTypeId = new SelectList(_db.CenterTypes, "Id", "Name", center.CenterTypeId);
            return View(center);
        }

        // GET: Centers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = _db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            ViewBag.Code = GenerateAutoCode();
            ViewBag.CenterTypeId = new SelectList(_db.CenterTypes, "Id", "Name", center.CenterTypeId);
            return View(center);
        }

        // POST: Centers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,ContactNo,Address,CenterTypeId")] Center center)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(center).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CenterTypeId = new SelectList(_db.CenterTypes, "Id", "Name", center.CenterTypeId);
            return View(center);
        }

        // GET: Centers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = _db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // POST: Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Center center = _db.Centers.Find(id);
            _db.Centers.Remove(center);
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

                autoCode = "CenterNo:" + (_start + 1).ToString("000");
            }
            autoCode = "CenterNo" + (_start + 1).ToString("000");

            return autoCode;
        }
    }
}
