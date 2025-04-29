namespace _05_VeterinaryActivitie.Models
{
    public class Animal
    {
        public int Id { get; set; }
        private Client? Owner { get; set; }
        private string? Type { get; set; }
        private char? Sex { get; set; }
        private string? Name { get; set; }
        private DateTime Birthdate { get; set; }
        private double Weight { get; set; }
        private double Height { get; set; }
        private double Length { get; set; }
        private string? Allergy { get; set; }
        public Service[]? Records { get; set; }
    }
}
