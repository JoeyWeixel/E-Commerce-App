using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class ContactInfoResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ContactInfoResponse(ContactInfo contactInfo)
        {
            Name = contactInfo.Name;
            Email = contactInfo.Email;
            PhoneNumber = contactInfo.PhoneNumber;
            Address = contactInfo.Address;
        }
        public ContactInfoResponse() { }
    }
}