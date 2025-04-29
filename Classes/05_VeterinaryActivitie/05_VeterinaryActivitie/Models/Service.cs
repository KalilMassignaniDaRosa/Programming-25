namespace _05_VeterinaryActivitie.Models
{
    public class Service
    {
        public int Id { get; set; }
        private int AnimalId { get; set; }
        private int ClientId { get; set; }
        public DateTime Date { get; set; }
        public Doctor? ResponsibleDoctor { get; set; }
        private string? Notes { get; set; }
        private VetClinic? Clinic { get; set; }
        private string? Procedure { get; set; }
    }
}
