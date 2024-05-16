using ECommerceAPI.Endpoints.ProductFolder.RequestResponse;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Endpoints.ProductFolder
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet("/products")]
        public ActionResult<IEnumerable<ProductResponse>> GetAllProducts()
        {
            var products = _service.GetAllProducts();
            return Ok(products);
        }


        [HttpGet("/products/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _service.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/products")]
        public IActionResult AddProduct(ProductRequest product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product is null.");
                }
                var newProduct = _service.AddProduct(product);
                return Created($"/products/{newProduct.Id}", newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _service.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
