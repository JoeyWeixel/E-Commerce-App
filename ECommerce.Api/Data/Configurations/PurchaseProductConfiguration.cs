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
            builder.HasOne(x => x.Cart)
                 .WithMany()
                 .HasForeignKey(x => x.Cart.Id);

            builder.HasOne(x => x.Product)
                   .WithMany()
                   .HasForeignKey(x => x.Product);
        }
    }
}
