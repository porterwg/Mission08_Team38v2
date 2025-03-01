using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team38v2.Models;

namespace Mission08_Team38v2.Controllers;

public class HomeController : Controller
{
    private ITaskRepository _repo;

    public HomeController(ITaskRepository temp)
    {
        _repo = temp;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    
}