# Greentube.Serialization [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.svg)](https://www.nuget.org/packages/Greentube.Serialization/)

This package hold the base abstraction of serialization. It's a simple contract which any implementation of a serialization format can adhere:

```csharp
interface ISerializer
{
    byte[] Serialize<T>(T @object);

    object Deserialize(Type type, byte[] bytes);
}
```

As an extension method on ISerializer, the more convenient Deserialize`<T>` is available. Useful when T is known at compile time.

```csharp
public static T Deserialize<T>(
    this ISerializer serializer,
    byte[] bytes);
```

This package depends on [.NET Standard 1.0 and hence is supported by any runtime introduced after 2010.](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)