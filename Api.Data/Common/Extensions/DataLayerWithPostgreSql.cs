using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Common.Extensions
{
    public static class DataLayerWithPostgreSql
    {
        public static IServiceCollection AddDataLayerWithPostgreSql(this IServiceCollection services,
            IConfiguration configuration)
        {
            var environmentConnectionString = Environment.GetEnvironmentVariable("HEROKU_POSTRE_CONNECTION_STRING");

            services.AddDbContext<PostgreContext>(options =>
                options.UseNpgsql(
                    environmentConnectionString ??
                    configuration.GetConnectionString("LOCAL_POSTGRES_CONNECTION_STRING")));

            services.AddTransient<DbContext, PostgreContext>();
            return services;
        }
    }
}