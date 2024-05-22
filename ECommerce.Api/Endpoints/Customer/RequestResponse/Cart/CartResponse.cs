using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class CartResponse
    {
        public List<PurchaseProduct> Products { get; set; }
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        public CartResponse(int customerId)
        {
            Products = new List<PurchaseProduct>();
            Id = customerId;
            TotalPrice = 0;

        }
        public CartResponse(Cart cart) { }

        public void AddProduct(PurchaseProduct product)
        {
            Products.Add(product);
            //TotalPrice = Products.Sum(p => Product.Price * p.Quantity);
        }

        public void RemoveProduct(PurchaseProduct product)
        {
            Products.Remove(product);
            //TotalPrice = Products.Subtract(p => Product.Price * p.Quantity);
        }
    }
}