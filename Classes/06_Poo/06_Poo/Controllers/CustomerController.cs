using Microsoft.AspNetCore.Mvc;
using PooModel;
using Repository;

namespace _06_Poo.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository? _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = _customerRepository!.RetriveAll();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _customerRepository!.Save(c);

            List<Customer> customers = _customerRepository!.RetriveAll();

            return View("Index", customers);
        }
    }
}
