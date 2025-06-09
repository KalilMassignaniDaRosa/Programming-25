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
            if (ModelState.IsValid)
            {
                _customerRepository!.Save(c);
                return RedirectToAction(nameof(Index));
            }
            return View(c);
        }

        [HttpGet]
        // Por padrao ele pega a view com o mesmo nome do metodo
        public IActionResult ExportDelimitatedCustumer()
        {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                if (c.AddressList != null && c.AddressList.Any())
                {
                    foreach (Address address in c.AddressList)
                    {
                        fileContent += $"{c.Id};{c.Name};{address.id};{address.City};" +
                                       $"{address.State};{address.Country};{address.StreetLine1};" +
                                       $"{address.StreetLine2};{address.PostalCode};" +
                                       $"{address.AddressType};\n";
                    }
                }
                else
                {
                    // sem endereço: Id;Name + (9) “;” em branco + newline
                    fileContent += $"{c.Id};{c.Name};;;;;;;;;\n";
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

            System.IO.File.WriteAllText(filepath, fileContent);


            return View("Export");
        }


    }
}
