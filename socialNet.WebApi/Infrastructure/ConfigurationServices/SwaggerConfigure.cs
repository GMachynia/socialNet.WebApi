using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using socialNet.WebApi.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class SwaggerConfigure
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "socialNet.WebApi", Version = "v1" });
                c.OperationFilter<SwaggerLanguageHeader>();
            });

            return services;
        }
    }
}
