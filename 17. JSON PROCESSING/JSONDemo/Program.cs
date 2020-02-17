using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace JSONDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var inputJson = File.ReadAllText("./../../../products.json");

            //var obj = JObject.Parse(inputJson)["products"]
            //    .Select(x => $"{x["Title"]}: {x["Price"]}")
            //    .ToList();

            //Console.WriteLine(String.Join(Environment.NewLine, obj));

            //var obje= JObject.Parse(inputJson);

            //foreach (JToken token in obje["products"])
            //{
            //    Console.WriteLine(token["Title"]);
            //    Console.WriteLine(token["Price"]);
            //    Console.WriteLine(token["SellerId"]);
            //    Console.WriteLine(token["BuyerId"]);
            //    Console.WriteLine();
            //}

            //var products = JsonConvert.DeserializeObject<ProductDTO[]>(inputJson);

            //var resolver = new DefaultContractResolver()
            //{
            //    NamingStrategy = new SnakeCaseNamingStrategy()
            //};

            //var againJson = JsonConvert.SerializeObject(products, new JsonSerializerSettings() { ContractResolver = resolver, Formatting = Formatting.Indented });

            //Console.WriteLine(againJson);

            var inputXml = File.ReadAllText("./../../../products.xml");

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(inputXml);

            var json = JsonConvert.SerializeObject(xmlDoc, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(json);
        }
    }
}
