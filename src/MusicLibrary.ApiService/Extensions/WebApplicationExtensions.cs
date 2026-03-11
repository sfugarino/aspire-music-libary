using FastEndpoints;
using MusicLibrary.Domain.Config;
using Scalar.AspNetCore;

namespace MusicLibrary.ApiService.Extensions;

/// <summary>
/// Extension methods for configuring the WebApplication for MusicLibrary.
/// </summary>
public static class WebApplicationExtensions
{
    public static WebApplication Configure(this WebApplication app, KeycloakSettings settings)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        // Enable FastEndpoints middleware
        app.UseFastEndpoints();

        // Enable OpenAPI and Scalar API reference endpoints in development
        if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
        {
            app.MapOpenApi();
            app.MapScalarApiReference((options, context) =>
            {
                options.AddPreferredSecuritySchemes("Bearer");

                options.AddDefaultScopes("Bearer", ["openid", "profile"]);
            });
        }


        // Map default endpoints (health checks, etc.)
        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline and global exception handler
        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
        {
            app.Map("/", () => Results.Redirect("/scalar/v1"));
        }
        return app;

    }
}
