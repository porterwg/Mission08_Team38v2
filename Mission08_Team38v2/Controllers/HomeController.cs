using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team38v2.Models;

namespace Mission08_Team38v2.Controllers;

public class HomeController : Controller
{
    // private repo _repo;
    //
    // public HomeController(repo temp)
    // {
    //     _repo = temp;
    // }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> TaskQuandrants()
    {
        var tasks = await _repo.Tasks.Where(t => !t.IsCompleted).ToListAsync();
        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> SaveTask(TaskModel task)
    {
        if (ModelState.IsValid)
        {
            if (task.TaskId == 0)
            {
                _repo.Tasks.Add(task);
            }
            else
            {
                _repo.Tasks.Update(task);
            }

            await _repo.SaveChangesAsync();
            return RedirectToAction("TaskQuandrants");
        }

        return View("AddEdit", task);
    }

    [HttpPost]
    public async Task<IActionResult> Complete(int id)
    {
        var task = await _repo.Tasks.FindAsync(id);
        if (task != null)
        {
            task.IsCompleted = true;
            await _repo.SaveChangesAsync();
        }
        return RedirectToAction("TaskQuandrants");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _repo.Tasks.FindAsync(id);
        if (task != null)
        {
            _repo.Tasks.Remove(task);
            await _repo.SaveChangesAsync();
        }
        return RedirectToAction("TaskQuandrants");
    }

    [HttpGet]
    public IActionResult AddEdit(int? id)
    {
        if (id == null)
        {
            return View(new TaskModel());
        }

        var task = _repo.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost]
    public IActionResult SaveTask(TaskModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("AddEdit", model);
        }

        if (model.TaskID == 0)
        {
            _repo.Tasks.Add(model);
        }
        else
        {
            var existingTAsk = _repo.Tasks.Find(model.TaskId);
            if (existingTask != null)
            {
                existingTask.Task = model.Task;
                existingTask.DueDate = model.DueDate;
                existingTask.Quadrant = model.Quadrant;
                existingTask.Category = model.Category;
                existingTask.IsCompleted = model.IsCompleted;
            }
        }

        _repo.SaveChange();
        return RedirectToAction("Quandrants");
    }
    
}