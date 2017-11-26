# Greentube.Serialization.MessagePack [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.MessagePack.svg)](https://www.nuget.org/packages/Greentube.Serialization.MessagePack/)

Implementation of [ISerializer](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) with [MessagePack-CSharp](https://github.com/neuecc/MessagePack-CSharp).

This library targets [netstandard2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) since that's the version [MessagePack](https://www.nuget.org/packages/MessagePack/) depends on.

No other dependencies besides [Greentube.Serialization](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) and [MessagePack](https://www.nuget.org/packages/MessagePack/) are introduced via this package.

```csharp
var messagePack = new MessagePackSerializer(new MessagePackOptions());
```

## Options

### FormatterResolver

MessagePack library exposes a IFormatterResolver to allow formatting extensibility. This is accessed via the [MessagePackOptions](https://github.com/Greentube/serialization/blob/master/src/Greentube.Serialization.MessagePack/MessagePackOptions.cs) like:

```csharp
var messagePack = new MessagePackSerializer(
    new MessagePackOptions
    {
        FormatterResolver = null // formatter
    });
```

By leaving the formatter null (default), the underlying package uses the default formatter.

One of such formatters which is fairly useful is the `ContractlessStandardResolver`. It can be defined like:

```csharp
var MessagePack = new MessagePackSerializer(
    new MessagePackOptions
    {
        FormatterResolver = global::MessagePack.Resolvers.ContractlessStandardResolver.Instance
    });
```

### LZ4 compression

It's also possible to use LZ4 compression by defining:

```csharp
var MessagePack = new MessagePackSerializer(
    new MessagePackOptions
    {
        UseLz4Compression = true
    });
```