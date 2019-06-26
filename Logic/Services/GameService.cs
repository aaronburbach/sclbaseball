using SclBaseball.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using SclBaseball.Models;
using SclBaseball.Data;

namespace SclBaseball.Logic.Services
{
    public class GameService : IGameService
    {
        private static readonly object _lock = new object();
        //object dataObject = Cache["globalData"];
        private GameContext db = new GameContext();

        public List<Game> GetGames(string term = null)
        {
            //if (dataObject == null)
            //{
            //    lock (_lock)
            //    {
            //        dataObject = Cache["globalData"];

            //        if (dataObject == null)
            //        {
            //            //Get Data from db
            //            dataObject = GlobalObj.GetData();
            //            Cache["globalData"] = dataObject;

            var games = from g in db.Games
                        where g.ScheduledDate.Year == DateTime.Now.Year
                        select g;

            //        }
            //    }
            //}

            if (!String.IsNullOrEmpty(term))
            {
                games = games.Where(s => s.HomeTeam.Contains(term) || s.AwayTeam.Contains(term));
            }

            return games.ToList();
        }
    }
}