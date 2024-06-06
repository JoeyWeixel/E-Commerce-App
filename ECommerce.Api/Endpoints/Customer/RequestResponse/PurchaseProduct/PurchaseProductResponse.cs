using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class PurchaseProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public PurchaseProductResponse(PurchaseProduct p)
        {
            ProductId = p.ProductId;
            ProductName = p.Product.Name;
            Quantity = p.Quantity;
            Price = p.Product.Price;
        }

        public PurchaseProductResponse() { }
    }
}
