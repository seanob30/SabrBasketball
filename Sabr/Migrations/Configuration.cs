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
                new Models.Team { Id = 1, TeamName = "Atlanta Hawks", City = "Atlanta" },
                new Models.Team { Id = 2, TeamName = "Boston Celtics", City = "Boston" },
                new Models.Team { Id = 3, TeamName = "Brooklyn Nets", City = "Brooklyn" },
                new Models.Team { Id = 4, TeamName = "Charlotte Hornets", City = "Charlotte" },
                new Models.Team { Id = 5, TeamName = "Chicago Bulls", City = "Chicago" },
                new Models.Team { Id = 6, TeamName = "Cleveland Cavaliers", City = "Cleveland" },
                new Models.Team { Id = 7, TeamName = "Dallas Mavericks", City = "Dallas" },
                new Models.Team { Id = 8, TeamName = "Denver Nuggets", City = "Denver" },
                new Models.Team { Id = 9, TeamName = "Detroit Pistons", City = "Detroit" },
                new Models.Team { Id = 10, TeamName = "Golden State Warriors", City = "Oakland" },
                new Models.Team { Id = 11, TeamName = "Houston Rockets", City = "Houston" },
                new Models.Team { Id = 12, TeamName = "Indiana Pacers", City = "Indiana" },
                new Models.Team { Id = 13, TeamName = "LA Clippers", City = "Los Angeles" },
                new Models.Team { Id = 14, TeamName = "Los Angeles Lakers", City = "Los Angeles" },
                new Models.Team { Id = 15, TeamName = "Memphis Grizzlies", City = "Memphis" },
                new Models.Team { Id = 16, TeamName = "Miami Heat", City = "Miami" },
                new Models.Team { Id = 17, TeamName = "Milwaukee Bucks", City = "Milwaukee" },
                new Models.Team { Id = 18, TeamName = "Minnesota Timberwolves", City = "Minnesota" },
                new Models.Team { Id = 19, TeamName = "New Orleans Pelicans", City = "New Orleans" },
                new Models.Team { Id = 20, TeamName = "New York Knicks", City = "New York" },
                new Models.Team { Id = 21, TeamName = "Oklahoma City Thunder", City = "Oklahoma City" },
                new Models.Team { Id = 22, TeamName = "Orlando Magic", City = "Orlando" },
                new Models.Team { Id = 23, TeamName = "Philadelphia 76ers", City = "Philadelphia" },
                new Models.Team { Id = 24, TeamName = "Phoenix Suns", City = "Phoenix" },
                new Models.Team { Id = 25, TeamName = "Portland Trail Blazers", City = "Portland" },
                new Models.Team { Id = 26, TeamName = "Sacramento Kings", City = "Sacramento" },
                new Models.Team { Id = 27, TeamName = "San Antonio Spurs", City = "San Antonio" },
                new Models.Team { Id = 28, TeamName = "Toronto Raptors", City = "Toronto" },
                new Models.Team { Id = 29, TeamName = "Utah Jazz", City = "Utah" },
                new Models.Team { Id = 30, TeamName = "Washington Wizards", City = "Washington" },
                new Models.Team { Id = 31, TeamName = "Free Agency" }
            );

            context.PlayerPositions.AddOrUpdate(m => m.Id,
                new Models.PlayerPosition { Id = 1, Position = "Point Guard" },
                new Models.PlayerPosition { Id = 2, Position = "Shooting Guard" },
                new Models.PlayerPosition { Id = 3, Position = "Small Forward" },
                new Models.PlayerPosition { Id = 4, Position = "Power Forward" },
                new Models.PlayerPosition { Id = 5, Position = "Center" }
            );

            context.Seasons.AddOrUpdate(m => m.Id,
                new Models.Season { Id = 1, Year = "2015-2016" },
                new Models.Season { Id = 2, Year = "2014-2015" },
                new Models.Season { Id = 3, Year = "2013-2014" },
                new Models.Season { Id = 4, Year = "2012-2013" },
                new Models.Season { Id = 5, Year = "2011-2012" },
                new Models.Season { Id = 6, Year = "2010-2011" }
                );

            context.HistoricalTeams.AddOrUpdate(m => m.Id,
                new Models.HistoricalTeam { Id = 1, TeamName = "Cleveland Cavaliers", SeasonId = 1 },
                new Models.HistoricalTeam { Id = 2, TeamName = "Golden State Warriors", SeasonId = 2 },
                new Models.HistoricalTeam { Id = 3, TeamName = "San Antonio Spurs", SeasonId = 3 },
                new Models.HistoricalTeam { Id = 4, TeamName = "Miami Heat", SeasonId = 4 },
                new Models.HistoricalTeam { Id = 5, TeamName = "Miami Heat", SeasonId = 5 },
                new Models.HistoricalTeam { Id = 6, TeamName = "Dallas Mavericks", SeasonId = 6 }
                );

            context.Players.AddOrUpdate(m => m.Id,
                new Models.Player { Id = 1, FirstName = "Kent", LastName = "Bazemore", FootHeight = 6, InchHeight = 5, Weight = 201, Age = 27, PlayerPositionId = 3, TeamId = 1 },
                new Models.Player { Id = 2, FirstName = "DeAndre", LastName = "Bembry", FootHeight = 6, InchHeight = 6, Weight = 210, Age = 22, PlayerPositionId = 3, TeamId = 1 },
                new Models.Player { Id = 3, FirstName = "Malcolm", LastName = "Delaney", FootHeight = 6, InchHeight = 3, Weight = 190, Age = 27, PlayerPositionId = 1, TeamId = 1 },
                new Models.Player { Id = 4, FirstName = "Mike", LastName = "Dunleavy", FootHeight = 6, InchHeight = 9, Weight = 230, Age = 36, PlayerPositionId = 2, TeamId = 1 },
                new Models.Player { Id = 5, FirstName = "Tim", LastName = "Hardaway Jr.", FootHeight = 6, InchHeight = 6, Weight = 205, Age = 24, PlayerPositionId = 2, TeamId = 1 },
                new Models.Player { Id = 6, FirstName = "Dwight", LastName = "Howard", FootHeight = 6, InchHeight = 11, Weight = 265, Age = 31, PlayerPositionId = 5, TeamId = 1 },
                new Models.Player { Id = 7, FirstName = "Kris", LastName = "Humphries", FootHeight = 6, InchHeight = 9, Weight = 235, Age = 32, PlayerPositionId = 4, TeamId = 1 },
                new Models.Player { Id = 8, FirstName = "Ersan", LastName = "Ilyasova", FootHeight = 6, InchHeight = 10, Weight = 235, Age = 29, PlayerPositionId = 4, TeamId = 1 },
                new Models.Player { Id = 9, FirstName = "Ryan", LastName = "Kelly", FootHeight = 6, InchHeight = 11, Weight = 230, Age = 25, PlayerPositionId = 4, TeamId = 1 },
                new Models.Player { Id = 10, FirstName = "Paul", LastName = "Millsap", FootHeight = 6, InchHeight = 8, Weight = 246, Age = 32, PlayerPositionId = 4, TeamId = 1 },
                new Models.Player { Id = 11, FirstName = "Mike", LastName = "Muscala", FootHeight = 6, InchHeight = 11, Weight = 240, Age = 25, PlayerPositionId = 4, TeamId = 1 },
                new Models.Player { Id = 12, FirstName = "Taurean", LastName = "Prince", FootHeight = 6, InchHeight = 8, Weight = 220, Age = 22, PlayerPositionId = 3, TeamId = 1 },
                new Models.Player { Id = 13, FirstName = "Dennis", LastName = "Schroder", FootHeight = 6, InchHeight = 1, Weight = 172, Age = 23, PlayerPositionId = 1, TeamId = 1 },
                new Models.Player { Id = 14, FirstName = "Thabo", LastName = "Sefolosha", FootHeight = 6, InchHeight = 7, Weight = 220, Age = 32, PlayerPositionId = 3, TeamId = 1 },
                new Models.Player { Id = 15, FirstName = "Giannis", LastName = "Antetokounmpo", FootHeight = 6, InchHeight = 11, Weight = 222, Age = 22, PlayerPositionId = 3, TeamId = 17 },
                new Models.Player { Id = 16, FirstName = "Michael", LastName = "Beasley", FootHeight = 6, InchHeight = 10, Weight = 235, Age = 28, PlayerPositionId = 3, TeamId = 17 },
                new Models.Player { Id = 17, FirstName = "Malcolm", LastName = "Brogdon", FootHeight = 6, InchHeight = 5, Weight = 215, Age = 24, PlayerPositionId = 2, TeamId = 17 },
                new Models.Player { Id = 18, FirstName = "Matthew", LastName = "Dellavedova", FootHeight = 6, InchHeight = 4, Weight = 198, Age = 26, PlayerPositionId = 1, TeamId = 17 },
                new Models.Player { Id = 19, FirstName = "Spencer", LastName = "Hawes", FootHeight = 7, InchHeight = 1, Weight = 245, Age = 28, PlayerPositionId = 4, TeamId = 17 },
                new Models.Player { Id = 20, FirstName = "John", LastName = "Henson", FootHeight = 6, InchHeight = 11, Weight = 229, Age = 26, PlayerPositionId = 5, TeamId = 17 },
                new Models.Player { Id = 21, FirstName = "Thon", LastName = "Maker", FootHeight = 7, InchHeight = 1, Weight = 223, Age = 20, PlayerPositionId = 4, TeamId = 17 },
                new Models.Player { Id = 22, FirstName = "Khris", LastName = "Middleton", FootHeight = 6, InchHeight = 8, Weight = 234, Age = 25, PlayerPositionId = 2, TeamId = 17 },
                new Models.Player { Id = 23, FirstName = "Greg", LastName = "Monroe", FootHeight = 6, InchHeight = 11, Weight = 265, Age = 26, PlayerPositionId = 5, TeamId = 17 },
                new Models.Player { Id = 24, FirstName = "Jabari", LastName = "Parker", FootHeight = 6, InchHeight = 8, Weight = 250, Age = 21, PlayerPositionId = 4, TeamId = 17 },
                new Models.Player { Id = 25, FirstName = "Tony", LastName = "Snell", FootHeight = 6, InchHeight = 7, Weight = 217, Age = 25, PlayerPositionId = 2, TeamId = 17 },
                new Models.Player { Id = 26, FirstName = "Mirza", LastName = "Teletovic", FootHeight = 6, InchHeight = 9, Weight = 245, Age = 31, PlayerPositionId = 4, TeamId = 17 },
                new Models.Player { Id = 27, FirstName = "Jason", LastName = "Terry", FootHeight = 6, InchHeight = 2, Weight = 185, Age = 39, PlayerPositionId = 2, TeamId = 17 },
                new Models.Player { Id = 28, FirstName = "Axel", LastName = "Toupane", FootHeight = 6, InchHeight = 7, Weight = 210, Age = 24, PlayerPositionId = 2, TeamId = 17 },
                new Models.Player { Id = 29, FirstName = "Rashad", LastName = "Vaughn", FootHeight = 6, InchHeight = 6, Weight = 202, Age = 20, PlayerPositionId = 2, TeamId = 17 },
                new Models.Player { Id = 30, FirstName = "Jimmy", LastName = "Butler", FootHeight = 6, InchHeight = 7, Weight = 231, Age = 27, PlayerPositionId = 3, TeamId = 5 },
                new Models.Player { Id = 31, FirstName = "Isaiah", LastName = "Canaan", FootHeight = 6, InchHeight = 0, Weight = 201, Age = 25, PlayerPositionId = 1, TeamId = 5 },
                new Models.Player { Id = 32, FirstName = "Michael", LastName = "Carter-Williams", FootHeight = 6, InchHeight = 6, Weight = 190, Age = 25, PlayerPositionId = 1, TeamId = 5 },
                new Models.Player { Id = 33, FirstName = "Cristiano", LastName = "Felicio", FootHeight = 6, InchHeight = 9, Weight = 266, Age = 24, PlayerPositionId = 4, TeamId = 5 },
                new Models.Player { Id = 34, FirstName = "Jerian", LastName = "Grant", FootHeight = 6, InchHeight = 4, Weight = 198, Age = 24, PlayerPositionId = 1, TeamId = 5 },
                new Models.Player { Id = 35, FirstName = "Joffrey", LastName = "Lauvergne", FootHeight = 6, InchHeight = 11, Weight = 220, Age = 25, PlayerPositionId = 5, TeamId = 5 },
                new Models.Player { Id = 36, FirstName = "Robin", LastName = "Lopez", FootHeight = 7, InchHeight = 0, Weight = 255, Age = 28, PlayerPositionId = 5, TeamId = 5 },
                new Models.Player { Id = 37, FirstName = "Nikola", LastName = "Mirotic", FootHeight = 6, InchHeight = 10, Weight = 238, Age = 26, PlayerPositionId = 4, TeamId = 5 },
                new Models.Player { Id = 38, FirstName = "Anthony", LastName = "Morrow", FootHeight = 6, InchHeight = 5, Weight = 210, Age = 31, PlayerPositionId = 2, TeamId = 5 },
                new Models.Player { Id = 39, FirstName = "Cameron", LastName = "Payne", FootHeight = 6, InchHeight = 3, Weight = 185, Age = 22, PlayerPositionId = 1, TeamId = 5 },
                new Models.Player { Id = 40, FirstName = "Bobby", LastName = "Portis", FootHeight = 6, InchHeight = 11, Weight = 246, Age = 22, PlayerPositionId = 4, TeamId = 5 },
                new Models.Player { Id = 41, FirstName = "Rajon", LastName = "Rondo", FootHeight = 6, InchHeight = 1, Weight = 186, Age = 31, PlayerPositionId = 1, TeamId = 5 },
                new Models.Player { Id = 42, FirstName = "Denzel", LastName = "Valentine", FootHeight = 6, InchHeight = 6, Weight = 212, Age = 23, PlayerPositionId = 2, TeamId = 5 },
                new Models.Player { Id = 43, FirstName = "Dwyane", LastName = "Wade", FootHeight = 6, InchHeight = 4, Weight = 220, Age = 35, PlayerPositionId = 2, TeamId = 5 },
                new Models.Player { Id = 44, FirstName = "Paul", LastName = "Zipser", FootHeight = 6, InchHeight = 8, Weight = 210, Age = 23, PlayerPositionId = 3, TeamId = 5 },
                new Models.Player { Id = 45, FirstName = "Andrew", LastName = "Bogut", FootHeight = 7, InchHeight = 0, Weight = 255, Age = 32, PlayerPositionId = 5, TeamId = 6 },
                new Models.Player { Id = 46, FirstName = "Kay", LastName = "Felder", FootHeight = 5, InchHeight = 9, Weight = 176, Age = 21, PlayerPositionId = 1, TeamId = 6 },
                new Models.Player { Id = 47, FirstName = "Channing", LastName = "Frye", FootHeight = 6, InchHeight = 11, Weight = 255, Age = 33, PlayerPositionId = 4, TeamId = 6 },
                new Models.Player { Id = 48, FirstName = "Kyrie", LastName = "Irving", FootHeight = 6, InchHeight = 3, Weight = 193, Age = 24, PlayerPositionId = 1, TeamId = 6 },
                new Models.Player { Id = 49, FirstName = "LeBron", LastName = "James", FootHeight = 6, InchHeight = 8, Weight = 250, Age = 32, PlayerPositionId = 3, TeamId = 6 },
                new Models.Player { Id = 50, FirstName = "Richard", LastName = "Jefferson", FootHeight = 6, InchHeight = 7, Weight = 233, Age = 36, PlayerPositionId = 3, TeamId = 6 },
                new Models.Player { Id = 51, FirstName = "James", LastName = "Jones", FootHeight = 6, InchHeight = 8, Weight = 218, Age = 36, PlayerPositionId = 2, TeamId = 6 },
                new Models.Player { Id = 52, FirstName = "Kyle", LastName = "Korver", FootHeight = 6, InchHeight = 7, Weight = 212, Age = 35, PlayerPositionId = 2, TeamId = 6 },
                new Models.Player { Id = 53, FirstName = "DeAndre", LastName = "Liggins", FootHeight = 6, InchHeight = 6, Weight = 209, Age = 28, PlayerPositionId = 2, TeamId = 6 },
                new Models.Player { Id = 54, FirstName = "Kevin", LastName = "Love", FootHeight = 6, InchHeight = 10, Weight = 251, Age = 28, PlayerPositionId = 4, TeamId = 6 },
                new Models.Player { Id = 55, FirstName = "Iman", LastName = "Shumpert", FootHeight = 6, InchHeight = 5, Weight = 220, Age = 26, PlayerPositionId = 2, TeamId = 6 },
                new Models.Player { Id = 56, FirstName = "J.R.", LastName = "Smith", FootHeight = 6, InchHeight = 6, Weight = 225, Age = 31, PlayerPositionId = 2, TeamId = 6 },
                new Models.Player { Id = 57, FirstName = "Tristan", LastName = "Thompson", FootHeight = 6, InchHeight = 9, Weight = 238, Age = 25, PlayerPositionId = 5, TeamId = 6 },
                new Models.Player { Id = 58, FirstName = "Deron", LastName = "Williams", FootHeight = 6, InchHeight = 3, Weight = 200, Age = 32, PlayerPositionId = 1, TeamId = 6 },
                new Models.Player { Id = 59, FirstName = "Derrick", LastName = "Williams", FootHeight = 6, InchHeight = 8, Weight = 240, Age = 25, PlayerPositionId = 4, TeamId = 6 },
                new Models.Player { Id = 60, FirstName = "Aron", LastName = "Baynes", FootHeight = 6, InchHeight = 10, Weight = 260, Age = 30, PlayerPositionId = 5, TeamId = 9 },
                new Models.Player { Id = 61, FirstName = "Reggie", LastName = "Bullock", FootHeight = 6, InchHeight = 7, Weight = 205, Age = 25, PlayerPositionId = 3, TeamId = 9 },
                new Models.Player { Id = 62, FirstName = "Kentavious", LastName = "Caldwell-Pope", FootHeight = 6, InchHeight = 5, Weight = 205, Age = 24, PlayerPositionId = 2, TeamId = 9 },
                new Models.Player { Id = 63, FirstName = "Andre", LastName = "Drummond", FootHeight = 6, InchHeight = 11, Weight = 279, Age = 23, PlayerPositionId = 5, TeamId = 9 },
                new Models.Player { Id = 64, FirstName = "Henry", LastName = "Ellenson", FootHeight = 6, InchHeight = 11, Weight = 245, Age = 20, PlayerPositionId = 4, TeamId = 9 },
                new Models.Player { Id = 65, FirstName = "Michael", LastName = "Gbinije", FootHeight = 6, InchHeight = 7, Weight = 200, Age = 24, PlayerPositionId = 2, TeamId = 9 },
                new Models.Player { Id = 66, FirstName = "Tobias", LastName = "Harris", FootHeight = 6, InchHeight = 9, Weight = 235, Age = 24, PlayerPositionId = 3, TeamId = 9 },
                new Models.Player { Id = 67, FirstName = "Darrun", LastName = "Hilliard", FootHeight = 6, InchHeight = 6, Weight = 205, Age = 23, PlayerPositionId = 2, TeamId = 9 },
                new Models.Player { Id = 68, FirstName = "Reggie", LastName = "Jackson", FootHeight = 6, InchHeight = 3, Weight = 208, Age = 26, PlayerPositionId = 1, TeamId = 9 },
                new Models.Player { Id = 69, FirstName = "Stanley", LastName = "Johnson", FootHeight = 6, InchHeight = 7, Weight = 245, Age = 20, PlayerPositionId = 3, TeamId = 9 },
                new Models.Player { Id = 70, FirstName = "Jon", LastName = "Leuer", FootHeight = 6, InchHeight = 10, Weight = 228, Age = 27, PlayerPositionId = 4, TeamId = 9 },
                new Models.Player { Id = 71, FirstName = "Boban", LastName = "Marjanovic", FootHeight = 7, InchHeight = 3, Weight = 290, Age = 28, PlayerPositionId = 5, TeamId = 9 },
                new Models.Player { Id = 72, FirstName = "Marcus", LastName = "Morris", FootHeight = 6, InchHeight = 9, Weight = 235, Age = 27, PlayerPositionId = 4, TeamId = 9 },
                new Models.Player { Id = 73, FirstName = "Ish", LastName = "Smith", FootHeight = 6, InchHeight = 0, Weight = 175, Age = 28, PlayerPositionId = 1, TeamId = 9 },
                new Models.Player { Id = 74, FirstName = "Beno", LastName = "Udrih", FootHeight = 6, InchHeight = 3, Weight = 205, Age = 34, PlayerPositionId = 1, TeamId = 9 },
                new Models.Player { Id = 75, FirstName = "Lavoy", LastName = "Allen", FootHeight = 6, InchHeight = 9, Weight = 260, Age = 28, PlayerPositionId = 4, TeamId = 12 },
                new Models.Player { Id = 76, FirstName = "Aaron", LastName = "Brooks", FootHeight = 6, InchHeight = 0, Weight = 161, Age = 32, PlayerPositionId = 1, TeamId = 12 },
                new Models.Player { Id = 77, FirstName = "Rakeem", LastName = "Christmas", FootHeight = 6, InchHeight = 9, Weight = 250, Age = 25, PlayerPositionId = 4, TeamId = 12 },
                new Models.Player { Id = 78, FirstName = "Monta", LastName = "Ellis", FootHeight = 6, InchHeight = 3, Weight = 185, Age = 31, PlayerPositionId = 2, TeamId = 12 },
                new Models.Player { Id = 79, FirstName = "Paul", LastName = "George", FootHeight = 6, InchHeight = 9, Weight = 220, Age = 26, PlayerPositionId = 3, TeamId = 12 },
                new Models.Player { Id = 80, FirstName = "Al", LastName = "Jefferson", FootHeight = 6, InchHeight = 10, Weight = 289, Age = 32, PlayerPositionId = 5, TeamId = 12 },
                new Models.Player { Id = 81, FirstName = "C.J.", LastName = "Miles", FootHeight = 6, InchHeight = 6, Weight = 225, Age = 29, PlayerPositionId = 3, TeamId = 12 },
                new Models.Player { Id = 82, FirstName = "Georges", LastName = "Niang", FootHeight = 6, InchHeight = 8, Weight = 230, Age = 23, PlayerPositionId = 3, TeamId = 12 },
                new Models.Player { Id = 83, FirstName = "Glenn", LastName = "Robinson III", FootHeight = 6, InchHeight = 6, Weight = 222, Age = 23, PlayerPositionId = 2, TeamId = 12 },
                new Models.Player { Id = 84, FirstName = "Kevin", LastName = "Seraphin", FootHeight = 6, InchHeight = 10, Weight = 278, Age = 27, PlayerPositionId = 5, TeamId = 12 },
                new Models.Player { Id = 85, FirstName = "Rodney", LastName = "Stuckey", FootHeight = 6, InchHeight = 5, Weight = 205, Age = 30, PlayerPositionId = 1, TeamId = 12 },
                new Models.Player { Id = 86, FirstName = "Jeff", LastName = "Teague", FootHeight = 6, InchHeight = 2, Weight = 186, Age = 28, PlayerPositionId = 1, TeamId = 12 },
                new Models.Player { Id = 87, FirstName = "Myles", LastName = "Turner", FootHeight = 6, InchHeight = 11, Weight = 243, Age = 20, PlayerPositionId = 5, TeamId = 12 },
                new Models.Player { Id = 88, FirstName = "Joe", LastName = "Young", FootHeight = 6, InchHeight = 2, Weight = 180, Age = 24, PlayerPositionId = 1, TeamId = 12 },
                new Models.Player { Id = 89, FirstName = "Thaddeus", LastName = "Young", FootHeight = 6, InchHeight = 8, Weight = 221, Age = 28, PlayerPositionId = 4, TeamId = 12 },
                new Models.Player { Id = 90, FirstName = "Matt", LastName = "Barnes", FootHeight = 6, InchHeight = 7, Weight = 226, Age = 36, PlayerPositionId = 3, TeamId = 10 },
                new Models.Player { Id = 91, FirstName = "Ian", LastName = "Clark", FootHeight = 6, InchHeight = 3, Weight = 175, Age = 25, PlayerPositionId = 2, TeamId = 10 },
                new Models.Player { Id = 92, FirstName = "Stephen", LastName = "Curry", FootHeight = 6, InchHeight = 3, Weight = 190, Age = 28, PlayerPositionId = 1, TeamId = 10 },
                new Models.Player { Id = 93, FirstName = "Kevin", LastName = "Durant", FootHeight = 6, InchHeight = 9, Weight = 240, Age = 28, PlayerPositionId = 3, TeamId = 10 },
                new Models.Player { Id = 94, FirstName = "Draymond", LastName = "Green", FootHeight = 6, InchHeight = 7, Weight = 230, Age = 26, PlayerPositionId = 4, TeamId = 10 },
                new Models.Player { Id = 95, FirstName = "Andre", LastName = "Iguodala", FootHeight = 6, InchHeight = 6, Weight = 215, Age = 33, PlayerPositionId = 3, TeamId = 10 },
                new Models.Player { Id = 96, FirstName = "Damian", LastName = "Jones", FootHeight = 7, InchHeight = 0, Weight = 245, Age = 21, PlayerPositionId = 5, TeamId = 10 },
                new Models.Player { Id = 97, FirstName = "Shaun", LastName = "Livingston", FootHeight = 6, InchHeight = 7, Weight = 192, Age = 31, PlayerPositionId = 1, TeamId = 10 },
                new Models.Player { Id = 98, FirstName = "Kevon", LastName = "Looney", FootHeight = 6, InchHeight = 9, Weight = 220, Age = 21, PlayerPositionId = 3, TeamId = 10 },
                new Models.Player { Id = 99, FirstName = "James", LastName = "Michael McAdoo", FootHeight = 6, InchHeight = 9, Weight = 240, Age = 24, PlayerPositionId = 3, TeamId = 10 },
                new Models.Player { Id = 100, FirstName = "Patrick", LastName = "McCaw", FootHeight = 6, InchHeight = 7, Weight = 185, Age = 21, PlayerPositionId = 2, TeamId = 10 },
                new Models.Player { Id = 101, FirstName = "JaVale", LastName = "McGee", FootHeight = 7, InchHeight = 0, Weight = 270, Age = 29, PlayerPositionId = 5, TeamId = 10 },
                new Models.Player { Id = 102, FirstName = "Zaza", LastName = "Pachulia", FootHeight = 6, InchHeight = 11, Weight = 275, Age = 33, PlayerPositionId = 5, TeamId = 10 },
                new Models.Player { Id = 103, FirstName = "Klay", LastName = "Thompson", FootHeight = 6, InchHeight = 7, Weight = 215, Age = 27, PlayerPositionId = 2, TeamId = 10 },
                new Models.Player { Id = 104, FirstName = "David", LastName = "West", FootHeight = 6, InchHeight = 9, Weight = 250, Age = 36, PlayerPositionId = 4, TeamId = 10 }

                );

            context.HistoricalPlayers.AddOrUpdate(m => m.Id,
                 new Models.HistoricalPlayer { Id = 1, FirstName = "Matthew", LastName = "Dellavedova", FootHeight = 6, InchHeight = 4, Weight = 198, Age = 25, PlayerPositionId = 1, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 2, FirstName = "Channing", LastName = "Frye", FootHeight = 6, InchHeight = 11, Weight = 255, Age = 32, PlayerPositionId = 4, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 3, FirstName = "Kyrie", LastName = "Irving", FootHeight = 6, InchHeight = 3, Weight = 193, Age = 24, PlayerPositionId = 1, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 4, FirstName = "LeBron", LastName = "James", FootHeight = 6, InchHeight = 8, Weight = 250, Age = 31, PlayerPositionId = 3, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 5, FirstName = "Richard", LastName = "Jefferson", FootHeight = 6, InchHeight = 7, Weight = 233, Age = 35, PlayerPositionId = 3, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 6, FirstName = "Dahntay", LastName = "Jones", FootHeight = 6, InchHeight = 6, Weight = 225, Age = 35, PlayerPositionId = 2, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 7, FirstName = "James", LastName = "Jones", FootHeight = 6, InchHeight = 8, Weight = 218, Age = 35, PlayerPositionId = 3, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 8, FirstName = "Sasha", LastName = "Kaun", FootHeight = 6, InchHeight = 11, Weight = 250, Age = 30, PlayerPositionId = 5, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 9, FirstName = "Kevin", LastName = "Love", FootHeight = 6, InchHeight = 10, Weight = 251, Age = 27, PlayerPositionId = 4, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 10, FirstName = "Jordan", LastName = "McRae", FootHeight = 6, InchHeight = 5, Weight = 179, Age = 25, PlayerPositionId = 2, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 11, FirstName = "Timofey", LastName = "Mozgov", FootHeight = 7, InchHeight = 1, Weight = 275, Age = 29, PlayerPositionId = 5, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 12, FirstName = "Iman", LastName = "Shumpert", FootHeight = 6, InchHeight = 5, Weight = 220, Age = 25, PlayerPositionId = 2, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 13, FirstName = "J.R.", LastName = "Smith", FootHeight = 6, InchHeight = 6, Weight = 225, Age = 30, PlayerPositionId = 2, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 14, FirstName = "Tristan", LastName = "Thompson", FootHeight = 6, InchHeight = 9, Weight = 238, Age = 25, PlayerPositionId = 4, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 15, FirstName = "Mo", LastName = "Williams", FootHeight = 6, InchHeight = 1, Weight = 198, Age = 33, PlayerPositionId = 1, HistoricalTeamId = 1 },
                 new Models.HistoricalPlayer { Id = 16, FirstName = "Leandro", LastName = "Barbosa", FootHeight = 6, InchHeight = 3, Weight = 194, Age = 32, PlayerPositionId = 2, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 17, FirstName = "Harrison", LastName = "Barnes", FootHeight = 6, InchHeight = 8, Weight = 210, Age = 22, PlayerPositionId = 3, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 18, FirstName = "Andrew", LastName = "Bogut", FootHeight = 7, InchHeight = 0, Weight = 260, Age = 30, PlayerPositionId = 5, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 19, FirstName = "Stephen", LastName = "Curry", FootHeight = 6, InchHeight = 3, Weight = 190, Age = 26, PlayerPositionId = 1, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 20, FirstName = "Festus", LastName = "Ezeli", FootHeight = 6, InchHeight = 11, Weight = 255, Age = 25, PlayerPositionId = 5, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 21, FirstName = "Draymond", LastName = "Green", FootHeight = 6, InchHeight = 7, Weight = 230, Age = 24, PlayerPositionId = 4, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 22, FirstName = "Justin", LastName = "Holiday", FootHeight = 6, InchHeight = 6, Weight = 215, Age = 25, PlayerPositionId = 2, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 23, FirstName = "Andre", LastName = "Iguodala", FootHeight = 6, InchHeight = 6, Weight = 215, Age = 31, PlayerPositionId = 3, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 24, FirstName = "Ognjen", LastName = "Kuzmic", FootHeight = 7, InchHeight = 1, Weight = 251, Age = 24, PlayerPositionId = 5, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 25, FirstName = "David", LastName = "Lee", FootHeight = 6, InchHeight = 9, Weight = 245, Age = 31, PlayerPositionId = 4, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 26, FirstName = "Shaun", LastName = "Livingston", FootHeight = 6, InchHeight = 7, Weight = 192, Age = 29, PlayerPositionId = 1, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 27, FirstName = "James", LastName = "Michael McAdoo", FootHeight = 6, InchHeight = 9, Weight = 230, Age = 22, PlayerPositionId = 4, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 28, FirstName = "Brandon", LastName = "Rush", FootHeight = 6, InchHeight = 6, Weight = 220, Age = 29, PlayerPositionId = 2, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 29, FirstName = "Marreese", LastName = "Speights", FootHeight = 6, InchHeight = 10, Weight = 255, Age = 27, PlayerPositionId = 5, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 30, FirstName = "Klay", LastName = "Thompson", FootHeight = 6, InchHeight = 7, Weight = 215, Age = 24, PlayerPositionId = 2, HistoricalTeamId = 2 },
                 new Models.HistoricalPlayer { Id = 31, FirstName = "Aron", LastName = "Baynes", FootHeight = 6, InchHeight = 10, Weight = 260, Age = 27, PlayerPositionId = 5, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 32, FirstName = "Marco", LastName = "Belinelli", FootHeight = 6, InchHeight = 5, Weight = 210, Age = 28, PlayerPositionId = 2, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 33, FirstName = "Matt", LastName = "Bonner", FootHeight = 6, InchHeight = 10, Weight = 235, Age = 34, PlayerPositionId = 4, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 34, FirstName = "Austin", LastName = "Daye", FootHeight = 6, InchHeight = 11, Weight = 220, Age = 25, PlayerPositionId = 3, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 35, FirstName = "Boris", LastName = "Diaw", FootHeight = 6, InchHeight = 8, Weight = 250, Age = 32, PlayerPositionId = 4, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 36, FirstName = "Tim", LastName = "Duncan", FootHeight = 6, InchHeight = 11, Weight = 250, Age = 37, PlayerPositionId = 4, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 37, FirstName = "Manu", LastName = "Ginobili", FootHeight = 6, InchHeight = 6, Weight = 205, Age = 36, PlayerPositionId = 2, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 38, FirstName = "Danny", LastName = "Green", FootHeight = 6, InchHeight = 6, Weight = 215, Age = 26, PlayerPositionId = 2, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 39, FirstName = "Damion", LastName = "James", FootHeight = 6, InchHeight = 7, Weight = 225, Age = 26, PlayerPositionId = 3, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 40, FirstName = "Cory", LastName = "Joseph", FootHeight = 6, InchHeight = 3, Weight = 190, Age = 22, PlayerPositionId = 1, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 41, FirstName = "Kawhi", LastName = "Leonard", FootHeight = 6, InchHeight = 7, Weight = 230, Age = 22, PlayerPositionId = 3, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 42, FirstName = "Patty", LastName = "Mills", FootHeight = 6, InchHeight = 0, Weight = 185, Age = 25, PlayerPositionId = 1, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 43, FirstName = "Tony", LastName = "Parker", FootHeight = 6, InchHeight = 2, Weight = 185, Age = 31, PlayerPositionId = 1, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 44, FirstName = "Jeff", LastName = "Ayres", FootHeight = 6, InchHeight = 10, Weight = 240, Age = 26, PlayerPositionId = 4, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 45, FirstName = "Tiago", LastName = "Splitter", FootHeight = 6, InchHeight = 11, Weight = 245, Age = 29, PlayerPositionId = 5, HistoricalTeamId =  3 },
                 new Models.HistoricalPlayer { Id = 46, FirstName = "Ray", LastName = "Allen", FootHeight = 6, InchHeight = 5, Weight = 205, Age = 37, PlayerPositionId = 2, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 47, FirstName = "Chris", LastName = "Anderson", FootHeight = 6, InchHeight = 10, Weight = 245, Age = 34, PlayerPositionId = 5, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 48, FirstName = "Joel", LastName = "Anthony", FootHeight = 6, InchHeight = 9, Weight = 245, Age = 30, PlayerPositionId = 5, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 49, FirstName = "Shane", LastName = "Battier", FootHeight = 6, InchHeight = 8, Weight = 220, Age = 34, PlayerPositionId = 3, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 50, FirstName = "Chris", LastName = "Bosh", FootHeight = 6, InchHeight = 11, Weight = 235, Age = 29, PlayerPositionId = 4, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 51, FirstName = "Mario", LastName = "Chalmers", FootHeight = 6, InchHeight = 2, Weight = 190, Age = 26, PlayerPositionId = 1, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 52, FirstName = "Norris", LastName = "Cole", FootHeight = 6, InchHeight = 2, Weight = 175, Age = 24, PlayerPositionId = 1, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 53, FirstName = "Udonis", LastName = "Haslem", FootHeight = 6, InchHeight = 8, Weight = 235, Age = 32, PlayerPositionId = 4, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 54, FirstName = "Juwan", LastName = "Howard", FootHeight = 6, InchHeight = 9, Weight = 240, Age = 40, PlayerPositionId = 4, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 55, FirstName = "LeBron", LastName = "James", FootHeight = 6, InchHeight = 8, Weight = 250, Age = 28, PlayerPositionId = 3, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 56, FirstName = "James", LastName = "Jones", FootHeight = 6, InchHeight = 8, Weight = 218, Age = 32, PlayerPositionId = 3, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 57, FirstName = "Rashard", LastName = "Lewis", FootHeight = 6, InchHeight = 10, Weight = 235, Age = 33, PlayerPositionId = 3, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 58, FirstName = "Mike", LastName = "Miller", FootHeight = 6, InchHeight = 8, Weight = 218, Age = 33, PlayerPositionId = 2, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 59, FirstName = "Jarvis", LastName = "Varnado", FootHeight = 6, InchHeight = 9, Weight = 230, Age = 25, PlayerPositionId = 4, HistoricalTeamId =  4 },
                 new Models.HistoricalPlayer { Id = 60, FirstName = "Dwyane", LastName = "Wade", FootHeight = 6, InchHeight = 4, Weight = 220, Age = 31, PlayerPositionId = 2, HistoricalTeamId =  4 }
                );
//                         G GS  MP  FG  FGA  FG%  3P  3PA  3P% 2P  2PA    2P% FT  FTA  FT% ORB DRB TRB AST STL BLK TOV  PTS/G
//Giannis Antetokounmpo   58 58 35.5 8.4 15.9 .526 0.7 2.5 .276 7.7 13.4  .573 5.8 7.4 .787 1.9 6.8 8.6 5.4 1.7 1.9 3.1  23.2
//Jabari Parker           51 50 33.9 7.8 16.0 .490 1.3 3.5 .365 6.5 12.5  .525 3.2 4.3 .743 1.5 4.6 6.1 2.8 1.0 0.4 1.8  20.1
//Tony Snell              58 58 28.7 2.9  6.4 .455 1.7 4.4 .398 1.2  2.1  .575 0.5 0.7 .769 0.3 2.9 3.2 1.2 0.5 0.2 0.6   8.1
//Matthew Dellavedova     54 46 26.5 2.7  7.0 .388 0.9 2.7 .338 1.8  4.2  .421 1.1 1.3 .806 0.3 1.7 2.0 5.2 0.8 0.0 1.8   7.4
//Malcolm Brogdon         59 13 25.7 3.6  8.2 .444 1.0 2.4 .423 2.6  5.8  .453 1.5 1.7 .845 0.6 2.1 2.6 4.2 1.2 0.1 1.6   9.8
//Khris Middleton          7  1 23.1 3.9  8.7 .443 1.0 1.7 .583 2.9  7.0  .408 2.7 3.1 .864 0.3 3.0 3.3 3.6 1.1 0.1 1.6  11.4
//Greg Monroe             58  0 22.0 4.6  8.7 .530 0.0 0.0 .000 4.6  8.7  .532 2.3 3.1 .736 2.0 4.7 6.7 2.3 1.3 0.5 1.6  11.5
//John Henson             49 38 20.0 2.8  5.4 .511 0.0 0.0 .000 2.8  5.4  .513 1.4 2.0 .707 1.4 3.7 5.1 1.1 0.6 1.3 1.0   7.0
//Jason Terry             51  0 17.3 1.3  3.0 .418 0.9 2.2 .429 0.3  0.8  .390 0.3 0.4 .778 0.2 0.9 1.2 1.3 0.5 0.3 0.5   3.7
//Michael Beasley         50  5 17.1 4.0  7.3 .544 0.3 0.8 .421 3.6  6.5  .558 1.4 2.0 .727 0.7 2.9 3.6 1.0 0.5 0.5 1.3   9.7
//Mirza Teletovic         49  2 15.9 2.2  5.9 .376 1.5 4.3 .347 0.7  1.6  .455 0.6 0.7 .778 0.2 2.1 2.3 0.7 0.1 0.2 0.7   6.5
//Rashad Vaughn           27  1 11.1 1.3  3.7 .350 0.7 2.2 .339 0.6  1.5  .366 0.0 0.1 .500 0.0 1.2 1.3 0.4 0.5 0.2 0.3   3.4
//Miles Plumlee           32 12  9.7 0.9  2.1 .441 0.0      0.0 0.9  2.1  .441 0.7 1.1 .629 0.7 0.9 1.7 0.6 0.3 0.3 0.7   2.6
//Thon Maker              34 11  7.7 1.2  2.6 .471 0.6 1.1 .513 0.6  1.4  .438 0.5 0.8 .630 0.5 1.1 1.6 0.2 0.2 0.4 0.3   3.5
//Axel Toupane             1  0  5.0 0.0  1.0 .000 0.0 1.0 .000 0.0        0.0 0.0      0.0 0.0 0.0 0.0 0.0 0.0 0.0 0.0   0.0
//Steve Novak              8  0  2.8 0.3  0.9 .286 0.1 0.8 .167 0.1  0.1 1.000 0.0      0.0 0.0 0.4 0.4 0.0 0.0 0.0 0.0   0.6
        }
    }
}
