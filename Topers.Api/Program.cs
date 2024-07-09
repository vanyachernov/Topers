using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.DataAccess.Postgres;
using Topers.DataAccess.Postgres.Repositories;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<TopersDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("TopersDbContext"));
    });

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
    builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();
    builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
    builder.Services.AddScoped<IGoodsRepository, GoodsRepository>();
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
    app.Run();
}