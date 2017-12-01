# Greentube.Serialization [![Build Status](https://travis-ci.org/Greentube/serialization.svg?branch=master)](https://travis-ci.org/Greentube/serialization) [![Build status](https://ci.appveyor.com/api/projects/status/2ib0oivho3ftgws2/branch/master?svg=true)](https://ci.appveyor.com/project/Greentube/serialization) [![codecov](https://codecov.io/gh/Greentube/serialization/branch/master/graph/badge.svg)](https://codecov.io/gh/Greentube/serialization)

A set of libraries for serialization which work as a **common interface for serialization**. It includes multiple implementations available for use.

Each project under `src` contains its own documentation and a link to its NuGet package.
One of such packages is the convenience package [Greentube.Serialization.All](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization.All) which is a metapackage that allows bringing all dependencies with one reference: [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.All.svg)](https://www.nuget.org/packages/Greentube.Serialization.All/)

```shell
dotnet add package Greentube.Serialization.All
```

Although optional, it provides one-line configuration for applications using [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/DependencyInjection).

## Implementations

The supported serialization formats are:

* MessagePack - with [MessagePack-CSharp](https://github.com/neuecc/MessagePack-CSharp)
* ProtoBuf - with [protobuf-net](https://github.com/mgravell/protobuf-net)
* JSON - with [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
* XML - with [System.Xml.XmlSerializer](https://github.com/dotnet/corefx/tree/master/src/System.Xml.XmlSerializer)

### Adding to your project

#### With Microsoft.Extensions.DependencyInjection

All of the above can be 'plugged-in' with a single line when using the Serialization.DependencyInjection.* packages.
Example serialization setup:

```shell
dotnet add package Greentube.Serialization.DependencyInjection.Json
```

Then JSON can be added with:

```csharp
services.AddJsonSerializer();
```

Other packages:

```shell
dotnet add package Greentube.Serialization.DependencyInjection.Xml
dotnet add package Greentube.Serialization.DependencyInjection.ProtoBuf
dotnet add package Greentube.Serialization.DependencyInjection.MessagePack
```

```csharp
services.AddXmlSerializer();
// or
services.AddProtoBufSerializer();
// or
services.AddMessagePackSerializer();
```

Or with the builder:

```csharp
services.AddSerialization(builder =>
    {
        builder.AddMessagePack();
        // or
        builder.AddProtoBuf();
        // or
        builder.AddJson();
        // or
        builder.AddXml();
    });
```

### Without dependency injection or using other containers

If you are using another container like Autofac, Castle Windsor or not using any container at all, you can avoid bringing the Microsoft.Extensions.DependencyInjection dependencies.
Just reference the implementation you want to use directly:

```shell
dotnet add package Greentube.Serialization.MessagePack
```

Then MessagePack can be used:

```csharp
var messagePack = new MessagePackSerializer();
```

Likewise with the other implementations:

```shell
dotnet add package Greentube.Serialization.Json
dotnet add package Greentube.Serialization.Xml
dotnet add package Greentube.Serialization.ProtoBuf
```

```csharp
new JsonSerializer();
new XmlSerializer();
new ProtoBufSerializer();
```

## Configuration

Each implementation has some additional settings

### MessagePack

Define a custom IFormatterResolver and compressiong LZ4:

```csharp

builder.AddMessagePack(o => {
    // Don't require attributes on model
    o.FormatterResolver = global::MessagePack.Resolvers.ContractlessStandardResolver.Instance;
    // Use LZ4 compression
    o.UseLz4Compression = true;
});
```

### ProtoBuf

Custom RuntimeTypeModel

```csharp
var model = RuntimeTypeModel.Create();
model.Add(typeof(SomeMessage), false).Add(1, nameof(SomeMessage.Body));
builder.AddProtoBuf(o => o.RuntimeTypeModel = model);
```

### JSON

Define the encoding.

```csharp
// Use UTF-16 instead of the default UTF-8
builder.AddJson(o => o.Encoding = Encoding.Unicode);
```

### XML

Xml with user-defined default namespace

```csharp
builder.AddXml(p => p.DefaultNamespace = "some-namespace");
```

Xml with user-defined factory delegate

```csharp
// Root attribute will be named: 'messaging'
builder.AddXml(p => p.Factory = type => new XmlSerializer(type, new XmlRootAttribute("messaging")));
```

## Highlights

* Simple abstraction
* Multiple serialization formats supported
* Pay for play: no unwanted dependencies
* DI packages to consume with single line of code

**This library was created mainly to support [Greentube.Messaging](https://github.com/Greentube/messaging).**