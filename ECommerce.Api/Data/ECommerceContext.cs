using ECommerce.Api.Data.Configurations;
using ECommerceAPI.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Domain
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PurchaseProduct> PurchaseProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new ContactInfoConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentInfosConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseProductConfiguration());
        }
    }
}
