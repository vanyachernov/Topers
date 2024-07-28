namespace Topers.DataAccess.Postgres;

using Microsoft.EntityFrameworkCore;
using Topers.DataAccess.Postgres.Configurations;
using Topers.DataAccess.Postgres.Entities;

public class TopersDbContext(DbContextOptions<TopersDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<GoodEntity> Goods { get; set; }
    public DbSet<GoodScopeEntity> GoodScopes { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderDetailsEntity> OrderDetails { get; set; }
    public DbSet<CartEntity> Cart { get; set; }
    public DbSet<CartItemEntity> CartDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new GoodConfiguration());
        modelBuilder.ApplyConfiguration(new GoodScopeConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
