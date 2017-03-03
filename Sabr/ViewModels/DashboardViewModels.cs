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
            public IEnumerable<Player> Players { get; set; }    
        }
    }
}