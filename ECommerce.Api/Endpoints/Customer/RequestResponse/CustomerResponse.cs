namespace ECommerce.Api.Endpoints.Customer.RequestResponse
{
    public class CustomerResponse
    {

        public string Id { get; set; }
        public Cart Cart { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
