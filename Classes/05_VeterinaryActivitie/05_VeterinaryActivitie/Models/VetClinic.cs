namespace _05_VeterinaryActivitie.Models
{
    public class VetClinic
    {
        public int Id { get; set; }
        private string? Address { get; set; }
        public Doctor[]? ResposibleDoctor { get; set; }
    }
}
