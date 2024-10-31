using Newtonsoft.Json;

namespace DStudio.API.Data.Models
{
    public class Manifest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("partitionKey")]
        public string PartitionKey { get; set; }
        
        [JsonProperty("product")]
        public Product.ProductManifest Product { get; set; }
        
        [JsonProperty("scene")]
        public Scene.SceneManifest Scene { get; set; }
        
        [JsonProperty("canvas")]
        public Canvas.Canvas Canvas { get; set; }
    }
}