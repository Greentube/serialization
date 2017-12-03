using System;
using Newtonsoft.Json;

namespace Greentube.Serialization.Json
{
    /// <inheritdoc />
    public class JsonSerializer : ISerializer
    {
        private readonly JsonOptions _options;

        /// <summary>
        /// Create a new instance of JsonSerializer
        /// </summary>
        /// <param name="options"></param>
        public JsonSerializer(JsonOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc />
        public ReadOnlySpan<byte> Serialize<T>(T @object)
        {
            if (@object == null) throw new ArgumentNullException(nameof(@object));

            var @string = JsonConvert.SerializeObject(@object);
            return _options.Encoding.GetBytes(@string);
        }

        /// <inheritdoc />
        public object Deserialize(Type type, ReadOnlySpan<byte> bytes)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (bytes == default) throw new ArgumentException(nameof(bytes));

            // .ToArray() on the Span until the underlying API supports it:
            var @string = _options.Encoding.GetString(bytes.ToArray());
            return JsonConvert.DeserializeObject(@string, type);
        }

    }
}