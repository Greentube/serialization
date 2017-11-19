using System;
using Greentube.Serialization.MessagePack;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="IServiceCollection"/>
    /// </summary>
    public static class MessagePackSerializationServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="MessagePackSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <param name="setupAction">The configuration action</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddMessagePackSerializer(this IServiceCollection services, Action<MessagePackOptions> setupAction)
        {
            services.Configure(setupAction);
            return services.AddMessagePackSerializer();
        }

        /// <summary>
        /// Adds <see cref="MessagePackSerializer"/> serializer
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddMessagePackSerializer(this IServiceCollection services)
        {
            services.AddSerializer<MessagePackSerializer, MessagePackOptions>();
            return services;
        }
    }
}