# Injeção de Dependências .NET CORE 5

## Packages

```csharp 
<PackageReference Include="Scrutor.AspNetCore" Version="3.3.0" />
```

## Code

```csharp
services.Scan(scan => scan
	.FromAssemblyOf<AppService>()
	.AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
	.AsImplementedInterfaces()
	.WithSingletonLifetime());
```