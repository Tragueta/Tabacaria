using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Handlers;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Domain.Utils.Validators;
using Tabacaria.Infra.Repositories;

namespace Product.Foundation.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(CreateEssenceHandler)));

            services.AddTransient<IValidator<CreateEssenceCommand>, EssenceValidator>();
            services.AddScoped<IEssenceRepository, EssenceRepository>();

            return services;
        }
    }
}
