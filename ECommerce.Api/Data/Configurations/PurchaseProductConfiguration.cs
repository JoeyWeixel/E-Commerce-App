using ECommerceAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Data.Configurations
{
    public class PurchaseProductConfiguration : IEntityTypeConfiguration<PurchaseProduct>
    {
        public void Configure(EntityTypeBuilder<PurchaseProduct> builder)
        {
            builder.ToTable("Product");
            builder.Property(x => x.Cart)
                .IsRequired();
            builder.Property(x => x.Product)
                .IsRequired();
            builder.HasKey(x => new { x.Cart, x.Product });
        }
    }
}
