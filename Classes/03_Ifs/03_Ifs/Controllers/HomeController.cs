using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _03_Ifs.Models;

namespace _03_Ifs.Controllers;

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
    public string GetIf(int x)
    {
        /*
            Estrutura sintatica do If
            if(expressao booleana)
            {
                Sentenca de codigo a ser executada
                Caso a condicao seja verdadeira
            }

            Caso o if tenha apenas uma linha de comando a ser executada na 
            condicional, nao ha necessidade do uso das chaves

            if(expressao booleana)
                Apenas um comando
         */

        string stringReturn = string.Empty;
        //int x = 10;

        if (x < 9)
            stringReturn = "X is bigger than 9";

        //x = 8;
        if (x > 9)
            stringReturn = "X is bigger than 9";
        else
            stringReturn = "X is smaller than 9";

        //x = 11;
        if( x == 10)
        {
            stringReturn = "Ora ora ";
            stringReturn += "X is equal to 10";
        }
        else if( x == 9)
        {
            stringReturn = "Hmmm ";
            stringReturn += "X is equal to 9";
        }
        else if( x == 8)
        {
            stringReturn = "Bahhh ";
            stringReturn = "X is equal to 8";
        }
        else
        {
            stringReturn = "I don't know what number is X";
        }

        return stringReturn;
    }

    [HttpGet]
    public string GetSwitch(int x)
    {
        string returnString = string.Empty;
        switch(x)
        {
            case 0:
                returnString = "X equals 0";
                break;
            case 1:
                returnString = "X equals 1";
                break;
            case 2:
                returnString = "X equals 2";
                break;
            case 3:
                returnString = "X equals 3";
                break;
            default:
                returnString = "X is an unexpected number";
                break;
        }

        return returnString;
    }

    [HttpGet]
    public string GetFor(int x)
    {
        /*
            O comando de repeticao for possui a seguinte sintaxe:
            for ( <inicializador> ; <expressao condicional>; <expressao de repeticao>)
            {
                Comandos a serem executados
            }
            Inicializador: elemento contador. Tradicionalmente utilizado o i = indice;
            Expressao condicional: especifica o teste a ser verificado quando o loop estiver 
            executado o numero definido de iteracoes (flag);
            Expressao de repeticao: especifica a acao a ser executada com a variavel contadora.
            Geralmente um acumulo ou decressimo (acumulador);
         */

        string returnString = string.Empty;

        for(int i = 1; i <= x; i++)
        {
            // E se eu quisesse interromper o laco caso ele fosse maior que 5
            if (i > 50)
                break; // O comando break interrompe a laco

            // Caso eu deseje que o laco siga em frente forcando a continuar a execucao
            if (i % 2 != 0)
                continue; // Avanca para a proxima repeticao

            returnString += $"{i}; ";
        }

        return returnString;
    }

    [HttpGet]
    public string GetForEach(string color)
    {
        /*
         O comando foreach (para cada) e utilizado para iterar por uma sequencia de itens
         em uma colecao e servir como uma opcao simples de repeticao.
         */
        string[] colors = {"Red","Black","Blue","Yellow","Green","White","Navy blue","Pink","Gray"};

        string returnString = string.Empty;


        if (colors.Contains(char.ToUpper(color[0]) + color.Substring(1)))
            returnString = "The chosen color is valid\n";
        else
            returnString = "Chosen color ivalid!\n";

        foreach (string s in colors)
        {
            returnString += $" [{s}]";
        }

        return returnString;
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
