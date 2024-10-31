using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class Mappings
    {
        [JsonProperty("variant")]
        public Dictionary<string, string> Variant { get; set; }
    }
}