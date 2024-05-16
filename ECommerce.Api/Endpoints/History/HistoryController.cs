using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Endpoints.History
{
    public class HistoryController : ControllerBase
    {

        HistoryService _service;
        public HistoryController(HistoryService service) { 
            _service = service;
        }

        [HttpPost("/history")]
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
    }
}
