using ECommerceAPI.Domain;

namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class PaymentInfoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public PaymentInfoResponse(PaymentInfo paymentInfo)
        {
            Id = paymentInfo.Id;
            Name = paymentInfo.Name;
            Email = paymentInfo.Email;
            Address = paymentInfo.Address;
        }
        public PaymentInfoResponse() { }
    }
}
