using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeekDay.Models;

namespace WeekDay.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(int number = 0) // Valor padrao
    {
        WeekDayModel wday = new();
        string day = (number == 0) ? "" : wday.NumberToDay(number); 

        @ViewBag.DayName = day;

        return View();
    }

    [HttpGet]
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
