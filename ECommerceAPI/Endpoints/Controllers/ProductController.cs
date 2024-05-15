using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service) {
            _service = service;
        }

        [HttpGet("/products")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _service.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/product/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _service.GetProduct();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
