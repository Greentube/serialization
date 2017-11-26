# Greentube.Serialization.DependencyInjection [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.DependencyInjection.svg)](https://www.nuget.org/packages/Greentube.Serialization.DependencyInjection/)

By extending the [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/DependencyInjection) it's possible to expose a simple fluent API to add a serializer to the container.
With that, it's easy to consume ISerializer via dependency injection.

Two hooks are provided by this package. A SerializationBuilder and extensions on IServiceCollection directly.

## Extensions to IServiceCollection

Consider you have an implementation of type NoOpSerializer.
```csharp
class NoOpSerializer : ISerializer
{
    public byte[] Serialize<T>(T @object) => null;
    public object Deserialize(Type type, byte[] bytes) => null;
}
```
It could be registered like:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerializer<NoOpSerializer>(ServiceLifetime.Singleton);
}
```

In case NoOpSerializer depends on some options:
```csharp
class NoOpOptions { }

class NoOpSerializer : ISerializer
{
    private NoOpOptions _options;
    public NoOpSerializer(NoOpOptions options) => _options = options;

    public byte[] Serialize<T>(T @object) => null;
    public object Deserialize(Type type, byte[] bytes) => null;
}
```

Registration can be done as:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerializer<NoOpSerializer, NoOpOptions>(ServiceLifetime.Singleton);
}
```

The options type provided will use the framework [Microsoft.Extensions.Options](https://github.com/aspnet/Options) for configuration. That means that values provided to the options instance could be defined via configuration files in different formats and even environment variables. For more information on MEO, refer to [Microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration?tabs=basicconfiguration).

Note that there's no dependency on IOptions`<T>` from NoOpSerializer's constructor. That allows decoupling between the assembly where NoOpSerializer was defined and Microsoft.Extensions.Options.

## SerializationBuilder

Besides adding the serializer directly to ServiceCollection, it's possible to use the builder. This allows other libraries to expose AddSerializer through their own builders and have a more fluent API when setting up libraries that require serialization.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerialization(builder =>
        builder.AddSerializer<NoOpSerializer>(ServiceLifetime.Singleton);
    );
}
```

This assembly was created to allow implementations have their own extension methods like:

* AddJson
* AddProtoBuf
* AddXml
* AddMessagePack
* etc

Which in turn simply call AddSerializer`<T>` with the desired lifetime while having their Options type also registered.