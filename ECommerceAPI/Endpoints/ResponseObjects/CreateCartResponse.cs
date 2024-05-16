using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.ResponseObjects
{
    public class CreateCartResponse
    {
        public Dictionary<Product, int> Products { get; set; }
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
    }
}
