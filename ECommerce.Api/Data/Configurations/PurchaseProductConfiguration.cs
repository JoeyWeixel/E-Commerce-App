using ECommerceAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Data.Configurations
{
    public class PurchaseProductConfiguration : IEntityTypeConfiguration<PurchaseProduct>
    {
        public void Configure(EntityTypeBuilder<PurchaseProduct> builder)
        {
            builder.ToTable("PurchaseProduct");
            builder.HasOne(x => x.Cart);
            builder.HasOne(x => x.Product);
            builder.HasKey(x => new { x.Cart, x.Product });
        }
    }
}
