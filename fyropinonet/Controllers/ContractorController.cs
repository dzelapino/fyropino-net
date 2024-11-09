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
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult List()
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
        
        return RedirectToAction("List");
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var contractor = await _context.Contractors.FindAsync(id);

        if (contractor is not null)
        {
            return View(contractor);
        }
        else
        {
            return RedirectToAction("List");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Contractor contractorViewModel)
    {
        var contractor = await _context.Contractors.FindAsync(contractorViewModel.Id);

        if (contractor is not null)
        {
            contractor.ShortName = contractorViewModel.ShortName;
            contractor.FullName = contractorViewModel.FullName;
            contractor.Address = contractorViewModel.Address;
            contractor.Color = contractorViewModel.Color;
            contractor.Email = contractorViewModel.Email;
            contractor.Phone = contractorViewModel.Phone;
            contractor.IsActive = contractorViewModel.IsActive;
            
            await _context.SaveChangesAsync();
        }
        
        return RedirectToAction("List");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Contractor contractorViewModel)
    {
        var contractor = await _context.Contractors.FindAsync(contractorViewModel.Id);

        if (contractor is not null)
        {
            _context.Contractors.Remove(contractor);
            await _context.SaveChangesAsync();
        }
        
        return RedirectToAction("List");
    }
}