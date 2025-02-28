using Microsoft.AspNetCore.Mvc;
using Mission08_Team38v2.Models;

namespace Mission08_Team38v2.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        // Constructor
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // Quadrants View
        public IActionResult Quadrants()
        {
            var tasks = _taskRepository.GetAllTasks();
            return View(tasks);
        }

        // Edit Task
        [HttpPost]
        public IActionResult Edit(int id, Task updatedTask)
        {
            _taskRepository.UpdateTask(id, updatedTask);
            return Json(new { success = true });
        }

        // Delete Task
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _taskRepository.DeleteTask(id);
            return Json(new { success = true });
        }

        // Mark as Completed
        public IActionResult Complete(int id)
        {
            _taskRepository.MarkAsCompleted(id);
            return RedirectToAction("Quadrants");
        }
    }
}