namespace ECommerceAPI.Endpoints.Customer.RequestResponse
{
    public class PaymentInfoRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
    }
}
