using System;
using Greentube.Serialization.Xml;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="IServiceCollection"/>
    /// </summary>
    public static class XmlSerializationServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="XmlSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <param name="setupAction">The configuration action</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddXmlSerializer(this IServiceCollection services, Action<XmlOptions> setupAction)
        {
            services.Configure(setupAction);
            return services.AddXmlSerializer();
        }

        /// <summary>
        /// Adds <see cref="XmlSerializer"/> serializer
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddXmlSerializer(this IServiceCollection services)
        {
            services.AddSerializer<XmlSerializer, XmlOptions>();
            return services;
        }
    }
}