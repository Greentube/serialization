using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Greentube.Serialization.DependencyInjection
{
    /// <summary>
    /// A builder to offer fluent API with a validation of at least one serializer was registered
    /// </summary>
    public class SerializationBuilder
    {
        /// <summary>
        /// ServiceCollection
        /// </summary>
        public IServiceCollection Services { get; }

        internal SerializationBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Adds the serializer of type TSerializer
        /// as the implemenatation of <see cref="ISerializer"/>
        /// </summary>
        /// <typeparam name="TSerializer">The implementation of <see cref="ISerializer"/></typeparam>
        /// <param name="lifetime">The component lifetime.</param>
        public void AddSerializer<TSerializer>(ServiceLifetime lifetime)
            where TSerializer : ISerializer
        {
            Services.AddSerializer<TSerializer>(lifetime);
        }

        /// <summary>
        /// Adds the serializer of type TSerializer
        /// as the implemenatation of <see cref="ISerializer"/>
        /// </summary>
        /// <typeparam name="TSerializer">The implementation of <see cref="ISerializer"/></typeparam>
        /// <typeparam name="TOptions">The options of the serializer</typeparam>
        /// <param name="lifetime">The component lifetime.</param>
        public void AddSerializer<TSerializer, TOptions>(ServiceLifetime lifetime)
            where TSerializer : ISerializer
            where TOptions : class, new()
        {
            Services.AddSerializer<TSerializer, TOptions>(lifetime);
        }

        /// <summary>
        /// IOptions configuration
        /// </summary>
        /// <typeparam name="TOptions">The type to configure</typeparam>
        /// <param name="setupAction">The action to invoke</param>
        public void Configure<TOptions>(Action<TOptions> setupAction) 
            where TOptions : class, new()
        {
            Services.Configure(setupAction);
        }

        /// <summary>
        /// Builds the Serialization library ensuring at least 1 implementation of <see cref="ISerializer"/> has been provided.
        /// </summary>
        public void Build()
        {
            var serializers = Services.Count(s => s.ServiceType == typeof(ISerializer));
            if (serializers == 0)
                throw new InvalidOperationException(
                    $"No serializer has been configured. Call builder.{nameof(AddSerializer)}");
        }
    }
}