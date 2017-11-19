using System;
using Greentube.Serialization.DependencyInjection;
using Greentube.Serialization.ProtoBuf;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="SerializationBuilder"/>
    /// </summary>
    public static class ProtoBufSerializationBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="ProtoBufSerializer"/> serializer
        /// </summary>
        /// <param name="builder">builder</param>
        public static void AddProtoBuf(this SerializationBuilder builder)
        {
            builder.AddSerializer<ProtoBufSerializer, ProtoBufOptions>(ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds <see cref="ProtoBufSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="builder">builder</param>
        /// <param name="setupAction">The configuration action</param>
        public static void AddProtoBuf(this SerializationBuilder builder, Action<ProtoBufOptions> setupAction)
        {
            builder.Configure(setupAction);
            builder.AddProtoBuf();
        }
    }
}