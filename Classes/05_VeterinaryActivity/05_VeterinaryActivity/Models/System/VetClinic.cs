namespace _05_VeterinaryActivity.Models.System
{
    public class VetClinic
    {
        private readonly List<Doctor> _doctors = new();
        private readonly List<Service> _serviceHistory = new();

        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; }

        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public void AddService(Service service)
        {
            _serviceHistory.Add(service);
        }

        public IReadOnlyList<Doctor> GetDoctors()
        {
            return _doctors.AsReadOnly();
        }

        public IReadOnlyList<Service> GetServiceHistory()
        {
            return _serviceHistory.AsReadOnly();
        }

        public void RemoveDoctor(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }

        public void UpdateAddress(Address newAddress)
        {
            Address = newAddress;
        }
    }
}
