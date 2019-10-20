using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDG_Education.Models;
using SDG_Education.Models.Core;

namespace SDG_Education.Controllers
{
    public class SponsorTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SponsorTypes
        public ActionResult Index()
        {
            var sponsorTypes = db.SponsorTypes.ToList();
            return View(sponsorTypes);
        }

        // GET: SponsorTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var sponsorType = db.SponsorTypes.SingleOrDefault(s=>s.Id==id);
              
                if (sponsorType == null)
                {
                    return HttpNotFound();
                }

                return View(sponsorType);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: SponsorTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SponsorTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SponsorType sponsorType)
        {
            if (ModelState.IsValid)
            {
                db.SponsorTypes.Add(sponsorType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sponsorType);
        }

        // GET: SponsorTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorType sponsorType = db.SponsorTypes.SingleOrDefault(st=>st.Id==id);
            if (sponsorType == null)
            {
                return HttpNotFound();
            }
            return View(sponsorType);
        }

        // POST: SponsorTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SponsorType sponsorType)
        {
            if (ModelState.IsValid)
            {
                var sponsorTypeInDb = db.SponsorTypes.Single(st => st.Id == sponsorType.Id);
                sponsorTypeInDb.Name = sponsorType.Name;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsorType);
        }

        // GET: SponsorTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorType sponsorType = db.SponsorTypes.SingleOrDefault(st => st.Id == id);
            if (sponsorType == null)
            {
                return HttpNotFound();
            }
            return View(sponsorType);
        }

        // POST: SponsorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SponsorType sponsorType = db.SponsorTypes.Find(id);
            db.SponsorTypes.Remove(sponsorType);
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
