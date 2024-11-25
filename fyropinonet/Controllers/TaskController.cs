using fyropinonet.Controllers.Data;
using fyropinonet.DataTransferObjects;
using fyropinonet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Task = fyropinonet.Models.Task;

namespace fyropinonet.Controllers;

public class TaskController : Controller
{
    private readonly ApplicationDBContext _context;
    
    public TaskController(ApplicationDBContext context)
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
        List<Task> tasks = _context.Tasks.Include(t => t.Contractors).ToList();

        return View(tasks);
    }
    
    [HttpGet]
    public IActionResult Calendar()
    {
        return View();
    }

    [HttpGet] 
    public IActionResult FetchCalendarData()
    {
        var model = new List<FullCalendarEvent>();
        
        List<Task> tasks = _context.Tasks.Include(t => t.Contractors).ToList();

        foreach (var task in tasks)
        {
            model.Add(new FullCalendarEvent(task.Id, task.Name, task.StartDate, task.EndDate));
        }
        
        return new JsonResult(model);
    }

    [HttpGet]
    public IActionResult Add()
    {

        List<Contractor> Contractors = _context.Contractors.ToList();
        
        List<SelectListItem> ContractorsSelectListItems = new List<SelectListItem>();

        foreach (var contractor in Contractors)
        {
            ContractorsSelectListItems.Add(new SelectListItem
            {
                Text = contractor.ShortName,
                Value = contractor.Id.ToString()
            });
        }
        
        var model = new AddTaskViewModel(ContractorsSelectListItems);
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTaskViewModel viewModel)
    {
        
        List<string> selectedContractorIdList = viewModel.SelectedContractorIdList;
        
        var task = new Task()
        {
            Name = viewModel.Name,
            StartDate = viewModel.StartDate,
            EndDate = viewModel.EndDate,
        };

        foreach (var selectedContractorId in selectedContractorIdList)
        {
            task.Contractors.Add(_context.Contractors.SingleOrDefault(c => c.Id == int.Parse(selectedContractorId)));
        }
        
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("List");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task is not null)
        {
            return View(task);
        }
        else
        {
            return RedirectToAction("List");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Task taskViewModel)
    {
        var task = await _context.Tasks.FindAsync(taskViewModel.Id);

        if (task is not null)
        {
            
            task.Name = taskViewModel.Name;
            task.StartDate = taskViewModel.StartDate;
            task.EndDate = taskViewModel.EndDate;
            
            await _context.SaveChangesAsync();
        }
        
        return RedirectToAction("List");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Task taskViewModel)
    {
        var task = await _context.Tasks.FindAsync(taskViewModel.Id);

        if (task is not null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        
        return RedirectToAction("List");
    }
}