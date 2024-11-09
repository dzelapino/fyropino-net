using fyropinonet.Controllers.Data;
using fyropinonet.Models;
using Microsoft.AspNetCore.Mvc;
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
        List<Task> tasks = _context.Tasks.OrderBy(e => e.Name).ToList();

        return View(tasks);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTaskViewModel viewModel)
    {
        
        var task = new Task()
        {
            Name = viewModel.Name,
            StartDate = viewModel.StartDate,
            EndDate = viewModel.EndDate
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("List");
    }
}