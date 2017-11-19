using System;
using Greentube.Serialization.DependencyInjection;
using Greentube.Serialization.Json;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="SerializationBuilder"/>
    /// </summary>
    public static class JsonSerializationBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="JsonSerializer"/> serializer
        /// </summary>
        /// <param name="builder">builder</param>
        public static void AddJson(this SerializationBuilder builder)
        {
            builder.AddSerializer<JsonSerializer, JsonOptions>(ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds <see cref="JsonSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="builder">builder</param>
        /// <param name="setupAction">The configuration action</param>
        public static void AddJson(this SerializationBuilder builder, Action<JsonOptions> setupAction)
        {
            builder.Configure(setupAction);
            builder.AddJson();
        }
    }
}