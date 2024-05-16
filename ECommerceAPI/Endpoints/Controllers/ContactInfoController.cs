//using ECommerceAPI.Endpoints.Services;
//using ECommerceAPI.Endpoints.ResponseObjects;
//using Microsoft.AspNetCore.Mvc;

//namespace ECommerceAPI.Endpoints.Controllers
//{
//    public class ContactInfoController
//    {
//        ContactInfoServices ContactInfoServices = new ContactInfoServices();

//        [HttpGet("customers/{id}/contactInfo")]
//        public IActionResult GetContactInfo(int id)
//        {
//            try
//            {
//                GetContactInfoResponse contactInfo = ContactInfoServices.GetContactInfo(id);
//                return new OkObjectResult(contactInfo);
//            }
//            catch (Exception ex)
//            {
//                return new BadRequestObjectResult(ex);
//            }
//        }
//    }
//}