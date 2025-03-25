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
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public string WeekDay(int number)
    {
        string[] weekDaysArray = ["Sunday","Monday","Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        string result;
        number--;
        
        switch (number)
        {
            case 0:
                result = weekDaysArray[number];
                break;
            case 1:
                result = weekDaysArray[number];
                break;
            case 2:
                result = weekDaysArray[number];
                break;
            case 3:
                result = weekDaysArray[number];
                break;
            case 4:
                result = weekDaysArray[number];
                break;
            case 5:
                result = weekDaysArray[number];
                break;
            case 6:
                result = weekDaysArray[number];
                break;
            default:
                result = "Error! Insert a number between 1 and 7";
                break;
        }

        return result;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
