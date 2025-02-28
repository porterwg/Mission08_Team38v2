using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team38v2.Models;

namespace Mission08_Team38v2.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    // public IActionResult Quadrants()
    // {
    //     var tasks = _taskRepository.GetAllTAsks();
    //     return View(tasks);
    // }
}