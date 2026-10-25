using Microsoft.EntityFrameworkCore;
using Portfoliositeapi.Data;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI configureren
builder.Services.AddOpenApi();

// Databaseverbinding configureren
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// OpenAPI beschikbaar maken tijdens development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Testendpoint
app.MapGet("/", () => "ByteForge API werkt!");

app.Run();