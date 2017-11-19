using System;
using System.Linq;
using Greentube.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.Json.Tests
{
    public class JsonSerializationServiceCollectionExtensionsTests
    {
        private readonly ServiceCollection _serviceCollection = new ServiceCollection();

        [Fact]
        public void AddJsonSerializer_RegistersJsonSerializer()
        {
            // Act
            _serviceCollection.AddJsonSerializer();

            // Assert
            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(JsonSerializer), descriptor.ImplementationType);

            var jsonOptions =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(JsonOptions));
            Assert.NotNull(jsonOptions);
        }

        [Fact]
        public void AddJson_Action_RegistersJsonSerializer()
        {
            // ReSharper disable once ConvertToLocalFunction - Reference is needed for comparison
            Action<JsonOptions> configAction = _ => { };

            // Act
            _serviceCollection.AddJsonSerializer(configAction);

            // Assert
            var optionsConfiguration =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(IConfigureOptions<JsonOptions>));

            Assert.NotNull(optionsConfiguration);
            Assert.Same(configAction,
                ((ConfigureNamedOptions<JsonOptions>)optionsConfiguration.ImplementationInstance).Action);

            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(JsonSerializer), descriptor.ImplementationType);

            var jsonOptions = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(JsonOptions));
            Assert.NotNull(jsonOptions);
        }
    }
}
