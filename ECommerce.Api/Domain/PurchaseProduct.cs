using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Domain
{
    [PrimaryKey(nameof(ProductId), nameof(CartId))]
    public class PurchaseProduct
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }


    }
}
