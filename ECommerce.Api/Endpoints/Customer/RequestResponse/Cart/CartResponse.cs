using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.Product.RequestResponse;

namespace ECommerceAPI.Endpoints.Customer.RequestResponse
{
    public class CartResponse
    {
        public Dictionary<ProductResponse, int> Products { get; set; }
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
