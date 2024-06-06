namespace ECommerceAPI.Domain
{
    public class Cart
    {
        public ICollection<PurchaseProduct> Products { get; set; }
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        public Cart()
        {
            Products = new List<PurchaseProduct>();
        }
    }
}
