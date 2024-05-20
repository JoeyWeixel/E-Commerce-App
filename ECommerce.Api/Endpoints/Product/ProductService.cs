using ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse;

namespace ECommerceAPI.Endpoints.ProductFolder
{
    public class ProductService
    {
        private readonly List<Domain.Product> _products = new List<Domain.Product>();
        private static int _nextId = 1;

        public ProductService() { }

        public IEnumerable<ProductResponse> GetAllProducts()
        {
            return _products.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                numInStock = product.numInStock,
                Price = product.Price
            }).ToList();
        }

        public ProductResponse GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                numInStock = product.numInStock,
                Price = product.Price
            };
        }

        public void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public ProductResponse AddProduct(ProductRequest productRequest)
        {
            var product = new Domain.Product
            {
                Id = _nextId++,
                Name = productRequest.Name,
                Description = productRequest.Description,
                numInStock = productRequest.numInStock,
                Price = productRequest.Price
            };

            _products.Add(product);

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                numInStock = product.numInStock,
                Price = product.Price
            };
        }
    }
}
