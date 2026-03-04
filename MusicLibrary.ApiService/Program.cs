using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Data;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

var builder = WebApplication.CreateBuilder(args);

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

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();

app.Run();

