using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooModel
{
    public class Vaccine
    {
        #region Atributes
        public int Id { get; set; }
        public string? VaccineName { get; set; }
        public DateTime VaccineDate { get; set; }
        public Animal? Animal { get; set; }
        #endregion

        public bool Validate()
        {
            bool isValid = true;

            isValid= !string.IsNullOrEmpty(VaccineName) &&Id > 0 &&
                VaccineDate != default && Animal != null;

            return isValid;
        }
    }
}
