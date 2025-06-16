
using Microsoft.AspNetCore.Mvc;
using Repository;
using PooModel;
using System.Globalization;
using System.Text;

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
            const string folder = "Product";
            const string fileName = "DelimitedProduct";

            foreach (Product p in ProductData.Products)
            {
                fileContent +=
                    $"{p.Id};" +
                    $"{p.Name};" +
                    $"{p.Description};" +
                    $"{p.CurrentPrice};" +
                    "\n";
            }

            SaveFile(fileContent, folder, fileName);

            ViewBag.File = new
            {
                Location = folder,
                Name = fileName + ".txt"
            };
            return View("Export");
        }

        [HttpGet]
        public IActionResult ExportFixedProduct()
        {
            string fileContent = string.Empty;
            string fileLocation = "Product";
            string fileName = "FixedProduct";

            foreach (Product p in ProductData.Products)
            {
                fileContent +=
                    String.Format("{0,-5}", p.Id) +
                    String.Format("{0,-30}", p.Name) +
                    String.Format("{0,-50}", p.Description) +
                    String.Format("{0,10:F2}", p.CurrentPrice) + // duas casas apos ,
                    "\n";
            }

            SaveFile(fileContent, fileLocation, fileName);

            ViewBag.File = new
            {
                Location = fileLocation,
                Name = fileName + ".txt"
            };
            return View("Export");
        }

        private bool SaveFile(string content, string fileLocation, string fileName)
        {
            if (string.IsNullOrEmpty(content)
             || string.IsNullOrEmpty(fileLocation)
             || string.IsNullOrEmpty(fileName))
                return false;

            var path = Path.Combine(_environment.WebRootPath,
                                    "TextFiles",
                                    fileLocation);
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var fullPath = Path.Combine(path, fileName + ".txt");
                System.IO.File.WriteAllText(fullPath, content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            Product product = _productRepository!.Retrieve(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null || id.Value <= 0)
                return NotFound();

            if (!_productRepository!.DeleteById(id.Value))
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}
