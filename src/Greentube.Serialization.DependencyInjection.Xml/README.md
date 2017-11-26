# Greentube.Serialization.DependencyInjection.Xml [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.DependencyInjection.Xml.svg)](https://www.nuget.org/packages/Greentube.Serialization.DependencyInjection,Xml/)

Brings [Greentube.Serialization.Xml](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.Xml) to your application with [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/DependencyInjection).

More information at: [Greentube.Serialization.DependencyInjection](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.DependencyInjection).

## Extensions to IServiceCollection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddXmlSerializer();
}
```

With an action to configure XmlOptions:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddXmlSerializer(o => o.DefaultNamespace = "some-namespace");
    // Or with your own factory delegate:
    services.AddXmlSerializer(o => 
        o.Factory = type => new XmlSerializer(type, new XmlRootAttribute("messaging")));
}
```

## SerializationBuilder

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerialization(builder =>
        builder.AddXml();
        // Or with options:
        builder.AddXml(o => { /* ... */ });
    );
```
