using Microsoft.AspNetCore.Mvc;
using PooModel;
using Repository;

namespace _06_Poo.Controllers
{
    public class CostumerController : Controller
    {
        private CostumerRepository? _costumerRepository;

        public CostumerController()
        {
            _costumerRepository = new CostumerRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Costumer> costumers = _costumerRepository!.RetriveAll();

            return View(costumers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Costumer c)
        {
            _costumerRepository!.Save(c);

            List<Costumer> costumers = _costumerRepository!.RetriveAll();

            return View("Index", costumers);
        }
    }
}
