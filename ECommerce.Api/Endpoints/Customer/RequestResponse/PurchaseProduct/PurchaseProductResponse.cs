using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class PurchaseProductResponse
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
