using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthendicationProject.Models;

namespace AuthendicationProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string status)
    {
        ViewBag.Status = status;
        return View();
    }

    public IActionResult Privacy(string status)
    {
        ViewBag.Status = status;
        return View();
    }

    public IActionResult Signup(string status)
    {
        ViewBag.Status = status;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

