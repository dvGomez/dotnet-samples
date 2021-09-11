# Injeção de Dependências em Serviços Windows .NET CORE 5 

## Packages

```csharp 
	<PackageReference Include="Microsoft.Extensions.Hosting" Version="5.0.0" />
    <PackageReference Include="Scrutor" Version="3.3.0" />
    <PackageReference Include="Topshelf" Version="4.3.0" />
```

## Code

```csharp
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
```