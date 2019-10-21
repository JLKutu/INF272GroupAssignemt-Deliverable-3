using System.Linq;
using System.Web.Mvc;
using GroupProjectDonation272.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GroupProjectDonation272.Controllers.Operation
{
    public class RolesController : Controller
    {
        // GET: Roles
        ApplicationDbContext _context;
        public RolesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Roles
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}