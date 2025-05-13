using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GreenHouse.Models;
using GreenHouseModel;

namespace GreenHouse.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Plant _plant;

    public HomeController(ILogger<HomeController> logger, Plant plant)
    {
        _logger = logger;
        _plant = plant;
    }

    public IActionResult Index()
    {
        return View();
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
