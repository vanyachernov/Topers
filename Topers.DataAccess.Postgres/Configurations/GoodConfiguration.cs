using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Configurations;

public class GoodConfiguration : IEntityTypeConfiguration<GoodEntity>
{
    public void Configure(EntityTypeBuilder<GoodEntity> builder)
    {
        builder.HasKey(g => g.Id);
        builder
            .HasOne(g => g.Category)
            .WithMany(c => c.Goods)
            .HasForeignKey(g => g.CategoryId);
        builder
            .HasMany(g => g.Scopes)
            .WithOne(s => s.Good)
            .HasForeignKey(s => s.GoodId);
    }
}