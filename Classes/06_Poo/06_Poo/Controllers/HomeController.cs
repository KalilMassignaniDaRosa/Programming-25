using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _06_Poo.Models;
using PooModel;
using StackExchange.Redis;


namespace _06_Poo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private PooModel.Order _order;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Customer c1 = new();
        c1.Name = "Frodo";
        c1.ObjectCount++;
        Customer.InstanceCount++;

        var c2 = new Customer();
        c2.Name = "Galadriel";
        c2.ObjectCount++;
        Customer.InstanceCount++;

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