using Microsoft.AspNetCore.Mvc;
using Mission08_Team38v2.Models;
using System.Linq;

namespace Mission08_Team38v2.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repo;

        // Constructor
        public TaskController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // Quadrants View
        public IActionResult Quadrants()
        {
            var tasks = _repo.GetAllTasks();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _repo.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Quadrants");
            }

            ViewBag.Categories = _repo.GetCategories();
            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null) return NotFound();

            ViewBag.Categories = _repo.GetCategories();
            return View(task);
        }

        // Edit Task
        [HttpPost]
        public IActionResult Edit(int id, Task updatedTask)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _repo.GetCategories();
                return View(updatedTask);
            }
            
            _repo.UpdateTask(id, updatedTask);

            if (Request.Headers["X-Requested_With"] == "XMLHttpRequest")
            {
                return Json(new { success = true });
            }

            return RedirectToAction("Quadrants");
        }

        // Delete Task
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repo.DeleteTask(id);
            return Json(new { success = true });
        }

        // Mark as Completed
        public IActionResult Complete(int id)
        {
            _repo.MarkAsCompleted(id);
            return RedirectToAction("Quadrants");
        }
    }
}