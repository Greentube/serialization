using System;
using System.Linq;
using Greentube.Serialization.ProtoBuf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.ProtoBuf.Tests
{
    public class ProtoBufSerializationServiceCollectionExtensionsTests
    {
        private readonly ServiceCollection _serviceCollection = new ServiceCollection();

        [Fact]
        public void AddProtoBufSerializer_RegistersProtoBufSerializer()
        {
            // Act
            _serviceCollection.AddProtoBufSerializer();

            // Assert
            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(ProtoBufSerializer), descriptor.ImplementationType);

            var protoBufOptions =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ProtoBufOptions));
            Assert.NotNull(protoBufOptions);
        }

        [Fact]
        public void AddProtoBuf_Action_RegistersProtoBufSerializer()
        {
            // ReSharper disable once ConvertToLocalFunction - Reference is needed for comparison
            Action<ProtoBufOptions> configAction = _ => { };

            // Act
            _serviceCollection.AddProtoBufSerializer(configAction);

            // Assert
            var optionsConfiguration =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(IConfigureOptions<ProtoBufOptions>));

            Assert.NotNull(optionsConfiguration);
            Assert.Same(configAction,
                ((ConfigureNamedOptions<ProtoBufOptions>)optionsConfiguration.ImplementationInstance).Action);

            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(ProtoBufSerializer), descriptor.ImplementationType);

            var protoBufOptions = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ProtoBufOptions));
            Assert.NotNull(protoBufOptions);
        }
    }
}
