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
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyTeam()
        {
            var currentUserName = User.Identity.GetUserName();
            var allPlayers = _context.Players.ToList();
            var user = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var userTeam = _context.Teams.FirstOrDefault(m => m.Id == user.TeamId);
            var viewModel = new DashboardViewModels.MyTeamViewModel
            {
                CurrentUser = user,
                Team = userTeam,
                Players = allPlayers
            };
            return View(viewModel);
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