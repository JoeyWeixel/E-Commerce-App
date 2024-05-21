namespace ECommerceAPI.Domain
{
    public class Cart
    {
        public List<PurchaseProduct> Products { get; set; }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
    }
}
