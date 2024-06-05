namespace ECommerceAPI.Domain
{
    public class Cart
    {
        public IEnumerable<PurchaseProduct> Products { get; set; }
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        public Cart() { }
    }
}
