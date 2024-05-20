using ECommerceAPI.Endpoints.Product.RequestResponse;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class CartResponse
    {
        public Dictionary<ProductResponse, int> Products { get; set; }
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
