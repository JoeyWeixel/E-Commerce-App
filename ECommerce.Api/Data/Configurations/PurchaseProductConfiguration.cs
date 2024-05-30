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


            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cart)
                 .WithMany()
                 .HasForeignKey(x => x.CartId);

            builder.HasOne(x => x.Product)
                   .WithMany()
                   .HasForeignKey(x => x.ProductId);
        }
    }
}
