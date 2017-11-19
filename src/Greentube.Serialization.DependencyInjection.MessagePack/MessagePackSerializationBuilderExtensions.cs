using System;
using Greentube.Serialization.DependencyInjection;
using Greentube.Serialization.MessagePack;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="SerializationBuilder"/>
    /// </summary>
    public static class MessagePackSerializationBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="MessagePackSerializer"/> serializer
        /// </summary>
        /// <param name="builder">builder</param>
        public static void AddMessagePack(this SerializationBuilder builder)
        {
            builder.AddSerializer<MessagePackSerializer, MessagePackOptions>(ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds <see cref="MessagePackSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="builder">builder</param>
        /// <param name="setupAction">The configuration action</param>
        public static void AddMessagePack(this SerializationBuilder builder, Action<MessagePackOptions> setupAction)
        {
            builder.Configure(setupAction);
            builder.AddMessagePack();
        }
    }
}