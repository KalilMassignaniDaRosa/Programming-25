using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AnimalRepository
    {
        public Animal Retrieve()
        {
            return new Animal();
        }

        public void Save(Animal animal)
        {
        }
    }
}
