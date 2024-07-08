using Microsoft.EntityFrameworkCore;
using Topers.DataAccess.Postgres;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<TopersDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("TopersDbContext"));
    });
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