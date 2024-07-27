namespace Topers.Api.Extenstions;

using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.CookiePolicy;
using Topers.Api.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder application, IWebHostEnvironment environment)
    {
        var defaultCulture = new CultureInfo("en-US");
        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(defaultCulture),
            SupportedCultures = new[] { defaultCulture },
            SupportedUICultures = new[] { defaultCulture }
        };

        if (environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.DocumentTitle = "Topers API";
                options.RoutePrefix = string.Empty;
            });
        }

        application.UseHttpsRedirection();
        application.UseRequestLocalization(localizationOptions);
        application.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(environment.ContentRootPath, "Uploads")
            ),
            RequestPath = "/Resources"
        });
        application.UseCookiePolicy(new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always
        });
        application.UseCors(options => options.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
        application.UseAuthentication();
        application.UseAuthorization();
        application.UseMiddleware<TaskCancellationHandlingMiddleware>();

        return application;
    }
};