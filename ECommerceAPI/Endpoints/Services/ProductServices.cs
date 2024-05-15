using ECommerceAPI.Endpoints.ResponseObjects;

namespace ECommerceAPI.Endpoints.Services
{
    public class ProductServices
    {

        public ProductServices() { }

        public ProductResponse[] GetAllProducts()
        {
            //TODO: Reference database which is yet to be created
            ProductResponse[] products = new ProductResponse[1];
            return products;
        }

        public ProductResponse GetProduct(int id) {
            //TODO query database
            return new ProductResponse();
        }

        public void DeleteProduct(int id){
            //TODO
        }

        public void AddProduct(ProductRequest product)
        {

        }
    }
}
