using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CostumerRepository
    {
        public Costumer Retrieve()
        {
            return new Costumer();
        }

        public void Save(Costumer costumer)
        {
        }
    }
}