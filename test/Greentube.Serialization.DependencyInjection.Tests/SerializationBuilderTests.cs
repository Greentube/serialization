using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.Tests
{
    public class SerializationBuilderTests
    {
        class Fixture
        {
            public ServiceCollection ServiceCollection { get; } = new ServiceCollection();
            public SerializationBuilder GetBuilder() => new SerializationBuilder(ServiceCollection);
        }

        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Build_NoCallsOnBuilder_ThrowsInvalidOperation()
        {
            // Arrange
            var builder = _fixture.GetBuilder();

            // Act/Assert
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Fact]
        public void Build_AddSerializer_BuildsSuccessfully()
        {
            // Arrange
            var builder = _fixture.GetBuilder();

            builder.AddSerializer<ISerializer>(ServiceLifetime.Scoped);

            // Assert
            builder.Build();
            _fixture.ServiceCollection.AssertISerializerRegistration(ServiceLifetime.Scoped);
        }

        [Fact]
        public void Build_AddSerializer_Options_BuildsSuccessfully()
        {
            // Arrange
            var builder = _fixture.GetBuilder();

            builder.AddSerializer<ISerializer, TestOptions>(ServiceLifetime.Scoped);

            // Assert
            builder.Build();
            _fixture.ServiceCollection.AssertISerializerWithOptions(ServiceLifetime.Scoped);
        }

        [Fact]
        public void Build_Configure_AddsConfigureSetuop()
        {
            // Arrange
            var builder = _fixture.GetBuilder();
            // ReSharper disable once ConvertToLocalFunction - Reference is needed for comparison
            Action<TestOptions> configAction = _ => { };

            // Act
            builder.AddSerializer<ISerializer>(ServiceLifetime.Scoped);
            builder.Configure(configAction);

            // Assert
            var optionsConfiguration =
                _fixture.ServiceCollection.FirstOrDefault(d => d.ServiceType == typeof(IConfigureOptions<TestOptions>));
            Assert.NotNull(optionsConfiguration);
            Assert.Same(configAction,
                ((ConfigureNamedOptions<TestOptions>)optionsConfiguration.ImplementationInstance).Action);
        }

        [Fact]
        public void Constructor_RequiresServicesCollection()
        {
            Assert.Throws<ArgumentNullException>(() => new SerializationBuilder(null));
        }
    }
}