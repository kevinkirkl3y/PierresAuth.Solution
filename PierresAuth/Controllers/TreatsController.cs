using Microsoft.AspNetCore.Mvc;
using PierresAuth.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresAuth.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresAuthContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, PierresAuthContext db)
    {
      _db = db;
      _userManager = userManager;
    }
    public ActionResult Index()
    {
      return View(_db.Treats.ToList());
    }
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
      .Include(treat => treat.Flavors)
      .ThenInclude(join => join.Flavor)
      .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorType");
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Treat treat, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      _db.Treats.Add(treat);
      if (FlavorId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorType");
      return View(thisTreat);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(Treat treat, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      if (FlavorId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddFlavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorType");
      return View(thisTreat);
    }
    [HttpPost]
    public async Task<ActionResult> AddFlavor(Treat treat, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      if(FlavorId != 0 )
      {
        _db.FlavorTreats.Add( new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      return View(thisTreat);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(Treat treat, int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<ActionResult> DeleteFlavor(Treat treat, int joinId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(x => x.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}