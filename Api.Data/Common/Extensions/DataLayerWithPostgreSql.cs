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
            var environmentConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            
            services.AddDbContext<RentalContextPostgreSql>(options =>
                options.UseNpgsql(
                    environmentConnectionString ??
                    configuration.GetConnectionString("LOCAL_POSTGRES_CONNECTION_STRING")));
            
            services.AddScoped<DbContext, RentalContextPostgreSql>();
            return services;
        }
    }
}