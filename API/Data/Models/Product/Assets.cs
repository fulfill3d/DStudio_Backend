using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class Assets
    {
        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("meshes")]
        public List<Mesh> Meshes { get; set; }
    }
}