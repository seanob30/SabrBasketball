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
                PlayersList = allPlayers
            };
            return View(viewModel);
        }

        public ActionResult League()
        {
            var currentUserName = User.Identity.GetUserName();
            var user = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var userTeam = _context.Teams.FirstOrDefault(m => m.Id == user.TeamId);
            var allTeams = _context.Teams.ToList();
            List<Team> filteredTeams = new List<Team>();

            foreach (var t in allTeams)
            {
                if (t.Id != userTeam.Id && t.Id != 31)
                {
                    filteredTeams.Add(t);
                }
            }

            var viewModel = new DashboardViewModels.LeagueViewModel
            {
                TeamsList = filteredTeams
            };

            return View(viewModel);
        }

        public ActionResult TeamBio(int id)
        {
            var team = _context.Teams.FirstOrDefault(m => m.Id == id);
            var players = _context.Players.ToList();
            var viewModel = new DashboardViewModels.TeamBioViewModel
            {
                Team = team,
                PlayersList = players
            };
            return View(viewModel);
        }

        public ActionResult PlayerBio(string name)
        {
            var playerStat = _context.PerGameStatLines.FirstOrDefault(m => m.Player.Contains(name));
            var viewModel = new DashboardViewModels.PlayerBioViewModel
            {
                PlayerStats = playerStat,
                FGPercentage = decimal.Parse(playerStat.FieldGoalPercentage) * 100,
                ThreePercentage = decimal.Parse(playerStat.ThreePointPercentage) * 100,
                FTPercentage = decimal.Parse(playerStat.FreeThrowPercentage) * 100
            };
            viewModel.FGPercentage = Decimal.Round(viewModel.FGPercentage, 1);
            viewModel.ThreePercentage = Decimal.Round(viewModel.ThreePercentage, 1);
            viewModel.FTPercentage = Decimal.Round(viewModel.FTPercentage, 1);
            return View(viewModel);
        }
        public ActionResult Historical()
        {
            var teams = _context.HistoricalTeams.ToList();

            var viewModel = new DashboardViewModels.HistoricalViewModel
            {
                HistoricalTeamsList = teams
            };
            return View(viewModel);
        }

        public ActionResult HistoricalBio(int id)
        {
            var team = _context.HistoricalTeams.FirstOrDefault(m => m.Id == id);
            var players = _context.HistoricalPlayers.ToList();
            var viewModel = new DashboardViewModels.HistoricalBioViewModel
            {
                HistoricalTeam = team,
                HistoricalPlayersList = players
            };
            return View(viewModel);
        }
    }
}