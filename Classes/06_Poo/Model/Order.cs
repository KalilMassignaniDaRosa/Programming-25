namespace PooModel
{
    class Order
    {
        public int Id { get; set; }
        public Costumer? Costumer { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }

        public bool Validade()
        {
            return true;
        }

        public Order Retrieve()
        {
            return new Order();
        }

        public void Save(Order order)
        {
        }
    }
}
