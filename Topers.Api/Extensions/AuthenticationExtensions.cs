namespace Topers.Api.Extensions;

using Topers.Infrastructure.Features;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptionsSection = configuration.GetSection(nameof(JwtOptions));
        var cookieOptionsSection = configuration.GetSection(nameof(CookiesOptions));
        var cookieName = cookieOptionsSection.GetValue<string>("Name")!;

        services.AddAuthentication(options =>
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

        return services;
    }
};