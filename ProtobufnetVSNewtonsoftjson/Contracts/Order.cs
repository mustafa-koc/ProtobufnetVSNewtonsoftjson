using ProtoBuf;
using System;
using System.Collections.Generic;

namespace ProtobufnetVSNewtonsoftjson.Contracts
{
    [ProtoContract]
    public class Order : BaseContract
    {
        [ProtoMember(1)]
        public string OrderNumber { get; set; }
        [ProtoMember(2)]
        public DateTime OrderDate { get; set; }
        [ProtoMember(3)]
        public decimal TotalPrice { get; set; }
        [ProtoMember(4)]
        public List<Product> Products { get; set; }
        [ProtoMember(5)]
        public Customer CustomerInfo { get; set; }
    }
}
