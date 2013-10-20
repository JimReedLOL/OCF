    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCFInventory.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Virtual Sticker Booth";

            return View();
        }

       

        public ActionResult Contact()
        {
            ViewBag.Message = "Support using Virtual Sticker Booth";

            return View();
        }
    }
}
