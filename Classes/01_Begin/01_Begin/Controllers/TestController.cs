using Microsoft.AspNetCore.Mvc;

namespace _01_Begin.Controllers
{
    public class Result
    {
        public string Text = string.Empty;
    }
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(
                ILogger<TestController> logger
            )
        {
            _logger = logger;
        }

        // Deixando explicito
        [HttpGet]
        // E uma interface com varios resultados
        // Por padrao ja e get
        public IActionResult Index()
        {
            return View("Index", new Result());
        }

        [HttpPost]
        public IActionResult Index(string myText)
        {
            Result myResult = new Result();
            myResult.Text = myText.ToUpper();

            return View("Index", myResult);
        }
         
    }
}