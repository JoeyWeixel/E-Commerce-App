using ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class CartResponse
    {
        public Dictionary<ProductResponse, int> Products { get; set; }
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        // Constructor to initialize the Products dictionary
        public CartResponse()
        {
            Products = new Dictionary<ProductResponse, int>();
        }
    }
}
