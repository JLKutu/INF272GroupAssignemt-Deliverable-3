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
    public class CenterTypesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: CenterTypes
        public ActionResult Index()
        {
            var centerTypes = _db.CenterTypes.ToList();
            return View(centerTypes);
        }

        // GET: CenterTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterType centerType = _db.CenterTypes.Find(id);
            if (centerType == null)
            {
                return HttpNotFound();
            }
            return View(centerType);
        }

        // GET: CenterTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CenterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CenterType centerType)
        {
            if (ModelState.IsValid)
            {
                _db.CenterTypes.Add(centerType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerType);
        }

        // GET: CenterTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var centerType = _db.CenterTypes.Find(id);
            if (centerType == null)
            {
                return HttpNotFound();
            }
            return View(centerType);
        }

        // POST: CenterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CenterType centerType)
        {
            if (ModelState.IsValid)
            {
                var centerTypeInDb = _db.CenterTypes.Single(ct => ct.Id == centerType.Id);
                centerTypeInDb.Name = centerType.Name;
                centerTypeInDb.Description = centerType.Description;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerType);
        }

        // GET: CenterTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterType centerType = _db.CenterTypes.Find(id);
            if (centerType == null)
            {
                return HttpNotFound();
            }
            return View(centerType);
        }

        // POST: CenterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CenterType centerType = _db.CenterTypes.Find(id);
            _db.CenterTypes.Remove(centerType);
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
