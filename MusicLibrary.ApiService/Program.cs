using FastEndpoints;
using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Data;
using MusicLibrary.ApiService.Exceptions;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails(config =>
{
    config.CustomizeProblemDetails = content =>
    {
        content.ProblemDetails.Extensions.TryAdd("requestId", content.HttpContext.TraceIdentifier);
    };
})
;
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

var mongoDbSection = builder.Configuration.GetSection("MusicLibraryDatabase")!;
var mongoDbSettings = mongoDbSection.Get<DatabaseSettings>()!;

builder.Services.Configure<DatabaseSettings>(mongoDbSection);

var client = new MongoClient(mongoDbSettings.ConnectionString);
var database = client.GetDatabase(mongoDbSettings.DatabaseName);

// Register the MongoDB context or direct collections
builder.Services.AddSingleton<IMongoDatabase>(database);

builder.Services.AddScoped<IMongoRepository<Genre>,GenreRepository>();
builder.Services.AddScoped<IMongoRepository<Artist>,ArtistRepository>();
builder.Services.AddScoped<IMongoRepository<Album>, AlbumRepository>();
builder.Services.AddScoped<IMongoRepository<Song>, SongRepository>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseFastEndpoints();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapDefaultEndpoints();

app.Run();

