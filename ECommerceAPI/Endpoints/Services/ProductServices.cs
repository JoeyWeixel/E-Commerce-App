namespace ECommerceAPI.Endpoints.Services
{
    public class ProductServices
    {
        public ProductServices() { }

        public List<GetProductsResponse> GetProducts()
        {
            return new List<GetProductsResponse>  {
                new GetProductsResponse { Id = 1, Name = "Product 1", Description = "Description 1" },
                new GetProductsResponse { Id = 2, Name = "Product 2", Description = "Description 2" },
                new GetProductsResponse { Id = 3, Name = "Product 3", Description = "Description 3" },
                new GetProductsResponse { Id = 4, Name = "Product 4", Description = "Description 4" },
                new GetProductsResponse { Id = 5, Name = "Product 5", Description = "Description 5" }
                };
        }

        public GetProductsResponse GetProduct(int productId)
        {
            // find prduct by id
            // return product object if found
            return new GetProductsResponse { Id = 1, Name = "Product 1", Description = "Description 1" };
        }

        public void DeleteProduct(int productId)
        {
            // find prduct by id
            // delete object from db
        }
    }
}