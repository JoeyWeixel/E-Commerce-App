namespace ECommerceAPI.Endpoints.Customer.RequestResponse
{
    public class CustomerRequest
    {
        public string Id { get; set; }
        public Cart Cart { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public History History { get; set; }
    }
}
