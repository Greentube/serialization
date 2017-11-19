using System;
using System.Linq;
using Greentube.Serialization.MessagePack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.MessagePack.Tests
{
    public class MessagePackSerializationServiceCollectionExtensionsTests
    {
        private readonly ServiceCollection _serviceCollection = new ServiceCollection();

        [Fact]
        public void AddMessagePackSerializer_RegistersMessagePackSerializer()
        {
            // Act
            _serviceCollection.AddMessagePackSerializer();

            // Assert
            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(MessagePackSerializer), descriptor.ImplementationType);

            var messagePackOptions =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(MessagePackOptions));
            Assert.NotNull(messagePackOptions);
        }

        [Fact]
        public void AddMessagePack_Action_RegistersMessagePackSerializer()
        {
            // ReSharper disable once ConvertToLocalFunction - Reference is needed for comparison
            Action<MessagePackOptions> configAction = _ => { };

            // Act
            _serviceCollection.AddMessagePackSerializer(configAction);

            // Assert
            var optionsConfiguration =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(IConfigureOptions<MessagePackOptions>));

            Assert.NotNull(optionsConfiguration);
            Assert.Same(configAction,
                ((ConfigureNamedOptions<MessagePackOptions>)optionsConfiguration.ImplementationInstance).Action);

            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(MessagePackSerializer), descriptor.ImplementationType);

            var messagePackOptions = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(MessagePackOptions));
            Assert.NotNull(messagePackOptions);
        }
    }
}
