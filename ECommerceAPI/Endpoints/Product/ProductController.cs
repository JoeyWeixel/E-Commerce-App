﻿using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Endpoints.Product.RequestResponse;

namespace ECommerceAPI.Endpoints.Product
{
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _service;

        public ProductController(ProductServices service)
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
                _service.AddProduct(product);
                return Ok(product);
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
