namespace ECommerceAPI.Domain
{
    public class Cart
    {
        public Dictionary<Product, int> Products { get; set; }
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
    }
}
