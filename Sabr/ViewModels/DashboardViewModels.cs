using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sabr.Models;

namespace Sabr.ViewModels
{
    public class DashboardViewModels
    {
        public class MyTeamViewModel
        {
            public ApplicationUser CurrentUser { get; set; }
            public Team Team { get; set; }
            public IEnumerable<Player> PlayersList { get; set; }    
        }

        public class AnalyzeMyTeamViewModel
        {
            public ApplicationUser CurrentUser { get; set; }
            public Team Team { get; set; }
            public IEnumerable<PlayerAndSabrScore> ListOfSabrScores { get; set; }
            public List<PlayerAndSabrScore> BottomFiveSabrScores { get; set; }


        }

        public class HistoricalViewModel
        {
            public IEnumerable<HistoricalTeam> HistoricalTeamsList { get; set; }
        }

        public class HistoricalBioViewModel
        {
            public HistoricalTeam HistoricalTeam { get; set; }
            public IEnumerable<HistoricalPlayer> HistoricalPlayersList { get; set; }
        }

        public class LeagueViewModel
        {
            public IEnumerable<Team> TeamsList { get; set; }
        }

        public class TeamBioViewModel
        {
            public Team Team { get; set; }
            public IEnumerable<Player> PlayersList { get; set; }
        }

        public class PlayerBioViewModel
        {
            public PerGameStatLine PlayerStats { get; set; }
            public int SabrMetric { get; set; }   

        }

        public class HistoricalPlayerBioViewModel
        {
            public HistoricalPerGameStatLine PlayerStats { get; set; }
            public int SabrMetric { get; set; }

        }

        public class FindReplacementViewModel
        {
            public IEnumerable<PlayerAndSabrScore> ReplacementsList { get; set; }
        }

        public class UndervaluedViewModel
        {
            public IEnumerable<PlayerAndSabrScore> UndervaluedPlayersList { get; set; }
        }

        public class PowerRankingsViewModel
        {
            public IEnumerable<TeamAndSabrScore> TeamAndSabrScoresList { get; set; }
        }

        public class SpecializedPositionsViewModel
        {
            public IEnumerable<PlayerAndSpecializedPosition> PlayerAndSpecializedPositionsList { get; set; }
        }
    }
}