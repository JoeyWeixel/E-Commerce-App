using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class CustomerResponse
    {

        public int Id { get; set; }
        public ContactInfoResponse ContactInfo { get; set; }
        public CustomerResponse(Customer customer)
        {
            Id = customer.Id;
            ContactInfo = new ContactInfoResponse(customer.ContactInfo);    
        }
        public CustomerResponse() { }
    }
}
