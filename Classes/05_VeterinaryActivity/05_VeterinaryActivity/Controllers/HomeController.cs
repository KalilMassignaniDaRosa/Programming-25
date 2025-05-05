using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _05_VeterinaryActivity.Models;
using System.Reflection;
using _05_VeterinaryActivity.Models.System;

namespace _05_VeterinaryActivity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ClassInfoService _classInfoService = new ClassInfoService();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var classesInfo = new List<ClassInfo>
        {
              _classInfoService.GetClassInfo(typeof(Address)),
              _classInfoService.GetClassInfo(typeof(Animal)),
              _classInfoService.GetClassInfo(typeof(Client)),
              _classInfoService.GetClassInfo(typeof(Doctor)),
              _classInfoService.GetClassInfo(typeof(Person)),
              _classInfoService.GetClassInfo(typeof(Service)),
              _classInfoService.GetClassInfo(typeof(VetClinic))
        };

        return View(classesInfo);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
