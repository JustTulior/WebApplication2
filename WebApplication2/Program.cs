using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication2;
using WebApplication2.Extentions;
using System.Configuration;
using WebApplication2.Shops;
using FluentMigrator.Runner;
using System.Reflection;
using WebApplication2.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var services = builder.Services;

services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c
                    .AddPostgres()
                     .WithGlobalConnectionString("User ID=admin;Password=admin;Host=localhost;Port=5432;database=prod")
                     .ScanIn(Assembly.GetExecutingAssembly()).For.All());
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddHttpClient();

services.AddSwaggerGen(
c =>
{   
c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
{
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    Description = "Input bearer token to access this API",
});
c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        },
                        new string[] { }
                    }
            });
});

services.AddHealthChecks();
services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
builder.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader();
})
);
services.AddBearerAuthentication(configuration);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(DatabaseContext)));
});
services.AddScoped<IShopsRepository, ShopsRepository>();
services.AddScoped<IUsersRepository, UsersRepository>();

var app = builder.Build();
app.UseCors("MyPolicy");
app.MapControllers();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.Migrate();
app.Run();
