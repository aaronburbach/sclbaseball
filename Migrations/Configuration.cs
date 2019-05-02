namespace SclBaseball.Migrations
{
    using SclBaseball.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SclBaseball.Data.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SclBaseball.Data.GameContext context)
        {
            // TODO: Your Migrations Seed method inserts test data. If you were deploying to a production environment, you would have to change the Seed method so that it only inserts data that you want to be inserted into your production database. 
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method  to avoid creating duplicate seed data.
            //var games = new List<Game>
            //{
            //    new Game { ScheduledDate = new DateTime(2015, 5, 17), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Crofton", AwayTeam = "Yankton", Location = "Crofton", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = true, RadioStation = "KVTK", IsLeagueGame = true },
            //    new Game { ScheduledDate = new DateTime(2015, 5, 17), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Lesterville", AwayTeam = "Yankton", Location = "Lesterville", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = false, RadioStation = null, IsLeagueGame = true },
            //    new Game { ScheduledDate = new DateTime(2015, 5, 17), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Irene", AwayTeam = "Freeman", Location = "Irene", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = false, RadioStation = null, IsLeagueGame = true },
            //    new Game { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Crofton", AwayTeam = "Freeman", Location = "Crofton", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = true, RadioStation = "KVHT", IsLeagueGame = true },
            //    new Game { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Irene", AwayTeam = "Lesterville", Location = "Irene", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = false, RadioStation = null, IsLeagueGame = true },
            //    new Game { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Wynot", AwayTeam = "Tabor", Location = "Wynot", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = false, RadioStation = null, IsLeagueGame = true },
            //    new Game { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Yankton", AwayTeam = "Scotland", Location = "Yankton", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = false, RadioStation = null, IsLeagueGame = true },
            //    new Game { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Freeman", AwayTeam = "Larchwood", Location = "Freeman", InningsPlayed = 0, HomeScore = 0, AwayScore = 0, IsOnRadio = false, RadioStation = null, IsLeagueGame = false }
            //};
            //games.ForEach(g => context.Games.AddOrUpdate(p => new { p.ScheduledDate, p.HomeTeam, p.AwayTeam, p.Location }, g));
            //context.SaveChanges();
        }
    }
}
