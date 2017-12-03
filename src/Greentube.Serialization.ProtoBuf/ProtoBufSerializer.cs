using System;
using System.IO;

namespace Greentube.Serialization.ProtoBuf
{
    /// <inheritdoc />
    public class ProtoBufSerializer : ISerializer
    {
        private readonly ProtoBufOptions _options;

        /// <summary>
        /// Creates a new instance of ProtoBufSerializer
        /// </summary>
        /// <param name="options"></param>
        public ProtoBufSerializer(ProtoBufOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc />
        public ReadOnlySpan<byte> Serialize<T>(T @object)
        {
            using (var stream = new MemoryStream())
            {
                _options.RuntimeTypeModel.Serialize(stream, @object);
                return stream.ToArray();
            }
        }

        /// <inheritdoc />
        public object Deserialize(Type type, ReadOnlySpan<byte> bytes)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (bytes == default) throw new ArgumentException(nameof(bytes));

            // .ToArray() on the Span until the underlying API supports it:
            using (var stream = new MemoryStream(bytes.ToArray()))
            {
                return _options.RuntimeTypeModel.Deserialize(stream, null, type);
            }
        }
    }
}
