using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Common.Extensions
{
    public static class DataLayerWithSqlServer
    {
        public static IServiceCollection AddDataLayerWithSqlServer(this IServiceCollection services,
            IConfiguration configuration)
        {
            var environmentConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            services.AddDbContext<RentalContextSqlServer>(options =>
                options.UseSqlServer(environmentConnectionString ??
                                     configuration.GetConnectionString("LOCAL_SQLSERVER_CONNECTION_STRING")));
            services.AddScoped<DbContext, RentalContextSqlServer>();
            return services;
        }
    }
}