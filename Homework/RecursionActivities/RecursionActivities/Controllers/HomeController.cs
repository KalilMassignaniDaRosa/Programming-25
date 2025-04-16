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
    public IActionResult PrintNumbersDecrease(int count = 10)
    {
        string ret = string.Empty;
        ret = NumbersDecrease(1, count);

        ViewBag.Title = "Numbers Decreasing from " + count;
        ViewBag.Result = ret;

        return View("Results");
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
    public IActionResult PrintSumArithmeticSequence(int count = 10)
    {
        string ret = string.Empty;

        ret = SumArithmeticSequence(1, count, 0);

        ViewBag.Title = "Sum of Arithmetic Sequence";
        ViewBag.Result = ret;

        return View("Results");
    }

    private string SumArithmeticSequence(int n, int count,int total)
    {
        string ret = string.Empty;
        total +=  count;

        if (count < 2)
            return $"{count} \n    Total: {total}";

        ret += $"{count} ";
        count--;

        ret += SumArithmeticSequence(n + 1, count, total);

        return ret;
    }

    [HttpGet]
    public IActionResult PrintCountCharacters(string text = "Hello World")
    {
        string ret = string.Empty;

        ret = CountCharacters(text, 0, 0);

        ViewBag.Title = $"Character Count in \"{text}\"";
        ViewBag.Result = ret;

        return View("Results");
    }

    private string CountCharacters(string str, int pos, int total)
    {
        int sum = total + 1;

        if (pos >= str.Length - 1)
            return $"|{str[pos]}| = {sum}";

        string ret = $"|{str[pos]}| + ";
        ret += CountCharacters(str, pos + 1, sum);

        return ret;
    }

    [HttpGet]
    public IActionResult PrintIsPalindrome(string word = "Radar")
    {
        string lower = word.ToLower();
        string ret = $"{word} " + IsPalindrome(lower, 0, word.Length - 1);

        ViewBag.Title = "Palindrome Check";
        ViewBag.Result = ret;

        return View("Results");
    }

    private string IsPalindrome(string word, int left, int right)
    {
        // Se os indices se cruzaram e um palindromo
        if (left >= right)
            return "is a palindrome";

        if (word[left] != word[right])
            return "isn't a palindrome";

        // Se move pro meio
        return IsPalindrome(word, left + 1, right - 1);
    }
}
