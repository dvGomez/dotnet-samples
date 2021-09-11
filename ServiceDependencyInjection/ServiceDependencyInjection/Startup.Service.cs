using Core.App.Services;
using Core.HostedServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDependencyInjection
{
    public class StartupService
    {
        void ConfigureDependencyInjection(IHostBuilder hostbuilder)
        {
            hostbuilder.ConfigureServices(services =>
            {
                services.Scan(scan => scan
                    .FromAssemblyOf<AppService>()
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

                services.AddHostedService<TestHostedService>();
            });
        }

        public void Start(string[] args) {

            var builder = Host.CreateDefaultBuilder(args);
            ConfigureDependencyInjection(builder);

            builder.Build().RunAsync();

        }

        public void Stop() {
        
        }
    }
}
