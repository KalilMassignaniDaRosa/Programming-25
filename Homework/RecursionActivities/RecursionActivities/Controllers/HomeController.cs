using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecursionActivities.Models;

namespace RecursionActivities.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

    [HttpGet]
    public string PrintNumbersDecrease(int count = 10)
    {
        string ret = string.Empty;

        ret = NumbersDecrease(1, count);

        return ret;
    }

    private string NumbersDecrease(int n, int count)
    {
        string ret = string.Empty;

        if (count < 1)
            return $"{count} ";

        ret += $"{count} ";
        count--;

        ret += NumbersDecrease(n-1, count);

        return ret;
    }

    [HttpGet]
    public string PrintFatorial(int count = 10)
    {
        string ret = string.Empty;

        ret = Fatorial(1, count, 0);

        return ret;
    }

    private string Fatorial(int n, int count,int total)
    {
        string ret = string.Empty;
        total +=  count;

        if (count < 2)
            return $"{count} \nTotal: {total}";

        ret += $"{count} ";
        count--;

        ret += Fatorial(n + 1, count, total);

        return ret;
    }
}
