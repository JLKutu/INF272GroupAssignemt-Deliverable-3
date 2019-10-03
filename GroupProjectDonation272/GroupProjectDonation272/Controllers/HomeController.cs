using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProjectDonation272.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult HowToDonate()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Navigation()
        {
            

            return View();
        }
        public ActionResult Contact()
        {


            return View();
        }

    }
}