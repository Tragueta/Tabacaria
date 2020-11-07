using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Tabacaria.Foundation.Domain.Entites;
using Tabacaria.Foundation.Domain.Validators;

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

                            //return new BadRequestObjectResult(new Response<dynamic>(false, "error", errors));
                            return new BadRequestObjectResult(new Response(false, "error", errors));
                        };
                    })
                    .AddFluentValidation();

            return services;
        }

        //public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        //{
        //    services.AddMediatR(Assembly.GetAssembly(typeof(CreateEssenceHandler)));
        //    services.AddScoped<IEssenceRepository, EssenceRepository>();
        //    AddValidationsInjection(services);

        //    return services;
        //}
        //public static IServiceCollection AddMediatRAssemblies(this IServiceCollection services)
        //{
        //    var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select((item) => Assembly.Load(item)).ToArray();
        //    assemblies = assemblies.Where(a => a.GetName().Name.StartsWith("Tabacaria")).ToArray();
        //    services.AddMediatR(assemblies);
        //    return services;
        //}

        public static void AddFluentValidationCulture(this IServiceCollection services, string culture) => ValidatorOptions.LanguageManager.Culture = new CultureInfo(culture);

        //private static void AddValidationsInjection(IServiceCollection services)
        //{
        //    services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BaseValidator<EssenceValidator>>());
        //}
        public static IServiceCollection AddValidationsInjection(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SampleVallidator>());

            return services;
        }
    }
}
