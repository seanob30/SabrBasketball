using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sabr.Models;
using Sabr.ViewModels;

namespace Sabr.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}