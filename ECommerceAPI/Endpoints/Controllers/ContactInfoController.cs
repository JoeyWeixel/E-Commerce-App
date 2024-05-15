using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class ContactInfoController
    {
        ContactInfoServices ContactInfoServices = new ContactInfoServices();

        [HttpGet("/ContactInfo/{email}")]
        public IActionResult getContactInfo({ string email})
        {
            try
            {
                GetContactInfoResponse contactInfo = ContactInfoServices.getContactInfo(email);
                return new OkObjectResult(contactInfo);
    }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.message);
}
        }
    }
}