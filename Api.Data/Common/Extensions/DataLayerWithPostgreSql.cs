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
            var environmentConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            services.AddDbContext<PostgreContext>(options =>
                options.UseNpgsql(
                    environmentConnectionString ??
                    configuration.GetConnectionString("HEROKU_POSTGRE_CONNECTION_STRING")));

            services.AddTransient<DbContext, PostgreContext>();
            return services;
        }
    }
}