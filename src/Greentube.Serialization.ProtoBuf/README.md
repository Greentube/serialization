# Greentube.Serialization.ProtoBuf [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.ProtoBuf.svg)](https://www.nuget.org/packages/Greentube.Serialization.ProtoBuf/)

Implementation of [ISerializer](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) with [protobuf-net](https://github.com/mgravell/protobuf-net).

Protocol Buffers is googles binary serialization format.

This library targets [netstandard1.3](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) since that's the version [protobuf-net](https://www.nuget.org/packages/protobuf-net/) depends on.

No other dependencies besides [Greentube.Serialization](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) and [protobuf-net](https://www.nuget.org/packages/protobuf-net/) are introduced via this package.

```csharp
var protoBuf = new ProtoBufSerializer(new ProtoBufOptions());
```

## Options

By default, `protobuf-net` will use `RuntimeTypeModel.Default`. This can be overwriten by:

```csharp
var protoBuf = new ProtoBufSerializer(
    new ProtoBufOptions
    {
        FormatterResolver = RuntimeTypeModel.Create()
    });
```