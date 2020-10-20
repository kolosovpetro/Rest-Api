using Api.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Services.Extensions
{
    public static class ServicesDi
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Сделай для сервиса интерфейс и передавай его
            return services.AddTransient<MoviesService, MoviesService>();
        }
    }
}