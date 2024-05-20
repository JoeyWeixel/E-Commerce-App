namespace ECommerceAPI.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public PaymentInfo paymentInfo { get; set; }
        public List<Order> Orders { get; set; }
    }
}

