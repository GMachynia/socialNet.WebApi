using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class SignalRConfigure
    {
        public static IServiceCollection AddSignalRServices(this IServiceCollection services)
        {
            services.AddSignalR();

            return services;
        }
    }
}
