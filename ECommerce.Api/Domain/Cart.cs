namespace ECommerceAPI.Domain
{
    public class Cart
    {
        public List<PurchaseProduct> Products { get; set; } = new List<PurchaseProduct>();
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        public Cart() { }
    }
}
