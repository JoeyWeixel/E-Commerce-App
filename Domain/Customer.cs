namespace Domain
{
    public class Customer
    {
        public Cart Cart { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public History History { get; set; }

    }
}