using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Configurations;

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
    {
        builder.HasKey(d => d.Id);
        builder
            .HasOne(d => d.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(d => d.OrderId);
        builder
            .HasOne(d => d.Good)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(d => d.GoodId);

    }
}