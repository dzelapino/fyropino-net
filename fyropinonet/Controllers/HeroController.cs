using fyropinonet.Controllers.Data;
using fyropinonet.Models;
using Microsoft.AspNetCore.Mvc;

namespace fyropinonet.Controllers;

public class HeroController : Controller
{
    private readonly ApplicationDBContext _context;

    public HeroController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Hero> heroes = _context.Heroes.ToList();
        
        return View(heroes);
    }
}