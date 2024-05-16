using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.ResponseObjects
{
    public class CreateCartRequest
    {
        public Dictionary<Product, int> Products { get; set; }

        public int CustomerID { get; set; }
    }
}
