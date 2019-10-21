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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private bool _status;
        private int _start;
        private int _id;

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _db.Employees.Include(e => e.Center);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Code = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Code,ContactNo,Address,CenterId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Code = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", employee.CenterId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", employee.CenterId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Code,ContactNo,Address,CenterId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Code = GenerateAutoCode();
            ViewBag.CenterId = new SelectList(_db.Centers, "Id", "Name", employee.CenterId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
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
            Employee employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
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

                autoCode = "Emp" + (_start + 1).ToString("000");
            }
            autoCode = "Emp" + (_start + 1).ToString("000");

            return autoCode;
        }

    }
}
