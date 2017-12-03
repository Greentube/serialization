using System;

namespace Greentube.Serialization
{
    /// <summary>
    /// A simple serialization abstraction using <see cref="ReadOnlySpan{B}"/>
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes T to <see cref="ReadOnlySpan{B}"/>
        /// </summary>
        /// <param name="object">The object to serialize</param>
        /// <typeparam name="T">The type of the object being serialized</typeparam>
        /// <returns>Serialized object</returns>
        ReadOnlySpan<byte> Serialize<T>(T @object);

        /// <summary>
        /// Deserializes the <see cref="ReadOnlySpan{B}"/> into an instance of an object of the specified type
        /// </summary>
        /// <param name="type">Type of the object to deserialize</param>
        /// <param name="bytes">The data to deserialize</param>
        /// <returns>The deserialized object</returns>
        object Deserialize(Type type, ReadOnlySpan<byte> bytes);
    }
}