namespace _05_VeterinaryActivitie.Models
{
    public class Client
    {
        public int Id { get; set; }
        public bool IsEnterprise { get; set; }
        public Animal[]? Pets { get; set; }
    }
}
