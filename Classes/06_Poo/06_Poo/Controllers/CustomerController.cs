using Microsoft.AspNetCore.Mvc;
using PooModel;
using Repository;
using StackExchange.Redis;

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
        public IActionResult ExportDelimitatedCustomer()
        {
            string fileContent = string.Empty;
            string fileLocation = "Customer";
            string fileName = "DelimitedCustomer";

            foreach (Customer c in CustomerData.Customers)
            {
                if (c.AddressList != null && c.AddressList.Any())
                {
                    foreach (Address address in c.AddressList)
                    {
                        fileContent += $"{c.Id};{c.Name};{address.Id};{address.City};" +
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

            SaveFile(fileContent, fileLocation, fileName);

            ViewBag.File = new
            {
                Location = fileLocation,
                Name = fileName + ".txt"
            };

            return View("Export");
        }

        [HttpGet]
        public IActionResult ExportFixedCustomer()
        {
            string fileContent = string.Empty;
            string fileLocation = "Customer";
            string fileName = "FixedCustomer";

            foreach (Customer c in CustomerData.Customers)
            {
                if (c.AddressList != null && c.AddressList.Any())
                {
                    foreach (Address address in c.AddressList)
                    {
                        fileContent +=
                            String.Format("{0,-5}", c.Id) +
                            String.Format("{0,-64}", c.Name) +
                            String.Format("{0,-5}", address.Id) +
                            String.Format("{0,-32}", address.City) +
                            String.Format("{0,-2}", address.State) +
                            String.Format("{0,-32}", address.Country) +
                            String.Format("{0,-64}", address.StreetLine1) +
                            String.Format("{0,-64}", address.StreetLine2) +
                            String.Format("{0,-9}", address.PostalCode) +
                            String.Format("{0,-16}", address.AddressType) +
                            "\n";
                    }
                }
                else
                {
                    fileContent +=
                        String.Format("{0,-5}", c.Id) +
                        String.Format("{0,-64}", c.Name) +
                        // Campos de endereço vazios
                        String.Format("{0,-5}", "") +  // address.Id
                        String.Format("{0,-32}", "") +  // address.City
                        String.Format("{0,-2}", "") +  // address.State
                        String.Format("{0,-32}", "") +  // address.Country
                        String.Format("{0,-64}", "") +  // address.StreetLine1
                        String.Format("{0,-64}", "") +  // address.StreetLine2
                        String.Format("{0,-9}", "") +  // address.PostalCode
                        String.Format("{0,-16}", "") +  // address.AddressType
                        "\n";
                }
            }

            SaveFile(fileContent,fileLocation ,fileName );

            ViewBag.File = new
            {
                Location = fileLocation,
                Name = fileName + ".txt"
            };

            return View("Export");
        }

        private bool SaveFile(string content, string fileLocation, string fileName)
        {
            bool ret = true;
            if(string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName)
                | string.IsNullOrEmpty(fileLocation))
                return false;

            var path = Path.Combine(
                _environment.WebRootPath,
                $"TextFiles/{fileLocation}"
            );

            try
            {
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                var filepath = Path.Combine(
                    path, $"{fileName}.txt"
                );

                System.IO.File.WriteAllText(filepath, content);
            }
            catch (IOException ioEx)
            {
                string msg = ioEx.Message;
                //throw ioEx;
                ret = false;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
            }

            return ret;
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            // e possivel usar o is null
            if (id is null || id.Value <= 0)
                return NotFound();

            Customer customer = _customerRepository!.Retrieve(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null || id.Value <= 0)
                return NotFound();

            if (!_customerRepository!.DeleteById(id.Value))
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}