using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class Material
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("diffuseColor")]
        public List<double> DiffuseColor { get; set; }

        [JsonProperty("specularColor")]
        public List<int> SpecularColor { get; set; }

        [JsonProperty("specularPower")]
        public int SpecularPower { get; set; }

        [JsonProperty("zOffset")]
        public int ZOffset { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("hasTexture")]
        public bool HasTexture { get; set; }

        [JsonProperty("hasColor")]
        public bool HasColor { get; set; }
    }
}