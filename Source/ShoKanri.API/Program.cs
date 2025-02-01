using Microsoft.AspNetCore.Mvc;
using ShoKanri.API.Extensions;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks()
    .AddResourceUtilizationHealthCheck();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddRouting(options => 
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Expose sample endpoint.
    app.MapGet("/", () => 
    {
        return Results.Ok(new { 
            Message = "Welcome to Shō-Kanri API, the sample API based on the Kanri project",
            GitHubUrl = "https://github.com/csvitor-dev/ShoKanri.API",
            ApiDocUrl = "https://localhost:7206/swagger"
        });
    })
    .WithName("Sample Endpoint")
    .WithOpenApi();
}

// Use native Health Check service (extension)
// of ASP.NET see https://learn.microsoft.com/en-us/dotnet/core/diagnostics/diagnostic-health-checks
await app.Services.UseHealthCheckResourceAsync();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
