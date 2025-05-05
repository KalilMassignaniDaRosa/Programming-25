namespace _05_VeterinaryActivity.Models.System
{
    public class Animal
    {
        public int Id { get; set; }
        public Client? Owner { get; set; }
        public string? Type { get; set; }
        public char? Sex { get; set; }
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public string? Allergy { get; set; }
        public List<Service> Records { get; set; } = new();
    }
}