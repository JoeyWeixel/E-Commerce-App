using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.Order.RequestResponse
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderResponse(Domain.Order order) { 
            Id = order.Id;
            Cart = order.Cart;
            DeliveryDate = order.DeliveryDate;
            OrderDate = order.OrderDate; 
        }
    }
}
