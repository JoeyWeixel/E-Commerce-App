namespace ECommerceAPI.Domain
{
    public class PurchaseProduct
    {
        public Product Product { get; set; }

        public int Id { get; set; } // Primary key

        public int ProductId { get; set; } // Foreign key property
        public int CartId { get; set; } // Foreign key property

        public int Quantity { get; set; }
    }
}
