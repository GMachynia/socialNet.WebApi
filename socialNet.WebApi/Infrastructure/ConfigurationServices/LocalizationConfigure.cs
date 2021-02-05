using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using socialNet.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class LocalizationConfigure
    {
        public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
        {
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.AddControllers().AddDataAnnotationsLocalization(options =>

                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(SignUpRequestDto).GetTypeInfo().Assembly.FullName);
                    return factory.Create("RequestDtosTranslations", assemblyName.Name);
                }
                );

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] {
                    new CultureInfo("en"),
                    new CultureInfo("pl")
                };
                options.DefaultRequestCulture = new RequestCulture("pl");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return services;
        }
    }
}
