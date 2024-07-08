using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(a => a.Id);
        builder
            .HasOne(a => a.Customer)
            .WithOne(c => c.Address)
            .HasForeignKey<AddressEntity>(a => a.CustomerId);
    }
}