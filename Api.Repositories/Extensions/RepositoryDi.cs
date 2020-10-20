using Api.Repositories.Base;
using Api.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Repositories.Extensions
{
    public static class RepositoryDi
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
    }
}