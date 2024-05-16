using ECommerceAPI.Endpoints.ResponseObjects;
using ECommerceAPI.Endpoints.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("/product")]

    public class CartController
    {
        CartServices cartServices = new CartServices();
        [HttpPost]
        public IActionResult CreateCart(CreateCartRequest cartRequest)
        {
            try
            {
                var products = cartServices.CreateCart(cartRequest);
                return new OkObjectResult(products);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
