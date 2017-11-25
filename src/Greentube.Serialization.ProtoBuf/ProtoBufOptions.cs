using ProtoBuf.Meta;

namespace Greentube.Serialization.ProtoBuf
{
    /// <summary>
    /// ProtoBuf Options
    /// </summary>
    public class ProtoBufOptions
    {
        /// <summary>
        /// The runtime type model
        /// </summary>
        public RuntimeTypeModel RuntimeTypeModel { get; set; } = RuntimeTypeModel.Default;
    }
}