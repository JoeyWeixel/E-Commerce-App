﻿namespace ECommerceAPI.Domain
{
    public class PurchaseProduct
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
