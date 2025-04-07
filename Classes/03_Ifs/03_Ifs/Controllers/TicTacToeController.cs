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
            if (string.IsNullOrWhiteSpace(A00) && string.IsNullOrWhiteSpace(A01) && string.IsNullOrWhiteSpace(A02) &&
            string.IsNullOrWhiteSpace(A10) && string.IsNullOrWhiteSpace(A11) && string.IsNullOrWhiteSpace(A12) &&
            string.IsNullOrWhiteSpace(A20) && string.IsNullOrWhiteSpace(A21) && string.IsNullOrWhiteSpace(A22))
            {
                ViewBag.Alert = "Please fill in all fields before submitting!";
                return View();
            }

            string[,] matrixTTT = new string[3, 3];

            matrixTTT[0, 0] = A00?.ToLower() ?? "";
            matrixTTT[0, 1] = A01?.ToLower() ?? "";
            matrixTTT[0, 2] = A02?.ToLower() ?? "";

            matrixTTT[1, 0] = A10?.ToLower() ?? "";
            matrixTTT[1, 1] = A11?.ToLower() ?? "";
            matrixTTT[1, 2] = A12?.ToLower() ?? "";

            matrixTTT[2, 0] = A20?.ToLower() ?? "";
            matrixTTT[2, 1] = A21?.ToLower() ?? "";
            matrixTTT[2, 2] = A22?.ToLower() ?? "";

            string winner = null!;

            // Linha ganhou
            for (int i = 0; i<3; i++)
            {
                if (!string.IsNullOrEmpty(matrixTTT[i,0]) &&
                    matrixTTT[i, 0] == matrixTTT[i, 1] &&
                     matrixTTT[i, 1] == matrixTTT[i, 2])
                {
                    winner = matrixTTT[i, 0];
                    break;
                }
            }
            // Coluna ganhou
            if (winner == null)
            {
                for (int i = 0; i <3; i++)
                {
                    if (!string.IsNullOrEmpty(matrixTTT[0, i]) &&
                        matrixTTT[0, i] == matrixTTT[1, i] &&
                        matrixTTT[1, i] == matrixTTT[2, i])
                    {
                        winner = matrixTTT[0, i];
                        break;
                    }
                }
            }
            if (winner == null)
            {
                // Diagonal ganhou
                if (!string.IsNullOrEmpty(matrixTTT[0,0]) &&
                    matrixTTT[0, 0] == matrixTTT[1, 1] &&
                    matrixTTT[1, 1] == matrixTTT[2, 2])
                {
                    winner = matrixTTT[0, 0];
                }
                else if(!string.IsNullOrEmpty(matrixTTT[0, 2]) &&
                    matrixTTT[0, 2] == matrixTTT[1, 1] &&
                    matrixTTT[1, 1] == matrixTTT[2, 0])
                {
                    winner = matrixTTT[0, 2];
                }
            }

            if (winner == null)
            {
                ViewBag.Message = "Draw";
            }
            else if (winner.Contains('x'))
            {
                ViewBag.Message = "X Wins";
            }
            else
            {
                ViewBag.Message = "O Wins";
            }

            return View();
        }
    }
}
