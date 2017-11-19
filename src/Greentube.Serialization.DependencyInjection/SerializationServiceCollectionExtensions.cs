using System;
using Greentube.Serialization;
using Greentube.Serialization.DependencyInjection;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace - Discoverability
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods on <see cref="IServiceCollection"/>
    /// </summary>
    public static class SerializationServiceCollectionExtensions
    {
        /// <summary>
        /// Add Serialization services
        /// </summary>
        /// <param name="services">ServicesCollection</param>
        /// <param name="builderAction">Action to handle the serialization builder</param>
        /// <returns>ServicesCollection</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SerializationBuilder AddSerialization(
            this IServiceCollection services,
            Action<SerializationBuilder> builderAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (builderAction == null) throw new ArgumentNullException(nameof(builderAction));

            var builder = new SerializationBuilder(services);
            builderAction.Invoke(builder);
            builder.Build();

            return builder;
        }

        /// <summary>
        /// Adds a serializer and its options to the <see cref="IServiceCollection"/>
        /// </summary>
        /// <typeparam name="TSerializer">The type implementing the <see cref="ISerializer"/> interface.</typeparam>
        /// <typeparam name="TOptions">The options of the serializer</typeparam>
        /// <param name="services">ServiceCollection</param>
        /// <param name="lifetime">The lifetime of the component. 
        /// <see cref="ServiceLifetime.Singleton"/> by default.</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddSerializer<TSerializer, TOptions>(
            this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Singleton)
            where TSerializer : ISerializer
            where TOptions : class, new()
        {
            services.AddSerializer<TSerializer>(lifetime);
            services.AddSingleton(c => c.GetRequiredService<IOptions<TOptions>>().Value);
            return services;
        }

        /// <summary>
        /// Adds a serializer to the <see cref="IServiceCollection"/>
        /// </summary>
        /// <typeparam name="TSerializer">The type implementing the <see cref="ISerializer"/> interface.</typeparam>
        /// <param name="services">ServiceCollection</param>
        /// <param name="lifetime">The lifetime of the component. 
        /// <see cref="ServiceLifetime.Singleton"/> by default.</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddSerializer<TSerializer>(
            this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Singleton)
            where TSerializer : ISerializer
        {
            services.Add(ServiceDescriptor.Describe(typeof(ISerializer), typeof(TSerializer), lifetime));
            return services;
        }
    }
}
