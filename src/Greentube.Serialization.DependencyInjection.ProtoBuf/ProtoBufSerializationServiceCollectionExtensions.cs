using System;
using Greentube.Serialization.ProtoBuf;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="IServiceCollection"/>
    /// </summary>
    public static class ProtoBufSerializationServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="ProtoBufSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <param name="setupAction">The configuration action</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddProtoBufSerializer(this IServiceCollection services, Action<ProtoBufOptions> setupAction)
        {
            services.Configure(setupAction);
            return services.AddProtoBufSerializer();
        }

        /// <summary>
        /// Adds <see cref="ProtoBufSerializer"/> serializer
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddProtoBufSerializer(this IServiceCollection services)
        {
            services.AddSerializer<ProtoBufSerializer, ProtoBufOptions>();
            return services;
        }
    }
}