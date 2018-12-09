using Newtonsoft.Json;
using ProtobufnetVSNewtonsoftjson.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProtobufnetVSNewtonsoftjson
{
    class Program
    {
        static void Main(string[] args)
        {
            #region inMemoryData
            var data = new Order
            {
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderNumber = "MSTF123456789",
                TotalPrice = 150,
                Products = new List<Product>{
                                              new Product {
                                                            ProductName = "Test Product 1" ,
                                                            ProductSKU = "TP123456",
                                                            Quantity = 2,
                                                            Price = 25
                                                          },
                                              new Product {
                                                            ProductName = "Test Product 2" ,
                                                            ProductSKU = "TP123457",
                                                            Quantity = 1,
                                                            Price = 100
                                                          }
                                            },
                CustomerInfo = new Customer
                {
                    FullName = "Mustafa KOÇ",
                    Phone = "5551112233",
                    Addresses = new List<Address> {
                                                   new Address {
                                                                   City ="İstanbul",
                                                                   Line1 = "Maslak Mh.",
                                                                   Line2 = "Şişli",
                                                                   Type = AddressType.Delivery
                                                                },
                                                   new Address {
                                                                   City ="İstanbul",
                                                                   Line1 = "Maslak Mh.",
                                                                   Line2 = "Şişli",
                                                                   Type = AddressType.Billing
                                                               }
                                                  }
                }
            };
            #endregion

            byte[] serializedData;
            Order deserializedOrder = new Order();

            #region Protobuf-net
            var watchProtoBuf = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                using (var mStream = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(mStream, data);
                    serializedData = mStream.ToArray();
                }
                using (var mStream = new MemoryStream(serializedData))
                {
                    deserializedOrder = ProtoBuf.Serializer.Deserialize<Order>(mStream);
                }
            }
            watchProtoBuf.Stop();
            var elapsedMsProtoBuf = watchProtoBuf.ElapsedMilliseconds;
            Console.WriteLine($"ProtoBuf-net 1.000.000 row data Serialize/Deserialize ExecutionTime(ms): {elapsedMsProtoBuf}");
            #endregion

            #region  Newtonsoft.Json
            string jsonSerializedData = string.Empty;
            var watchJson = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                jsonSerializedData = JsonConvert.SerializeObject(data);
                deserializedOrder = JsonConvert.DeserializeObject<Order>(jsonSerializedData);
            }
            watchJson.Stop();
            var elapsedMsJson = watchJson.ElapsedMilliseconds;
            Console.WriteLine($"Newtonsoft.Json 1.000.000 row data Serialize/Deserialize ExecutionTime(ms): {elapsedMsJson}");
            #endregion

            Console.ReadKey();
        }
    }
}
