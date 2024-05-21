namespace ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse

{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int numInStock { get; set; }
        public double Price { get; set; }
    }
}
