namespace ECommerceAPI.Domain
{
    public class PurchaseProduct
    {
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }


    }
}
