namespace PooModel
{
    public class Order
    {
        #region Atributes
        public int Id { get; set; }
        public Customer? Costumer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        #endregion Atributes

        public Order()
        {
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        // Herdando metodo construtor atraves de sobrecarga
        public Order(int orderId) : this()
        {
            this.Id = orderId;
        }

        public bool Validate()
        {
            bool isValid = true;

            isValid = (ShippingAddress != null)&&
                (this.Id > 0) && (this.OrderItems!.Count > 0) && (Costumer != null);

            return isValid;
        }
    }
}
