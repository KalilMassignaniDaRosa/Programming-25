using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CheckBook.Models;

namespace CheckBook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new CheckBookModel());
    }

    [HttpPost]
    public IActionResult Index(int number)
    {
        CheckBookModel checkModel = new();
        string inFull = checkModel.ConvertNumber(number);
        return View("Index", checkModel);
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
