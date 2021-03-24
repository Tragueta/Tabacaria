using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Linq;
using Tabacaria.Foundation.Domain.Entites;

namespace Tabacaria.Foundation.Api.Configuration
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

                            return new BadRequestObjectResult(new Response(false, "error", errors));
                        };
                    })
                    .AddFluentValidation();

            return services;
        }

        public static void AddFluentValidationCulture(this IServiceCollection services, string culture)
            => ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo(culture);

    }
}
