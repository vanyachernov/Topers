using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder
            .HasMany(c => c.Goods)
            .WithOne(g => g.Category)
            .HasForeignKey(g => g.CategoryId);
    }
}