using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupProjectDonation272.Models;

namespace GroupProjectDonation272.Controllers
{
    public class EmployeesController : Controller
    {
        private DonationFinalEntities db = new DonationFinalEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Donation).Include(e => e.Sponsor).Include(e => e.User);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Donations, "DonationID", "DonationName");
            ViewBag.EmployeeID = new SelectList(db.Sponsors, "SponsorID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Users, "UserID", "Username");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,Surname,EmailAddress,PhysicalAddress,ContactNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Donations, "DonationID", "DonationName", employee.EmployeeID);
            ViewBag.EmployeeID = new SelectList(db.Sponsors, "SponsorID", "Name", employee.EmployeeID);
            ViewBag.EmployeeID = new SelectList(db.Users, "UserID", "Username", employee.EmployeeID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Donations, "DonationID", "DonationName", employee.EmployeeID);
            ViewBag.EmployeeID = new SelectList(db.Sponsors, "SponsorID", "Name", employee.EmployeeID);
            ViewBag.EmployeeID = new SelectList(db.Users, "UserID", "Username", employee.EmployeeID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,Surname,EmailAddress,PhysicalAddress,ContactNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Donations, "DonationID", "DonationName", employee.EmployeeID);
            ViewBag.EmployeeID = new SelectList(db.Sponsors, "SponsorID", "Name", employee.EmployeeID);
            ViewBag.EmployeeID = new SelectList(db.Users, "UserID", "Username", employee.EmployeeID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
