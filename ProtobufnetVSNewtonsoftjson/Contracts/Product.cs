using ProtoBuf;

namespace ProtobufnetVSNewtonsoftjson.Contracts
{
    [ProtoContract]
    public class Product
    {
        [ProtoMember(1)]
        public string ProductSKU { get; set; }
        [ProtoMember(2)]
        public string ProductName { get; set; }
        [ProtoMember(3)]
        public int Quantity { get; set; }
        [ProtoMember(4)]
        public decimal Price { get; set; }
    }
}
