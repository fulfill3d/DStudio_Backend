using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class ProductManifest
    {
        [JsonProperty("materials")]
        public List<Material> Materials { get; set; }

        [JsonProperty("textures")]
        public List<Texture> Textures { get; set; }

        [JsonProperty("assets")]
        public Assets Assets { get; set; }

        [JsonProperty("variants")]
        public List<Variant> Variants { get; set; }

        [JsonProperty("mappings")]
        public Mappings Mappings { get; set; }

        [JsonProperty("components")]
        public List<Component> Components { get; set; }
    }
}