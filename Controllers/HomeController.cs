using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using A2.Data;

public class HomeController : Controller
{
    private GameDbContext db = new GameDbContext();

    public ActionResult Index()
    {
        // Fetch 3 random games from the database
        var randomGames = db.Games.OrderBy(r => Guid.NewGuid()).Take(3).ToList();
        return View(randomGames);
    }

    public ActionResult About()
    {
        ViewBag.Message = "About page.";

        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Contact page.";

        return View();
    }

}
