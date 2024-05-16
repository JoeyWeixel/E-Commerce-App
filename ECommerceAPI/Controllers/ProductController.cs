using ECommerceAPI.Endpoints.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("/product")]

    public class ProductController
    {
        ProductServices productServices = new ProductServices();
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = productServices.GetProducts();
                return new OkObjectResult(products);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetProducts(int id)
        {
            try
            {
                var products = productServices.GetProduct(id);
                return new OkObjectResult(products);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            var products = productServices.DeleteProduct();
            return new OkObjectResult(products);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}
