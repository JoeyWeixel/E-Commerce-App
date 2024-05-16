namespace ECommerceAPI.Endpoints.Customer.RequestResponse
{
    public class CustomerResponse
    {

        public int Id { get; set; }
        public Cart Cart { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
