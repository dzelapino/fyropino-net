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
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddContractorViewModel viewModel)
    {

        var contractor = new Contractor()
        {
            ShortName = viewModel.ShortName,
            FullName = viewModel.FullName,
            Address = viewModel.Address,
            Color = viewModel.Color,
            Email = viewModel.Email,
            Phone = viewModel.Phone
        };

        await _context.Contractors.AddAsync(contractor);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
}