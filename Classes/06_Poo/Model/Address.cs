using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooModel
{
    public class Address
    {
        public int id { get; set; }
        public string ?StreetLine1 { get; set; }
        public string ?StreetLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Province { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
        public string? AddressType { get; set; }

        public bool Validate()
        {
            bool isValid = true;

            isValid = !string.IsNullOrEmpty(this.StreetLine1) &&
                (this.PostalCode > 0) && !string.IsNullOrEmpty(this.AddressType) &&
                !string.IsNullOrEmpty(this.Country);


            return isValid;
        }
    }
}
