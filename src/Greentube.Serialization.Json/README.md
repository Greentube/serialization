# Greentube.Serialization.Json [![NuGet](https://img.shields.io/nuget/v/Greentube.Serialization.Json.svg)](https://www.nuget.org/packages/Greentube.Serialization.Json/)

Implementation of [ISerializer](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) with [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json).

This library targets [netstandard1.3](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) since that's the version Newtonsoft.Json depends on.

No other dependencies besides [Greentube.Serialization](https://github.com/Greentube/serialization/tree/master/src/Greentube.Serialization) and [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) are introduced via this package.

## Options

By default `JsonOptions` uses UTF8 encoding. This can be changed:

```csharp
// JsonSerializer with ASCII encoding:
var json = new JsonSerializer(new JsonOptions { Encoding = Encoding.ASCII });
```
