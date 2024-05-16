using Microsoft.AspNetCore.Mvc;
using ECommerce.Api.Endpoints.PaymentInfo.RequestResponse;

namespace ECommerceAPI.Endpoints.PaymentInfo
{
    public class PaymentInfoController : ControllerBase
    {
        private readonly PaymentInfoService _service;

        public PaymentInfoController(PaymentInfoService service)
        {
            _service = service;
        }

        [HttpGet("/paymentinfo/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _service.GetPaymentInfo(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

