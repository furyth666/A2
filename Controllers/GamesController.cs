using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using A2.Data;
using A2.Models;

namespace A2.Controllers
{
    public class GamesController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Games
        public ActionResult Index(string search, string sortOrder, string gameType, string developer)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "name_desc" ? "name" : "name_desc";
            ViewBag.DateSortParm = sortOrder == "date_desc" ? "Date" : "date_desc";
            ViewBag.RatingSortParm = sortOrder == "rating_desc" ? "Rating" : "rating_desc";
            ViewBag.GameTypeFilter = new SelectList(db.GameTypes, "Name", "Name");
            ViewBag.DeveloperFilter = new SelectList(db.Games.Select(g => g.Developer).Distinct());

            var games = db.Games.Include(g => g.GameType).AsQueryable();

            if (!String.IsNullOrEmpty(search))
            {
                games = games.Where(g => g.Title.Contains(search));
            }

            if (!String.IsNullOrEmpty(gameType))
            {
                games = games.Where(g => g.GameType.Name == gameType);
            }

            if (!String.IsNullOrEmpty(developer))
            {
                games = games.Where(g => g.Developer == developer);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    games = games.OrderByDescending(g => g.Title);
                    break;
                case "name":
                    games = games.OrderBy(g => g.Title);
                    break;
                case "Date":
                    games = games.OrderBy(g => g.ReleaseDate);
                    break;
                case "date_desc":
                    games = games.OrderByDescending(g => g.ReleaseDate);
                    break;
                case "Rating":
                    games = games.OrderBy(g => g.Rating);
                    break;
                case "rating_desc":
                    games = games.OrderByDescending(g => g.Rating);
                    break;
                default:
                    games = games.OrderBy(g => g.Title);
                    break;
            }

            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Include(g => g.GameType).FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
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
