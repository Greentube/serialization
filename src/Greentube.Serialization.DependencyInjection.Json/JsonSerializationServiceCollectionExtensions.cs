using System;
using Greentube.Serialization.Json;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="IServiceCollection"/>
    /// </summary>
    public static class JsonSerializationServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="JsonSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <param name="setupAction">The configuration action</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddJsonSerializer(this IServiceCollection services, Action<JsonOptions> setupAction)
        {
            services.Configure(setupAction);
            return services.AddJsonSerializer();
        }

        /// <summary>
        /// Adds <see cref="JsonSerializer"/> serializer
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddJsonSerializer(this IServiceCollection services)
        {
            services.AddSerializer<JsonSerializer, JsonOptions>();
            return services;
        }
    }
}