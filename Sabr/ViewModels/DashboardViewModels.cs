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

        public class HistoricalViewModel
        {
            public IEnumerable<HistoricalTeam> HistoricalTeamsList { get; set; }
        }

        public class HistoricalBioViewModel
        {
            public HistoricalTeam HistoricalTeam { get; set; }
            public IEnumerable<HistoricalPlayer> HistoricalPlayersList { get; set; }
        }
    }
}