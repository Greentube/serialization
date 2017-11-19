using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.Tests
{
    public class SerializationServiceCollectionExtensionsTests
    {
        private readonly ServiceCollection _serviceCollection = new ServiceCollection();

        [Fact]
        public void AddSerialization_NoCallsOnBuilder_ThrowsInvalidOperation()
        {
            // Act/Assert
            Assert.Throws<InvalidOperationException>(() => _serviceCollection.AddSerialization(builder => { }));
        }

        [Fact]
        public void AddSerialization_RequiresBuilderAction()
        {
            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => _serviceCollection.AddSerialization(null));
        }

        [Fact]
        public void AddSerializer_LifetimeProvided()
        {
            // Act
            _serviceCollection.AddSerializer<ISerializer>(ServiceLifetime.Scoped);

            // Assert
            _serviceCollection.AssertISerializerRegistration(ServiceLifetime.Scoped);
        }

        [Fact]
        public void AddSerializer_DefaultLifetime()
        {
            // Act
            _serviceCollection.AddSerializer<ISerializer>();

            // Assert
            _serviceCollection.AssertISerializerRegistration();
        }

        [Fact]
        public void AddSerializer_Options_LifetimeProvided()
        {
            // Act
            _serviceCollection.AddSerializer<ISerializer, TestOptions>(ServiceLifetime.Scoped);

            // Assert
            _serviceCollection.AssertISerializerWithOptions(ServiceLifetime.Scoped);
        }

        [Fact]
        public void AddSerializer_Options_DefaultLifetime()
        {
            // Act
            _serviceCollection.AddSerializer<ISerializer, TestOptions>();

            // Assert
            _serviceCollection.AssertISerializerWithOptions();
        }

    
    }
}