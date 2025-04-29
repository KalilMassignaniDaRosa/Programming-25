namespace _05_VeterinaryActivitie.Models
{
    public class Person
    {
       private string? Cpf { get; set; }
       public string? FirstName { get; set; }
       public string? LastName { get; set; }
       private char? Sex { get; set; }
       public string? Gender { get; set; }
       private DateTime BirthDate { get; set; }
       private string[]? Address { get; set; }
       private double Weight { get; set; }
       private double Height { get; set; }
    }
}
