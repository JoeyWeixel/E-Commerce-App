namespace ECommerceAPI.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Cart Cart { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
