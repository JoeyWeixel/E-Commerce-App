using ECommerceAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.TotalPrice)
                            .IsRequired()
                            .HasColumnType("decimal(18,2)");

            builder.HasMany(c => c.Products)
                            .WithOne()
                            .HasForeignKey(p => p.CartId)
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}