using ECommerceAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Cart);
            builder.HasOne(c => c.ContactInfo);
            builder.HasMany(c => c.PaymentInfos);
            builder.HasMany(c => c.Orders);
        }
    }
}
