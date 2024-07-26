using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.DataAccess.Postgres;
using Topers.DataAccess.Postgres.Repositories;
using Topers.Infrastructure.Features;
using Topers.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.FileProviders;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Topers.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    var jwtOptionsSection = builder.Configuration.GetSection(nameof(JwtOptions));
    var cookieOptionsSection = builder.Configuration.GetSection(nameof(CookiesOptions));
    var cookieName = cookieOptionsSection.GetValue<string>("Name")!;

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

    builder.Services.Configure<JwtOptions>(jwtOptionsSection);
    builder.Services.Configure<CookiesOptions>(cookieOptionsSection);

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtOptionsSection.GetValue<string>("SecretKey")!))
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context => 
                {
                    context.Token = context.Request.Cookies[cookieName];
                    
                    return Task.CompletedTask;
                }
            };
        });

    builder.Services.AddAuthorization();

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
    builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

    builder.Services.AddScoped<ICategoriesService, CategoriesService>();
    builder.Services.AddScoped<IAddressesService, AddressesService>();
    builder.Services.AddScoped<ICustomersService, CustomersService>();
    builder.Services.AddScoped<IGoodsService, GoodsService>();
    builder.Services.AddScoped<IUsersService, UsersService>();
    builder.Services.AddScoped<IOrdersService, OrdersService>();

    builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
    builder.Services.AddScoped<IJwtProvider, JwtProvider>();
    builder.Services.AddScoped<IFileService, FileService>();
};

var defaultCulture = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = [defaultCulture],
    SupportedUICultures = [defaultCulture]
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
    app.UseRequestLocalization(localizationOptions);
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "Uploads")
        ),
        RequestPath = "/Resources"
    });
    app.UseCookiePolicy(new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.Strict,
        HttpOnly = HttpOnlyPolicy.Always,
        Secure = CookieSecurePolicy.Always
    });
    app.UseCors(options => options.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod());
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.MapGet("get", () => {
        Results.Ok("ok");
    });
    app.UseMiddleware<TaskCancellationHandlingMiddleware>();
    app.Run();
}