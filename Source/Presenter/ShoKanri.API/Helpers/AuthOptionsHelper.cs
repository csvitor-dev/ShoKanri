namespace ShoKanri.API.Helpers;

internal static class AuthOptionsHelper
{
    internal static string Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!;
    internal static string Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!;
}
