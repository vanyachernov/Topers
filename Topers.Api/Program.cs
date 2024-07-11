using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.DataAccess.Postgres;
using Topers.DataAccess.Postgres.Repositories;
using Topers.Infrastructure.Features;
using Topers.Infrastructure.Services;
using Topers.Api.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
{
    var jwtOptionsSection = builder.Configuration.GetSection(nameof(JwtOptions));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

    builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

    builder.Services.AddDbContext<TopersDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("TopersDbContext"));
    });

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
    builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();
    builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
    builder.Services.AddScoped<IGoodsRepository, GoodsRepository>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();

    builder.Services.AddScoped<ICategoriesService, CategoriesService>();
    builder.Services.AddScoped<IAddressesService, AddressesService>();
    builder.Services.AddScoped<ICustomersService, CustomersService>();
    builder.Services.AddScoped<IGoodsService, GoodsService>();
    builder.Services.AddScoped<IUsersService, UsersService>();

    builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
    builder.Services.AddScoped<IJwtProvider, JwtProvider>();
};

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.DocumentTitle = "Topers API";
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}