using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Configurations;

public class GoodScopeConfiguration : IEntityTypeConfiguration<GoodScopeEntity>
{
    public void Configure(EntityTypeBuilder<GoodScopeEntity> builder)
    {
        builder.HasKey(s => s.Id);
        builder
            .HasOne(s => s.Good)
            .WithMany(g => g.Scopes)
            .HasForeignKey(s => s.GoodId);
    }
}