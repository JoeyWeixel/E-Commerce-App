using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<PurchaseProductResponse> Products { get; set; }

        public OrderResponse(Order order)
        {
            Id = order.Id;
            OrderDate = order.OrderDate;
            Products = order.Cart.Products.Select(p => new PurchaseProductResponse(p)).ToList();
        }

        public OrderResponse() { }
    }
}
