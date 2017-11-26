# Greentube.Serialization.DependencyInjection.ProtoBuf [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.DependencyInjection.ProtoBuf.svg)](https://www.nuget.org/packages/Greentube.Serialization.DependencyInjection,ProtoBuf/)

Brings [Greentube.Serialization.ProtoBuf](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.ProtoBuf) to your application with [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/DependencyInjection).

More information at: [Greentube.Serialization.DependencyInjection](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.DependencyInjection).

## Extensions to IServiceCollection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddProtoBufSerializer();
}
```

With an action to configure ProtoBufOptions:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddProtoBufSerializer(o => {
        var model = RuntimeTypeModel.Create();
        model.Add(typeof(SomeMessage), false).Add(1, nameof(SomeMessage.Body));
        o.RuntimeTypeModel = runtimeTypeModel;
    });
}
```

## SerializationBuilder

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerialization(builder =>
        builder.AddProtoBuf();
        // Or with options:
        builder.AddProtoBuf(o => { /* ... */ });
    );
```
