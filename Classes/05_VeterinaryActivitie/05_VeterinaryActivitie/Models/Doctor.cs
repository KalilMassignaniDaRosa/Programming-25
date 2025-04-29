namespace _05_VeterinaryActivitie.Models
{
    public class Doctor : Person
    {
        private string? OficialVetDocument { get; set; }
        private string? Specialization { get; set; }
        public VetClinic? Clinic { get; set; }
    }
}
