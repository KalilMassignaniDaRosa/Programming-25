using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository
    {

        public Order Retrieve(int id)
        {
            foreach (Order o in CustomerData.Orders)
            {
                if (o.Id == id)
                    return o;
            }

            return null!;
        }

        public List<Order> RetrieveByName(string name)
        {
            List<Order> ret = [];

            foreach (Order o in CustomerData.Orders)
            {
                if (o.Customer!.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(o);
            }

            return ret;
        }

        public List<Order> RetriveAll()
        {
            return CustomerData.Orders;
        }

        public void Save(Order order)
        {
            order.Id = GetCount() + 1;
            CustomerData.Orders.Add(order);
        }

        public void Update(Order newOrder)
        {
            Order oldOrder = Retrieve(newOrder.Id);
            oldOrder.Id = newOrder.Id;
            oldOrder.Customer = newOrder.Customer;
            oldOrder.OrderDate = newOrder.OrderDate;
            oldOrder.ShippingAddress = newOrder.ShippingAddress;
            oldOrder.OrderItems = newOrder.OrderItems;
        }

        public bool Delete(Order order)
        {
            return CustomerData.Orders.Remove(order);
        }

        public bool DeleteById(int id)
        {
            return Delete(Retrieve(id));
        }

        // Prog funcional
        // => e o lambda
        public int GetCount() => CustomerData.Orders.Count;
    }   
}