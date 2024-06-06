using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class PurchaseProductResponse
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }

        public PurchaseProductResponse(PurchaseProduct p)
        {
            ProductId = p.ProductId;
            CartId = p.CartId;
            Quantity = p.Quantity;
        }

        public PurchaseProductResponse() { }
    }
}
