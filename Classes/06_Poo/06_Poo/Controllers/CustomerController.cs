using Microsoft.AspNetCore.Mvc;
using PooModel;
using Repository;

namespace _06_Poo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private CustomerRepository? _customerRepository;

        public CustomerController(IWebHostEnvironment environment)
        {
            _customerRepository = new CustomerRepository();
            _environment = environment;
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

        [HttpGet]
        // Por padrao ele pega a view com o mesmo nome do metodo
        public IActionResult ExportDelimitatedCustumer()
        {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                foreach (Address address in c.AddressList!)
                {
                    fileContent += $"{c.Id};{c.Name};{address.id};{address.City};{address.State};{address.Country};{address.StreetLine1};{address.StreetLine2};{address.PostalCode};{address.AddressType};\n";
                }

            }

            var path = Path.Combine(
                _environment.WebRootPath,
                "TextFiles/Customer"
            );

            if(!System.IO.Directory.Exists( path ) )
                System.IO.Directory.CreateDirectory( path );

            var filepath = Path.Combine(
                path,
                "DelimitatedCustomer.txt"
            );

            if(!System.IO.File.Exists( filepath ) )
            {
                using (StreamWriter sw = System.IO.File.CreateText( filepath ) )
                {
                    sw.Write(fileContent);
                }
            }

            return View("Export");
        }
    }
}
