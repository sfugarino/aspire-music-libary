using FastEndpoints;
using MusicLibrary.ApiService.Extensions;
using Scalar.AspNetCore;

// Create the web application builder and configure all MusicLibrary services and settings
var builder = WebApplication.CreateBuilder(args)
    .ConfigureMusicLibrary()
    .AddOpenTelemetry();


// Build the web application
var app = builder.Build();


// Enable FastEndpoints middleware
app.UseFastEndpoints();


// Configure the HTTP request pipeline and global exception handler
app.UseExceptionHandler();


// Enable OpenAPI and Scalar API reference endpoints in development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


// Map default endpoints (health checks, etc.)
app.MapDefaultEndpoints();

app.Map("/", () => Results.Redirect("/scalar/v1"));

// Run the application
app.Run();

