using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Tabacaria.Domain.Handlers;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Domain.Utils.HttpUtils;
using Tabacaria.Domain.Utils.Validators;
using Tabacaria.Infra.Repositories;

namespace Product.Foundation.Api.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddApiBehaviorConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var errors = context.ModelState.Keys.Select(key =>
                            {
                                var er = context.ModelState[key];

                                return er.Errors.Select(x => new { Field = key, Message = x.ErrorMessage });
                            })
                            .SelectMany(x => x)
                            .ToList();

                            return new BadRequestObjectResult(new Response<dynamic>(false, "error", errors));
                        };
                    })
                    .AddFluentValidation();

            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(CreateEssenceHandler)));
            services.AddScoped<IEssenceRepository, EssenceRepository>();
            AddValidationsInjection(services);

            return services;
        }

        public static void AddFluentValidationCulture(this IServiceCollection services, string culture) => ValidatorOptions.LanguageManager.Culture = new CultureInfo(culture);

        private static void AddValidationsInjection(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BaseValidator<EssenceValidator>>());
        }
    }
}
