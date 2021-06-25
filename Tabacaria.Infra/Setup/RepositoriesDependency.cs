using Microsoft.Extensions.DependencyInjection;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Infra.Repositories;

namespace Tabacaria.Infra.Setup
{
    public static class RepositoriesDependency
    {
        public static IServiceCollection AddRepositoriesDependency(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IEssenceRepository, EssenceRepository>();

            return services;

        }
    }
}
