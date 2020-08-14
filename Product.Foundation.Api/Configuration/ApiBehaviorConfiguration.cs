using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Product.Foundation.Domain.Configuration
{
    public static class ApiBehaviorConfiguration
    {
        public static IServiceCollection AddApiBehaviorConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var messages = context.ModelState.Values
                                .Where(x => x.ValidationState == ModelValidationState.Invalid)
                                .SelectMany(x => x.Errors)
                                .OrderBy(x => x.ErrorMessage)
                                .Select(x => x.ErrorMessage)
                                .ToList();

                            return new BadRequestObjectResult(string.Join($"{Environment.NewLine}", messages));
                        };
                    })
                    .AddFluentValidation();

            return services;
        }
    }
}
