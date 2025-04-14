using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _04_Recursion.Models;

namespace _04_Recursion.Controllers;

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
    public string PrintNaturalFor(int n = 10)
    {
        string returnString = string.Empty;
        int i = 1;

        while(i <= n)
        {
            returnString += $"{i} ";
            i++;
        }

        return returnString;
    }

    [HttpGet]
    public string PrintNaturalRecursion(int count = 10)
    {
        string returnString = string.Empty;

        returnString = NaturalNumberRecursion(1, count);

        return returnString;
    }

    private string NaturalNumberRecursion(int n, int count)
    {
        string ret = string.Empty;

        // Caso base: Se o contador for menor 
        if (count <= 1)
            return $"{n} ";

        ret += $"{n} ";
        count--; // Decrementa count

        // Chamada recursiva: Incrementa n e decrementa count 
        // Para imprimir o numero
        ret += NaturalNumberRecursion(n + 1, count);

        return ret;
    }
}
