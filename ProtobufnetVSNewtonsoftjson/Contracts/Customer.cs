using ProtoBuf;
using System.Collections.Generic;

namespace ProtobufnetVSNewtonsoftjson.Contracts
{
    [ProtoContract]
    public class Customer
    {
        [ProtoMember(1)]
        public string FullName { get; set; }
        [ProtoMember(2)]
        public string Phone { get; set; }
        [ProtoMember(3)]
        public List<Address> Addresses { get; set; }
    }
}
