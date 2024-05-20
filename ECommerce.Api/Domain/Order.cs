namespace ECommerceAPI.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
