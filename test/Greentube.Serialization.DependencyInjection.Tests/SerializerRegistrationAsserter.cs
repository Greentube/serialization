using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Greentube.Serialization.DependencyInjection.Tests
{
    internal static class SerializerRegistrationAsserter
    {
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        public static void AssertISerializerWithOptions(this IServiceCollection @this, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            Assert.Equal(1, @this.Count(d => d.ServiceType == typeof(TestOptions)));
            @this.AssertISerializerRegistration(lifetime);
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        public static void AssertISerializerRegistration(this IServiceCollection @this, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            Assert.Equal(1, @this.Count(d => d.ServiceType == typeof(ISerializer)));

            var descriptor = @this.FirstOrDefault(d => d.ServiceType == typeof(ISerializer));
            Assert.NotNull(descriptor);

            Assert.Equal(lifetime, descriptor.Lifetime);
            Assert.Equal(typeof(ISerializer), descriptor.ImplementationType);
        }
    }
}
