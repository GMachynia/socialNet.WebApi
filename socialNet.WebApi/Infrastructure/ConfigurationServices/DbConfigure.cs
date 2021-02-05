using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using socialNet.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class DbConfigure
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies()
                 .UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

            return services;
        }
    }
}
