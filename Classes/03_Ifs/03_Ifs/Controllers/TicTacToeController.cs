using Microsoft.AspNetCore.Mvc;

namespace _03_Ifs.Controllers
{
    public class TicTacToeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(
            string A00, string A01, string A02,
            string A10, string A11, string A12,
            string A20, string A21, string A22
            )
        {
            string[,] matrixTTT = new string[3, 3];
            bool xWon = false;

            matrixTTT[0, 0] = A00.ToLower();
            matrixTTT[0, 1] = A01.ToLower();
            matrixTTT[0, 2] = A02.ToLower();

            matrixTTT[1, 0] = A10.ToLower();
            matrixTTT[1, 1] = A11.ToLower();
            matrixTTT[1, 2] = A12.ToLower();

            matrixTTT[2, 0] = A20.ToLower();
            matrixTTT[2, 1] = A21.ToLower();
            matrixTTT[2, 2] = A22.ToLower();

            // Linha ganhou
            if (matrixTTT[0, 0] == matrixTTT[0, 1] && matrixTTT[0, 2] == matrixTTT[0, 0])
            {
                if (matrixTTT[0, 0].Contains('x'))
                    xWon = true;
            }
            // Coluna ganhou
            else if (matrixTTT[0, 0] == matrixTTT[1, 0] && matrixTTT[2, 0] == matrixTTT[0, 0])
            {
                if (matrixTTT[0, 0].Contains('x'))
                    xWon = true;
            }
            // Diagonal ganhou
            else if (matrixTTT[0, 0] == matrixTTT[1, 1] && matrixTTT[2, 2] == matrixTTT[0, 0])
            {
                if (matrixTTT[0, 0].Contains('x'))
                    xWon = true;
            }
            // Diagonal invertida ganhou
            else  if (matrixTTT[0, 2] == matrixTTT[1, 1] && matrixTTT[2, 0] == matrixTTT[0, 2])
            {
                string teste = matrixTTT[0, 0];
                if (matrixTTT[0, 0].Contains('x'))
                    xWon = true;
            }
            else
            {
                ViewBag.Message = "Error";
                return View();
            }

            if (xWon)
            {
                ViewBag.Message = "X Wins";
                return View();
            }else
            {
                ViewBag.Message = "O wins";
                return View();
            }
        }
    }
}
