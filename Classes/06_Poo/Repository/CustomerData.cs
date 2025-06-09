using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerData
    {
        // Por ser estatico nao sera criada uma instancia para cada vez que for usado
        public static List<Customer> Customers { get; set; } = new();
        public static List<Product> Products { get; set; } = new();
        public static List<Order> Orders { get; set; } = new();
    }
}
