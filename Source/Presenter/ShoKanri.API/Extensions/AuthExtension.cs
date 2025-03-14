using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ShoKanri.API.Helpers;
using ShoKanri.API.Services;

namespace ShoKanri.API.Extensions;

internal static class AuthExtension
{
    internal static void AddJwtAuthentication(this IServiceCollection self)
    {
        self.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = AuthOptionsHelper.Issuer,
                    ValidAudience = AuthOptionsHelper.Audience,

                    IssuerSigningKey = new RsaSecurityKey(RSAKeyHelper.PublicKey)
                };
            });

        self.AddSingleton(new TokenService(RSAKeyHelper.PrivateKey));

        self.AddAuthorization();
    }
}