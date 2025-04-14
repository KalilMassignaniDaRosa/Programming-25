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

    [HttpGet]
    public string PrintNaturalNumberDescendingRecursion(int count = 10)
    {
        string returnString = string.Empty;

        returnString = NaturalNumberDescendingRecursion(1, count);

        return returnString;
    }

    private string NaturalNumberDescendingRecursion(int n, int count)
    {
        string ret = string.Empty;

        // Caso base
        if (n > count)
            return $"{count} ";

        ret += $"{count} ";
        count--;

        // Chamada recursiva
        ret += NaturalNumberDescendingRecursion(n, count);

        return ret;
    }

    [HttpGet]
    public string PrintSumArithmeticSequence(int count = 10)
    {
        string returnString = string.Empty;

        returnString = SumArithmeticSequence(1, count, 0);

        return returnString;
    }

    private string SumArithmeticSequence(int n, int count, int total)
    {
        string ret = string.Empty;
        int sum = total + n;

        if (count <= 1)
            return $"{n} = {sum} ";

        ret += $"{n} + ";
        count--;

        ret += SumArithmeticSequence(n + 1, count, sum);

        return ret;
    }

    [HttpGet]
    public string PrintCountCharacters(string text = "Hello World")
    {
        string returnString = string.Empty;

        returnString = CountCharacters(text, 0, 0);

        return returnString;
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

    public string PrintIsPalindrome(string word = "Radar")
    {
        string lower = word.ToLower();

        return $"{word} " + IsPalindrome(lower, 0, word.Length - 1);
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
