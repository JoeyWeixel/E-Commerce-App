using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class OrderRequest
    {
        public Cart Cart { get; set; }
        public int Id { get; set; }
    }
}
