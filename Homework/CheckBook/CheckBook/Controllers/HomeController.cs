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

    public IActionResult Index(string language)
    {
        language = string.IsNullOrEmpty(language) ? "pt" : language.ToLower();

        if (language == "en")
        {
            return View("IndexEn", new CheckBookModelEn());
        }
        else
        {
            return View("IndexPt", new CheckBookModelPt());
        }
    }


    [HttpPost]
    public IActionResult Index(string language, int number)
    {
        language = string.IsNullOrEmpty(language) ? "pt" : language.ToLower();

        if (language == "en")
        {
            var modelEn = new CheckBookModelEn();
            modelEn.NumberInWords = modelEn.ConvertNumber(number); 
            return View("IndexEn", modelEn); 
        }
        else
        {
            var modelPt = new CheckBookModelPt();
            modelPt.NumberInWords = modelPt.ConvertNumber(number); 
            return View("IndexPt", modelPt);
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
