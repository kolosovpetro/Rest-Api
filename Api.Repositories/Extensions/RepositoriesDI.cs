using Api.Repositories.Base;
using Api.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Repositories.Extensions
{
    public static class RepositoriesDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
    }
}