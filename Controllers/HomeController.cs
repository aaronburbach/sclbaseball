using SclBaseball.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SclBaseball.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Schedule", "Game");
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            //return View();
            return RedirectToAction("Schedule", "Game");
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            //return View();
            return RedirectToAction("Schedule", "Game");
        }
    }
}