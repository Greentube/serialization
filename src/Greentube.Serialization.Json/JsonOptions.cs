using System.Text;

namespace Greentube.Serialization.Json
{
    /// <summary>
    /// JSON Options
    /// </summary>
    public class JsonOptions
    {
        /// <summary>
        /// The encoding to use when serializing and deserializing
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.UTF8;
    }
}