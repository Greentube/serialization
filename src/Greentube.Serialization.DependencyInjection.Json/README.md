# Greentube.Serialization.DependencyInjection.Json [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.DependencyInjection.Json.svg)](https://www.nuget.org/packages/Greentube.Serialization.DependencyInjection,Json/)

Brings [Greentube.Serialization.Json](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.Json) to your application with [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/DependencyInjection).

More information at: [Greentube.Serialization.DependencyInjection](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.DependencyInjection).

## Extensions to IServiceCollection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddJsonSerializer();
}
```

With an action to configure JsonOptions:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddJsonSerializer(o => o.Encoding = Encoding.Unicode);
}
```

## SerializationBuilder

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerialization(builder =>
        builder.AddJson();
        // Or with options:
        builder.AddJson(o => { /* ... */ });
    );
```
