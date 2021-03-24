using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Tabacaria.Core.Utils.Validators;
using Tabacaria.Foundation.Api.Configuration;
using Tabacaria.Infra.Setup;

namespace Tabacaria.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApiBehaviorConfiguration();
            services.AddAutoMapper(typeof(Startup));

            services.AddRepositoriesDependency();

            var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select((item) => Assembly.Load(item)).ToArray();
            assemblies = assemblies.Where(a => a.GetName().Name.StartsWith("Tabacaria")).ToArray();
            services.AddMediatR(assemblies);

            services.AddControllers().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<EssenceValidator>());
            services.AddFluentValidationCulture("us");

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Tabacaria",
                        Version = "v1",
                        Description = "APIs - Tabacaria",
                        Contact = new OpenApiContact
                        {
                            Name = "GOD"
                        }
                    });
                var commentFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentFilePath = Path.Combine(AppContext.BaseDirectory, commentFileName);
                options.IncludeXmlComments(commentFilePath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIs - Tabacaria");
            });
        }
    }
}
