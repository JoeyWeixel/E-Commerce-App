using ECommerceAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Cart).IsRequired();
            builder.Property(c => c.ContactInfo).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PaymentInfos).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Orders).IsRequired().HasMaxLength(50);
        }
    }
}
