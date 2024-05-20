namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class CustomerResponse
    {

        public Guid Id { get; set; }
        public ContactInfoResponse ContactInfo { get; set; }
    }
}
