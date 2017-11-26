# Greentube.Serialization.Xml [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.Xml.svg)](https://www.nuget.org/packages/Greentube.Serialization.Xml/)

Implementation of [ISerializer](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) with [System.Xml.XmlSerializer](https://github.com/dotnet/corefx/tree/master/src/System.Xml.XmlSerializer).

This library targets [netstandard1.3](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) since that's the version [System.Xml.XmlSerializer](https://www.nuget.org/packages/System.Xml.XmlSerializer/) depends on.

No other dependencies besides [Greentube.Serialization](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) and [System.Xml.XmlSerializer](https://www.nuget.org/packages/System.Xml.XmlSerializer/) are introduced via this package.

```csharp
var xml = new XmlSerializer(new XmlOptions());
```

## Options

The default namespace can be defined via:

```csharp
var xml = new XmlSerializer(
    new XmlOptions
    {
        DefaultNamespace = "namespace"
    });
```

A factory delegate can be used also:

```csharp
var xml = new XmlSerializer(
    new XmlOptions
    {
        Factory = type => new XmlSerializer(type, new XmlRootAttribute("messaging"))
    });
```