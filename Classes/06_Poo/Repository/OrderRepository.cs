﻿using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository
    {
        private readonly List<Order> _orders = new();


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

        public Order? RetrieveLastByCustomer(int customerId)
        {
            return CustomerData.Orders
                .Where(o => o.Customer is not null && o.Customer.Id == customerId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefault();
        }

        public List<Order> RetriveAll()
        {
            var productRepo = new ProductRepository();
            foreach (var order in _orders)
            {
                foreach (var item in order.OrderItems)
                {
                    item.Product = productRepo.Retrieve(item.Product!.Id);
                }
            }
            return _orders;
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