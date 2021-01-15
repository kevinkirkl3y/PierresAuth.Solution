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
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly PierresAuthContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public FlavorsController(UserManager<ApplicationUser> userManager, PierresAuthContext db)
    {
      _db = db;
      _userManager = userManager;
    }
    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }
    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors
      .Include(x => x.Treats)
      .ThenInclude(join => join.Treat)
      .FirstOrDefault(x => x.FlavorId == id);
      return View(thisFlavor);
    }
    public ActionResult Create()
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatType");
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor, int TreatId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      _db.Flavors.Add(flavor);
      if (TreatId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatType");
      return View(thisFlavor);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(Flavor flavor, int TreatId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      if (TreatId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
      }
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatType");
      return View(thisFlavor);
    }
    [HttpPost]
    public async Task<ActionResult> AddTreat(Flavor flavor, int TreatId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      if(TreatId != 0 )
      {
        _db.FlavorTreats.Add( new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      return View(thisFlavor);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(Flavor flavor, int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<ActionResult> DeleteTreat(Flavor flavor, int joinId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(x => x.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}