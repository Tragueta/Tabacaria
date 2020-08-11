using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Tabacaria.Domain.Handlers;
using Tabacaria.Domain.Utils.NotificationPattern;

namespace Tabacaria.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddFluentValidation();

            services.AddMediatR(Assembly.GetAssembly(typeof(CreateEssenceHandler)));

            services.AddTransient<Domain.Interfaces.INotification, Notification>();

            services.AddAutoMapper(typeof(Startup));
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
