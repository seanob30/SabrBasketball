using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sabr.HelperFunctions;
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

            foreach (var p in allPlayers)
            {
                p.PlayerPosition = _context.PlayerPositions.FirstOrDefault(m => m.Id == p.PlayerPositionId);
            }
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

        public ActionResult UndervaluedPlayers()
        {
            var currentUserName = User.Identity.GetUserName();
            var user = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var userTeam = _context.Teams.FirstOrDefault(m => m.Id == user.TeamId);
            var allPlayers = _context.Players.ToList();
            List<PlayerAndSabrScore> undervaluedPlayers = new List<PlayerAndSabrScore>();

            foreach (var p in allPlayers)
            {
                if (p.TeamId != userTeam.Id)
                {
                    try
                    {
                        var name = p.FirstName + " " + p.LastName;
                        var playerStat = _context.PerGameStatLines.FirstOrDefault(m => m.Player.Contains(name));
                        var sabrMetric = GetSabrMetrics.GetSabrMetric(playerStat, p.PlayerPositionId);
                        var position = _context.PlayerPositions.FirstOrDefault(m => m.Id == p.PlayerPositionId);
                        var minutes = decimal.Parse(playerStat.MinutesPlayed);
                        if (sabrMetric >= 70 && minutes.CompareTo(20) <= 0)
                        {
                            var score = new PlayerAndSabrScore
                            {
                                PlayerName = name,
                                SabrScore = sabrMetric,
                                PositionId = p.PlayerPositionId,
                                Position = position,
                                TeamId = p.TeamId
                            };
                            undervaluedPlayers.Add(score);
                        }
                        
                    }
                    catch
                    {

                    }
                }
            }

            var sortedPlayers = undervaluedPlayers.OrderByDescending(m => m.SabrScore);

            var viewModel = new DashboardViewModels.UndervaluedViewModel
            {
               UndervaluedPlayersList = sortedPlayers
            };

            return View(viewModel);
        }

        public ActionResult PowerRankings()
        {
            var allTeams = _context.Teams.ToList();
            var allPlayers = _context.Players.ToList();
            var teamScores = new List<TeamAndSabrScore>();

            foreach (var t in allTeams)
            {
                if (t.Id != 31)
                {
                    var teamsPlayers = new List<Player>();
                    int teamSabrScore = 0;
                    foreach (var p in allPlayers)
                    {
                        try
                        {
                            if (p.TeamId == t.Id)
                            {
                                var name = p.FirstName + " " + p.LastName;
                                var playerStat = _context.PerGameStatLines.FirstOrDefault(m => m.Player.Contains(name));
                                var sabrMetric = GetSabrMetrics.GetSabrMetric(playerStat, p.PlayerPositionId);

                                teamsPlayers.Add(p);
                                teamSabrScore += sabrMetric;
                            }
                        }
                        catch
                        {

                        }

                    }
                    var medianScore = 0;
                    if (teamsPlayers.Count > 0)
                    {
                        medianScore = teamSabrScore / teamsPlayers.Count;
                    }
                    else
                    {
                        medianScore = 0;
                    }

                    var teamAndScore = new TeamAndSabrScore
                    {
                        Team = t,
                        SabrScore = medianScore,
                    };
                    teamScores.Add(teamAndScore);
                }

            }

            var sortedScores = teamScores.OrderByDescending(m => m.SabrScore);
            var viewModel = new DashboardViewModels.PowerRankingsViewModel
            {
                TeamAndSabrScoresList = sortedScores
            };

            return View(viewModel);
        }
        public ActionResult TeamBio(int id)
        {
            var team = _context.Teams.FirstOrDefault(m => m.Id == id);
            var players = _context.Players.ToList();
            foreach (var p in players)
            {
                p.PlayerPosition = _context.PlayerPositions.FirstOrDefault(m => m.Id == p.PlayerPositionId);
            }
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
            
            if (playerStat.FieldGoalPercentage == "")
            {
                playerStat.FieldGoalPercentage = "0.0";
            }
            if (playerStat.ThreePointPercentage == "")
            {
                playerStat.ThreePointPercentage = "0.0";
            }
            if (playerStat.TwoPointPercentage == "")
            {
                playerStat.TwoPointPercentage = "0.0";
            }
            if (playerStat.FreeThrowPercentage == "")
            {
                playerStat.FreeThrowPercentage = "0.0";
            }

            var sabrMetric = GetSabrMetrics.GetSabrMetric(playerStat, position);
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
            var sabrMetric = GetSabrMetrics.GetHistoricalSabrMetric(playerStat, position);
            if (playerStat.FieldGoalPercentage == "")
            {
                playerStat.FieldGoalPercentage = "0.0";
            }
            if (playerStat.ThreePointPercentage == "")
            {
                playerStat.ThreePointPercentage = "0.0";
            }
            if (playerStat.TwoPointPercentage == "")
            {
                playerStat.TwoPointPercentage = "0.0";
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
            foreach (var p in players)
            {
                p.PlayerPosition = _context.PlayerPositions.FirstOrDefault(m => m.Id == p.PlayerPositionId);
            }
            var viewModel = new DashboardViewModels.HistoricalBioViewModel
            {
                HistoricalTeam = team,
                HistoricalPlayersList = players
            };
            return View(viewModel);
        }

        public ActionResult SpecializedPositions()
        {
            List<Player> userPlayers = new List<Player>();
            List<PlayerAndSpecializedPosition> playerPositionsList = new List<PlayerAndSpecializedPosition>();
            var currentUserName = User.Identity.GetUserName();
            var allPlayers = _context.Players.ToList();
            var user = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var userTeam = _context.Teams.FirstOrDefault(m => m.Id == user.TeamId);

            foreach (var player in allPlayers)
            {
                if (player.TeamId == userTeam.Id)
                {
                    userPlayers.Add(player);
                }
            }
            foreach (var p in userPlayers)
            {
                var name = p.FirstName + " " + p.LastName;
                var playerStat = _context.PerGameStatLines.FirstOrDefault(m => m.Player.Contains(name));
                if (playerStat.FieldGoalPercentage == "")
                {
                    playerStat.FieldGoalPercentage = "0.0";
                }
                if (playerStat.ThreePointPercentage == "")
                {
                    playerStat.ThreePointPercentage = "0.0";
                }
                if (playerStat.TwoPointPercentage == "")
                {
                    playerStat.TwoPointPercentage = "0.0";
                }
                if (playerStat.FreeThrowPercentage == "")
                {
                    playerStat.FreeThrowPercentage = "0.0";
                }
                var specializedPosition = GetSpecializedPosition.GetCurrentPlayerSpecialization(playerStat, p.PlayerPositionId);
                var playerSpecialization = new PlayerAndSpecializedPosition
                {
                    Player = p,
                    SpecializedPosition = specializedPosition
                };
                playerPositionsList.Add(playerSpecialization);
            }

            var viewModel = new DashboardViewModels.SpecializedPositionsViewModel
            {
                PlayerAndSpecializedPositionsList = playerPositionsList
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
                    if (playerStat.FieldGoalPercentage == "")
                    {
                        playerStat.FieldGoalPercentage = "0.0";
                    }
                    if (playerStat.ThreePointPercentage == "")
                    {
                        playerStat.ThreePointPercentage = "0.0";
                    }
                    if (playerStat.TwoPointPercentage == "")
                    {
                        playerStat.TwoPointPercentage = "0.0";
                    }
                    if (playerStat.FreeThrowPercentage == "")
                    {
                        playerStat.FreeThrowPercentage = "0.0";
                    }
                    var sabrMetric = GetSabrMetrics.GetSabrMetric(playerStat, player.PlayerPositionId);
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
                        if (playerStat.FieldGoalPercentage == "")
                        {
                            playerStat.FieldGoalPercentage = "0.0";
                        }
                        if (playerStat.ThreePointPercentage == "")
                        {
                            playerStat.ThreePointPercentage = "0.0";
                        }
                        if (playerStat.TwoPointPercentage == "")
                        {
                            playerStat.TwoPointPercentage = "0.0";
                        }
                        if (playerStat.FreeThrowPercentage == "")
                        {
                            playerStat.FreeThrowPercentage = "0.0";
                        }
                        var sabrMetric = GetSabrMetrics.GetSabrMetric(playerStat, player.PlayerPositionId);
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
        
    }
}