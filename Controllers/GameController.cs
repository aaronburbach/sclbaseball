using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SclBaseball.Data;
using SclBaseball.Models;
using SclBaseball.ViewModels;
using SclBaseball.Logic.Interfaces;
using SclBaseball.Logic.Services;
using SclBaseball.Logic.Shared;
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace SclBaseball.Controllers
{
    [RequireHttps]
    public class GameController : Controller
    {
        private GameContext db = new GameContext();
        private IGameService _gameService = null;

        public GameController()
        {
            _gameService = new GameService();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index(string searchString)
        {
            var games = _gameService.GetGames(searchString);

            return View(games.OrderBy(g => g.ScheduledDate));
        }

        public ActionResult Schedule()
        {
            var games = _gameService.GetGames()
                .Where(g => g.Type == Enums.GameType.League)
                .ToList();

            var scheduledGames = new List<GameViewModel>();

            if (games.Count > 0)
            {
                games.ForEach(g => scheduledGames.Add(new GameViewModel
                {
                    ScheduledDate = g.ScheduledDate,
                    PlayedDate = g.PlayedDate,
                    InningsPlayed = g.InningsPlayed,
                    HomeTeam = g.HomeTeam,
                    HomeScore = g.HomeScore,
                    AwayTeam = g.AwayTeam,
                    AwayScore = g.AwayScore,
                    Location = g.Location,
                    CreatedDate = g.CreatedDate,
                    IsOnRadio = g.IsOnRadio,
                    RadioStation = g.RadioStation,
                    Type = g.Type,
                    GameClass = DetermineGameClass(g)
                }));
            }

            var gamesDictionary = scheduledGames.GroupBy(g => g.ScheduledDate.Date)
                .OrderBy(g => g.Key.DayOfYear)
                .ToDictionary(g => g.Key, g => g.ToList());

            var schedule = new List<ScheduleViewModel>();

            foreach (KeyValuePair<DateTime, List<GameViewModel>> entry in gamesDictionary)
            {
                schedule.Add(new ScheduleViewModel
                {
                    ScheduledDate = entry.Key,
                    ScheduledGames = entry.Value,
                    HeaderClass = entry.Value.Any(g => g.PlayedDate.HasValue) ? "game-played" : ""
                });
            }

            return View(schedule);
        }

        private string DetermineGameClass(Game g)
        {
            // Icky business rule ... InningsPlayed == -1 == game is postponed
            return g.PlayedDate.HasValue ? "game-played" : g.InningsPlayed == -1 ? "game-postponed" : "";
        }

        public ActionResult Postseason()
        {
            return View();
        }

        public ActionResult Standings()
        {
            var standings = new List<StandingsViewModel>();

            var results = new Dictionary<string, List<Game>>
            {
                { "Crofton", null },
                { "Freeman", null },
                { "Lesterville", null },
                { "Menno", null },
                { "Tabor", null },
                { "Wynot", null },
                { "Yankton Tappers", null }
            };

            var keys = new List<string>(results.Keys);

            var allGames = _gameService.GetGames();

            foreach (var key in keys)
            {
                results[key] = allGames.Where(g => g.HomeTeam == key || g.AwayTeam == key).ToList();
            }

            foreach (var result in results)
            {
                var teamGames = result.Value;
                var teamHomeWins = teamGames.Where(g => g.HomeTeam == result.Key && g.PlayedDate != null && g.HomeScore > g.AwayScore).Count();
                var teamHomeLosses = teamGames.Where(g => g.AwayTeam == result.Key && g.PlayedDate != null && g.AwayScore > g.HomeScore).Count();
                var teamAwayWins = teamGames.Where(g => g.HomeTeam == result.Key && g.PlayedDate != null && g.AwayScore > g.HomeScore).Count();
                var teamAwayLosses = teamGames.Where(g => g.AwayTeam == result.Key && g.PlayedDate != null && g.HomeScore > g.AwayScore).Count();
                var teamHomeRunsScored = teamGames.Where(g => g.HomeTeam == result.Key && g.PlayedDate != null).Sum(r => r.HomeScore);
                var teamAwayRunsScored = teamGames.Where(g => g.AwayTeam == result.Key && g.PlayedDate != null).Sum(r => r.AwayScore);
                var teamHomeRunsAllowed = teamGames.Where(g => g.HomeTeam == result.Key && g.PlayedDate != null).Sum(r => r.AwayScore);
                var teamAwayRunsAllowed = teamGames.Where(g => g.AwayTeam == result.Key && g.PlayedDate != null).Sum(r => r.HomeScore);
                var teamGamesPlayed = teamGames.Where(g => g.PlayedDate != null && (g.HomeTeam == result.Key || g.AwayTeam == result.Key)).Count();

                standings.Add(new StandingsViewModel
                {
                    Team = result.Key,
                    TotalWins = teamHomeWins + teamHomeLosses,
                    TotalLosses = teamAwayWins + teamAwayLosses,
                    // Should this be TotalWins + TotalLosses?
                    Percentage = teamGamesPlayed > 0 ? (decimal)(teamHomeWins + teamHomeLosses) / teamGamesPlayed : 0.00m,
                    GamesBehind = 0.00m,
                    HomeWins = teamHomeWins,
                    HomeLosses = teamAwayWins,
                    AwayWins = teamHomeLosses,
                    AwayLosses = teamAwayLosses,
                    RunsScored = teamHomeRunsScored + teamAwayRunsScored,
                    RunsScoredPerGame = teamGamesPlayed > 0 ? (decimal)(teamHomeRunsScored + teamAwayRunsScored) / teamGamesPlayed : 0.00m,
                    RunsAllowed = teamHomeRunsAllowed + teamAwayRunsAllowed,
                    RunsAllowedPerGame = teamGamesPlayed > 0 ? (decimal)(teamHomeRunsAllowed + teamAwayRunsAllowed) / teamGamesPlayed : 0.00m,
                    GamesPlayed = teamGamesPlayed
                });
            }

            // Order to get the leader in wins/losses.
            //standings = standings.OrderByDescending(s => s.Percentage).ThenByDescending(s => s.TotalWins).ThenBy(s => s.TotalLosses).ToList();
            standings = standings.OrderByDescending(s => s.TotalWins).ThenBy(s => s.TotalLosses).ToList();
            var leader = standings.First();

            foreach (var s in standings)
            {
                var gamesBehind = (decimal)((leader.TotalWins - s.TotalWins) + (s.TotalLosses - leader.TotalLosses)) / 2;
                //(decimal)((leader.TotalWins - s.TotalWins) - (leader.TotalLosses - s.TotalLosses)) / 2;
                s.GamesBehind = gamesBehind < 0 ? 0 : gamesBehind;
                //s.GamesBehind = (decimal) ((leader.TotalWins - s.TotalWins) + (s.TotalLosses - leader.TotalLosses)) / 2;
            }

            // Now order for presentation.
            standings = standings.OrderBy(s => s.GamesBehind).ThenByDescending(s => s.Percentage).ThenByDescending(s => s.TotalWins).ThenBy(s => s.TotalLosses)
                //.ThenBy(s => s.Team.StartsWith("Wynot") ? 1 : 2) // Icky 2019 final standings hack
                //.ThenBy(s => s.Team.StartsWith("Scotland") ? 1 : 2) // Icky 2019 final standings hack
                //                                                    //.ThenBy(s => s.Team)
                //.ThenBy(s => s.Team.StartsWith("Tabor") ? 1 : 2) // Icky 2020 final standings hack
                //.ThenBy(s => s.Team.StartsWith("Menno") ? 1 : 2) // Icky 2020 final standings hack
                //                                                    //.ThenBy(s => s.Team)
                .ToList();

            return View(standings);
        }

        // GET: Games1/Details/5
        [HttpGet]
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games1/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduledDate,PlayedDate,InningsPlayed,HomeTeam,HomeScore,AwayTeam,AwayScore,Location,CreatedDate,IsOnRadio,RadioStation,Type")] Game game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Games.Add(game);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //TODO: Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(game);
        }

        // GET: Games1/Edit/5
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Game game)
        {
            if (game?.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var gameToUpdate = db.Games.Find(game.Id);

            var playedDate = game.PlayedDate;
            if (playedDate.HasValue)
            {
                gameToUpdate.PlayedDate = new DateTime(playedDate.Value.Year, playedDate.Value.Month, playedDate.Value.Day, playedDate.Value.Hour, playedDate.Value.Minute, 0, 0);
            }
            var createdDate = game.CreatedDate;
            gameToUpdate.CreatedDate = new DateTime(createdDate.Year, createdDate.Month, createdDate.Day, createdDate.Hour, createdDate.Minute, 0, 0);
            var scheduledDate = game.ScheduledDate;
            gameToUpdate.ScheduledDate = new DateTime(scheduledDate.Year, scheduledDate.Month, scheduledDate.Day, scheduledDate.Hour, scheduledDate.Minute, 0, 0);

            // As a best practice to prevent overposting, the fields that you want to be updateable by the Edit page are whitelisted in the TryUpdateModel parameters.
            // Currently there are no extra fields that you're protecting, but listing the fields that you want the model binder to bind ensures that if you add fields to the data model in the future, they're automatically protected until you explicitly add them here.
            if (TryUpdateModel(gameToUpdate, "", new string[] { "ScheduledDate", "PlayedDate", "InningsPlayed", "HomeTeam", "HomeScore", "AwayTeam", "AwayScore", "Location", "CreatedDate", "IsOnRadio", "RadioStation", "Type" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(gameToUpdate);
        }

        // GET: Games1/Delete/5
        [HttpGet]
        [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games1/Delete/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Game gameToDelete = new Game() { Id = id };
                db.Entry(gameToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //TODO: Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
