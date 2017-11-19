using System;
using Greentube.Serialization.DependencyInjection;
using Greentube.Serialization.Xml;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="SerializationBuilder"/>
    /// </summary>
    public static class XmlSerializationBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="XmlSerializer"/> serializer
        /// </summary>
        /// <param name="builder">builder</param>
        public static void AddXml(this SerializationBuilder builder)
        {
            builder.AddSerializer<XmlSerializer, XmlOptions>(ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds <see cref="XmlSerializer"/> serializer while configuring it
        /// </summary>
        /// <param name="builder">builder</param>
        /// <param name="setupAction">The configuration action</param>
        public static void AddXml(this SerializationBuilder builder, Action<XmlOptions> setupAction)
        {
            builder.Configure(setupAction);
            builder.AddXml();
        }
    }
}