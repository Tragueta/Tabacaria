using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Infra.Repositories;

namespace Tabacaria.Infra.Setup
{
    public static class RepositoriesDependency
    {
        public static IServiceCollection AddRepositoriesDependency(this IServiceCollection services)
        {
            services.AddScoped<IEssenceRepository, EssenceRepository>();

            return services;

        }
    }
}
