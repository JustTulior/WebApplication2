using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApplication2.Extentions
{
    public static class MigrateExtention   
    {

        public static IApplicationBuilder Migrate (this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope ();
            var runner = scope.ServiceProvider.GetService<IMigrationRunner> ();
            runner.ListMigrations();
            runner.MigrateUp(4);
            return app;
        }


    }
}
