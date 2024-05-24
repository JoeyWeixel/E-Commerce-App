using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class OrderResponse
    {
        public Cart Cart { get; set; }
        public int Id { get; set; }
        public OrderResponse(Order order)
        {
            Cart = order.Cart;
            Id = order.Id;
        }
        public OrderResponse() { }
    }
}