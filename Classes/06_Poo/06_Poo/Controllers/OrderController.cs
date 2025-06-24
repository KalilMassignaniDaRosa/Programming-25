using Microsoft.AspNetCore.Mvc;
using Repository;
using PooModel;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using _06_Poo.ViewModels;

namespace _06_Poo.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderController(IWebHostEnvironment environment)
        {
            _environment = environment;
            _orderRepository = new OrderRepository();
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allOrders = CustomerData.Orders
                               .Concat(_orderRepository.RetriveAll())
                               .ToList();

            foreach (var order in allOrders)
            {
                foreach (var item in order.OrderItems)
                {
                    var prodId = item.Product?.Id;
                    if (!prodId.HasValue)
                        continue;

                    item.Product =
                        _productRepository.Retrieve(prodId.Value)
                        ?? CustomerData.Products.First(p => p.Id == prodId.Value);
                }
            }

            return View(allOrders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var customers = _customerRepository.RetriveAll();
            var vm = new OrderViewModel
            {
                Customers = customers,
                SelectedItems = new List<SelectedItem>()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult LoadProducts(OrderViewModel viewModel)
        {
            viewModel.Customers = _customerRepository.RetriveAll();

            if (viewModel.CustomerId.HasValue)
            {
                viewModel.SelectedItems = LoadSelectedItems(viewModel.CustomerId.Value);
            }
            else
            {
                viewModel.SelectedItems = new List<SelectedItem>();
            }

            return View("Create", viewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Customers = _customerRepository.RetriveAll();
                if (model.CustomerId.HasValue)
                    model.SelectedItems = LoadSelectedItems(model.CustomerId.Value);
                else
                    model.SelectedItems = new List<SelectedItem>();

                return View(model);
            }

            var order = new Order
            {
                Customer = _customerRepository.Retrieve(model.CustomerId!.Value),
                OrderDate = DateTime.Now
            };

            int count = 1;
            foreach (var item in model.SelectedItems!)
            {
                if (item.IsSelected)
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        Id = count++,
                        Product = item.OrderItem.Product!,
                        Quantity = item.OrderItem.Quantity,
                        PurchasePrice = item.OrderItem.PurchasePrice
                    });
                }
            }

            _orderRepository.Save(order);

            return RedirectToAction(nameof(Index));
        }

        private List<SelectedItem> LoadSelectedItems(int customerId)
        {
            var allProducts = _productRepository.RetriveAll();
            return allProducts.Select(p => new SelectedItem
            {
                IsSelected = false,
                OrderItem = new OrderItem
                {
                    Product = p,
                    Quantity = 1,
                    PurchasePrice = p.CurrentPrice
                }
            }).ToList();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedOrder()
        {
            string fileContent = string.Empty;
            const string folder = "Order";
            const string fileName = "DelimitedOrder";

            foreach (Order o in _orderRepository.RetriveAll())
            {
                fileContent +=
                    $"{o.Id};" +
                    $"{o.Customer?.Name};" +
                    $"{o.OrderDate:yyyy-MM-dd};" +
                    $"{o.CalculateTotalAmount().ToString(CultureInfo.InvariantCulture)};" +
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
        public IActionResult ExportFixedOrder()
        {
            string fileContent = string.Empty;
            const string folder = "Order";
            const string fileName = "FixedOrder";

            foreach (Order o in _orderRepository.RetriveAll())
            {
                fileContent +=
                    string.Format("{0,-5}", o.Id) +
                    string.Format("{0,-30}", o.Customer?.Name) +
                    string.Format("{0,-15}", o.OrderDate.ToString("yyyy-MM-dd")) +
                    string.Format("{0,15:F2}", o.CalculateTotalAmount()) +
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
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            Order order = _orderRepository.Retrieve(id.Value);
            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            if (!_orderRepository.DeleteById(id.Value))
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        private bool SaveFile(string content, string fileLocation, string fileName)
        {
            if (string.IsNullOrEmpty(content) ||
                string.IsNullOrEmpty(fileLocation) ||
                string.IsNullOrEmpty(fileName))
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
    }
}
