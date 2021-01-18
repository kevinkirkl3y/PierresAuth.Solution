using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PierresAuth.Models;

namespace PierresAuth.Controllers
{
  public class HomeController : Controller
  {
    private readonly PierresAuthContext _db;
    public HomeController(PierresAuthContext db)
    {
      _db = db;
    }
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Treat> allTreats = _db.Treats.ToList();
      List<Flavor> allFlavors = _db.Flavors.ToList();
      ViewBag.AllTreats = allTreats;
      ViewBag.allFlavors = allFlavors;
      ViewBag.Treats = _db.Treats;
      ViewBag.Flavors = _db.Flavors;
      return View();
    }
  }
}