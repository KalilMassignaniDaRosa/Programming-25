
using Microsoft.AspNetCore.Mvc;
using Repository;
using PooModel;

namespace _06_Poo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private ProductRepository? _ProductRepository;

        public ProductController(IWebHostEnvironment environment)
        {
            _ProductRepository = new ProductRepository();
            _environment = environment;
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

        [HttpGet]
        public IActionResult ExportDelimitatedProduct()
        {
            string fileContent = string.Empty;
            foreach (Product p in ProductData.Products)
            {
                fileContent += $"{p.Id};{p.Name};{p.Description};{p.CurrentPrice}\n";
            }

            var path = Path.Combine(
                _environment.WebRootPath,
                "TextFiles/Product"
            );

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            var filepath = Path.Combine(
                path,
                "DelimitatedProduct.txt"
            );

            if (!System.IO.File.Exists(filepath))
            {
                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.Write(fileContent);
                }
            }

            return View("Export");
        }
    }
}
