using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class OrderRepository
    {
        public Order Retrieve()
        {
            return new Order();
        }

        public void Save(Order order)
        {
        }
    }
}