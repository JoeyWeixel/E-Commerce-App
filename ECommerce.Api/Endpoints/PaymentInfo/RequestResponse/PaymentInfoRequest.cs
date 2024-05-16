namespace ECommerceAPI.Endpoints.PaymentInfo.RequestResponse
{
    public class PaymentInfoRequest
    {

        public string Name { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public string PaymentMethod { get; set; }

        public string ID { get; set; }
    }
}
