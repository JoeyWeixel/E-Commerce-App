using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service) {
            _service = service;
        }

        [HttpGet("./Products")]
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

    }
}
