using ECommerceAPI.Endpoints.Product.RequestResponse;

namespace ECommerceAPI.Endpoints.Product
{
    public class ProductService
    {

        public ProductService() { }

        public IEnumerable<ProductResponse> GetAllProducts()
        {
            //TODO: Reference database which is yet to be created
            var products = new List<ProductResponse>();
            return products;
        }

        public ProductResponse GetProduct(int id)
        {
            //TODO query database
            return new ProductResponse();
        }

        public void DeleteProduct(int id)
        {
            //TODO
        }

        public ProductResponse AddProduct(ProductRequest product)
        {
            return new ProductResponse
            {
                Id = Guid.NewGuid().ToString(),
            }; 
        }
    }
}
