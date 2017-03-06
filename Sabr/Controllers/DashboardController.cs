using System;
using System.Collections;
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

        public ActionResult PlayerBio(string name, int position)
        {
            var playerStat = _context.PerGameStatLines.FirstOrDefault(m => m.Player.Contains(name));
            var sabrMetric = GetSabrMetric(playerStat, position);
            if (playerStat.FieldGoalPercentage == "")
            {
                playerStat.FieldGoalPercentage = "0.0";
            }
            if (playerStat.ThreePointPercentage == "")
            {
                playerStat.ThreePointPercentage = "0.0";
            }
            if (playerStat.FreeThrowPercentage == "")
            {
                playerStat.FreeThrowPercentage = "0.0";
            }

            var viewModel = new DashboardViewModels.PlayerBioViewModel
            {
                PlayerStats = playerStat,
                SabrMetric = sabrMetric
            };
            return View(viewModel);
        }

        public ActionResult HistoricalPlayerBio(string name, int season, int position)
        {
            var allStats = _context.HistoricalPerGameStatLines.ToList();
            var allYears = new List<HistoricalPerGameStatLine>();

            foreach (var stat in allStats)
            {
                if (stat.Player.Contains(name))
                {
                    allYears.Add(stat);
                }
            }

            var playerStat = allYears.FirstOrDefault(m => m.SeasonId == season);
            var sabrMetric = GetHistoricalSabrMetric(playerStat, position);
            if (playerStat.FieldGoalPercentage == "")
            {
                playerStat.FieldGoalPercentage = "0.0";
            }
            if (playerStat.ThreePointPercentage == "")
            {
                playerStat.ThreePointPercentage = "0.0";
            }
            if (playerStat.FreeThrowPercentage == "")
            {
                playerStat.FreeThrowPercentage = "0.0";
            }

            var viewModel = new DashboardViewModels.HistoricalPlayerBioViewModel
            {
                PlayerStats = playerStat,
                SabrMetric = sabrMetric
            };
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

        public ActionResult AnalyzeMyTeam()
        {
            List<Player> userPlayers = new List<Player>();
            List<PlayerAndSabrScore> sabrScoresList = new List<PlayerAndSabrScore>();

            var currentUserName = User.Identity.GetUserName();
            var allPlayers = _context.Players.ToList();
            var user = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var userTeam = _context.Teams.FirstOrDefault(m => m.Id == user.TeamId);

            foreach (var player in allPlayers)
            {
                if (player.TeamId == user.TeamId)
                {
                    userPlayers.Add(player);
                }
            }
            
            foreach (var player in userPlayers)
            {
                try
                {
                    var name = player.FirstName + " " + player.LastName;
                    var playerStat = _context.PerGameStatLines.FirstOrDefault(m => m.Player.Contains(name));
                    var sabrMetric = GetSabrMetric(playerStat, player.PlayerPositionId);
                    var score = new PlayerAndSabrScore
                    {
                        PlayerName = name,
                        SabrScore = sabrMetric,
                        PositionId = player.PlayerPositionId,
                        TeamId = player.TeamId
                    };

                    sabrScoresList.Add(score);
                }
                catch
                {
                    
                }
            }
            List<PlayerAndSabrScore> sortedSabrScores = sabrScoresList.OrderByDescending(m => m.SabrScore).ToList();
            List<PlayerAndSabrScore> bottomFive = new List<PlayerAndSabrScore>();
            bottomFive.Add(sortedSabrScores[sortedSabrScores.Count - 1]);
            bottomFive.Add(sortedSabrScores[sortedSabrScores.Count - 2]);
            bottomFive.Add(sortedSabrScores[sortedSabrScores.Count - 3]);
            bottomFive.Add(sortedSabrScores[sortedSabrScores.Count - 4]);
            bottomFive.Add(sortedSabrScores[sortedSabrScores.Count - 5]);
            
            var viewModel = new DashboardViewModels.AnalyzeMyTeamViewModel
            {
                CurrentUser = user,
                Team = userTeam,
                ListOfSabrScores = sabrScoresList,
                BottomFiveSabrScores = bottomFive
            };

            return View(viewModel);
        }

        public ActionResult FindReplacement(string name, int score, int position, int team)
        {
            var allPlayers = _context.Players.ToList();
            List<PlayerAndSabrScore> replacements = new List<PlayerAndSabrScore>();

            foreach (var player in allPlayers)
            {
                if (player.PlayerPositionId == position && player.TeamId != team)
                {
                    try
                    {
                        var replacementName = player.FirstName + " " + player.LastName;
                        var playerStat = _context.PerGameStatLines.FirstOrDefault(m => m.Player.Contains(replacementName));
                        var sabrMetric = GetSabrMetric(playerStat, player.PlayerPositionId);
                        if (sabrMetric > score)
                        {
                            var replacement = new PlayerAndSabrScore
                            {
                                PlayerName = replacementName,
                                SabrScore = sabrMetric,
                                PositionId = player.PlayerPositionId,
                                TeamId = player.TeamId
                            };

                            replacements.Add(replacement);
                        }
                        
                    }
                    catch
                    {

                    }
                }
            }

            List<PlayerAndSabrScore> sortedSabrScores = replacements.OrderByDescending(m => m.SabrScore).ToList();

            var viewModel = new DashboardViewModels.FindReplacementViewModel
            {
                ReplacementsList = sortedSabrScores
            };
            return View(viewModel);
        }

        public int GetSabrMetric(PerGameStatLine stat, int position)
        {
            try
            {
                if (position == 1 || position == 2)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 15;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 12;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) >= 2)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    return sabrMetric;
                }
                else if (position == 3)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 13;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 11;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 5)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers)  >= 4)
                    {
                        sabrMetric -= 5;
                    }
                    else if (decimal.Parse(stat.Turnovers) * 10 >= 35)
                    {
                        sabrMetric -= 4;
                    }
                    else if(decimal.Parse(stat.Turnovers) >= 2)
                    {
                        sabrMetric -= 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 <= 29 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 1)
                    {
                        sabrMetric -= 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) * 10 >= 15)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    return sabrMetric;
                }
                else if (position == 4 || position == 5)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Points) > 4)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 7)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) >= 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) >= 3)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) >= 12)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 10)
                    {
                        sabrMetric += 9;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 6)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 4)
                    {
                        sabrMetric += 3;
                    }
                    else if(decimal.Parse(stat.TotalRebounds) >= 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 67 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 50 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 <= 40 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 2)
                    {
                        sabrMetric += 5;
                    }
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    return sabrMetric;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int GetHistoricalSabrMetric(HistoricalPerGameStatLine stat, int position)
        {
            try
            {
                if (position == 1 || position == 2)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 15;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 12;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) >= 2)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    return sabrMetric;
                }
                else if (position == 3)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 13;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 11;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 5)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) >= 4)
                    {
                        sabrMetric -= 5;
                    }
                    else if (decimal.Parse(stat.Turnovers) * 10 >= 35)
                    {
                        sabrMetric -= 4;
                    }
                    else if (decimal.Parse(stat.Turnovers) >= 2)
                    {
                        sabrMetric -= 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 <= 29 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 1)
                    {
                        sabrMetric -= 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) * 10 >= 15)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    return sabrMetric;
                }
                else if (position == 4 || position == 5)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Points) > 4)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 7)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) >= 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) >= 3)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) >= 12)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 10)
                    {
                        sabrMetric += 9;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 6)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 4)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 67 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 50 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 <= 40 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 2)
                    {
                        sabrMetric += 5;
                    }
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    return sabrMetric;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }


    }
}