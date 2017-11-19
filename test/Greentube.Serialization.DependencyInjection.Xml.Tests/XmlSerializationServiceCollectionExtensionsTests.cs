using System;
using System.Linq;
using Greentube.Serialization.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.Xml.Tests
{
    public class XmlSerializationServiceCollectionExtensionsTests
    {
        private readonly ServiceCollection _serviceCollection = new ServiceCollection();

        [Fact]
        public void AddXmlSerializer_RegistersXmlSerializer()
        {
            // Act
            _serviceCollection.AddXmlSerializer();

            // Assert
            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(XmlSerializer), descriptor.ImplementationType);

            var xmlOptions =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(XmlOptions));
            Assert.NotNull(xmlOptions);
        }

        [Fact]
        public void AddXml_Action_RegistersXmlSerializer()
        {
            // ReSharper disable once ConvertToLocalFunction - Reference is needed for comparison
            Action<XmlOptions> configAction = _ => { };

            // Act
            _serviceCollection.AddXmlSerializer(configAction);

            // Assert
            var optionsConfiguration =
                _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(IConfigureOptions<XmlOptions>));

            Assert.NotNull(optionsConfiguration);
            Assert.Same(configAction,
                ((ConfigureNamedOptions<XmlOptions>)optionsConfiguration.ImplementationInstance).Action);

            var descriptor = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
            Assert.Equal(typeof(XmlSerializer), descriptor.ImplementationType);

            var xmlOptions = _serviceCollection.FirstOrDefault(d => d.ServiceType == typeof(XmlOptions));
            Assert.NotNull(xmlOptions);
        }
    }
}
