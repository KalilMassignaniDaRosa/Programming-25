namespace PooModel
{
    public class Order
    {
        #region Atributes
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Address ShippingAddress { get; set; } = null!;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        #endregion Atributes

        public double CalculateTotalAmount()
        {
            double total = 0;
            foreach (var item in OrderItems)
            {
                total += item.Quantity * item.PurchasePrice;
            }
            return total;
        }

        public double CalculateTotalItems()
        {
            double total = 0;
            foreach (var item in OrderItems)
            {
                total += item.Quantity;
            }
            return total;
        }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderId) : this()
        {
            this.Id = orderId;
        }

        public bool Validate()
        {
            bool isValid = true;

            isValid = (ShippingAddress != null) &&
                (this.Id > 0) && (this.OrderItems.Count > 0) && (Customer != null);

            return isValid;
        }
    }
}