namespace Topers.Api.Extenstions;

using Topers.Infrastructure.Features;
using Topers.DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.DataAccess.Postgres.Repositories;
using Topers.Infrastructure.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        services.Configure<CookiesOptions>(configuration.GetSection(nameof(CookiesOptions)));

        services.AddDbContext<TopersDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("TopersDbContext"));
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IAddressesRepository, AddressesRepository>();
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IGoodsRepository, GoodsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();

        services.AddScoped<ICategoriesService, CategoriesService>();
        services.AddScoped<IAddressesService, AddressesService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IGoodsService, GoodsService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IOrdersService, OrdersService>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IFileService, FileService>();

        return services;
    }
};