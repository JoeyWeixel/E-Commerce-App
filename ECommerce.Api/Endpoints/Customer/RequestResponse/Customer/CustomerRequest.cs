namespace ECommerceAPI.Endpoints.Customer.RequestResponse.Customer
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public List<Order> Orders { get; set; }
    }
}
