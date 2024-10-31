using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class Variant
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mapping")]
        public Dictionary<string, int> Mapping { get; set; }
    }
}