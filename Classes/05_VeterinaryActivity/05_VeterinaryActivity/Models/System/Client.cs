namespace _05_VeterinaryActivity.Models.System
{
    public class Client
    {
        private readonly List<Animal> _pets = new();

        public bool IsEnterprise { get; private set; }
        public string? CompanyName { get; private set; }

        public void AddPet(Animal pet)
        {
            _pets.Add(pet);
        }

        public IReadOnlyList<Animal> GetPets()
        {
            return _pets.AsReadOnly();
        }
        public void RemovePet(Animal pet)
        {
            _pets.Remove(pet);
        }
    }
}