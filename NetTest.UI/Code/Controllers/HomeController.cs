using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetTest.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/content/app/home/index.cshtml");
        }
    }
}