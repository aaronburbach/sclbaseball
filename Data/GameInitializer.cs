using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SclBaseball.Models;

namespace SclBaseball.Data
{
    //public class GameInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GameContext>
    //{
    //    protected override void Seed(GameContext context)
    //    {
    //        var games = new List<Game>
    //        {
    //            new Game() { ScheduledDate = new DateTime(2015, 5, 17), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Crofton", AwayTeam = "Yankton", Location = "Crofton", InningsPlayed = 9, HomeScore = 1, AwayScore = 3 },
    //            new Game() { ScheduledDate = new DateTime(2015, 5, 17), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Lesterville", AwayTeam = "Wynot", Location = "Lesterville", InningsPlayed = 9, HomeScore = 7, AwayScore = 16 },
    //            new Game() { ScheduledDate = new DateTime(2015, 5, 17), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Irene", AwayTeam = "Freeman", Location = "Irene", InningsPlayed = 9, HomeScore = 7, AwayScore = 8 },
    //            new Game() { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Crofton", AwayTeam = "Freeman", Location = "Crofton", InningsPlayed = 9, HomeScore = 0, AwayScore = 12 },
    //            new Game() { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Irene", AwayTeam = "Lesterville", Location = "Irene", InningsPlayed = 9, HomeScore = 11, AwayScore = 6 },
    //            new Game() { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Wynot", AwayTeam = "Tabor", Location = "Wynot", InningsPlayed = 9, HomeScore = 9, AwayScore = 8 },
    //            new Game() { ScheduledDate = new DateTime(2015, 5, 21), PlayedDate = null, CreatedDate = DateTime.Now, HomeTeam = "Yankton", AwayTeam = "Scotland", Location = "Yankton", InningsPlayed = 9, HomeScore = 0, AwayScore = 12 }
    //        };

    //        games.ForEach(s => context.Games.Add(s));
    //        context.SaveChanges();
    //    }
    //}
}