namespace PooModel
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Address>? AddressList { get; set; }
        public static int InstanceCount = 0;
        public int ObjectCount = 0;

        public bool Validate()
        {
            bool isValid = true;

            isValid = !string.IsNullOrEmpty(this.Name) &&
                (this.Id > 0) && (AddressList != null);

            return isValid;
        }
    }
}
