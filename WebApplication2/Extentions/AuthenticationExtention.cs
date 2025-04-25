using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApplication2.Extentions
{
    public static class AuthenticationExtention
    {
        public static IServiceCollection AddBearerAuthentication (this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services);
            var authority = configuration.GetSection("IdentityClientConnection").GetSection("ServerAddress").Value;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                options =>
                { options.TokenValidationParameters.ValidateLifetime = false;
                    options.TokenValidationParameters.ValidateAudience = false;
                    options.TokenValidationParameters.ValidateIssuerSigningKey = false;
                    options.TokenValidationParameters.ValidateIssuer = true;

                    options.Authority = authority;
                    options.TokenValidationParameters.ClockSkew = TimeSpan.FromSeconds(5);
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters.ValidAudience = "account";
                    //options.ClaimsIssuer = "http://localhost:8080/realms/my-realm";
                    //options.Audience = "account";
                    
                });
            //services.AddSingleton<IJwtService, JwtService>();

            return services;
        }
    }
}
