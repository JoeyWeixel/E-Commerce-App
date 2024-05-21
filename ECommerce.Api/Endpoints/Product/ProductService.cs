using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse;

namespace ECommerceAPI.Endpoints.ProductEndpoint
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>();
        private static int _nextId = 1;

        ECommerceContext _db;

        public ProductService(ECommerceContext db) {
            var _db = db;
        }

        public IEnumerable<ProductResponse> GetAllProducts()
        {
            return _db.Products.Select(product => new ProductResponse
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
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
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
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public ProductResponse AddProduct(ProductRequest productRequest)
        {
            var product = new Product
            {
                Id = _nextId,
                Name = productRequest.Name,
                Description = productRequest.Description,
                numInStock = productRequest.numInStock,
                Price = productRequest.Price
            };
            _nextId++;

            _db.Products.Add(product);

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
