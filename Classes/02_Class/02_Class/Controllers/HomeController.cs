using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _02_Class.Models;

namespace _02_Class.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Index por padrao e sempre get
    [HttpGet]
    public IActionResult Index()
    {
        DataType dataType = new();
        return View(dataType);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
