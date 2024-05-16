using ECommerceAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Domain

{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
    }
}
