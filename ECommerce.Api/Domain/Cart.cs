namespace ECommerceAPI.Domain
{
    public class Cart
    {
        public List<PurchaseProduct> Products { get; set; }
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        public Cart(int customerId)
        {
            Products = new List<PurchaseProduct>();
            Id = customerId;
            TotalPrice = 0;
        }

        public Cart() { }
    }
}
