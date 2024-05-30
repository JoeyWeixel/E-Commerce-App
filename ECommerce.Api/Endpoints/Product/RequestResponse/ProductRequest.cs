namespace ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumInStock { get; set; }
        public double Price { get; set; }
    }
}
