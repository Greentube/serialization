﻿using ProtoBuf.Meta;

namespace Greentube.Serialization.ProtoBuf
{
    public class ProtoBufOptions
    {
        public RuntimeTypeModel RuntimeTypeModel { get; set; } = RuntimeTypeModel.Default;
    }
}