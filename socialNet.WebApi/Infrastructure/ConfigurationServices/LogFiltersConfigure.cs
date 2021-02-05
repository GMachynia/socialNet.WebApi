using Microsoft.Extensions.DependencyInjection;
using socialNet.WebApi.Infrastructure.Helpers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class LogFiltersConfigure
    {
        public static IServiceCollection AddLogFiltersServices(this IServiceCollection services)
        {
            services.AddControllers(option =>
            {
                option.Filters.Add(typeof(ActionInfoLogFilter));
                option.Filters.Add(typeof(ExceptionLogFilter));
            });

            return services;
        }
    }
}
