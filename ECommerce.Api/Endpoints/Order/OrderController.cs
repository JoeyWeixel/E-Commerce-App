using ECommerce.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Endpoints.History
{
    public class OrderController : ControllerBase
    {

        OrderService _service;
        public OrderController(OrderService service) { 
            _service = service;
        }

        [HttpPost("/orders")]
        public IActionResult AddOrder(OrderRequest order) {
            try
            {
                var newOrder = _service.AddOrder(order);
                return Created($"/history/{newOrder.id}",newOrder);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/orders/{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var order = _service.GetOrder(id);
                return Ok(order);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/orders")]
        public IActionResult GetAllOrders() {
            try
            {
                var orders = _service.GetAllOrders();
                return Ok(orders);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
