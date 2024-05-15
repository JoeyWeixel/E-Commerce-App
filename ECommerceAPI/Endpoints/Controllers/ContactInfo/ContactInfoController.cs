using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ContactInfoController : BaseApiController
    {
        private readonly ContactInfoService _service;

        public ContactInfoController(ContactInfoService service)
        {
            _service = service;
        }

        [HttpGet("ContactInfo/name")]
        public IActionResult GetName()
        {
            try
            {
                var name = _service.GetName();
                return Ok(name);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("ContactInfo/email")]
        public IActionResult GetEmail()
        {
            try
            {
                var email = _service.GetEmail();
                return Ok(email);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("ContactInfo/phonenumber")]
        public IActionResult GetPhoneNumber()
        {
            try
            {
                var phoneNumber = _service.GetPhoneNumber();
                return Ok(phoneNumber);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("ContactInfo/address")]
        public IActionResult GetAddress()
        {
            try
            {
                var address = _service.GetAddress();
                return Ok(address);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}