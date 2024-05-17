using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.Customer.RequestResponse
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public Cart Cart { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
