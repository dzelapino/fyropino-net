using fyropinonet.Controllers.Data;
using fyropinonet.Models;
using Microsoft.AspNetCore.Mvc;

namespace fyropinonet.Controllers;

public class ContractorController : Controller
{
    private readonly ApplicationDBContext _context;

    public ContractorController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Contractor> contractors = _context.Contractors.ToList();

        return View(contractors);
    }
}