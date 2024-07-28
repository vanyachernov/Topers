using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<CartEntity>
{
    public void Configure(EntityTypeBuilder<CartEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder
            .HasOne(c => c.Customer)
            .WithOne(o => o.Cart)
            .HasForeignKey<CartEntity>(c => c.CustomerId);
        builder
            .HasMany(c => c.CartItems)
            .WithOne(i => i.Cart)
            .HasForeignKey(i => i.CartId);
    }
}