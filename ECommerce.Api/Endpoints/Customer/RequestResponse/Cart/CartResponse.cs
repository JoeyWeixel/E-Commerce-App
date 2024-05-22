using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class CartResponse
    {
        public List<PurchaseProduct> Products { get; set; }
        public int Id { get; set; }

        public CartResponse(int customerId)
        {
            Products = new List<PurchaseProduct>();
            Id = customerId;

        }
        public CartResponse(Cart cart) { }

        public void AddProduct(PurchaseProduct product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(PurchaseProduct product)
        {
            Products.Remove(product);
        }
    }
}