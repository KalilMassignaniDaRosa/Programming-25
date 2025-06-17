using _06_Poo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository;

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
            _orderRepository = new();
            _customerRepository = new();
            _productRepository = new();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_orderRepository.RetriveAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel viewModel = new();
            viewModel.Customers = _customerRepository.RetriveAll();

            var products = _productRepository.RetriveAll();
            List<SelectedItem> items = [];
            foreach (var product in products)
            {
                items.Add(new SelectedItem()
                {
                    OrderItem = new()
                    {
                        Product = product
                    }
                });
            }
            viewModel.SelectedItems = items;

            return View(viewModel);
        }
    }
}
