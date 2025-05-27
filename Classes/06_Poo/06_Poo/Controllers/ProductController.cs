
using Microsoft.AspNetCore.Mvc;
using Repository;
using PooModel;

namespace _06_Poo.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository? _ProductRepository;

        public ProductController()
        {
            _ProductRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> Products = _ProductRepository!.RetriveAll();

            return View(Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product c)
        {
            _ProductRepository!.Save(c);

            List<Product> Products = _ProductRepository!.RetriveAll();

            return View("Index", Products);
        }
    }
}
