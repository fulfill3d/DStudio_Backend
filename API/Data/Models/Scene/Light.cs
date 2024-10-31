using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Scene
{
    public class Light
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("direction")]
        public List<int> Direction { get; set; }

        [JsonProperty("intensity")]
        public double Intensity { get; set; }
    }
}