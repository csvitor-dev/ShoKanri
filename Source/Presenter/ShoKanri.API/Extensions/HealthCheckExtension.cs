using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ShoKanri.API.Extensions;

internal static class HealthCheckExtension
{
    internal async static Task UseHealthCheckResourceAsync(this IServiceProvider self)
    {
        var service = self.GetRequiredService<HealthCheckService>();
        var result = await service.CheckHealthAsync();

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\t[HEALTHCHECK] ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Status: ${result.Status}, took {result.TotalDuration.TotalSeconds}s\n");
    }
}