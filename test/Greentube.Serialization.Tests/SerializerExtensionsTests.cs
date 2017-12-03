using System;
using NSubstitute;
using Xunit;

namespace Greentube.Serialization.Tests
{
    public class SerializerExtensionsTests
    {
        [Fact]
        public void Deserialize_ThrowsOnNullData()
        {
            Assert.Throws<ArgumentNullException>(() => SerializerExtensions.Deserialize<object>(null, null));
        }

        [Fact]
        public void Deserialize_TypeOfPassedAlongWithBytes()
        {
            // Arrange
            var stubDeserializer = new StubDeserializer();
            var expectedBytes = new byte[] {1};

            // Act
            stubDeserializer.Deserialize<SerializerExtensionsTests>(expectedBytes);

            // Assert
            Assert.Equal(typeof(SerializerExtensionsTests), stubDeserializer.Type);
            Assert.Equal(expectedBytes, stubDeserializer.Bytes);
        }

        private class StubDeserializer : ISerializer
        {
            public byte[] Bytes { get; private set; }
            public Type Type { get; private set; }

            public ReadOnlySpan<byte> Serialize<T>(T @object) => throw new NotSupportedException();

            public object Deserialize(Type type, ReadOnlySpan<byte> bytes)
            {
                Bytes = bytes.ToArray();
                Type = type;
                return null;
            }
        }
    }
}
