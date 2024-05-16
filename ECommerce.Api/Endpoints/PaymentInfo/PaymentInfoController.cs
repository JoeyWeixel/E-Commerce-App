using Microsoft.AspNetCore.Mvc;

using ECommerceAPI.Endpoints.PaymentInfo.RequestResponse;


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
        public IActionResult GetPaymentInfo(int id)
        {
            try
            {
                var paymentinfo = _service.GetPaymentInfo(id);
                return Ok(paymentinfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

