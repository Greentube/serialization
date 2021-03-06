﻿using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Greentube.Serialization.Json;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.Json.Tests
{
    public class JsonSerializationBuilderExtensionsTests
    {
        class Fixture
        {
            public ServiceCollection ServiceCollection { get; } = new ServiceCollection();
            public SerializationBuilder GetBuilder() => new SerializationBuilder(ServiceCollection);
        }

        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void AddJson_RegistersJsonSerializer()
        {
            // Arrange
            var builder = _fixture.GetBuilder();

            // Act
            builder.AddJson();

            // Assert
            var descriptor = _fixture.ServiceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(JsonSerializer), descriptor.ImplementationType);

            var jsonOptions =
                _fixture.ServiceCollection.FirstOrDefault(d => d.ServiceType == typeof(JsonOptions));
            Assert.NotNull(jsonOptions);
        }

        [Fact]
        public void AddJson_Action_RegistersJsonSerializer()
        {
            // Arrange
            var builder = _fixture.GetBuilder();
            // ReSharper disable once ConvertToLocalFunction - Reference is needed for comparison
            Action<JsonOptions> configAction = _ => { };

            // Act
            builder.AddJson(configAction);

            // Assert
            var optionsConfiguration =
                _fixture.ServiceCollection.FirstOrDefault(d => d.ServiceType == typeof(IConfigureOptions<JsonOptions>));

            Assert.NotNull(optionsConfiguration);
            Assert.Same(configAction,
                ((ConfigureNamedOptions<JsonOptions>) optionsConfiguration.ImplementationInstance).Action);

            var descriptor = _fixture.ServiceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(JsonSerializer), descriptor.ImplementationType);

            var jsonOptions = _fixture.ServiceCollection.FirstOrDefault(d => d.ServiceType == typeof(JsonOptions));
            Assert.NotNull(jsonOptions);
        }
    }
}