using PooModel;

namespace Repository
{
    public class CustomerRepository
    {
        public Customer Retrieve(int id)
        {
            foreach(Customer c in CustomerData.Customers)
            {
                if(c.Id == id)
                    return c;
            } 

            return null!;
        }

        public List<Customer> RetrieveByName (string name)
        {
            List<Customer> ret = new();

            foreach(Customer c in CustomerData.Customers)
            {
                if( c.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(c);
            }

            return ret;
        }

        public List<Customer> RetriveAll()
        {
            return CustomerData.Customers;
        }

        public void Save(Customer costumer)
        {
            costumer.Id = GetCount() + 1;
            CustomerData.Customers.Add(costumer);
        }

        public void Update(Customer newCostumer)
        {
            Customer oldCostumer = Retrieve(newCostumer.Id);
            oldCostumer.Name = newCostumer.Name;
            oldCostumer.AddressList = newCostumer.AddressList;
        }

        public bool Delete(Customer costumer)
        {
            return CustomerData.Customers.Remove(costumer);
        }

        public bool DeleteById(int id)
        {
            return Delete(Retrieve(id));
        }

        public int GetCount()
        {
            return CustomerData.Customers.Count;
        }
    }
}