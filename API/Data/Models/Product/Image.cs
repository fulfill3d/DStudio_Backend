using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}