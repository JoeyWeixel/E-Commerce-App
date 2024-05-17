namespace ECommerceAPI.Domain
{
    public class PaymentInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public Guid ID { get; set; }
    }
}
