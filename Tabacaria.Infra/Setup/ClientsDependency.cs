using Microsoft.Extensions.DependencyInjection;
using Tabacaria.Domain.Interfaces.Clients;
using Tabacaria.Infra.Clients;

namespace Tabacaria.Infra.Setup
{
    public static class ClientsDependency
    {
        public static IServiceCollection AddClientsDependency(this IServiceCollection services)
        {
            services.AddScoped<IDapperClient, DapperClient>();

            return services;

        }
    }
}
