using Newtonsoft.Json;

namespace JSONDemo
{
    public class ProductDTO
    {
        [JsonProperty("Title")]
        public string Name { get; set; }

        public double Price { get; set; }

        public int? SellerId { get; set; }

        public int? BuyerId { get; set; }
    }
}
