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
            matrixTTT[0, 0] = A00;
            matrixTTT[0, 1] = A01;
            matrixTTT[0, 2] = A02;

            matrixTTT[1, 0] = A10;
            matrixTTT[1, 1] = A11;
            matrixTTT[1, 2] = A12;

            matrixTTT[2, 0] = A20;
            matrixTTT[2, 1] = A21;
            matrixTTT[2, 2] = A22;

            return View();
        }
    }
}
