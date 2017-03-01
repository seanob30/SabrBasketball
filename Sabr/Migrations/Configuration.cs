namespace Sabr.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sabr.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sabr.Models.ApplicationDbContext context)
        {
            context.Teams.AddOrUpdate(m => m.Id,
                new Models.Team {Id = 1, TeamName = "Atlanta Hawks", City = "Atlanta"},
                new Models.Team {Id = 2, TeamName = "Boston Celtics", City = "Boston"},
                new Models.Team {Id = 3, TeamName = "Brooklyn Nets", City = "Brooklyn"},
                new Models.Team {Id = 4, TeamName = "Charlotte Hornets", City = "Charlotte"},
                new Models.Team {Id = 5, TeamName = "Chicago Bulls", City = "Chicago"},
                new Models.Team {Id = 6, TeamName = "Cleveland Cavaliers", City = "Cleveland"},
                new Models.Team {Id = 7, TeamName = "Dallas Mavericks", City = "Dallas"},
                new Models.Team {Id = 8, TeamName = "Denver Nuggets", City = "Denver"},
                new Models.Team {Id = 9, TeamName = "Detroit Pistons", City = "Detroit"},
                new Models.Team {Id = 10, TeamName = "Golden State Warriors", City = "Oakland"},
                new Models.Team {Id = 11, TeamName = "Houston Rockets", City = "Houston"},
                new Models.Team {Id = 12, TeamName = "Indiana Pacers", City = "Indiana"},
                new Models.Team {Id = 13, TeamName = "LA Clippers", City = "Los Angeles"},
                new Models.Team {Id = 14, TeamName = "Los Angeles Lakers", City = "Los Angeles"},
                new Models.Team {Id = 15, TeamName = "Memphis Grizzlies", City = "Memphis"},
                new Models.Team {Id = 16, TeamName = "Miami Heat", City = "Miami"},
                new Models.Team {Id = 17, TeamName = "Milwaukee Bucks", City = "Milwaukee"},
                new Models.Team {Id = 18, TeamName = "Minnesota Timberwolves", City = "Minnesota"},
                new Models.Team {Id = 19, TeamName = "New Orleans Pelicans", City = "New Orleans"},
                new Models.Team {Id = 20, TeamName = "New York Knicks", City = "New York"},
                new Models.Team {Id = 21, TeamName = "Oklahoma City Thunder", City = "Oklahoma City"},
                new Models.Team {Id = 22, TeamName = "Orlando Magic", City = "Orlando"},
                new Models.Team {Id = 23, TeamName = "Philadelphia 76ers", City = "Philadelphia"},
                new Models.Team {Id = 24, TeamName = "Phoenix Suns", City = "Phoenix"},
                new Models.Team {Id = 25, TeamName = "Portland Trail Blazers", City = "Portland"},
                new Models.Team {Id = 26, TeamName = "Sacramento Kings", City = "Sacramento"},
                new Models.Team {Id = 27, TeamName = "San Antonio Spurs", City = "San Antonio"},
                new Models.Team {Id = 28, TeamName = "Toronto Raptors", City = "Toronto"},
                new Models.Team {Id = 29, TeamName = "Utah Jazz", City = "Utah"},
                new Models.Team {Id = 30, TeamName = "Washington Wizards", City = "Washington"},
                new Models.Team {Id = 31, TeamName = "Free Agency"}
            );

            context.PlayerPositions.AddOrUpdate(m => m.Id,
                new Models.PlayerPosition {Id = 1, Position = "Point Guard"},
                new Models.PlayerPosition {Id = 2, Position = "Shooting Guard"},
                new Models.PlayerPosition {Id = 3, Position = "Small Forward"},
                new Models.PlayerPosition {Id = 4, Position = "Power Forward"},
                new Models.PlayerPosition {Id = 5, Position = "Center"}
            );
        }
    }
}
