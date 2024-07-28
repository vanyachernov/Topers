using Topers.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;
    var services = builder.Services;

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();
    services.AddCustomServices(configuration);
    services.AddCustomAuthentication(configuration);
    services.AddAuthorization();
};

var app = builder.Build();
{
    app.UseCustomMiddlewares(app.Environment);
    app.MapControllers();
    app.Run();
}