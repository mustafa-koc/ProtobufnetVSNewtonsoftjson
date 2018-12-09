using ProtoBuf;
using System;

namespace ProtobufnetVSNewtonsoftjson.Contracts
{
    [ProtoContract]
    [ProtoInclude(3, typeof(Order))]
    public class BaseContract
    {
        [ProtoMember(1)]
        public int CreatedBy { get; set; }
        [ProtoMember(2)]
        public DateTime CreatedDate { get; set; }
    }
}
