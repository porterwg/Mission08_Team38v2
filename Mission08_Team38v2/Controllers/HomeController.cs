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

    [HttpGet]
    public IActionResult Quadrants()
    {
        return View();
    }
    
}