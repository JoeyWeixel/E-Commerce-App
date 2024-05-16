namespace ECommerceAPI.Endpoints.Product.RequestResponse
{
    public class ProductRequest
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }
        public decimal[] Size { get; set; }
    }
}
