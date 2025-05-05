using System.Net;

namespace _05_VeterinaryActivity.Models.System
{
    public class Person
    {
        public int Id { get; set; }
        public string? CPF { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
