using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class Component
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_design_component")]
        public bool IsDesignComponent { get; set; }

        [JsonProperty("mesh")]
        public int Mesh { get; set; }

        [JsonProperty("material")]
        public int Material { get; set; }

        [JsonProperty("texture")]
        public int Texture { get; set; }
    }
}