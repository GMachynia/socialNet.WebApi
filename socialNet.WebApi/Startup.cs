using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using socialNet.Data;
using System.Text;
using socialNet.WebApi.Infrastructure.ConfigurationServices;
using System.Reflection;
using socialNet.SignalR.Hubs;

namespace socialNet.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.JWTSecret);

            services.Configure<AppSettings>(appSettingsSection);

            services.AddDbServices(Configuration);

            services.AddLogFiltersServices();

            services.AddAuthenticationServices(key);

            services.AddSignalRServices();

            services.AddAutoMapperServices();

            services.AddDIServices();

            services.AddControllers();

            services.AddLocalizationServices();

            services.AddSwaggerServices();

            services.AddCorsServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("socialNet.Client");

            app.UseRequestLocalization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "socialNet.WebApi v1"));
               // app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/signalR/chat");
                endpoints.MapHub<NotificationHub>("/signalR/notification");
            });
            
        }
    }
}
