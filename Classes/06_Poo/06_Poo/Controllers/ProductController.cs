
using Microsoft.AspNetCore.Mvc;
using Repository;
using PooModel;
using System.Globalization;

namespace _06_Poo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private ProductRepository? _productRepository;

        public ProductController(IWebHostEnvironment environment)
        {
            _productRepository = new ProductRepository();
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> Products = _productRepository!.RetriveAll();

            return View(Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _productRepository!.Save(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult ExportDelimitatedProduct()
        {
            string fileContent = string.Empty;
            foreach (Product p in ProductData.Products)
            {
                fileContent += $"{p.Id};{p.Name};{p.Description};{p.CurrentPrice};\n";
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

            System.IO.File.WriteAllText(filepath, fileContent);

            return View("Export");
        }
    }
}
