using PooModel;

namespace Repository
{
    public class CostumerRepository
    {
        public Costumer Retrieve(int id)
        {
            foreach(Costumer c in CostumerData.Costumers)
            {
                if(c.Id == id)
                    return c;
            } 

            return null!;
        }

        public List<Costumer> RetrieveByName (string name)
        {
            List<Costumer> ret = new();

            foreach(Costumer c in CostumerData.Costumers)
            {
                if( c.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(c);
            }

            return ret;
        }

        public List<Costumer> RetriveAll()
        {
            return CostumerData.Costumers;
        }

        public void Save(Costumer costumer)
        {
            costumer.Id = GetCount() + 1;
            CostumerData.Costumers.Add(costumer);
        }

        public void Update(Costumer newCostumer)
        {
            Costumer oldCostumer = Retrieve(newCostumer.Id);
            oldCostumer.Name = newCostumer.Name;
            oldCostumer.AddressList = newCostumer.AddressList;
        }

        public bool Delete(Costumer costumer)
        {
            return CostumerData.Costumers.Remove(costumer);
        }

        public bool DeleteById(int id)
        {
            return Delete(Retrieve(id));
        }

        public int GetCount()
        {
            return CostumerData.Costumers.Count;
        }
    }
}