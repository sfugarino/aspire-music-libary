using MusicLibrary.ApiService.Extensions;
using MusicLibrary.Domain.Config;

// Create the web application builder and configure all MusicLibrary services and settings
var builder = WebApplication.CreateBuilder(args)
    .AddServices()
    .ConfigureAuthentication()
    .AddOpenTelemetry();

// Build the web application
var app = builder.Build();
        var settings = builder.Configuration.GetSection("Keycloak").Get<KeycloakSettings>()
            ?? throw new InvalidOperationException("Application settings are not configured properly.");

app.Configure(settings)
   .Run();

