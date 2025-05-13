namespace PooModel
{
    public class Costumer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? HomeAddress { get; set; }
        public string? WorkAddress { get; set; }
        public static int InstanceCount = 0;
        public int ObjectCount = 0;

        public bool Validate()
        {
            return true;
        }

        public Costumer Retrieve()
        {
            return new Costumer();
        }

        public void Save(Costumer costumer)
        {
        }
    }
}
