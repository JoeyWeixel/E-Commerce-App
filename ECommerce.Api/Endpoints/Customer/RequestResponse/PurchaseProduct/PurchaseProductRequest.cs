namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class PurchaseProductRequest
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}