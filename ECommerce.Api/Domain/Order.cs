namespace ECommerceAPI.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; } // Foreign key property
        public Cart Cart { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
