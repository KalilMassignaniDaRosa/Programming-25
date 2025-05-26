using PooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VaccineRepository
    {
        public Vaccine Retrieve()
        {
            return new Vaccine();
        }

        public void Save(Vaccine vaccine)
        {
        }
    }
}