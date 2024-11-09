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