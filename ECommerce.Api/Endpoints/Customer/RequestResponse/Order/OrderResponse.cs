using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.Order.RequestResponse
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
