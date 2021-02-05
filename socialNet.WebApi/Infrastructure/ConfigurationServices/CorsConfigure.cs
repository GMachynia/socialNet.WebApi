using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class CorsConfigure
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("socialNet.Client",
                builder =>
                {
                    builder.WithOrigins(configuration["AppSettings:AngularClient"].ToString())
                         .AllowAnyHeader()
                         .AllowAnyMethod()
                         .AllowCredentials();
                });
            });
            return services;
        }
    }
}
