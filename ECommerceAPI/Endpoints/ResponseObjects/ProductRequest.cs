namespace ECommerceAPI.Endpoints.ResponseObjects
{
    public class ProductRequest
    {
        public decimal price { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string productId { get; set; }
        public decimal[] size { get; set; } 
    }
}
