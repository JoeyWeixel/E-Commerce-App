using ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse;
using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.ProductEndpoint
{
    public class ProductService
    {
        private static int _nextId = 1;

        ECommerceContext _db;

        public ProductService(ECommerceContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductResponse> GetAllProducts()
        {
            return _db.Product.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                NumInStock = product.NumInStock,
                Price = product.Price
            }).ToList();
        }

        public ProductResponse GetProduct(int id)
        {
            var product = _db.Product.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                NumInStock = product.NumInStock,
                Price = product.Price
            };
        }

        public void DeleteProduct(int id)
        {
            var product = _db.Product.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _db.Product.Remove(product);
            }
            _db.SaveChanges();
        }

        public ProductResponse AddProduct(ProductRequest productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                NumInStock = productRequest.NumInStock,
                Price = productRequest.Price
            };
            _nextId++;

            _db.Product.Add(product);
            _db.SaveChanges();
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                NumInStock = product.NumInStock,
                Price = product.Price
            };
        }
    }
}
