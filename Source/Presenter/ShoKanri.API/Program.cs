using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using ShoKanri.API.Filters;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// Apply exception handling with ExceptionFilters
// see https://learn.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ExceptionFilter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Expose sample endpoint.
app.MapGet("/", () =>
    {
        return Results.Ok(new
        {
            Message = "Welcome to Shō-Kanri API, the sample API based on the Kanri project",
            GitHubUrl = "https://github.com/csvitor-dev/ShoKanri",
            ApiDocUrl = "Go to the '/swagger' route to access the API documentation."
        });
    })
    .WithName("Sample Endpoint")
    .WithOpenApi();

// Use native Health Check service (extension)
// of ASP.NET see https://learn.microsoft.com/en-us/dotnet/core/diagnostics/diagnostic-health-checks
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();