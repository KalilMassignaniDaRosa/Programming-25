using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int id)
        {
            foreach (Product p in ProductData.Products)
            {
                if (p.Id == id)
                    return p;
            }

            return null!;
        }

        public List<Product> RetrieveByName(string name)
        {
            List<Product> ret = new();

            foreach (Product p in ProductData.Products)
            {
                if (p.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(p);
            }

            return ret;
        }

        public List<Product> RetriveAll()
        {
            return ProductData.Products;
        }

        public void Save(Product Product)
        {
            Product.Id = GetCount() + 1;
            ProductData.Products.Add(Product);
        }

        public void Update(Product newProduct)
        {
            Product oldProduct = Retrieve(newProduct.Id);

            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.CurrentPrice = newProduct.CurrentPrice;
        }

        public bool Delete(Product Product)
        {
            return ProductData.Products.Remove(Product);
        }

        public bool DeleteById(int id)
        {
            return Delete(Retrieve(id));
        }

        public int GetCount()
        {
            return ProductData.Products.Count;
        }
    }
}