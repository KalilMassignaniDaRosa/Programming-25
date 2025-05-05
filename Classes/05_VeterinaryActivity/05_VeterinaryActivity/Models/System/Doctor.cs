namespace _05_VeterinaryActivity.Models.System
{
    public class Doctor : Person
    {
        private readonly List<Service> _servicesPerformed = new();

        public string? CRMV { get; private set; }
        private string? Specialization { get; set; }
        public VetClinic? Clinic { get; set; }

        public void AddServicePerformed(Service service)
        {
            _servicesPerformed.Add(service);
        }

        public IReadOnlyList<Service> GetServicesPerformed()
        {
            return _servicesPerformed.AsReadOnly();
        }
    }
}
