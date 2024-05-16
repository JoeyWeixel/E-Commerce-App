using ECommerceAPI.Endpoints.Order.RequestResponse;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Endpoints.Order
{
    public class OrderController : ControllerBase
    {

        OrderService _service;
        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpPost("/orders")]
        public IActionResult AddOrder(OrderRequest order)
        {
            try
            {
                var newOrder = _service.AddOrder(order);
                return Created($"/history/{newOrder.Id}", newOrder);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/orders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _service.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
