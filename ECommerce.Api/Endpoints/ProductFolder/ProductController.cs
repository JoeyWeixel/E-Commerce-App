﻿using ECommerceAPI.Endpoints.ProductFolder.RequestResponse;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Endpoints.ProductFolder
{
<<<<<<< HEAD:ECommerce.Api/Endpoints/Product/ProductController.cs
    public class PaymentInfoController : ControllerBase
=======
    [ApiController]
    public class ProductController : ControllerBase
>>>>>>> b71a1defd2f5ce490fc4a063c4eec2b98cf2a951:ECommerce.Api/Endpoints/ProductFolder/ProductController.cs
    {
        private readonly ProductService _service;

        public PaymentInfoController(ProductService service)
        {
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
