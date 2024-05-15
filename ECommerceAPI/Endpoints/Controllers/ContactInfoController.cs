using ECommerceAPI.Endpoints.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class ContactInfoController
    {
        ContactInfoServices ContactInfoServices = new ContactInfoServices();

        [HttpGet("customers/{id}/contactInfo")]
        public IActionResult getContactInfo(int id)
        {
            try
            {
                GetContactInfoResponse contactInfo = ContactInfoServices.getContactInfo(id);
                return new OkObjectResult(contactInfo);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}