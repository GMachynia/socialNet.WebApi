using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class AutoMapperConfigure
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
                services.AddAutoMapper(Assembly.Load("socialNet.Services"));
    
            return services;
        }
    }
}
