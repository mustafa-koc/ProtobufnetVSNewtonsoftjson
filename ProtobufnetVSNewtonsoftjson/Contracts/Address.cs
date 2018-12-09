using ProtoBuf;

namespace ProtobufnetVSNewtonsoftjson.Contracts
{
    [ProtoContract]
    public class Address
    {
        [ProtoMember(1)]
        public string City { get; set; }
        [ProtoMember(2)]
        public string Line1 { get; set; }
        [ProtoMember(3)]
        public string Line2 { get; set; }
        [ProtoMember(4)]
        public AddressType Type { get; set; }
    }
}
