using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sabr.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyTeam()
        {
            return View();
        }

        public ActionResult League()
        {
            return View();
        }

        public ActionResult Historical()
        {
            return View();
        }
    }
}