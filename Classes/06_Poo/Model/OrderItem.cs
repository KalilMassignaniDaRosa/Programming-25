namespace PooModel
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }

        public bool Validate()
        {
            bool isValid = true;

            isValid = (this.Id > 0) && (this.Quantity > 0) &&
                (Product != null) && (this.PurchasePrice > 0);

            return isValid;
        }

        public OrderItem Retrieve(int orderId)
        {
            return new OrderItem();
        }

        
    }
}
