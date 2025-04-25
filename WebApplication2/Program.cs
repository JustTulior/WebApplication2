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

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddHttpClient();

services.AddSwaggerGen(
c =>
{   
c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "basic",
    In = ParameterLocation.Header,
    Description = "Basic Authorization header using the Bearer scheme."
});
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

//services.AddSingleton<IJwtServices, JwtService>();
//services.AddScoped<IJwtServices, JwtService>();
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
app.MapHealthChecks("/weatherforecast")
    .RequireAuthorization()
    ;
app.MapGet("/", () => "fgfg");
app.MapGet("/users", () =>{ });
app.Run();
