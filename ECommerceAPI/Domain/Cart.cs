namespace ECommerceAPI.Domain
{
    public class Cart
    {
        // dictionary of products and the quantity of each product in the cart.
        public Dictionary<Product, int> Products { get; set; }
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
    }
}
