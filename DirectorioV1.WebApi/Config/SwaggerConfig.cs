using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace DirectorioV1.WebApi.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            RegistrationServices(services);
            return services;
        }

        private static IServiceCollection RegistrationServices(IServiceCollection services)
        {
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basePath, "DirectorioV1.Api.xml");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",new OpenApiInfo {
                 Title = "Directorio App", 
                    Version = "v1", 
                    Description = "Api para aplicacion de directorio" 
                });
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Directorio Api"));
            return app;
        }
    }
}
