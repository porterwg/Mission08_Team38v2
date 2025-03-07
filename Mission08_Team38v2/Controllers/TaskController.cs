//Most of the functionality in the app comes from this controller instead of the home controller
using Microsoft.AspNetCore.Mvc;
using Mission08_Team38v2.Models;
using System.Linq;
using Task = Mission08_Team38v2.Models.Task;

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
            var tasks = _repo.Tasks;
            ViewBag.Categories = _repo.Categories;
            return View(tasks);
        }

        //Add get and post routes
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _repo.Categories;
            return View("AddEdit", new Task());
        }

        [HttpPost]
        public IActionResult Add(Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Quadrants");
            }

            ViewBag.Categories = _repo.Categories;
            return View("AddEdit", task);
        }

        //Edit get route
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null) return NotFound();

            ViewBag.Categories = _repo.Categories;
            return View("AddEdit", task);
        }

        // Edit Task
        [HttpPost]
        public IActionResult Edit(int id, Task updatedTask)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _repo.Categories;
                return View("AddEdit", updatedTask);
            }

            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == updatedTask.TaskId);
            if (task == null) return NotFound();

            // Update only the fields that can be edited
            task.TaskName = updatedTask.TaskName;
            task.DueDate = updatedTask.DueDate;
            task.CategoryId = updatedTask.CategoryId;

            _repo.EditTask(task); // Save changes

            return RedirectToAction("Quadrants");
        }


        // Delete Task
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null) return NotFound();
            
            _repo.DeleteTask(task);
            return Json(new { success = true });
        }

        // Mark as Completed
        public IActionResult Complete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null) return NotFound();

            task.Completed = true;
            _repo.EditTask(task);

            return RedirectToAction("Quadrants");
        }
    }
}
