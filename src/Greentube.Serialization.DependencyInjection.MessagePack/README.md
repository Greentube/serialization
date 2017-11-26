# Greentube.Serialization.DependencyInjection.MessagePack [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.DependencyInjection.MessagePack.svg)](https://www.nuget.org/packages/Greentube.Serialization.DependencyInjection,MessagePack/)

Brings [Greentube.Serialization.MessagePack](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.MessagePack) to your application with [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/DependencyInjection).

More information at: [Greentube.Serialization.DependencyInjection](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.DependencyInjection).

## Extensions to IServiceCollection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMessagePackSerializer();
}
```

With an action to configure MessagePackOptions:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMessagePackSerializer(o => {
        // Don't require attributes on model
        o.FormatterResolver = global::MessagePack.Resolvers.ContractlessStandardResolver.Instance;
        // Use LZ4 compression
        o.UseLz4Compression = true;
    });
}
```

## SerializationBuilder

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerialization(builder =>
        builder.AddMessagePack();
        // Or with options:
        builder.AddMessagePack(o => { /* ... */ });
    );
```
