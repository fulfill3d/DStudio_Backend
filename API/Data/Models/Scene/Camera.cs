using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Scene
{
    public class Camera
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("alpha")]
        public int Alpha { get; set; }

        [JsonProperty("beta")]
        public int Beta { get; set; }

        [JsonProperty("radius")]
        public int Radius { get; set; }

        [JsonProperty("target")]
        public List<int> Target { get; set; }

        [JsonProperty("upperRadiusLimit")]
        public int UpperRadiusLimit { get; set; }

        [JsonProperty("lowerRadiusLimit")]
        public int LowerRadiusLimit { get; set; }

        [JsonProperty("upperBetaLimit")]
        public int UpperBetaLimit { get; set; }

        [JsonProperty("lowerBetaLimit")]
        public int LowerBetaLimit { get; set; }
    }
}